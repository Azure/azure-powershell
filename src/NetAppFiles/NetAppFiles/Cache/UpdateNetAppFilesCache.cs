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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.Cache
{
    [Cmdlet(
        VerbsData.Update,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesCache",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesCache))]
    [Alias("Update-AnfCache")]
    public class UpdateAzureRmNetAppFilesCache : AzureNetAppFilesCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.NetApp/netAppAccounts", nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF capacity pool")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.NetApp/netAppAccounts/capacityPools", nameof(ResourceGroupName), nameof(AccountName))]
        public string PoolName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF cache")]
        [ValidateNotNullOrEmpty]
        [Alias("CacheName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/caches",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName))]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The resource id of the ANF cache")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The cache object to update")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesCache InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Maximum storage quota for the file system in bytes")]
        public long? Size { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Set of supported protocol types")]
        public string[] ProtocolType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Export policy for the cache")]
        public PSNetAppFilesVolumeExportPolicy ExportPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Maximum throughput in MiB/s for manual qos cache")]
        public double? ThroughputMibps { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Resource ID of the private endpoint for KeyVault")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultPrivateEndpointResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether CIFS change notifications are enabled")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string CifsChangeNotification { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether writeback is enabled for the cache")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string WriteBack { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enables encryption for in-flight SMB3 data")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string SmbEncryption { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enables access-based enumeration for SMB shares")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string SmbAccessBasedEnumeration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enables non-browsable property for SMB shares")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string SmbNonBrowsable { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A hashtable representing resource tags")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                PoolName = parentResources[3];
                Name = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                var nameParts = ResourceIdHelpers.NamePartsFromId(InputObject.Id);
                AccountName = nameParts[0];
                PoolName = nameParts[1];
                Name = nameParts[2];
            }

            var smbSettings = BuildSmbSettings();

            var props = new CacheUpdateProperties
            {
                Size = Size,
                ProtocolTypes = ProtocolType?.ToList(),
                ExportPolicy = CacheExtensions.ConvertExportPolicyFromPs(ExportPolicy),
                SmbSettings = smbSettings,
                ThroughputMibps = ThroughputMibps,
                KeyVaultPrivateEndpointResourceId = KeyVaultPrivateEndpointResourceId,
                CifsChangeNotifications = CifsChangeNotification,
                WriteBack = WriteBack
            };

            var patch = new CacheUpdate
            {
                Tags = Tag != null ? TagsConversionHelper.CreateTagDictionary(Tag, validate: true) : null,
                Properties = props
            };

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.UpdateResourceMessage, Name)))
            {
                try
                {
                    var anfCache = AzureNetAppFilesManagementClient.Caches.Update(ResourceGroupName, AccountName, PoolName, Name, patch);
                    WriteObject(anfCache.ConvertToPs());
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }
        }

        private SmbSettings BuildSmbSettings()
        {
            if (string.IsNullOrEmpty(SmbEncryption) && string.IsNullOrEmpty(SmbAccessBasedEnumeration) && string.IsNullOrEmpty(SmbNonBrowsable))
            {
                return null;
            }
            return new SmbSettings(SmbEncryption, SmbAccessBasedEnumeration, SmbNonBrowsable);
        }
    }
}
