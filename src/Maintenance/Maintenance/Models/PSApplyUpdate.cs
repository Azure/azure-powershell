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
    public partial class PSApplyUpdate
    {
        public string Status { get; set; }
        public string ResourceId { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

    }
}
