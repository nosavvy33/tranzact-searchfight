using SearchFight.ApplicationDomain.Models;
using System.Collections.Generic;

namespace SearchFight.ApplicationDomain.Interfaces.IServices
{
    public interface IWinnerService
    {
        /// <summary>
        /// Get winner candidate by search engine
        /// </summary>
        /// <param name="searchData">search results</param>
        List<Search> GetWinnerBySearchEngine(List<Search> searchData);

        /// <summary>
        /// Get winner candidate among all search engines
        /// </summary>
        /// <param name="searchData">search results</param>
        string GetTotalWinner(List<Search> searchData);

    }
}
