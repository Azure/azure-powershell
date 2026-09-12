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
    public class PSExpressRouteLinkFailoverTestBgpStatus : PSChildResource
    {
        public string Type { get; set; }

        public string Link { get; set; }

        public string Status { get; set; }

        public string CheckTimeUtc { get; set; }
    }
}
