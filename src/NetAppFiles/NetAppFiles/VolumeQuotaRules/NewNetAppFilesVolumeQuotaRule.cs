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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.NetAppFiles.Backup
{
    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesVolumeQuotaRule",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesBackup))]
    [Alias("New-AnfVolumeQuotaRule")]
    [CmdletPreview(PreviewMessage)]
    public class NewAzureRmNetAppFilesVolumeQuotaRule: AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/netAppAccounts/capacityPools/volumes/volumequotarules")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccount",
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
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/volumes",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName))]
        public string VolumeName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF QuotaRule")]
        [ValidateNotNullOrEmpty]
        [Alias("VolumeQuotaRuleName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/volumes/volumequotarules",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName),
            nameof(VolumeName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags")]
        [ValidateNotNullOrEmpty]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = true,            
            HelpMessage = "Size of quota in KiBs")]
        [ValidateNotNullOrEmpty]
        public int QuotaSize { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Type of quota")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("DefaultUserQuota", "DefaultGroupQuota", "IndividualUserQuota", "IndividualGroupQuota")]
        public string QuotaType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "UserID/GroupID/SID based on the quota target type. UserID and groupID can be found by running ‘id’ or ‘getent’ command for the user or group and SID can be found by running <wmic useraccount where name='user-name' get sid>")]
        [ValidateNotNullOrEmpty]
        public string QuotaTarget { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The volume for the new VolumeQuotaRule object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolume VolumeObject { get; set; }

        public override void ExecuteCmdlet()
        {
            IDictionary<string, string> tagPairs = null;
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = VolumeObject.ResourceGroupName;
                Location = VolumeObject.Location;
                var NameParts = VolumeObject.Name.Split('/');
                AccountName = NameParts[0];
                PoolName = NameParts[1];
                VolumeName = NameParts[2];
            }
            if (Tag != null)
            {
                tagPairs = new Dictionary<string, string>();

                foreach (string key in Tag.Keys)
                {
                    tagPairs.Add(key, Tag[key].ToString());
                }
            }

            var volumeQuotaRuleBody = new Management.NetApp.Models.VolumeQuotaRule()
            {
                Location = Location,
                QuotaSizeInKiBs = QuotaSize,
                QuotaTarget = QuotaTarget ?? "",
                QuotaType = QuotaType,
                Tags = tagPairs
            };

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, Name)))
            {
                var anfVolumeQuotaRule = AzureNetAppFilesManagementClient.VolumeQuotaRules.Create(volumeQuotaRuleBody, ResourceGroupName, AccountName, poolName: PoolName, volumeName: VolumeName, volumeQuotaRuleName: Name);
                WriteObject(anfVolumeQuotaRule.ConvertToPs());
            }
        }
    }
}
