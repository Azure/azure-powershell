﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json;

namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    public partial class StatusCodeCount
    {
        public override string ToString()
        {
            return this.ToJsonString();
        }
    }
}
