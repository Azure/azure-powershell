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
using Commands.StorageSync.Interop.Interfaces;

namespace Commands.StorageSync.Interop
{
    /// <summary>
    /// Class InteropClientFactory.
    /// </summary>
    public static class InteropClientFactory
    {
        /// <summary>
        /// Creates the ecs management.
        /// </summary>
        /// <param name="isTestMode">if set to <c>true</c> [is test mode].</param>
        /// <returns>IEcsManagement.</returns>
        public static IEcsManagement CreateEcsManagement(bool isTestMode)
        {
            return isTestMode ? new EcsManagementInteropClientPlayback() as IEcsManagement : new EcsManagementInteropClient();
        }

        /// <summary>
        /// Creates the synchronize server registration client.
        /// </summary>
        /// <param name="ecsManagementClient">The ecs management client.</param>
        /// <returns>ISyncServerRegistration.</returns>
        public static ISyncServerRegistration CreateSyncServerRegistrationClient(IEcsManagement ecsManagementClient)
        {
            return new SyncServerRegistrationClient(ecsManagementClient);
        }
    }
}
