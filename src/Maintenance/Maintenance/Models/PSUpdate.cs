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
    public partial class PSUpdate
    {
        public string MaintenanceScope { get; set; }
        public string ImpactType { get; set; }
        public string Status { get; set; }
        public int? ImpactDurationInSec { get; set; }
        public DateTime? NotBefore { get; set; }
        public string ResourceId { get; set; }

    }
}
