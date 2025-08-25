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
    public partial class PSExpressRouteFailoverAllTestDetails : PSTopLevelResource
    {
        public List<PSExpressRouteFailoverTestDetails> TestDetails { get; set; }

        [JsonIgnore]
        public string TestDetailsText => JsonConvert.SerializeObject(TestDetails, Formatting.Indented);
    }
}
