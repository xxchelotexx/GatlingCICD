using System;
using TechTalk.SpecFlow;

namespace GatlingCICD
{
    [Binding]
    public class GetSpecificIDStepDefinitions
    {
        [Given(@"Given I have a Valid product ID")]
        public void GivenGivenIHaveAValidProductID()
        {
            throw new PendingStepException();
        }

        [When(@"I send a Get request")]
        public void WhenISendAGetRequest()
        {
            throw new PendingStepException();
        }

        [Then(@"I Spect a Valid Response")]
        public void ThenISpectAValidResponse()
        {
            throw new PendingStepException();
        }
    }
}
