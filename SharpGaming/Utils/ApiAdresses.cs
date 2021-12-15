using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGaming.Utils
{
    public static class ApiAdresses
    {
        public static string BaseApiUrl => "http://affiliate-feed.petfre.sgp.bet/1/";
        public static string HealthTest => BaseApiUrl + "health";
        public static string LanguageTest(string languageCode) => BaseApiUrl + $"countries?languageCode={languageCode}";
    }
}
