using NUnit.Framework;
using SharpGaming.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SharpGaming.StepDefinitionAPI
{
    [Binding]
    class CountriesByLanguageTest
    {

        private List<dynamic> responseList;

        [Given(@"user checks endpoint for different languages")]
        public async Task GivenUserChecksEndpointForDifferentLanguages(Table table)
        {
            var list = TableToList.ConvertTableToList(table);
            responseList = new List<dynamic>();

            for (int i = 0; i < list.Count; i++)
            {
                responseList.Add(await ApiRequests.GetCountries(list[i]));
            }
        }

        [Then(@"the result sould be the same for each language")]
        public async Task ThenTheResultSouldBeTheSameForEachLanguage()
        {
            var english = await ApiRequests.GetCountries("en");

            foreach (var item in responseList)
            {
                Assert.That(english, Is.EqualTo(item));
            }

            
        }

    }
}
