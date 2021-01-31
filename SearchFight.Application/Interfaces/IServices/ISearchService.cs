using SearchFight.ApplicationDomain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFight.ApplicationDomain.Interfaces.IServices
{
    public interface ISearchService
    {
        /// <summary>
        /// Get search results
        /// </summary>
        /// <param name="query">Search query words</param>
        /// <returns>Search results</returns>
        Task<List<Search>> GetResultsAsync(List<string> query);
    }
}
