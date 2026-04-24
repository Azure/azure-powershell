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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.Cache
{
    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesCache",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesCache))]
    [Alias("New-AnfCache")]
    public class NewAzureRmNetAppFilesCache : AzureNetAppFilesCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/netAppAccounts/capacityPools/caches")]
        public string Location { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.NetApp/netAppAccounts", nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF capacity pool")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.NetApp/netAppAccounts/capacityPools", nameof(ResourceGroupName), nameof(AccountName))]
        public string PoolName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the ANF cache")]
        [ValidateNotNullOrEmpty]
        [Alias("CacheName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The file path of the cache")]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Maximum storage quota allowed for the file system in bytes (50 GiB to 1 PiB)")]
        public long Size { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Azure Resource URI for a delegated cache subnet that will be used to allocate data IPs")]
        [ValidateNotNullOrEmpty]
        public string CacheSubnetResourceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Azure Resource URI for a delegated subnet that will be used for ANF Intercluster Interface IP addresses")]
        [ValidateNotNullOrEmpty]
        public string PeeringSubnetResourceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Source of the encryption key. Either 'Microsoft.NetApp' or 'Microsoft.KeyVault'")]
        [PSArgumentCompleter("Microsoft.NetApp", "Microsoft.KeyVault")]
        public string EncryptionKeySource { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "ONTAP cluster name of external cluster hosting the origin volume")]
        [ValidateNotNullOrEmpty]
        public string OriginPeerClusterName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "ONTAP Intercluster LIF IP addresses; one IP address per cluster node")]
        [ValidateNotNullOrEmpty]
        public string[] OriginPeerAddress { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "External Vserver (SVM) name hosting the origin volume")]
        [ValidateNotNullOrEmpty]
        public string OriginPeerVserverName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "External origin volume name associated to this cache")]
        [ValidateNotNullOrEmpty]
        public string OriginPeerVolumeName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Set of supported protocol types (NFSv3, NFSv4 or SMB)")]
        public string[] ProtocolType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Export policy for the cache")]
        public PSNetAppFilesVolumeExportPolicy ExportPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether Kerberos is enabled for the cache. Either 'Disabled' or 'Enabled'")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string KerberosEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Maximum throughput in MiB/s for manual qos cache")]
        public double? ThroughputMibps { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Resource ID of the private endpoint for KeyVault when EncryptionKeySource is Microsoft.KeyVault")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultPrivateEndpointResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether LDAP is enabled for the flexcache volume. Either 'Disabled' or 'Enabled'")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string Ldap { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Type of LDAP server. Either 'ActiveDirectory' or 'OpenLDAP'")]
        [PSArgumentCompleter("ActiveDirectory", "OpenLDAP")]
        public string LdapServerType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether CIFS change notification is enabled. Either 'Disabled' or 'Enabled'")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string CifsChangeNotification { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether the global file lock is enabled. Either 'Disabled' or 'Enabled'")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string GlobalFileLocking { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether writeback is enabled for the cache. Either 'Disabled' or 'Enabled'")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string WriteBack { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enables encryption for in-flight SMB3 data. Either 'Disabled' or 'Enabled'")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string SmbEncryption { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enables access-based enumeration for SMB shares. Either 'Disabled' or 'Enabled'")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string SmbAccessBasedEnumeration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enables non-browsable property for SMB shares. Either 'Disabled' or 'Enabled'")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string SmbNonBrowsable { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The availability zones for the cache")]
        public string[] Zone { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A hashtable representing resource tags")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(ParameterSetName = ParentObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The pool object for the new cache")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesPool PoolObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = PoolObject.ResourceGroupName;
                Location = PoolObject.Location;
                var nameParts = PoolObject.Name.Split('/');
                AccountName = nameParts[0];
                PoolName = nameParts[1];
            }

            var origin = new OriginClusterInformation(
                peerClusterName: OriginPeerClusterName,
                peerAddresses: OriginPeerAddress?.ToList(),
                peerVserverName: OriginPeerVserverName,
                peerVolumeName: OriginPeerVolumeName);

            var smbSettings = BuildSmbSettings();

            var properties = new CacheProperties(
                filePath: FilePath,
                size: Size,
                cacheSubnetResourceId: CacheSubnetResourceId,
                peeringSubnetResourceId: PeeringSubnetResourceId,
                encryptionKeySource: EncryptionKeySource,
                originClusterInformation: origin)
            {
                ProtocolTypes = ProtocolType?.ToList(),
                ExportPolicy = CacheExtensions.ConvertExportPolicyFromPs(ExportPolicy),
                Kerberos = KerberosEnabled,
                SmbSettings = smbSettings,
                ThroughputMibps = ThroughputMibps,
                KeyVaultPrivateEndpointResourceId = KeyVaultPrivateEndpointResourceId,
                Ldap = Ldap,
                LdapServerType = LdapServerType,
                CifsChangeNotifications = CifsChangeNotification,
                GlobalFileLocking = GlobalFileLocking,
                WriteBack = WriteBack
            };

            var cacheBody = new Management.NetApp.Models.Cache(Location, properties)
            {
                Tags = Tag != null ? TagsConversionHelper.CreateTagDictionary(Tag, validate: true) : null,
                Zones = Zone?.ToList()
            };

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, Name)))
            {
                try
                {
                    var anfCache = AzureNetAppFilesManagementClient.Caches.CreateOrUpdate(ResourceGroupName, AccountName, PoolName, Name, cacheBody);
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
