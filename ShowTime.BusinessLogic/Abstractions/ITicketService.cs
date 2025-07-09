using ShowTime.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface ITicketService
    {
        Task<TicketGetDto?> GetTicketByIdAsync(int id);
        Task<IList<TicketGetDto>> GetAllTicketsAsync();
        Task<IList<TicketGetDto>> GetTicketsByFestivalIdAsync(int festivalId);
        Task AddTicketAsync(TicketCreateDto ticketCreateDto);
        Task UpdateTicketAsync(TicketUpdateDto ticketUpdateDto);
        Task DeleteTicketAsync(int id);
    }
}
