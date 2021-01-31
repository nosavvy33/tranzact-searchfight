using Microsoft.Extensions.Options;
using SearchFight.ApplicationDomain.Interfaces.IRepositories;
using SearchFight.Infrastructure.EngineOptionsConfig;
using SearchFight.Infrastructure.Models.Bing;
using SearchFight.Infrastructure.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight.Infrastructure.Repository
{
    public class BingSearchEngineRepository : ISearchEngineRepository
    {

        private readonly BingConfig _bingConfig;

        public BingSearchEngineRepository(IOptions<BingConfig> bingConfig) 
        {
            _bingConfig = bingConfig.Value;
        }

        public string Name => _bingConfig.Name;

        public async Task<long> GetResultAsync(string query)
        {
            if (query is null || query == string.Empty)
            {
                throw new ArgumentException($"The object {nameof(query)} is null or empty.");
            }

            var baseAddress = $"{_bingConfig.Url}?q={Uri.EscapeDataString(query)}";
            
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _bingConfig.ApiKey);

                try
                {

                    var response = await client.GetAsync(baseAddress);

                    if (!response.IsSuccessStatusCode)
                        throw new Exception("Unable to process request. Please try again.");

                    var stringResponse = await response.Content.ReadAsStringAsync();

                    var result = stringResponse.DeserializeSearchResult<BingResponse>();

                    return result.WebPages.TotalEstimatedMatches;

                }
                catch (Exception exception) 
                {
                    throw new Exception(exception.Message);
                }
            }
        }
    }
}
