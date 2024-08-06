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

using Commands.StorageSync.Interop.Clients;
using Commands.StorageSync.Interop.DataObjects;
using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity;
using Microsoft.Azure.Commands.StorageSync.Test.Common;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Management.Automation.Runspaces;
using System.Text.RegularExpressions;

namespace StorageSync.Test.Common
{
    /// <summary>
    /// Class StorageSyncResourceManager.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.IStorageSyncResourceManager" />
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Interfaces.IStorageSyncResourceManager" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Interfaces.IStorageSyncResourceManager" />
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.IStorageSyncResourceManager" />
    public class MockStorageSyncResourceManager : IStorageSyncResourceManager
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MockStorageSyncResourceManager"/> class.
        /// </summary>
        /// <param name="testName">Name of the test.</param>
        public MockStorageSyncResourceManager(string testName)
        {
            TestName = testName;
        }

        /// <summary>
        /// Gets the name of the test.
        /// </summary>
        /// <value>The name of the test.</value>
        protected string TestName;

        /// <summary>
        /// The is playback mode
        /// </summary>
        private bool? isPlaybackMode;

        /// <summary>
        /// Gets a value indicating whether this instance is playback mode.
        /// </summary>
        /// <value><c>true</c> if this instance is playback mode; otherwise, <c>false</c>.</value>
        /// <exception cref="NotSupportedException"></exception>
        protected bool IsPlaybackMode
        {
            get
            {
                if (!isPlaybackMode.HasValue)
                {
                    if (Microsoft.Azure.Test.HttpRecorder.HttpMockServer.Mode == Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode.Playback)
                    {
                        isPlaybackMode = true;
                    }
                    else if (Microsoft.Azure.Test.HttpRecorder.HttpMockServer.Mode == Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode.Record)
                    {
                        isPlaybackMode = false;

                    }
                    else
                    {
                        throw new NotSupportedException($"{Microsoft.Azure.Test.HttpRecorder.HttpMockServer.Mode} Mode is not supported");
                    }
                }
                return isPlaybackMode.Value;
            }
        }

        /// <summary>
        /// Creates the ecs management.
        /// </summary>
        /// <returns>IEcsManagement.</returns>
        public IEcsManagement CreateEcsManagement() => IsPlaybackMode ? new MockEcsManagementInteropClient() as IEcsManagement : new EcsManagementInteropClient();

        /// <summary>
        /// Create Server Managed Identity Provider
        /// </summary>
        /// <returns>ServerManagedIdentityProvider interface</returns>
        public IServerManagedIdentityProvider CreateServerManagedIdentityProvider() => IsPlaybackMode ? new MockServerManagedIdentityProvider() : new ServerManagedIdentityProvider();

        /// <summary>
        /// Creates the Sync Server Registration management.
        /// </summary>
        /// <returns>IEcsManagement.</returns>
        public ISyncServerRegistration CreateSyncServerManagement() => IsPlaybackMode ? new MockSyncServerRegistrationClient(CreateEcsManagement()) as ISyncServerRegistration :
            new SyncServerRegistrationClient(CreateEcsManagement(),CreateServerManagedIdentityProvider());

        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <returns>Guid.</returns>
        public Guid GetGuid() => Microsoft.Azure.Test.HttpRecorder.HttpMockServer.GetAssetGuid(TestName);

        /// <summary>
        /// Gets the afs agent installer path.
        /// </summary>
        /// <param name="afsAgentInstallerPath">The afs agent installer path.</param>
        /// <returns>System.String.</returns>
        public bool TryGetAfsAgentInstallerPath(out string afsAgentInstallerPath)
        {
            afsAgentInstallerPath = @"C:\Program Files\Azure\StorageSyncAgent\";
            return true;
        }

        /// <summary>
        /// Gets the afs agent version.
        /// </summary>
        /// <param name="afsAgentVersion">The afs agent version.</param>
        /// <returns>System.String.</returns>
        public bool TryGetAfsAgentVersion(out string afsAgentVersion)
        {
            afsAgentVersion = @"13.0.0.0";
            return true;
        }

        /// <summary>
        /// Updates the server registration data.
        /// </summary>
        /// <param name="pServerRegistrationData">The p server registration data.</param>
        /// <returns>ServerRegistrationData.</returns>
        public ServerRegistrationData UpdateServerRegistrationData(ServerRegistrationData pServerRegistrationData)
        {
            pServerRegistrationData.Id = Microsoft.Azure.Test.HttpRecorder.HttpMockServer.GetVariable(StorageSyncConstants.SyncServerId, pServerRegistrationData.Id);
            pServerRegistrationData.ServerId = Guid.Parse(Regex.Match(pServerRegistrationData.Id, @"([^/]+)$").Value);
            return pServerRegistrationData;
        }

        /// <summary>
        /// Waits for access propogation.
        /// </summary>
        public void Wait()
        {
            TestUtilities.Wait(40 * 1000);
        }

        public string GetTenantId()
        {
            string tenantId = null;

            if (IsPlaybackMode)
            {
                // The TestFx framework defaults to a dummy tenant id in their automation pipeline, so default to our test tenant in Playback mode if not set.
                // Failure to do this will cause cross tenant CloudEndpoint creation errors in PR validation automation.
                tenantId = HttpMockServer.GetVariable(StorageSyncConstants.TenantId, "0483643a-cb2f-462a-bc27-1a270e5bdc0a");
            }
            return tenantId;
        }

        /// <summary>
        /// Get Service Principal Or Null
        /// </summary>
        /// <returns>MicrosoftGraphServicePrincipal</returns>
        public MicrosoftGraphServicePrincipal GetServicePrincipalOrNull() => new() { Id = "384dab06-7a70-4ecf-a04e-284602199124" }; // Change Object ID if we are using some other tenant
    }
}