using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepository;

        public BookingService(IRepository<Booking> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<BookingGetDto?> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking == null) return null;

            return new BookingGetDto
            {
                Id = booking.Id,
                UserId = booking.UserId,
                FestivalId = booking.FestivalId,
                TicketId = booking.TicketId,
                BookingTime = booking.BookingTime
            };
        }

        public async Task<IList<BookingGetDto>> GetAllBookingsAsync()
        {
            try
            {
                var bookings = await _bookingRepository.GetAllAsync();
                return bookings.Select(b => new BookingGetDto
                {
                    Id = b.Id,
                    UserId = b.UserId,
                    FestivalId = b.FestivalId,
                    TicketId = b.TicketId,
                    BookingTime = b.BookingTime
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all bookings.", ex);
            }
        }

        public async Task<IList<BookingGetDto>> GetBookingsByFestivalIdAsync(int festivalId)
        {
            try
            {
                var bookings = await _bookingRepository.GetAllAsync();
                return bookings
                       .Where(b => b.FestivalId == festivalId)
                       .Select(b => new BookingGetDto
                       {
                           Id = b.Id,
                           UserId = b.UserId,
                           FestivalId = b.FestivalId,
                           TicketId = b.TicketId,
                           BookingTime = b.BookingTime
                       })
                       .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving bookings for festival {festivalId}.", ex);
            }
        }

        public async Task<IList<BookingGetDto>> GetBookingsByUserIdAsync(int userId)
        {
            try
            {
                var bookings = await _bookingRepository.GetAllAsync();
                return bookings
                       .Where(b => b.UserId == userId)
                       .Select(b => new BookingGetDto
                       {
                           Id = b.Id,
                           UserId = b.UserId,
                           FestivalId = b.FestivalId,
                           TicketId = b.TicketId,
                           BookingTime = b.BookingTime
                       })
                       .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving bookings for user {userId}.", ex);
            }
        }

        public async Task<IList<BookingGetDto>> GetBookingsByTicketIdAsync(int ticketId)
        {
            try
            {
                var bookings = await _bookingRepository.GetAllAsync();
                return bookings
                       .Where(b => b.TicketId == ticketId)
                       .Select(b => new BookingGetDto
                       {
                           Id = b.Id,
                           UserId = b.UserId,
                           FestivalId = b.FestivalId,
                           TicketId = b.TicketId,
                           BookingTime = b.BookingTime
                       })
                       .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving bookings for ticket {ticketId}.", ex);
            }
        }

        public async Task AddBookingAsync(BookingCreateDto dto)
        {
            try
            {
                var booking = new Booking
                {
                    UserId = dto.UserId,
                    FestivalId = dto.FestivalId,
                    TicketId = dto.TicketId,
                    BookingTime = dto.BookingTime
                };
                await _bookingRepository.AddAsync(booking);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the booking.", ex);
            }
        }

        public async Task UpdateBookingAsync(BookingUpdateDto dto)
        {
            var booking = await _bookingRepository.GetByIdAsync(dto.Id)
                          ?? throw new KeyNotFoundException($"Booking {dto.Id} not found");

            booking.UserId = dto.UserId;
            booking.FestivalId = dto.FestivalId;
            booking.TicketId = dto.TicketId;
            booking.BookingTime = dto.BookingTime;

            await _bookingRepository.UpdateAsync(booking);
        }

        public async Task DeleteBookingAsync(int id)
        {
            try
            {
                await _bookingRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the booking with ID {id}.", ex);
            }
        }
    }
}

