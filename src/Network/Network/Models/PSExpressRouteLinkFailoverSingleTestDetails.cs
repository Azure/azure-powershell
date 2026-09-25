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
    public class PSExpressRouteLinkFailoverSingleTestDetails : PSChildResource
    {
        public string StartTimeUTC { get; set; }

        public string EndTimeUTC { get; set; }

        public string Status { get; set; }

        public bool WasSimulationSuccessful { get; set; }

        public string LinkType { get; set; }

        public string CircuitTestCategory { get; set; }

        public bool IsSimulationVerified { get; set; }

        public PSExpressRouteLinkFailoverRouteList RedundantRoutes { get; set; }

        public PSExpressRouteLinkFailoverRouteList NonRedundantRoutes { get; set; }

        public List<PSExpressRouteLinkFailoverTestBgpStatus> BgpStatus { get; set; }

        [JsonIgnore]
        public string BgpStatusText => JsonConvert.SerializeObject(BgpStatus, Formatting.Indented);
    }
}

    