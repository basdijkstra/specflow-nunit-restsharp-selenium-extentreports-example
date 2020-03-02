using AutomationExample.DataEntities;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using TechTalk.SpecFlow;

namespace AutomationExample.StepDefinitions
{
    [Binding]
    public class ZipCodeRequestSteps
    {
        private RestClient client;
        private RestRequest request;
        private LocationResponse locationResponse;

        [Given(@"(.*) wants to learn the places associated with (.*) zip code (.*)")]
        public void GivenAliceWantsToLearnThePlacesAssociatedWithUsZipCode(string firstName, string countryCode, string zipCode)
        {
            client = new RestClient("http://api.zippopotam.us");
            request = new RestRequest($"{countryCode}/{zipCode}", Method.GET);
        }
        
        [When(@"she consults the Zippopotam\.us API")]
        public void WhenSheConsultsTheZippopotam_UsAPI()
        {
            IRestResponse response = client.Execute(request);
            locationResponse = new JsonDeserializer().Deserialize<LocationResponse>(response);
        }
        
        [Then(@"she learns that the associated place name is (.*)")]
        public void ThenSheLearnsThatTheAssociatedPlaceNameIs(string expectedPlaceName)
        {
            Assert.That(locationResponse.Places[0].PlaceName, Is.EqualTo(expectedPlaceName));
        }
    }
}
