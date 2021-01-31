using SearchFight.ApplicationDomain.Interfaces.IServices;
using SearchFight.ApplicationDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight.ApplicationDomain.Services
{
    public class ResultPrinter : IResultPrinter
    {
        public void DisplayReport(SearchReport report)
        {
            PrintSearchResults(report.SearchResults);
            PrintWinnersBySearchengine(report.SearchWinners);
            PrintToltalWinner(report.SearchTotalWinner);
        }

        private void PrintSearchResults(List<Search> searchResults)
        {
            searchResults
                .GroupBy(result => result.SearchQuery)
                .Select(group => $"{group.Key}: {string.Join(" ", group.Select(group => $"{group.SearchEngine}: {group.TotalResults}"))}")
                .ToList()
                .ForEach(resultString => Console.WriteLine(resultString));
        }

        private void PrintWinnersBySearchengine(List<Search> winners)
        {
            winners
                .Select(winner => $"{winner.SearchEngine} winner: {winner.SearchQuery}")
                .ToList()
                .ForEach(resultString => Console.WriteLine(resultString));
        }

        private void PrintToltalWinner(string totalWinner)
        {
            Console.WriteLine($"Total winner: {totalWinner}");
        }
    }
}
