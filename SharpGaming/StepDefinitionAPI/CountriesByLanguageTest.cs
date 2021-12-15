using NUnit.Framework;
using SharpGaming.Utils;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SharpGaming.StepDefinitionAPI
{
    [Binding]
    class CountriesByLanguageTest
    {
        object jsonCountry;

        [Given(@"user checks endpoint for different languages")]
        public async Task GivenUserChecksEndpointForDifferentLanguages(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            jsonCountry = await ApiRequests.GetCountries((string)data.Language);

        }


        //[Given(@"user checks endpoint for different languages")]
        //public async Task GivenUserChecksEndpointForDifferentLanguages()
        //{
        //    var english = await ApiRequests.GetCountries("en");
        //    var spanish = await ApiRequests.GetCountries("es");
        //    var bulgarian = await ApiRequests.GetCountries("bg");

        //    Assert.That(english, Is.EqualTo(spanish));
        //    Assert.That(spanish, Is.EqualTo(bulgarian));
        //}

        [Then(@"the result sould be the same for each language")]
        public async Task ThenTheResultSouldBeTheSameForEachLanguage()
        {
            var english = await ApiRequests.GetCountries("en");
            Assert.That(english, Is.EqualTo(jsonCountry));
        }

    }
}
