// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.GeoJson;
using Azure.Maps.Weather;

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetTropicalStormLocationsOptions
    {
        /// <summary> Year of the cyclone(s). </summary>
        public int Year { get; set; }
        /// <summary> Basin identifier. Allowed values: "AL" | "EP" | "SI" | "NI" | "CP" | "NP" | "SP". </summary>
        public string BasinId { get; set; }
        /// <summary> Government storm Id. </summary>
        public int GovernmentStormId { get; set; }
        /// <summary> When true, wind radii summary data is included in the response. </summary>
        public bool? IncludeDetails { get; set; }
        /// <summary> When true, wind radii summary data and geoJSON details are included in the response. </summary>
        public bool? IncludeGeometricDetails { get; set; }
        /// <summary> Specifies to return the data in either metric units or imperial units. </summary>
        public WeatherDataUnit? Unit { get; set; }
        /// <summary> When true, return the current storm location. </summary>
        public bool? IncludeCurrentStorm { get; set; }
    }
}