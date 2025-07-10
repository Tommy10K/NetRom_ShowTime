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
    public class LineupService : ILineupService
    {
        private readonly IRepository<Lineup> _repo;

        public LineupService(IRepository<Lineup> repo)
        {
            _repo = repo;
        }

        public async Task<LineupGetDto?> GetLineupByIdAsync(int id)
        {
            var l = await _repo.GetByIdAsync(id);
            return l == null
                ? null
                : new LineupGetDto
                {
                    Id = l.Id,
                    FestivalId = l.FestivalId,
                    ArtistId = l.ArtistId,
                    Stage = l.Stage,
                    StartTime = l.StartTime
                };
        }

        public async Task<IList<LineupGetDto>> GetAllLineupsAsync()
        {
            try
            {
                var list = await _repo.GetAllAsync();
                return list.Select(l => new LineupGetDto
                {
                    Id = l.Id,
                    FestivalId = l.FestivalId,
                    ArtistId = l.ArtistId,
                    Stage = l.Stage,
                    StartTime = l.StartTime
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all line-ups.", ex);
            }
        }

        public async Task<IList<LineupGetDto>> GetLineupsByFestivalIdAsync(int festivalId)
        {
            try
            {
                var list = await _repo.GetAllAsync();
                return list.Where(l => l.FestivalId == festivalId)
                           .Select(l => new LineupGetDto
                           {
                               Id = l.Id,
                               FestivalId = l.FestivalId,
                               ArtistId = l.ArtistId,
                               Stage = l.Stage,
                               StartTime = l.StartTime
                           })
                           .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving line-ups for festival {festivalId}.", ex);
            }
        }

        public async Task<IList<LineupGetDto>> GetLineupsByArtistIdAsync(int artistId)
        {
            try
            {
                var list = await _repo.GetAllAsync();
                return list.Where(l => l.ArtistId == artistId)
                           .Select(l => new LineupGetDto
                           {
                               Id = l.Id,
                               FestivalId = l.FestivalId,
                               ArtistId = l.ArtistId,
                               Stage = l.Stage,
                               StartTime = l.StartTime
                           })
                           .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving line-ups for artist {artistId}.", ex);
            }
        }

        public async Task AddLineupAsync(LineupCreateDto dto)
        {
            try
            {
                var l = new Lineup
                {
                    FestivalId = dto.FestivalId,
                    ArtistId = dto.ArtistId,
                    Stage = dto.Stage,
                    StartTime = dto.StartTime
                };
                await _repo.AddAsync(l);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding line-up.", ex);
            }
        }

        public async Task UpdateLineupAsync(LineupUpdateDto dto)
        {
            var l = await _repo.GetByIdAsync(dto.Id)
                    ?? throw new KeyNotFoundException($"Line-up {dto.Id} not found.");

            l.FestivalId = dto.FestivalId;
            l.ArtistId = dto.ArtistId;
            l.Stage = dto.Stage;
            l.StartTime = dto.StartTime;

            await _repo.UpdateAsync(l);
        }

        public async Task DeleteLineupAsync(int id)
        {
            try
            {
                await _repo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting line-up {id}.", ex);
            }
        }
    }
}

