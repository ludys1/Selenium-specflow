using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharpGaming.Utils
{
    class ApiRequests
    {
        public static async Task<string> GetHealthStatus()
        {
            return (await ApiAdresses.HealthTest
                .GetJsonAsync()).service;
        }

        public static async Task<object> GetCountries(string languageCode)
        {
            return (await ApiAdresses.LanguageTest(languageCode)
                .GetJsonAsync());
        }
    }
}
