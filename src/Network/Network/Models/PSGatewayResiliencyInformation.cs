// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSGatewayResiliencyInformation : PSTopLevelResource
    {
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string OverallScore { get; set; }

        [JsonProperty(Order = 2)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string ScoreChange { get; set; }

        public string MinScoreFromRecommendations { get; set; }

        public string MaxScoreFromRecommendations { get; set; }

        public string LastComputedTime { get; set; }

        public string NextEligibleComputeTime { get; set; }

        // Component list is included in the response
        public List<PSResiliencyRecommendationComponents> Components { get; set; }

        // Removed optional properties not in the response
        // public PSCircuitMetadataMap CircuitMetadata { get; set; }
        // public List<string> PrimaryConnectionIds { get; set; }
        // public List<string> SecondaryConnectionIds { get; set; }

        [JsonIgnore]
        public string ComponentsText =>
            JsonConvert.SerializeObject(Components, Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    }
}
