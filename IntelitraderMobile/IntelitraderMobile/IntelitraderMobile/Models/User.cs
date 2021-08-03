using System;
using System.Text.Json.Serialization;

namespace IntelitraderMobile.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public Guid id { get; set; }

        [JsonPropertyName("firstName")]
        public string firstName { get; set; }

        [JsonPropertyName("surName")]
        public string surName { get; set; }

        [JsonPropertyName("age")]
        public int age { get; set; }
    }
}