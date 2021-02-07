using Moq;
using SearchFight.ApplicationDomain.DTO;
using SearchFight.ApplicationDomain.Interfaces.IRepositories;
using System;
using System.Threading.Tasks;

namespace SearchFight.ConsoleTests.MockDependencies
{
    public class MockSearchEngineRepository : Mock<ISearchEngineRepository>
    {
        public MockSearchEngineRepository SetSearchEngineName(string engineName) 
        {
            Setup(repo => repo.Name).Returns(engineName);
            return this;
        }

        public MockSearchEngineRepository SetSearchResults() 
        {
            Setup(repo => repo.GetResultAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new ResultDTO() { Results = new Random().Next(1, 100), ResponseCode = ApplicationDomain.Enums.SearchResponseCode.OK }));
            return this;
        }
    }
}
