// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0
//
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSExpressRouteFailoverCircuitResourceDetails : PSChildResource
    {
        public string NrpResourceUri { get; set; }

        public new string Name { get; set; }

        public string ConnectionName { get; set; }
    }
}
