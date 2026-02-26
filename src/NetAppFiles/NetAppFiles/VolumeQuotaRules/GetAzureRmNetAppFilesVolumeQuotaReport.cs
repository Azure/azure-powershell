// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using System;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.Volume
{
    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesVolumeQuotaReport",
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesListQuotaReportResponse))]
    [Alias("Get-AnfVolumeQuotaReport")]
    public class GetAzureRmNetAppFilesVolumeQuotaReport: AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF volume")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts",
            nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF pool")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string PoolName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF volume")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParentObjectParameterSet,
            HelpMessage = "The name of the ANF volume")]
        [ValidateNotNullOrEmpty]
        [Alias("VolumeName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/volumes",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName))]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "Type of quota. If provided, QuotaTarget must also be specified. Possible values include: 'DefaultUserQuota', 'DefaultGroupQuota', 'IndividualUserQuota', 'IndividualGroupQuota'")]
        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = false,
            HelpMessage = "Type of quota. If provided, QuotaTarget must also be specified. Possible values include: 'DefaultUserQuota', 'DefaultGroupQuota', 'IndividualUserQuota', 'IndividualGroupQuota'")]
        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = false,
            HelpMessage = "Type of quota. If provided, QuotaTarget must also be specified. Possible values include: 'DefaultUserQuota', 'DefaultGroupQuota', 'IndividualUserQuota', 'IndividualGroupQuota'")]
        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = false,
            HelpMessage = "Type of quota. If provided, QuotaTarget must also be specified. Possible values include: 'DefaultUserQuota', 'DefaultGroupQuota', 'IndividualUserQuota', 'IndividualGroupQuota'")]
        [PSArgumentCompleter("DefaultUserQuota", "DefaultGroupQuota", "IndividualUserQuota", "IndividualGroupQuota")]
        public string QuotaType { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "UserID/GroupID/SID based on the quota target type. If provided, QuotaType must also be specified.")]
        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = false,
            HelpMessage = "UserID/GroupID/SID based on the quota target type. If provided, QuotaType must also be specified.")]
        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = false,
            HelpMessage = "UserID/GroupID/SID based on the quota target type. If provided, QuotaType must also be specified.")]
        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = false,
            HelpMessage = "UserID/GroupID/SID based on the quota target type. If provided, QuotaType must also be specified.")]
        public string QuotaTarget { get; set; }

        [Parameter(
            ParameterSetName = FieldsParameterSet,
            Mandatory = false,
            HelpMessage = "Returns records where the usage is greater than or equal to this percentage value (1-100).")]
        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = false,
            HelpMessage = "Returns records where the usage is greater than or equal to this percentage value (1-100).")]
        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = false,
            HelpMessage = "Returns records where the usage is greater than or equal to this percentage value (1-100).")]
        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = false,
            HelpMessage = "Returns records where the usage is greater than or equal to this percentage value (1-100).")]
        [ValidateRange(1, 100)]
        public int? UsageThresholdPercentage { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The resource id of the ANF volume")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = ParentObjectParameterSet,
            HelpMessage = "The pool object containing the volume to return the quota report for")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesPool PoolObject { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The volume object to return the quota report for")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolume InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                PoolName = parentResources[3];
                Name = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                var NameParts = InputObject.Name.Split('/');
                AccountName = NameParts[0];
                PoolName = NameParts[1];
                Name = NameParts[2];
            }
            else if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = PoolObject.ResourceGroupName;
                var NameParts = PoolObject.Name.Split('/');
                AccountName = NameParts[0];
                PoolName = NameParts[1];
            }

            Management.NetApp.Models.Volume existingVolume = null;
            try
            {
                existingVolume = AzureNetAppFilesManagementClient.Volumes.Get(ResourceGroupName, AccountName, PoolName, Name);
            }
            catch
            {
                existingVolume = null;
            }
            if (existingVolume == null)
            {
                throw new AzPSResourceNotFoundCloudException($"A Volume with name '{this.Name}' in resource group '{this.ResourceGroupName}' does not exist. Please use New-AzNetAppFilesVolume to create a new Volume.");
            }

            // Validate that QuotaType and QuotaTarget are supplied together
            if (!string.IsNullOrEmpty(QuotaType) ^ !string.IsNullOrEmpty(QuotaTarget))
            {
                throw new AzPSArgumentException("Both QuotaType and QuotaTarget must be provided together.", string.IsNullOrEmpty(QuotaType) ? nameof(QuotaType) : nameof(QuotaTarget));
            }

            QuotaReportFilterRequest body = null;
            if (!string.IsNullOrEmpty(QuotaType) || !string.IsNullOrEmpty(QuotaTarget) || UsageThresholdPercentage.HasValue)
            {
                body = new QuotaReportFilterRequest(
                    quotaType: QuotaType,
                    quotaTarget: QuotaTarget,
                    usageThresholdPercentage: UsageThresholdPercentage);
            }

            try
            {
                ListQuotaReportResult anfQuotaReport = AzureNetAppFilesManagementClient.Volumes.ListQuotaReport(ResourceGroupName, AccountName, PoolName, Name, body);
                WriteObject(anfQuotaReport.ConvertToPs());
            }
            catch (ErrorResponseException erx)
            {
                throw new CloudException(erx.Message + " : " + erx.Body.Error.Code + " : " + erx.Body.Error.Message, erx);
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }
    }
}
