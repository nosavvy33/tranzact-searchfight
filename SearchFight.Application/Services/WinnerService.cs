using SearchFight.ApplicationDomain.Interfaces.IServices;
using SearchFight.ApplicationDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight.ApplicationDomain.Services
{
    public class WinnerService : IWinnerService
    {
        public string GetTotalWinner(List<Search> searchData)
        {
            if (searchData is null || searchData.Count() == 0)
            {
                throw new ArgumentException($"The object {nameof(searchData)} is null or empty.");
            }

            var groupedResults = searchData
                .GroupBy(search => search.SearchQuery)
                .Select(group => 
                    new { Id = group.Key, TotalResults = group.Sum(result => result.TotalResults) }
                    );

            var totalWinner = groupedResults
                .Aggregate((current, next) => current.TotalResults > next.TotalResults ? current : next);
            
            return totalWinner.Id;
        }

        public List<Search> GetWinnerBySearchEngine(List<Search> searchData)
        {
            if (searchData is null || searchData.Count() == 0)
            {
                throw new ArgumentException($"The object {nameof(searchData)} is null or empty.");
            }

            var winners = new List<Search>();
            
            var groupedData = searchData
                .GroupBy(data => data.SearchEngine)
                .ToList();

            foreach (var data in groupedData)
            {
                winners.Add(data.Aggregate((current, next) => current.TotalResults > next.TotalResults ? current : next));
            }

            return winners;
        }
    }
}
