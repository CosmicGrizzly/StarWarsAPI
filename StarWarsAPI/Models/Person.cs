using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsAPI.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public string HomePlanet { get; set; }

        public Person(string APIText)
        {
            JObject starData = JObject.Parse(APIText);
            JObject speciesData = JObject.Parse(StarWarsDAL.GetData(starData["species"][0].ToString()));
            JObject planetData = JObject.Parse(StarWarsDAL.GetData(starData["homeworld"].ToString()));
            Name = starData["name"].ToString();
            Species = speciesData["name"].ToString();
            Gender = starData["gender"].ToString();
            HomePlanet = planetData["name"].ToString();
        }
    }
}