using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;
using ShowTime.BusinessLogic.Dtos;

namespace ShowTime.BusinessLogic.Abstractions;

public interface IArtistService
{
    Task<ArtistGetDto?> GetArtistByIdAsync(int id);
    Task<IList<ArtistGetDto>> GetAllArtistsAsync();
    Task AddArtistAsync(ArtistCreateDto artistCreateDto);
    Task UpdateArtistAsync(ArtistUpdateDto artistUpdateDto);
    Task DeleteArtistAsync(int id);
}
