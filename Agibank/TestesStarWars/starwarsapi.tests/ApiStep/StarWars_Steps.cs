using Newtonsoft.Json;
using NUnit.Framework;
using starwarsapi.tests.ApiClass;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace starwarsapi.tests.ApiStep
{
    [Binding]
    public class StarWars_Steps
    {
        private readonly HttpClient _httpClient;
        private RetornoPeople RetornoPeople;
        private RetornoPlanets RetornoPlanets;
        private RetornoSpecies RetornoSpecies;
        private RetornoStarships RetornoStarships;
        public StarWars_Steps()
        {
            _httpClient = new HttpClient();
        }

        [When(@"passo o id da pessoa '(.*)'")]
        public async Task People(int id)
        {
            _httpClient.BaseAddress = new Uri("https://swapi.co/api/");
            string result = await _httpClient.GetStringAsync($"people/{id}");

            RetornoPeople = JsonConvert.DeserializeObject<RetornoPeople>(result);
        }

        [Then(@"recebo o nome da pessoa '(.*)'")]
        public async Task People(string nome)
        {
            Assert.AreEqual(nome, RetornoPeople.name);
        }

        [When(@"passo o id do planeta '(.*)'")]
        public async Task Planets(int id)
        {
            _httpClient.BaseAddress = new Uri("https://swapi.co/api/");
            string result = await _httpClient.GetStringAsync($"planets/{id}");

            RetornoPlanets = JsonConvert.DeserializeObject<RetornoPlanets>(result);
        }

        [Then(@"recebo o nome do planeta '(.*)'")]
        public async Task Planets(string nome)
        {
            Assert.AreEqual(nome, RetornoPlanets.name);
        }

        [When(@"passo o id da especie '(.*)'")]
        public async Task Species(int id)
        {
            _httpClient.BaseAddress = new Uri("https://swapi.co/api/");
            string result = await _httpClient.GetStringAsync($"species/{id}");

            RetornoSpecies = JsonConvert.DeserializeObject<RetornoSpecies>(result);
        }

        [Then(@"recebo o nome da especie '(.*)'")]
        public async Task Species(string nome)
        {
            Assert.AreEqual(nome, RetornoSpecies.name);
        }

        [When(@"passo o id do starships '(.*)'")]
        public async Task Starships(int id)
        {
            _httpClient.BaseAddress = new Uri("https://swapi.co/api/");
            string result = await _httpClient.GetStringAsync($"starships/{id}");

            RetornoStarships = JsonConvert.DeserializeObject<RetornoStarships>(result);
        }

        [Then(@"recebo o nome do starships '(.*)'")]
        public async Task Starships(string nome)
        {
            Assert.AreEqual(nome, RetornoStarships.name);
        }
    }
}
