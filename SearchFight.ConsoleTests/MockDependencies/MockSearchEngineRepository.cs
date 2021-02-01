using Moq;
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
                .Returns(Task.FromResult(long.Parse(new Random().Next(1, 100).ToString())));
            return this;
        }
    }
}
