using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface IFestivalService
    {
        Task<FestivalGetDto?> GetFestivalByIdAsync(int id);
        Task<IList<FestivalGetDto>> GetAllFestivalsAsync();
        Task AddFestivalAsync(FestivalCreateDto dto);
        Task UpdateFestivalAsync(FestivalUpdateDto dto);
        Task DeleteFestivalAsync(int id);
    }
}
