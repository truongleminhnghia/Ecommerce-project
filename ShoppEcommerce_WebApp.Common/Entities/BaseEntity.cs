
using System.ComponentModel.DataAnnotations;

namespace ShoppEcommerce_WebApp.Common.Entities
{
    public class BaseEntity
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UpdateAt { get; set; }

    }
}
