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
using System.Linq;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.NetApp.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class CacheExtensions
    {
        public static PSNetAppFilesCache ConvertToPs(this Management.NetApp.Models.Cache cache)
        {
            var props = cache.Properties ?? new CacheProperties();
            return new PSNetAppFilesCache
            {
                ResourceGroupName = new ResourceIdentifier(cache.Id).ResourceGroupName,
                Id = cache.Id,
                Name = cache.Name,
                Type = cache.Type,
                Location = cache.Location,
                Tags = cache.Tags,
                Zones = cache.Zones,
                Etag = cache.Etag,
                SystemData = cache.SystemData?.ToPsSystemData(),

                FilePath = props.FilePath,
                Size = props.Size,
                ExportPolicy = ConvertExportPolicyToPs(props.ExportPolicy),
                ProtocolTypes = props.ProtocolTypes,
                ProvisioningState = props.ProvisioningState,
                CacheState = props.CacheState,
                CacheSubnetResourceId = props.CacheSubnetResourceId,
                PeeringSubnetResourceId = props.PeeringSubnetResourceId,
                MountTargets = props.MountTargets,
                Kerberos = props.Kerberos,
                SmbSettings = props.SmbSettings,
                ThroughputMibps = props.ThroughputMibps,
                ActualThroughputMibps = props.ActualThroughputMibps,
                EncryptionKeySource = props.EncryptionKeySource,
                KeyVaultPrivateEndpointResourceId = props.KeyVaultPrivateEndpointResourceId,
                MaximumNumberOfFiles = props.MaximumNumberOfFiles,
                Encryption = props.Encryption,
                Language = props.Language,
                Ldap = props.Ldap,
                LdapServerType = props.LdapServerType,
                OriginClusterInformation = props.OriginClusterInformation,
                CifsChangeNotifications = props.CifsChangeNotifications,
                GlobalFileLocking = props.GlobalFileLocking,
                WriteBack = props.WriteBack,
                FileAccessLogs = props.FileAccessLogs
            };
        }

        public static List<PSNetAppFilesCache> ConvertToPS(this IEnumerable<Management.NetApp.Models.Cache> caches)
        {
            return caches.Select(c => c.ConvertToPs()).ToList();
        }

        public static PSNetAppFilesCachePeeringPassphrase ConvertToPs(this PeeringPassphrases passphrases)
        {
            return new PSNetAppFilesCachePeeringPassphrase
            {
                ClusterPeeringCommand = passphrases.ClusterPeeringCommand,
                ClusterPeeringPassphrase = passphrases.ClusterPeeringPassphrase,
                VserverPeeringCommand = passphrases.VserverPeeringCommand,
                CriticalWarning = passphrases.CriticalWarning
            };
        }

        public static CachePropertiesExportPolicy ConvertExportPolicyFromPs(PSNetAppFilesVolumeExportPolicy psExportPolicy)
        {
            if (psExportPolicy == null || psExportPolicy.Rules == null)
            {
                return null;
            }

            var exportPolicy = new CachePropertiesExportPolicy { Rules = new List<ExportPolicyRule>() };
            foreach (var rule in psExportPolicy.Rules)
            {
                exportPolicy.Rules.Add(new ExportPolicyRule
                {
                    RuleIndex = rule.RuleIndex,
                    UnixReadOnly = rule.UnixReadOnly,
                    UnixReadWrite = rule.UnixReadWrite,
                    Cifs = rule.Cifs,
                    Nfsv3 = rule.Nfsv3,
                    Nfsv41 = rule.Nfsv41,
                    AllowedClients = rule.AllowedClients,
                    HasRootAccess = rule.HasRootAccess,
                    Kerberos5IReadOnly = rule.Kerberos5iReadOnly,
                    Kerberos5IReadWrite = rule.Kerberos5iReadWrite,
                    Kerberos5PReadOnly = rule.Kerberos5pReadOnly,
                    Kerberos5PReadWrite = rule.Kerberos5pReadWrite,
                    Kerberos5ReadOnly = rule.Kerberos5ReadOnly,
                    Kerberos5ReadWrite = rule.Kerberos5ReadWrite
                });
            }
            return exportPolicy;
        }

        public static PSNetAppFilesVolumeExportPolicy ConvertExportPolicyToPs(CachePropertiesExportPolicy exportPolicy)
        {
            if (exportPolicy?.Rules == null)
            {
                return null;
            }

            return new PSNetAppFilesVolumeExportPolicy
            {
                Rules = exportPolicy.Rules.Select(rule => new PSNetAppFilesExportPolicyRule
                {
                    RuleIndex = rule.RuleIndex,
                    UnixReadOnly = rule.UnixReadOnly,
                    UnixReadWrite = rule.UnixReadWrite,
                    Cifs = rule.Cifs,
                    Nfsv3 = rule.Nfsv3,
                    Nfsv41 = rule.Nfsv41,
                    AllowedClients = rule.AllowedClients,
                    HasRootAccess = rule.HasRootAccess,
                    Kerberos5iReadOnly = rule.Kerberos5IReadOnly,
                    Kerberos5iReadWrite = rule.Kerberos5IReadWrite,
                    Kerberos5pReadOnly = rule.Kerberos5PReadOnly,
                    Kerberos5pReadWrite = rule.Kerberos5PReadWrite,
                    Kerberos5ReadOnly = rule.Kerberos5ReadOnly,
                    Kerberos5ReadWrite = rule.Kerberos5ReadWrite
                }).ToArray()
            };
        }
    }
}
