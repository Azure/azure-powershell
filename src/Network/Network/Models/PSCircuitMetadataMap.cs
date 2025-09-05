// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
//
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSCircuitMetadataMap : PSChildResource
    {
        public new string Name { get; set; }

        public string Link { get; set; }

        public string Location { get; set; }
    }
}
