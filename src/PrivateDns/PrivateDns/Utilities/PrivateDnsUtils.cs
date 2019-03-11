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
        public const string ARecord = "A";
        public const string AaaaRecord = "AAAA";
        public const string SrvRecord = "SRV";
        public const string TxtRecord = "TXT";
        public const string CnameRecord = "CNAME";
        public const string MxRecord = "MX";
        public const string PtrRecord = "PTR";

        public static void GetResourceGroupNameAndZoneNameFromResourceId(
            string resourceId,
            out string resourceGroupName,
            out string zoneName)
        {
            var identifier = new ResourceIdentifier(resourceId);
            resourceGroupName = identifier.ResourceGroupName;
            zoneName = identifier.ResourceName;
        }

        public static void GetResourceGroupNameZoneNameRecordNameAndRecordTypeFromResourceId(
            string resourceId,
            out string resourceGroupName,
            out string zoneName,
            out string recordName,
            out string recordType)
        {
            var identifier = new ResourceIdentifier(resourceId);
            resourceGroupName = identifier.ResourceGroupName;
            recordName = identifier.ResourceName;
            zoneName = identifier.ParentResource.Split('/').Last();
            recordType = identifier.ResourceType.Split('/').Last();
        }

        public static void GetResourceGroupNameFromResourceId(
            string resourceId,
            out string resourceGroupName)
        {
            var identifier = new ResourceIdentifier(resourceId);
            resourceGroupName = identifier.ResourceGroupName;
        }

        public static void ParseVirtualNetworkId(
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
