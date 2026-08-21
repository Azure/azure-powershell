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
    public class PSExpressRouteLinkFailoverAllTestsDetails : PSChildResource
    {
        public string Status { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string TestGuid { get; set; }

        public string TestType { get; set; }

        public List<string> Issues { get; set; }

        public bool WasSimulationSuccessful { get; set; }

        public string CircuitTestCategory { get; set; }

        public string LinkType { get; set; }

        public List<PSExpressRouteLinkFailoverTestBgpStatus> BgpStatus { get; set; }

        [JsonIgnore]
        public string IssuesText => JsonConvert.SerializeObject(Issues, Formatting.Indented);

        [JsonIgnore]
        public string BgpStatusText => JsonConvert.SerializeObject(BgpStatus, Formatting.Indented);
    }
}