using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Didi10Rugby.Models
{
    public class MyRegistrationModel
    {
        [Required(ErrorMessage ="შეავსეთ სახელის ველი"),MaxLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "შეავსეთ გვარისს ველი"), MaxLength(50)]
        public string SurName { get; set; }
        [Required(ErrorMessage = "შეავსეთ თარიღის ველი")]
        [DataType(DataType.Date)]
        public DateTime BornDate { get; set; }
        [Required(ErrorMessage = "შეავსეთ ასაკის ველი")]
        [Range(16, 99, ErrorMessage = "Age should be between 16 and 99")]
        public int Age { get; set; }
        [Required(ErrorMessage = "შეავსეთ მისამართის ველი")]
        public string Address { get; set; }
        [Required(ErrorMessage = "შეავსეთ ტელეფონის ველი")]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }
        [Required(ErrorMessage = "შეავსეთ გუნდის ველი")]
        public string Team { get; set; }
        [Required(ErrorMessage = "შეავსეთ ელ.ფოსტის ველი")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "შეავსეთ პაროლის ველი")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "გაიმეორეთ პაროლი")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "შეავსეთ მომხმარებლის კატეგორია")]
        public string UserCategory { get; set; }
    }

}