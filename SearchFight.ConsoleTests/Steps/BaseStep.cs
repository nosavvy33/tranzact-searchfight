using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SearchFight.ConsoleTests.Steps
{
    [Binding]
    public class BaseStep
    {
        private readonly ScenarioContext _scenarioContext;
        public BaseStep(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
        }

        [AfterStep]
        public void MarkSetupAssertionExceptionsAsInconclusive()
        {
            if (_scenarioContext.TestError is AssertionException &&
                _scenarioContext.CurrentScenarioBlock == ScenarioBlock.Given)
                Assert.Inconclusive($"{_scenarioContext.TestError.Message}\nIn Given block");
        }
    }
}
