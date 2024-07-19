using BookReservationService.Models;

namespace BookReservationService.DataAccessLayer
{
    public interface IBookReservationDL
    {
        Task<int> CreateBookReservation(BookReservation bookInformation);
        Task<int> DeleteBookReservation(BookReservation bookInformation);
        Task<BookReservation?> GetBookReservation(int id);
        Task<List<BookReservation>?> GetBookReservations();
        Task<List<BookReservation>?> SearchBookReservations(string searchTerm);
        Task<int> UpdateBookReservation(BookReservation bookInformation);
    }
}