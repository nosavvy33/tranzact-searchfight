using Microsoft.Extensions.Options;
using SearchFight.ApplicationDomain.DTO;
using SearchFight.ApplicationDomain.Enums;
using SearchFight.ApplicationDomain.Interfaces.IRepositories;
using SearchFight.Infrastructure.EngineOptionsConfig;
using SearchFight.Infrastructure.Models.Google;
using SearchFight.Infrastructure.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight.Infrastructure.Repository
{
    public class GoogleSearchEngineRepository : ISearchEngineRepository
    {

        private readonly GoogleConfig _googleConfig;

        public GoogleSearchEngineRepository(IOptions<GoogleConfig> googleConfig) 
        {
            _googleConfig = googleConfig.Value;
        }

        public string Name => _googleConfig.Name;

        public async Task<ResultDTO> GetResultAsync(string query)
        {
            if (query is null || query == string.Empty)
            {
                throw new ArgumentException($"The object {nameof(query)} is null or empty.");
            }

            var baseAddress = $"{_googleConfig.Url}?key={_googleConfig.ApiKey}&cx={_googleConfig.Cx}&q={Uri.EscapeDataString(query)}";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();

                try
                {

                    var response = await client.GetAsync(baseAddress);

                    if (!response.IsSuccessStatusCode)
                        throw new Exception("Unable to process request. Please try again.");

                    var stringResponse = await response.Content.ReadAsStringAsync();

                    var result = stringResponse.DeserializeSearchResult<GoogleResponse>();

                    var resultDTO = new ResultDTO() { ResponseCode = SearchResponseCode.OK, Results = long.Parse(result.SearchInformation.TotalResults) };

                    return resultDTO;

                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }
    }
}
