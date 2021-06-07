using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IPlayerServiceAPI
    {
        Task<Player> AddPlayer(string teamName,Player player);
        Task<Player> DeletePlayer(int playerId);
    }
}