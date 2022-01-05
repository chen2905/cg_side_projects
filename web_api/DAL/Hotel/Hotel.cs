using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

public class Hotel
    {
    [JsonProperty("HotelID")]
    public int HotelID { get; set; }
    [JsonProperty("HotelName")]
    public string HotelName { get; set; }
    [JsonProperty("City")]
    public string City { get; set; }
    [JsonProperty("Stars")]
    public double Stars { get; set; }
    [JsonProperty("HotelStatus")]
    public int HotelStatus { get; set; }
    [JsonProperty("Rating")]
    public string Rating { get; set; }
    [JsonProperty("Allotment")]
    public string Allotment { get; set; }
    [JsonProperty("xCountryID")]
    public int xCountryID { get; set; }
    [JsonProperty("RegionName")]
    public string RegionName { get; set; }
    [JsonProperty("DistanceFromCenter")]
    public double DistanceFromCenter { get; set; }
    [JsonProperty("HotelImagePath")]
    public string HotelImagePath { get; set; }
    [JsonProperty("Lat")]
    public string Lat { get; set; }
    [JsonProperty("Lng")]
    public string Lng { get; set; }
    [JsonProperty("HotelOrder")]
    public int HotelOrder { get; set; }
    [JsonProperty("TotalRows")]
    public int TotalRows { get; set; }
    }
