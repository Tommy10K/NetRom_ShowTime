using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services;

public class ArtistService : IArtistService
{
    private readonly IRepository<Artist> _artistRepository;

    public ArtistService(IRepository<Artist> artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<ArtistGetDto?> GetArtistByIdAsync(int id)
    {
        var artist = await _artistRepository.GetByIdAsync(id);
        if (artist == null) return null;

        return new ArtistGetDto
        {
            Id = artist.Id,
            Name = artist.Name,
            Image = artist.Image,
            Genre = artist.Genre
        };
    }

    public async Task<IList<ArtistGetDto>> GetAllArtistsAsync()
    {
        try
        {
            var artists = await _artistRepository.GetAllAsync();

            return artists.Select(artist => new ArtistGetDto
            {
                Id = artist.Id,
                Name = artist.Name,
                Image = artist.Image,
                Genre = artist.Genre
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving all artists.", ex);
        }
    }

    public async Task AddArtistAsync(ArtistCreateDto artistCreateDto)
    {
        try
        {
            var artist = new Artist
            {
                Name = artistCreateDto.Name,
                Image = artistCreateDto.Image,
                Genre = artistCreateDto.Genre
            };
            await _artistRepository.AddAsync(artist);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while adding the artist.", ex);
        }
    }

    public async Task UpdateArtistAsync(ArtistUpdateDto dto)
    {
        var artist = await _artistRepository.GetByIdAsync(dto.Id)
                     ?? throw new KeyNotFoundException($"Artist {dto.Id} not found");

        artist.Name = dto.Name;
        artist.Genre = dto.Genre;
        artist.Image = dto.Image;

        await _artistRepository.UpdateAsync(artist);
    }

    public async Task DeleteArtistAsync(int id)
    {
        try
        {             
            await _artistRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while deleting the artist with ID {id}.", ex);
        }
    }
}