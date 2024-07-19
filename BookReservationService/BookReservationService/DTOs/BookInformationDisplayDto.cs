using System.ComponentModel.DataAnnotations;

namespace BookReservationService.DTOs
{
    /// <summary>
    /// Represents the information about a book reservation for display to the user.
    /// </summary>
    public class BookReservationDisplayDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the book reservation.
        /// </summary>
        /// <example>1</example>
        [Required]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Book ID of Book Information.
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
