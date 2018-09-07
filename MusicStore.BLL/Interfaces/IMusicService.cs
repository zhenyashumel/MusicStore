using MusicStore.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.BLL.Interfaces
{
    public interface IMusicService
    {
        ICRUDService<SongDTO> SongService { get; }
        ICRUDService<AuthorDTO> AuthorService { get; }
        ICRUDService<AlbumDTO> AlbumService { get; }
        ICRUDService<OrderDTO> OrderService { get; }
    }
}
