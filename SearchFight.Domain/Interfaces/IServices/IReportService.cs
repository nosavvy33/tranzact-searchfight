using SearchFight.ApplicationDomain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFight.ApplicationDomain.Interfaces.IServices
{
    public interface IReportService
    {
        /// <summary>
        /// Execute search query
        /// </summary>
        /// <param name="args">Query terms</param>
        /// <returns>Report results</returns>
        Task<SearchReport> ExecuteSearchFightAsync(List<string> args);
    }
}
