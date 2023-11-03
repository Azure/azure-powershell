using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json;

namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904
{
    public partial class CloudService
    {
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 0)]
        public string ResourceGroupName
        { 
            get {
                var _match = new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.Compute/cloudServices/(?<cloudServiceName>[^/]+)$").Match(this.Id);
                if (!_match.Success) {
                    return null;
                }
                return _match.Groups["resourceGroupName"].Value;
            }
        }
    }

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
