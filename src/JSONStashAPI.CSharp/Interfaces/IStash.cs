using JSONStashAPI.CSharp.Models;

namespace JSONStashAPI.CSharp.Interfaces
{
    public interface IStash
    {
        /// <summary>
        /// Get data of a stash.
        /// </summary>
        /// <returns></returns>
        Task<StashResponse> GetStashDataAsync(string key, string stashId);

        /// <summary>
        /// Update data of a stash.
        /// </summary>
        /// <returns></returns>
        Task<StashResponse> UpdateStashDataAsync(string key, string stashId, string json);
    }
}
