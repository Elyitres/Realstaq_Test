using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Realstaq.Models
{
    public class RealEstate
    {
        public List<House> Houses { get; set; }
    }

    public class House
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("mls_id")]
        public int MlsId { get; set; }

        [JsonProperty("mls_listing_id")]
        public string MlsListingId { get; set; }

        [JsonProperty("property_type")]
        public string PropertyType { get; set; }

        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("location")]
        public List<double> Location { get; set; }

        [JsonProperty("bedrooms")]
        public int? Bedrooms { get; set; }

        [JsonProperty("bathrooms")]
        public int Bathrooms { get; set; }

        [JsonProperty("list_date")]
        public DateTime ListDate { get; set; }

        [JsonProperty("mls_update_date")]
        public DateTime MlsUpdateDate { get; set; }

        [JsonProperty("price_display")]
        public string PriceDisplay { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("square_feet")]
        public int? SquareFeet { get; set; }

        [JsonProperty("hero")]
        public Hero Hero { get; set; }

    }

}
