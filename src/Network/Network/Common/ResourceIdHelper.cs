using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Network.Common
{
  internal static class ResourceIdHelper
  {
    private static readonly Regex SubnetResourceIdRegEx = new Regex("/subscriptions/(?<SubscriptionId>[0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})/resourceGroups/(?<ResourceGroupName>[\\w|\\.|_|\\-|\\(|\\)]{1,90})/providers/Microsoft\\.Network/virtualNetworks/(?<VirtualNetworkName>[a-z0-9][\\w|\\.|\\-]{0,62}\\w)/subnets/(?<SubnetName>.+)", RegexOptions.IgnoreCase);

    internal static bool TryParseSubnetMetadataFromResourceId(string resourceId, out string resourceGroupName, out string virtualNetworkName, out string subnetName) {
      var match = SubnetResourceIdRegEx.Match(resourceId);
      if (match.Success) {
        resourceGroupName = match.Groups["ResourceGroupName"].Value;
        virtualNetworkName = match.Groups["VirtualNetworkName"].Value;
        subnetName = match.Groups["SubnetName"].Value;

        return true;
      }

      resourceGroupName = null;
      virtualNetworkName = null;
      subnetName = null;

      return false;
    }
  }
}
