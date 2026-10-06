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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Commands.StorageSync.Properties;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Azure.Management.StorageSync.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Register, StorageSyncNouns.NounAzureRmStorageSyncServer, SupportsShouldProcess = true)]
    [OutputType(typeof(PSRegisteredServer))]
    public class RegisterServerCommand : StorageSyncClientCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = HelpMessages.ResourceGroupNameParameter)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = HelpMessages.StorageSyncServiceNameParameter)]
        [ResourceNameCompleter("Microsoft.StorageSync/storageSyncServices", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string StorageSyncServiceName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The application ID of the server system-assigned managed identity.")]
        [ValidateNotNullOrEmpty]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The Azure File Sync agent version reported by the local server (from Get-StorageSyncServer).")]
        [ValidateNotNullOrEmpty]
        public string AgentVersion { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The local server role, Standalone or ClusterNode (from Get-StorageSyncServer).")]
        [ValidateNotNullOrEmpty]
        public string ServerRole { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The local server operating system version (from Get-StorageSyncServer).")]
        public string ServerOSVersion { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "A friendly name for the registered server, typically the local server name.")]
        public string FriendlyName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The cluster id when the local server is a failover cluster node (from Get-StorageSyncServer).")]
        public Guid? ClusterId { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The cluster name when the local server is a failover cluster node (from Get-StorageSyncServer).")]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJobParameter)]
        public SwitchParameter AsJob { get; set; }

        protected override string Target => StorageSyncServiceName;

        protected override string ActionMessage =>
            $"{StorageSyncResources.RegisterServerActionMessage} {StorageSyncServiceName}";

        protected override void InitializeComponent()
        {
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                Guid serverId = StorageSyncClientWrapper.StorageSyncResourceManager.GetGuid();
                Target = string.Join("/", ResourceGroupName, StorageSyncServiceName, serverId);

                if (ShouldProcess(Target, ActionMessage))
                {
                    var createParameters = new RegisteredServerCreateParameters
                    {
                        ServerId = serverId.ToString(),
                        ApplicationId = ApplicationId.ToString(),
                        Identity = true,
                        AgentVersion = AgentVersion,
                        ServerOSVersion = ServerOSVersion,
                        ServerRole = ServerRole,
                        FriendlyName = string.IsNullOrEmpty(FriendlyName) ? serverId.ToString() : FriendlyName,
                        LastHeartBeat = DateTime.Now.ToString()
                    };

                    if (ClusterId.HasValue && ClusterId.Value != Guid.Empty)
                    {
                        createParameters.ClusterId = ClusterId.Value.ToString();
                    }

                    if (!string.IsNullOrEmpty(ClusterName))
                    {
                        createParameters.ClusterName = ClusterName;
                    }

                    WriteObject(StorageSyncClientWrapper.StorageSyncManagementClient.RegisteredServers.Create(
                        ResourceGroupName,
                        StorageSyncServiceName,
                        serverId,
                        createParameters));
                }
            });
        }
    }
}
