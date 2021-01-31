using System.Threading.Tasks;

namespace SearchFight.ApplicationDomain.Interfaces.IRepositories
{
    public interface ISearchEngineRepository
    {
        /// <summary>
        /// Get current search engine name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get search results
        /// </summary>
        /// <param name="query">Search query words</param>
        /// <returns>Total search coincidences</returns>
        Task<long> GetResultAsync(string query);
    }
}
