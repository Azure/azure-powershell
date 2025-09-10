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
    public class PSExpressRouteFailoverStopApiParameters
    {
        public string PeeringLocation { get; set; }

        public bool WasSimulationSuccessful { get; set; }

        public List<PSFailoverConnectionDetails> Detail { get; set; }

        [JsonIgnore]
        public string DetailsText => JsonConvert.SerializeObject(Detail, Formatting.Indented);
    }
}
