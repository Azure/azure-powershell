// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0
//
// ----------------------------------------------------------------------------------

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSExpressRouteLinkFailoverRouteList : PSChildResource
    {
        public List<PSExpressRouteLinkFailoverRoute> BeforeSimulation { get; set; }

        public List<PSExpressRouteLinkFailoverRoute> DuringSimulation { get; set; }

        [JsonIgnore]
        public string BeforeSimulationText => JsonConvert.SerializeObject(BeforeSimulation, Formatting.Indented);

        [JsonIgnore]
        public string DuringSimulationText => JsonConvert.SerializeObject(DuringSimulation, Formatting.Indented);
    }
}