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

        //Ako imam posebne zahtjeve promijeni, inace dovoljan validator
        [Required(ErrorMessage = "Seat number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Seat number must be greater than 0.")]
        public int Seat { get; set; }

        // Seated je da ili ne, dovoljno

        public User? User { get; set; }
        public Occasion? Occasion { get; set; }
    }
}


