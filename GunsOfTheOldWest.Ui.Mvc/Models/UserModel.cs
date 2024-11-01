using System.ComponentModel.DataAnnotations;

namespace GunsOfTheOldWest.Ui.Mvc.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Voornaam is verplicht.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Familienaam is verplicht.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is verplicht.")]
        [EmailAddress(ErrorMessage = "Voer een geldig emailadres in.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefoonnummer is verplicht.")]
        [Phone(ErrorMessage = "Voer een geldig telefoonnummer in.")]
        public string PhoneNumber { get; set; }
    }
}