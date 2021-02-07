using SearchFight.ApplicationDomain.Interfaces.IServices;
using SearchFight.ApplicationDomain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFight.ApplicationDomain.Services
{
    public class ReportService : IReportService
    {
        private readonly ISearchService _searchService;
        private readonly IWinnerService _winnerService;

        public ReportService(ISearchService searchService,
                             IWinnerService winnerService)
        {
            _searchService = searchService;
            _winnerService = winnerService;
        }

        public async Task<SearchReport> ExecuteSearchFightAsync(List<string> args)
        {
            if (args is null || args.Count == 0)
            {
                throw new ArgumentException($"No args provided");
            }

            var report = new SearchReport
            {
                SearchResults = await _searchService.GetResultsAsync(args)
            };
            
            report.SearchWinners = _winnerService.GetWinnerBySearchEngine(report.SearchResults);
            report.SearchTotalWinner = _winnerService.GetTotalWinner(report.SearchWinners);
            
            return report;
        }
    }
}
