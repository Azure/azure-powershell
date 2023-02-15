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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Configuration;
using System.Reflection;
using RecoveryServicesBackupNS = Microsoft.Azure.Management.RecoveryServices.Backup;
using RecoveryServicesBackupCRRNS = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore;
using RecoveryServicesNS = Microsoft.Azure.Management.RecoveryServices;
using ResourcesNS = Microsoft.Azure.Management.Internal.Resources;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    /// <summary>
    /// Adapter for service client to communicate with the backend service
    /// </summary>
    public partial class ServiceClientAdapter
    {
        const string AzureFabricName = "Azure";
        public const string ResourceProviderProductionNamespace = "Microsoft.RecoveryServices";

        public ClientProxy<RecoveryServicesBackupNS.RecoveryServicesBackupClient> BmsAdapter;
        public ClientProxy<RecoveryServicesBackupCRRNS.RecoveryServicesBackupClient> CrrAdapter;
        
        ClientProxy<RecoveryServicesNS.RecoveryServicesClient> RSAdapter;

        ClientProxy<ResourcesNS.ResourceManagementClient> RMAdapter;
        ClientProxy<ResourcesNS.FeatureClient> FeatureAdapter;

        public string SubscriptionId;

        /// <summary>
        /// Resource provider namespace that this adapter uses to 
        /// communicate with the backend service.
        /// </summary>
        public static string ResourceProviderNamespace => ResourceProviderProductionNamespace;

        /// <summary>
        /// AzureContext based ctor
        /// </summary>
        /// <param name="context">Azure context</param>
        public ServiceClientAdapter(IAzureContext context)
        {
            BmsAdapter = new ClientProxy<RecoveryServicesBackupNS.RecoveryServicesBackupClient>(context);
            CrrAdapter = new ClientProxy<RecoveryServicesBackupCRRNS.RecoveryServicesBackupClient>(context);
            RSAdapter = new ClientProxy<RecoveryServicesNS.RecoveryServicesClient>(context);
            RMAdapter = new ClientProxy<ResourcesNS.ResourceManagementClient>(context);
            FeatureAdapter = new ClientProxy<ResourcesNS.FeatureClient>(context);
            SubscriptionId = context.Subscription.Id;
        }
    }
}
