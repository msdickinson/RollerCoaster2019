using RollerCoaster2019.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollerCoaster2019.Services.ManageCoaster
{
    public class ManageCoasterService : IManageCoasterService
    {
        public async Task RenameCoaster(string coasterName, string newCoasterName)
        {
            await Task.CompletedTask;
        }
        public async Task SaveCoaster(string coasterName, Coaster coaster)
        {
            await Task.CompletedTask;
        }
        public async Task DeleteCoaster(string coasterName)
        {
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<Coaster>> FetchCoasters()
        {
            await Task.CompletedTask;
            return new List<Coaster>();
        }
        public async Task<Coaster> LoadCoaster(string coasterName)
        {
            await Task.CompletedTask;
            return null;
        }
    }
}
