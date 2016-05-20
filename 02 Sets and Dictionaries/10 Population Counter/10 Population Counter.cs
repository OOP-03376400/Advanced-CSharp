using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population_Counter
{
    class Population_Counter
    {
        static void Main(string[] args)
        {
            // country, city, population
            Dictionary<string, Dictionary<string, int>> population = new Dictionary<string, Dictionary<string, int>>();
            // country, total population
            Dictionary<string, long> countryPopulation = new Dictionary<string, long>();

            string input = "";
            while ((input = Console.ReadLine()) != "report")
            {
                string[] data = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string city = data[0];
                string country = data[1];
                int cityPopulation = int.Parse(data[2]);

                if (!population.ContainsKey(country))
                {
                    population[country] = new Dictionary<string, int>();
                    countryPopulation[country] = 0;
                }
                population[country].Add(city, cityPopulation); 
                countryPopulation[country] += cityPopulation;
            }
            var orderedCountryStats = countryPopulation.OrderByDescending(x => x.Value);
            foreach (var countryStats in orderedCountryStats)
            {
                // country & population in desc.order
                Console.WriteLine("{0} (total population: {1})", countryStats.Key, countryStats.Value); 
                // city & population in desc.order
                var orderedCityStats = population[countryStats.Key].OrderByDescending(x => x.Value);
                foreach (var cityStats in orderedCityStats)
                    Console.WriteLine("=>{0}: {1}", cityStats.Key, cityStats.Value);
            }
        }
    }
}
