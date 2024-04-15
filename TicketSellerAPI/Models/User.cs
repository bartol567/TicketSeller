using System;
using System.ComponentModel.DataAnnotations;

namespace TicketSellerAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Required(ErrorMessage = "Email is required to receive the ticket.")]
        public string Email { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "OIB must be numeric and exactly 11 digits long.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "OIB must be exactly 11 digits long.")]
        public string Oib { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        public string adress { get; set; }

        [StringLength(100, ErrorMessage = "City name cannot be longer than 100 characters.")]
        public string City { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Registration date is required.")]
        public DateTime RegistrationDate { get; set; }
    }
}
