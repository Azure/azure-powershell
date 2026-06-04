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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// PowerShell representation of an Azure NetApp Files Cache resource.
    /// </summary>
    public class PSNetAppFilesCache
    {
        public string ResourceGroupName { get; set; }

        public string Location { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public IList<string> Zones { get; set; }

        public string Etag { get; set; }

        public PSSystemData SystemData { get; set; }

        // Cache properties
        public string FilePath { get; set; }

        public long Size { get; set; }

        public PSNetAppFilesVolumeExportPolicy ExportPolicy { get; set; }

        public IList<string> ProtocolTypes { get; set; }

        public string ProvisioningState { get; set; }

        public string CacheState { get; set; }

        public string CacheSubnetResourceId { get; set; }

        public string PeeringSubnetResourceId { get; set; }

        public IList<PSNetAppFilesCacheMountTarget> MountTargets { get; set; }

        public string Kerberos { get; set; }

        public PSNetAppFilesCacheSmbSettings SmbSettings { get; set; }

        public double? ThroughputMibps { get; set; }

        public double? ActualThroughputMibps { get; set; }

        public string EncryptionKeySource { get; set; }

        public string KeyVaultPrivateEndpointResourceId { get; set; }

        public long? MaximumNumberOfFiles { get; set; }

        public string Encryption { get; set; }

        public string Language { get; set; }

        public string Ldap { get; set; }

        public string LdapServerType { get; set; }

        public PSNetAppFilesCacheOriginClusterInformation OriginClusterInformation { get; set; }

        public string CifsChangeNotifications { get; set; }

        public string GlobalFileLocking { get; set; }

        public string WriteBack { get; set; }
    }
}
