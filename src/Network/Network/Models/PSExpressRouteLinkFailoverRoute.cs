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
    public class PSExpressRouteLinkFailoverRoute : PSChildResource
    {
        public string Route { get; set; }

        public string NextHop { get; set; }

        public string PrimaryASPath { get; set; }

        public string SecondaryASPath { get; set; }
    }
}