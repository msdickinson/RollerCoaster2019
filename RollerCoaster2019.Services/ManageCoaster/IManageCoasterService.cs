using System.Collections.Generic;
using System.Threading.Tasks;
using RollerCoaster2019.Contracts;

namespace RollerCoaster2019.Services.ManageCoaster
{
    public interface IManageCoasterService
    {
        Task DeleteCoaster(string coasterName);
        Task<IEnumerable<Coaster>> FetchCoasters();
        Task<Coaster> LoadCoaster(string coasterName);
        Task RenameCoaster(string coasterName, string newCoasterName);
        Task SaveCoaster(string coasterName, Coaster coaster);
    }
}