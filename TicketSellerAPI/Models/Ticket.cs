using System.ComponentModel.DataAnnotations;

namespace TicketSellerAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Occasion ID is required.")]
        public int OccasionId { get; set; }

        // If you have specific requirements for seats, validate them. Otherwise, basic validation is sufficient.
        [Required(ErrorMessage = "Seat number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Seat number must be greater than 0.")]
        public int Seat { get; set; }

        // Seated can be true or false; no additional validation is required unless specific logic is applied.

        public User? User { get; set; }
        public Occasion? Occasion { get; set; }
    }
}


