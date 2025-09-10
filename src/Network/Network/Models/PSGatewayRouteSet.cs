// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
//
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSGatewayRouteSet : PSChildResource
    {
        public new string Name { get; set; }

        public List<string> Locations { get; set; }

        public Dictionary<string, List<PSRouteSourceDetails>> Detail { get; set; }

        [JsonIgnore]
        public string LocationsText => JsonConvert.SerializeObject(Locations, Formatting.Indented);

        [JsonIgnore]
        public string DetailsText => JsonConvert.SerializeObject(Detail, Formatting.Indented);
    }
}
