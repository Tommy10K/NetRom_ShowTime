using ShowTime.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface IBookingService
    {
        Task<BookingGetDto?> GetBookingByIdAsync(int id);
        Task<IList<BookingGetDto>> GetAllBookingsAsync();
        Task<IList<BookingGetDto>> GetBookingsByFestivalIdAsync(int festivalId);
        Task<IList<BookingGetDto>> GetBookingsByUserIdAsync(int userId);
        Task<IList<BookingGetDto>> GetBookingsByTicketIdAsync(int ticketId);
        Task AddBookingAsync(BookingCreateDto bookingCreateDto);
        Task UpdateBookingAsync(BookingUpdateDto bookingUpdateDto);
        Task DeleteBookingAsync(int id);

    }
}
