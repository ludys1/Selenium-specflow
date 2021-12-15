using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bogus;
using Bogus.DataSets;

namespace SharpGaming.Utils
{
    public static class FakerData
    {
        public static string RegistrationUserName => new Bogus.Person().UserName;
        public static string FirsName => new Bogus.Person().FirstName;
        public static string LastName => new Bogus.Person().LastName;
        public static string Email => new Bogus.Faker().Internet.ExampleEmail();
        public static string Text => new Bogus.Faker().Company.Random.Word();
        public static string Country => new Bogus.Faker().Address.Country();
        public static string PhoneNumber => new Faker().Phone.PhoneNumber("#########");
        public static string Pass => new Faker().Internet.Password();
        public static string Day => new Bogus.Faker().Random.Number(1, 28).ToString();
        public static string Month => new Bogus.Faker().Random.Number(1, 12).ToString();
        public static string Year => new Bogus.Faker().Random.Number(1902, 2002).ToString();
    }
}
