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
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<TicketGetDto?> GetTicketByIdAsync(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null) return null;

            return new TicketGetDto
            {
                Id = ticket.Id,
                FestivalId = ticket.FestivalId,
                Name = ticket.Name,
                Price = ticket.Price,
                Quantity = ticket.Quantity
            };
        }

        public async Task<IList<TicketGetDto>> GetAllTicketsAsync()
        {
            try
            {
                var tickets = await _ticketRepository.GetAllAsync();
                return tickets.Select(t => new TicketGetDto
                {
                    Id = t.Id,
                    FestivalId = t.FestivalId,
                    Name = t.Name,
                    Price = t.Price,
                    Quantity = t.Quantity
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all tickets.", ex);
            }
        }

        public async Task<IList<TicketGetDto>> GetTicketsByFestivalIdAsync(int festivalId)
        {
            try
            {
                var tickets = await _ticketRepository.GetAllAsync();
                return tickets.Where(t => t.FestivalId == festivalId)
                              .Select(t => new TicketGetDto
                              {
                                  Id = t.Id,
                                  FestivalId = t.FestivalId,
                                  Name = t.Name,
                                  Price = t.Price,
                                  Quantity = t.Quantity
                              }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving tickets for festival {festivalId}.", ex);
            }
        }

        public async Task AddTicketAsync(TicketCreateDto dto)
        {
            try
            {
                var ticket = new Ticket
                {
                    FestivalId = dto.FestivalId,
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity
                };
                await _ticketRepository.AddAsync(ticket);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the ticket.", ex);
            }
        }

        public async Task UpdateTicketAsync(TicketUpdateDto dto)
        {
            var ticket = await _ticketRepository.GetByIdAsync(dto.Id)
                         ?? throw new KeyNotFoundException($"Ticket {dto.Id} not found");

            ticket.Name = dto.Name;
            ticket.Price = dto.Price;
            ticket.Quantity = dto.Quantity;

            await _ticketRepository.UpdateAsync(ticket);
        }

        public async Task DeleteTicketAsync(int id)
        {
            try
            {
                await _ticketRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the ticket with ID {id}.", ex);
            }
        }
    }
}
