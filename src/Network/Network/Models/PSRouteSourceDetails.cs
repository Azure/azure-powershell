// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
//
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSRouteSourceDetails : PSChildResource
    {
        public string Circuit { get; set; }

        public string Pri { get; set; }

        public string Sec { get; set; }
    }
}
