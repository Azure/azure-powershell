// ------------------------------------------------------------------------------------------------
// <copyright file="PrivateDnsUtils.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.PrivateDns.Utilities
{
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    internal class PrivateDnsUtils
    {
        public static void GetResourceGroupNameAndZoneNameFromResourceId(
            string resourceId,
            out string resourceGroupName,
            out string zoneName)
        {
            var identifier = new ResourceIdentifier(resourceId);
            resourceGroupName = identifier.ResourceGroupName;
            zoneName = identifier.ResourceName;
        }

        public static void GetResourceGroupNameFromResourceId(
            string resourceId,
            out string resourceGroupName)
        {
            var identifier = new ResourceIdentifier(resourceId);
            resourceGroupName = identifier.ResourceGroupName;
        }

        public static void GetResourceGroupNameZoneNameAndLinkNameFromLinkId(
            string resourceId,
            out string resourceGroupName,
            out string zoneName,
            out string linkName)
        {
            var identifier = new ResourceIdentifier(resourceId);
            resourceGroupName = identifier.ResourceGroupName;
            linkName = identifier.ResourceName;
            zoneName = identifier.ParentResource.Split('/').Last();
        }
    }
}
