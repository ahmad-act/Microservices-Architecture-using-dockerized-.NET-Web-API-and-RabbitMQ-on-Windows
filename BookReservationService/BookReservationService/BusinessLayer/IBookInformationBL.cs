using BookReservationService.DTOs;
using BookReservationService.Models;

namespace BookReservationService.BusinessLayer
{
    public interface IBookReservationBL
    {
        Task<BookReservationDisplayDto?> CreateBookReservation(BookReservationUpdateDto bookInformationUpdateDto);
        Task<string> DeleteBookReservation(int id);
        Task<BookReservationDisplayDto?> GetBookReservation(int id);
        Task<List<BookReservationDisplayDto>?> GetBookReservations();
        Task<List<BookReservationDisplayDto>?> SearchBookReservations(string searchTerm);
        Task<BookReservationDisplayDto?> UpdateBookReservation(int id, BookReservationUpdateDto bookInformationUpdateDto);
    }
}