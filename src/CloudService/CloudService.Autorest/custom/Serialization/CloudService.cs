using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json;

namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models
{
    /// <summary>
    /// Adds the [-ResourceGroupName] property to the ICloudService interface.
    /// This property is required by the Get/New/Update-AzCloudService cmdlets for output,
    /// but was missing in the generated ICloudService.cs file.
    /// </summary>
    public partial interface ICloudService
    {
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ResourceGroupName",
        SerializedName = @"ResourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGroupName { get; }
    }
}