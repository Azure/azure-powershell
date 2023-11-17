using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json;

namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904
{
    public partial class ResourceInstanceViewStatus
    {
        public override string ToString()
        {
            return this.DisplayStatus;
        }
    }
}
