using NUnit.Framework;
using SearchFight.ApplicationDomain.Interfaces.IRepositories;
using SearchFight.ApplicationDomain.Models;
using SearchFight.ApplicationDomain.Services;
using SearchFight.ConsoleApplication.Helper;
using SearchFight.ConsoleTests.MockDependencies;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SearchFight.ConsoleTests.Steps
{
    [Binding]
    public class SearchQuerySteps
    {
        private MockSearchEngineRepository _googleSearchEngineRepository;
        private MockSearchEngineRepository _bingSearchEngineRepository;

        private ReportService _reportService;

        SearchReport results;

        [Given(@"two search engines are set")]
        public void GivenTwoSearchEnginesAreSet()
        {
            _googleSearchEngineRepository = new MockSearchEngineRepository()
                            .SetSearchEngineName("Google")
                            .SetSearchResults();
            _bingSearchEngineRepository = new MockSearchEngineRepository()
                .SetSearchEngineName("Bing")
                .SetSearchResults();

            var searchService = new SearchService(new List<ISearchEngineRepository>() 
                {
                    _googleSearchEngineRepository.Object, _bingSearchEngineRepository.Object
                });

            var winnerService = new WinnerService();

            _reportService = new ReportService(searchService, winnerService);
        }
        
        [When(@"I enter my search words as '(.*)'")]
        public async Task WhenIEnterMySearchWordsAs(string querySearch)
        {
            results = await _reportService.ExecuteSearchFightAsync(ArgsHelper.ExtractArgs(querySearch));
        }

        [Then(@"the results should include (.*) search results")]
        public void ThenTheResultsShouldIncludeSearchResults(int totalSearchResults)
        {
            Assert.AreEqual(totalSearchResults, results.SearchResults.Count);
        }

        [Then(@"the results include (.*) search engine winners")]
        public void ThenTheResultsIncludeSearchEngineWinners(int winnersPerSearchEngine)
        {
            Assert.AreEqual(winnersPerSearchEngine, results.SearchWinners.Count);
        }

        [Then(@"the results has an absolute winner")]
        public void ThenTheResultsHasAnAbsoluteWinner()
        {
            Assert.NotNull(results.SearchTotalWinner);
            Assert.IsNotEmpty(results.SearchTotalWinner);
        }
    }
}
