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
    public class PSExpressRouteFailoverSingleTestDetailsObject : PSTopLevelResource
    {
        public List<PSExpressRouteFailoverSingleTestDetails> TestDetails { get; set; }

        [JsonIgnore]
        public string TestDetailsText => JsonConvert.SerializeObject(TestDetails, Formatting.Indented);
    }
}
