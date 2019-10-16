//-----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Refer to the class documentation.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Maintenance.Models;

namespace Microsoft.Azure.Commands.Maintenance.Models
{
    public partial class PSMaintenanceConfiguration
    {
        public string Location { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        public string NamespaceProperty { get; set; }
        public IDictionary<string, string> ExtensionProperties { get; set; }
        public string MaintenanceScope { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

    }
}
