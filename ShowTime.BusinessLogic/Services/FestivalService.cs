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
    public class FestivalService : IFestivalService
    {
        private readonly IRepository<Festival> _repo;

        public FestivalService(IRepository<Festival> repo)
        {
            _repo = repo;
        }

        public async Task<FestivalGetDto?> GetFestivalByIdAsync(int id)
        {
            var f = await _repo.GetByIdAsync(id);
            if (f == null) return null;

            return new FestivalGetDto
            {
                Id = f.Id,
                Name = f.Name,
                Location = f.Location,
                StartDate = f.StartDate,
                EndDate = f.EndDate,
                SplashArt = f.SplashArt,
                Capacity = f.Capacity
            };
        }

        public async Task<IList<FestivalGetDto>> GetAllFestivalsAsync()
        {
            var all = await _repo.GetAllAsync();
            return all.Select(f => new FestivalGetDto
            {
                Id = f.Id,
                Name = f.Name,
                Location = f.Location,
                StartDate = f.StartDate,
                EndDate = f.EndDate,
                SplashArt = f.SplashArt,
                Capacity = f.Capacity
            }).ToList();
        }

        public async Task AddFestivalAsync(FestivalCreateDto dto)
        {
            var f = new Festival
            {
                Name = dto.Name,
                Location = dto.Location,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                SplashArt = dto.SplashArt,
                Capacity = dto.Capacity
            };
            await _repo.AddAsync(f);
        }

        public async Task UpdateFestivalAsync(FestivalUpdateDto dto)
        {
            var f = await _repo.GetByIdAsync(dto.Id)
                  ?? throw new KeyNotFoundException($"Festival {dto.Id} not found.");

            f.Name = dto.Name;
            f.Location = dto.Location;
            f.StartDate = dto.StartDate;
            f.EndDate = dto.EndDate;
            f.SplashArt = dto.SplashArt;
            f.Capacity = dto.Capacity;

            await _repo.UpdateAsync(f);
        }

        public async Task DeleteFestivalAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
