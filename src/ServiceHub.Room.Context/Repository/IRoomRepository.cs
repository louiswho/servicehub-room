using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHub.Room.Context.Repository
{
    public interface IRoomsRepository
    {
        /// <summary>
        /// Interface for the CRUD functionality of the Room repository
        /// </summary>
        /// <param name="room"></param>
        Task InsertAsync(Models.Room room);
        Task<List<Models.Room>> GetAsync();
        Task<Models.Room> GetByIdAsync(Guid id);
        Task UpdateAsync(Models.Room room);
        Task DeleteAsync(Guid id);
    }
}