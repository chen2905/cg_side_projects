using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for HotelImage
/// </summary>
public class HotelImage
    {

    [JsonProperty("ImageA")]
    public string ImageA { get; set; }

    [JsonProperty("ImageB")]
    public string ImageB { get; set; }

    [JsonProperty("ImageC")]
    public string ImageC { get; set; }

    [JsonProperty("ImageD")]
    public string ImageD { get; set; }

    [JsonProperty("ImageASecure")]
    public string ImageASecure { get; set; }

    [JsonProperty("ImageBSecure")]
    public string ImageBSecure { get; set; }

    [JsonProperty("ImageCSecure")]
    public string ImageCSecure { get; set; }

    [JsonProperty("ImageDSecure")]
    public string ImageDSecure { get; set; }

    }