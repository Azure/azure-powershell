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
    public partial class PSGatewayRouteSetsInformation : PSTopLevelResource
    {
        [JsonProperty(Order = 1)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string LastComputedTime { get; set; }

        [JsonProperty(Order = 2)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string NextEligibleComputeTime { get; set; }

        [JsonProperty(Order = 3)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string RouteSetVersion { get; set; }

        public List<PSGatewayRouteSet> RouteSets { get; set; }

        public Dictionary<string, PSCircuitMetadataMap> CircuitsMetadataMap { get; set; }

        [JsonIgnore]
        public string RouteSetsText =>
            JsonConvert.SerializeObject(RouteSets, Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        [JsonIgnore]
        public string CircuitsMetadataMapText =>
            JsonConvert.SerializeObject(CircuitsMetadataMap, Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    }
}
