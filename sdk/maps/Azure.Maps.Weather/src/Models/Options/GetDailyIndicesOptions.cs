// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.GeoJson;
using Azure.Maps.Weather;

namespace Azure.Maps.Weather.Models.Options
{
    /// <summary> Options. </summary>
    public class GetDailyIndicesOptions
    {
        /// <summary> Specifies the coordinates. </summary>
        public GeoPosition Coordinates { get; set; }
        /// <summary> Specifies the language code in which the timezone names should be returned. Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> </summary>
        public WeatherLanguage Language { get; set; }
        /// <summary> Specifies for how long the responses are returned. </summary>
        public int? Duration { get; set; }
        /// <summary> Numeric index identifier that can be used for restricting returned results to the corresponding index type. Cannot be paired with `indexGroupId`. Please refer to [Weather services in Azure Maps](/azure/azure-maps/weather-services-concepts#index-ids-and-index-groups-ids) for details and to see the supported indices. </summary>
        public int? IndexId { get; set; }
        /// <summary> Numeric index group identifier that can be used for restricting returned results to the corresponding subset of indices (index group). Cannot be paired with `indexId`. Please refer to [Weather services in Azure Maps](/azure/azure-maps/weather-services-concepts#index-ids-and-index-groups-ids) for details and to see the supported index groups. </summary>
        public int? IndexGroupId { get; set; }
    }
}