using System.ComponentModel.DataAnnotations;

namespace BookReservationService.DTOs
{
    /// <summary>
    /// Represents the create/update book reservation.
    /// </summary>
    public class BookReservationUpdateDto
    {
        /// <summary>
        /// Gets or sets the Book ID of BookInformation.
        /// </summary>
        /// <example>1</example>
        [Required]
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the reserved book count.
        /// </summary>
        /// <example>1</example>
        [Required]
        [Range(0, 100)]
        public int Reserved { get; set; }
    }
}