using ShowTime.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface ILineupService
    {
        Task<LineupGetDto?> GetLineupByIdAsync(int id);
        Task<IList<LineupGetDto>> GetAllLineupsAsync();
        Task<IList<LineupGetDto>> GetLineupsByFestivalIdAsync(int festivalId);
        Task<IList<LineupGetDto>> GetLineupsByArtistIdAsync(int artistId);
        Task AddLineupAsync(LineupCreateDto dto);
        Task UpdateLineupAsync(LineupUpdateDto dto);
        Task DeleteLineupAsync(int id);
    }
}
