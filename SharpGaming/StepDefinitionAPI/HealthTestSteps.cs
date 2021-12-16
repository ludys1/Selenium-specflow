using NUnit.Framework;
using SharpGaming.Utils;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SharpGaming.StepDefinitionAPI
{
    [Binding]
    public sealed class HealthTestSteps
    {

        private string healthServiceStaus; 

        [Given(@"user asks api for health")]
        public async Task GivenUserApiAsksForHealth()
        {
            healthServiceStaus = await ApiRequests.GetHealthStatus();
        }

        [Then(@"health service should be ok")]
        public async Task ThenHealthShouldBeOk()
        {
            Assert.That(healthServiceStaus == "OK");
        }
    }
}
