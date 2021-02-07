using Microsoft.Extensions.Options;
using SearchFight.ApplicationDomain.DTO;
using SearchFight.ApplicationDomain.Enums;
using SearchFight.ApplicationDomain.Interfaces.IRepositories;
using SearchFight.Infrastructure.EngineOptionsConfig;
using System;
using System.Threading.Tasks;

namespace SearchFight.Infrastructure.Repository
{
    public class YandexSearchEngineRepository : ISearchEngineRepository
    {

        private readonly YandexConfig _yandexConfig;

        public YandexSearchEngineRepository(IOptions<YandexConfig> yandexConfig)
        {
            _yandexConfig = yandexConfig.Value;
        }
        public string Name => _yandexConfig.Name;

        public async Task<ResultDTO> GetResultAsync(string query)
        {
            try
            {
                throw new Exception($"{Name} failed!");
            }
            catch (Exception exception) 
            {
                return await Task.FromResult(new ResultDTO() { Results = 0, ResponseCode = SearchResponseCode.Failed });
            }
        }
    }
}
