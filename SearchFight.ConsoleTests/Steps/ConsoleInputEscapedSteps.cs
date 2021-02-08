using NUnit.Framework;
using SearchFight.ConsoleApplication.Helper;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SearchFight.ConsoleTests.Steps
{
    [Binding]
    public class ConsoleInputEscapedSteps
    {
        private List<string> result;

        [Given(@"the query helper is available")]
        public void GivenTheQueryHelperIsAvailable()
        {
            // Arrange result list
            result = new List<string>();

            // Assert ArgsHelper is available before running tests
            Type type = typeof(ArgsHelper);
            bool isHelperAvailable = type.IsAbstract && type.IsSealed; //test
            Assert.IsTrue(isHelperAvailable);
        }


        [When(@"I enter query as '(.*)'")]
        public void WhenIEnterQueryAs(string querySearch)
        {
            // Act
            result = ArgsHelper.ExtractArgs(querySearch);
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            // Assert
            Assert.AreEqual(expectedResult, result.Count);
        }
    }
}
