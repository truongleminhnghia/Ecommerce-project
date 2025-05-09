using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ShoppEcommerce_WebApp.Common.Entities;
using ShoppEcommerce_WebApp.Common.Exceptions;
using ShoppEcommerce_WebApp.Common.ViewModels.Requests;
using ShoppEcommerce_WebApp.Common.ViewModels.Responses;
using ShoppEcommerce_WebApp.DAL;

namespace ShoppEcommerce_WebApp.BLL.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressService> _logger;


        public AddressService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AddressService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> AddAddress(AddressRequest request)
        {
            try
            {
                var address = _mapper.Map<Address>(request);
                await _unitOfWork.Addresses.CreateAsync(address);
                await _unitOfWork.SaveChangesWithTransactionAsync();
                // _logger.LogInformation("Delete account successfully with id {Id}", id);
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

        public Task<bool> DeleteAddress(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressResponse>> GetByAccount(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AddressResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAddress(Guid id, AddressUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}