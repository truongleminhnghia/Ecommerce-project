using AutoMapper;
using Microsoft.Extensions.Logging;
using ShoppEcommerce_WebApp.BLL.HashPasswords;
using ShoppEcommerce_WebApp.BLL.JWTServices;
using ShoppEcommerce_WebApp.Common.Entities;
using ShoppEcommerce_WebApp.Common.Enums;
using ShoppEcommerce_WebApp.Common.Exceptions;
using ShoppEcommerce_WebApp.Common.ViewModels.AuthenticateResponse;
using ShoppEcommerce_WebApp.Common.ViewModels.Requests;
using ShoppEcommerce_WebApp.DAL;

namespace ShoppEcommerce_WebApp.BLL.AuthenticateServices
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthenticateService> _logger;

        public AuthenticateService(IUnitOfWork unitOfWork, IJwtService jwtService, IPasswordHasher passwordHasher, IMapper mapper, ILogger<AuthenticateService> logger)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AuthenticateResponse> Login(string email, string password)
        {
            try
            {
                Account? account = await _unitOfWork.Accounts.GetByEmail(email);
                if (account == null) throw new AppException(ErrorCode.EMAIL_DOT_NOT_EXISTS);
                bool checkPassword = _passwordHasher.VerifyPassword(password, account.Password);
                if (!checkPassword) throw new AppException(ErrorCode.INVALID_PASSWORD);
                var token = _jwtService.GenerateJwtToken(account);
                if (string.IsNullOrEmpty(token)) throw new AppException(ErrorCode.TOKEN_NOT_NULL);
                var currentAccount = _mapper.Map<AccountCurrent>(account);
                var authenticateResponse = new AuthenticateResponse
                {
                    Token = token,
                    AccountCurrent = currentAccount
                };
                return authenticateResponse;
            }
            catch (AppException ex)
            {
                _logger.LogWarning(ex, "AppException occurred: {Message}", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                throw new AppException(ErrorCode.INTERNAL_SERVER_ERROR);
            }
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            try
            {
                bool result = true;
                var existingAccount = await _unitOfWork.Accounts.GetByEmail(request.Email);
                if (existingAccount != null)
                {
                    _logger.LogWarning("Không thể tạo tài khoản, email {Email} đã tồn tại.", request.Email);
                    throw new AppException(ErrorCode.EMAIL_ALREADY_EXISTS);
                }
                var account = _mapper.Map<Account>(request);
                Role? role = await _unitOfWork.Roles.GetByName(EnumRoleName.ROLE_CUSTOMER);
                if (role == null) throw new AppException(ErrorCode.ROLE_NOT_NULL);
                account.RoleId = role.Id;
                account.Role = role;
                account.EnumAccountStatus = EnumAccountStatus.WAIT_CONFIRM;
                account.CreateAt = DateTime.UtcNow;
                account.UpdateAt = DateTime.UtcNow;
                if (account.EnumAccountStatus == null) throw new AppException(ErrorCode.ACCOUNT_STATUS_NOT_NULL);
                if (request.Password != request.ConfirmPassword) throw new AppException(ErrorCode.INVALID_PASSWORD);
                account.Password = _passwordHasher.HashPassword(request.Password);
                await _unitOfWork.Accounts.CreateAsync(account);
                await _unitOfWork.SaveChangesWithTransactionAsync();
                Customer customer = new Customer
                {
                    Account = account,
                    HomeAddressId = null,
                    OrderAddresses = new List<Address>()
                };
                await _unitOfWork.Customers.CreateAsync(customer);
                await _unitOfWork.SaveChangesWithTransactionAsync();
                _logger.LogInformation("Tạo tài khoản mới thành công với email {Email}, Role: {Role}", request.Email, account.Role);
                return true;
            }
            catch (AppException ex)
            {
                _logger.LogWarning(ex, "AppException occurred: {Message}", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                throw new AppException(ErrorCode.INTERNAL_SERVER_ERROR);
            }
        }
    }
}
