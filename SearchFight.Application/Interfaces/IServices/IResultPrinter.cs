using SearchFight.ApplicationDomain.Models;
using System.Threading.Tasks;

namespace SearchFight.ApplicationDomain.Interfaces.IServices
{
    public interface IResultPrinter
    {
        /// <summary>
        /// Print search report to Console
        /// </summary>
        /// <param name="report">report results</param>
        void DisplayReport(SearchReport report);
    }
}
