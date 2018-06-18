using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHub.Room.Context.Repository
{
    /// <summary>
    /// Interface for the CRUD functionality of the Room repository
    /// </summary>
    public interface IRoomsRepository
    {
        /// <summary>
        /// Inserts a Room into the data source.
        /// </summary>
        /// <param name="room">Room to be inserted.</param>
        /// <returns>Asynchronous task.</returns>
        Task InsertAsync(Models.Room room);

        /// <summary>
        /// Gets all Rooms from the data source.
        /// </summary>
        /// <returns>Asynchronous task that generates a list of Room context models.</returns>
        Task<List<Models.Room>> GetAsync();

        /// <summary>
        /// Gets a Room by its Id from the data source.
        /// </summary>
        /// <param name="id">Guid identifying the Room.</param>
        /// <returns>Asynchronous task that generates a Room context model.</returns>
        Task<Models.Room> GetByIdAsync(Guid id);

        /// <summary>
        /// Updates a Room that already exists in the data source.
        /// </summary>
        /// <param name="room">Room to be updated.</param>
        /// <returns>Asynchronous task.</returns>
        Task UpdateAsync(Models.Room room);

        /// <summary>
        /// Deletes a Room from the data source.
        /// </summary>
        /// <param name="id">Guid identifying the Room.</param>
        /// <returns>Asynchronous task.</returns>
        Task DeleteAsync(Guid id);
    }

}