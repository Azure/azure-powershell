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
    public class PSExpressRouteFailoverTestDetails : PSChildResource
    {
        public string PeeringLocation { get; set; }

        public string Status { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string TestType { get; set; }

        public string TestGuid { get; set; }

        public List<PSExpressRouteFailoverCircuitResourceDetails> Circuits { get; set; }

        public List<PSExpressRouteFailoverConnectionResourceDetails> Connections { get; set; }

        public List<string> Issues { get; set; }

        [JsonIgnore]
        public string CircuitsText => JsonConvert.SerializeObject(Circuits, Formatting.Indented);

        [JsonIgnore]
        public string ConnectionsText => JsonConvert.SerializeObject(Connections, Formatting.Indented);

        [JsonIgnore]
        public string IssuesText => JsonConvert.SerializeObject(Issues, Formatting.Indented);
    }
}
