using NUnit.Framework;
using SharpGaming.Utils;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SharpGaming.StepDefinitionAPI
{
    [Binding]
    public sealed class HealthTestSteps
    {
        [Given(@"user asks api for health")]
        public async Task GivenUserApiAsksForHealth()
        {
            await ApiRequests.GetHealthStatus();
        }

        [Then(@"health service should be ok")]
        public async Task ThenHealthShouldBeOk()
        {
            var healthServiceStaus = await ApiRequests.GetHealthStatus();
            Assert.That(healthServiceStaus == "OK");
        }

    }
}
