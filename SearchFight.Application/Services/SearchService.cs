using SearchFight.ApplicationDomain.Interfaces.IRepositories;
using SearchFight.ApplicationDomain.Interfaces.IServices;
using SearchFight.ApplicationDomain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFight.ApplicationDomain.Services
{
    public class SearchService : ISearchService
    {
        private readonly IEnumerable<ISearchEngineRepository> _searchRepositories;

        public SearchService(IEnumerable<ISearchEngineRepository> searchRepositories)
        {
            _searchRepositories = searchRepositories;
        }

        public async Task<List<Search>> GetResultsAsync(List<string> query)
        {
            if(query is null || query.Count == 0)
            {
                throw new ArgumentException($"The object {nameof(query)} is null or empty.");
            }

            var list = new List<Search>();
            
            foreach (var term in query)
            {
                foreach (var repository in _searchRepositories)
                {
                    var result = new Search()
                    {
                        SearchEngine = repository.Name,
                        SearchQuery = term,
                        TotalResults = await repository.GetResultAsync(term)
                    };

                    list.Add(result);
                }
            }

            return list;
        }
    }
}
