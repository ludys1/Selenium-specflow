using NUnit.Framework;
using SharpGaming.Utils;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SharpGaming.StepDefinitionAPI
{
    [Binding]
    class CountriesByLanguageTest
    {
        [Given(@"user checks endpoint for different languages")]
        public async Task GivenUserChecksEndpointForDifferentLanguages()
        {
            var english = await ApiRequests.GetCountries("en");
            var spanish = await ApiRequests.GetCountries("es");
            var bulgarian = await ApiRequests.GetCountries("bg");

            Assert.That(english, Is.EqualTo(spanish));
            Assert.That(spanish, Is.EqualTo(bulgarian));
        }
    }
}
