using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAspNetCore.Models
{
    public class CustomerCreateModel
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        [MaxLength(40, ErrorMessage = "Ad alanı en fazla 30 karakter olabilir")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        [MinLength(3, ErrorMessage = "Soyad alanı en az 3 karakter olabilir")]
        public string LastName { get; set; }

        [Range(18, 40, ErrorMessage = "Yaş değeri en az 18 , en fazla 40 olabilir")]
        public int Age { get; set; }
    }
}
