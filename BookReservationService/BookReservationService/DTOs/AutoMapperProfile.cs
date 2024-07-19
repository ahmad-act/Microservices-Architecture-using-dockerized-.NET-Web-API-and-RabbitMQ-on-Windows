using AutoMapper;
using BookReservationService.Models;

namespace BookReservationService.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookReservation, BookReservationDisplayDto>();
            CreateMap<BookReservationUpdateDto, BookReservation>();
        }
    }
}
