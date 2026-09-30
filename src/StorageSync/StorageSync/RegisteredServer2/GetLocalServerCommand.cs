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

using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.InternalObjects;
using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
using Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity;
using Microsoft.Azure.Commands.StorageSync.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{
    /// <summary>
    /// Class GetLocalStorageSyncServerCommand.
    /// Reads local server information through the Azure File Sync agent COM interface.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.StorageSyncClientCmdletBase" />
    [Cmdlet(VerbsCommon.Get, StorageSyncNouns.NounStorageSyncServer)]
    [OutputType(typeof(PSLocalStorageSyncServer))]
    public class GetLocalStorageSyncServerCommand : StorageSyncClientCmdletBase
    {
        /// <summary>
        /// This command reads only local state and does not require Azure context initialization.
        /// </summary>
        protected override void InitializeComponent()
        {
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                var localServer = new PSLocalStorageSyncServer
                {
                    ServerName = SystemUtility.GetMachineName(),
                    AgentVersion = StorageSyncClientWrapper.AfsAgentVersion,
                    ServerOSVersion = System.Environment.OSVersion.Version.ToString()
                };

                using (IEcsManagement ecsManagement = StorageSyncClientWrapper.StorageSyncResourceManager.CreateEcsManagement())
                {
                    int hr = ecsManagement.GetSyncServerId(out string localServerId);
                    if (hr != 0 || !Guid.TryParse(localServerId, out Guid localServerGuid))
                    {
                        throw new PSArgumentException("Unable to retrieve the local ServerId. Ensure the Azure File Sync agent is installed and running.");
                    }

                    localServer.ServerId = localServerGuid;

                    bool isInCluster = ecsManagement.IsInCluster();
                    localServer.IsInCluster = isInCluster;
                    localServer.ServerRole = (isInCluster ? ServerRoleType.ClusterNode : ServerRoleType.Standalone).ToString();

                    if (isInCluster)
                    {
                        int clusterHr = ecsManagement.GetClusterInfo(out string clusterId, out string clusterName);
                        if (clusterHr != 0 || !Guid.TryParse(clusterId, out Guid clusterGuid))
                        {
                            throw new PSArgumentException("Unable to retrieve the local cluster information for this cluster node.");
                        }

                        localServer.ClusterId = clusterGuid;
                        localServer.ClusterName = clusterName;
                    }
                }

                IServerManagedIdentityProvider serverManagedIdentityProvider = StorageSyncClientWrapper.StorageSyncResourceManager.CreateServerManagedIdentityProvider();
                serverManagedIdentityProvider.EnableMIChecking = true;

                LocalServerType serverTypeFromRegistry = StorageSyncClientWrapper.StorageSyncResourceManager.GetServerTypeFromRegistry();
                ServerApplicationIdentity serverApplicationIdentity = serverManagedIdentityProvider.GetServerApplicationIdentityAsync(serverTypeFromRegistry, throwIfNotFound: false).GetAwaiter().GetResult();

                if (serverApplicationIdentity != null && serverApplicationIdentity.ApplicationId != Guid.Empty)
                {
                    localServer.ApplicationId = serverApplicationIdentity.ApplicationId;

                    if (serverApplicationIdentity.TenantId != Guid.Empty)
                    {
                        localServer.TenantId = serverApplicationIdentity.TenantId;
                    }
                }

                WriteObject(localServer);
            });
        }
    }
}
