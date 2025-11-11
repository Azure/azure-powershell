// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0
//
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSFailoverConnectionDetails
    {
        public string FailoverConnectionName { get; set; }

        public string FailoverLocation { get; set; }

        public bool IsVerified { get; set; }
    }
}
