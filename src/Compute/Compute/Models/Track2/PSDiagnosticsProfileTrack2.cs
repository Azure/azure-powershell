// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Commands.Compute.Models.Track2
{
    // Boot Diagnostics - exposed directly in VirtualMachineData
    public class PSBootDiagnostics
    {
        public bool? Enabled { get; set; }
        public string StorageUri { get; set; }
    }
}