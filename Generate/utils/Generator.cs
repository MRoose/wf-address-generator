using System;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Generate
{
    public static class Generator
    {
        
        private static Random random = new Random();

        public static string generateFirstName(string gender, string receiver)
        {
            string fileName = string.Empty;

            if (gender.Equals("m") && receiver.Equals("ru"))
            {
                fileName = "russian-man-first-names.json";
            }
            if (gender.Equals("w") && receiver.Equals("ru"))
            {
                fileName = "russian-woman-first-names.json";
            }
            if (gender.Equals("m") && receiver.Equals("gr"))
            {
                fileName = "greek-man-first-names.json";
            }
            if (gender.Equals("w") && receiver.Equals("gr"))
            {
                fileName = "greek-woman-first-names.json";
            }

            string[] firstNames = getDictionary(fileName);

            return firstNames[random.Next(firstNames.Length)];
        }

        public static string generateLastName(string gender, string receiver)
        {
            string fileName = string.Empty;

            if (gender.Equals("m") && receiver.Equals("ru"))
            {
                fileName = "russian-man-last-names.json";
            }
            if (gender.Equals("w") && receiver.Equals("ru"))
            {
                fileName = "russian-woman-last-names.json";
            }
            if (gender.Equals("m") && receiver.Equals("gr"))
            {
                fileName = "greek-man-last-names.json";
            }
            if (gender.Equals("w") && receiver.Equals("gr"))
            {
                fileName = "greek-woman-last-names.json";
            }

            string[] lastNames = getDictionary(fileName);

            return lastNames[random.Next(lastNames.Length)];
        }

        public static string generateAddress(int from, int to)
        {
            string[] streets = getDictionary("greek-streets.json");
            string street = streets[random.Next(streets.Length)];
            int houseNumber = random.Next(from, to);

            return string.Format("{0} {1}", street, houseNumber.ToString());
        }

        public static string generateCity()
        {
            string[] cities = getDictionary("greek-cities.json");
            return cities[random.Next(cities.Length)];
        }

        public static string generateCounty()
        {
            string[] counties = getDictionary("greek-counties.json");
            return counties[random.Next(counties.Length)];
        }

        public static string generateZipCode()
        {
            return random.Next(13671, 13679).ToString();
        }

        public static string generatePhoneNumber()
        {
            return string.Format("+3069{0}", random.Next(1111111, 9999999));
        }

        private static string[] getDictionary(string fileName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(string.Format("Generate.resources.{0}", fileName));
            StreamReader streamReader = new StreamReader(stream);
            string jsonAsString = streamReader.ReadToEnd();
            string[] stringArray = JsonSerializer.Deserialize<string[]>(jsonAsString);

            return stringArray;
        }
    }
}
