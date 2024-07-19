using BookReservationService.DatabaseContext;
using BookReservationService.DTOs;
using BookReservationService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReservationService.DataAccessLayer
{
    public class BookReservationDL : IBookReservationDL
    {
        private readonly ILogger<object> _logger;
        private readonly SystemDbContext _dbContext;

        public BookReservationDL(ILogger<object> logger, SystemDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<List<BookReservation>?> GetBookReservations()
        {
            return await _dbContext.BookReservations.ToListAsync();
        }

        public async Task<BookReservation?> GetBookReservation(int id)
        {
            return await _dbContext.BookReservations.FindAsync(id);
        }

        public async Task<int> CreateBookReservation(BookReservation bookInformation)
        {
            _dbContext.BookReservations.Add(bookInformation);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateBookReservation(BookReservation bookInformation)
        {
            _dbContext.BookReservations.Update(bookInformation);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteBookReservation(BookReservation bookInformation)
        {
            _dbContext.BookReservations.Remove(bookInformation);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<BookReservation>?> SearchBookReservations(string searchTerm)
        {
            return await _dbContext.BookReservations
                .Where(b => b.BookId == Convert.ToInt32(searchTerm))
                .ToListAsync();
        }
    }
}
