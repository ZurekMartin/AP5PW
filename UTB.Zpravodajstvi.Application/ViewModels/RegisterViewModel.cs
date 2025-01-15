using System.ComponentModel.DataAnnotations;
using UTB.Zpravodajstvi.Domain.Validations;

namespace UTB.Zpravodajstvi.Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Uživatelské jméno je povinné")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Uživatelské jméno musí být dlouhé 3-50 znaků")]
        [ValidUsername]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Jméno je povinné")]
        [FirstLetterCapitalizedCZ]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Příjmení je povinné")]
        [FirstLetterCapitalizedCZ]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email je povinný")]
        [EmailAddress(ErrorMessage = "Neplatný formát emailu")]
        [StringLength(100)]
        public string? Email { get; set; }

        [CzechPhone]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Heslo je povinné")]
        [StrongPassword]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Potvrzení hesla je povinné")]
        [Compare(nameof(Password), ErrorMessage = "Hesla se neshodují")]
        public string? RepeatedPassword { get; set; }
    }
}