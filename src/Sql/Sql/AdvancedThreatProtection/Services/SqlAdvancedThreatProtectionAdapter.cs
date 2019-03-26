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
using Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ThreatDetection.Model;
using Microsoft.Azure.Commands.Sql.ThreatDetection.Services;

namespace Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Services
{
    /// <summary>
    /// The SqlAdvancedThreatProtectionAdapter class is responsible for transforming the data that was received form the endpoints to the cmdlets model of AdvancedThreatProtection policy and vice versa
    /// </summary>
    public class SqlAdvancedThreatProtectionAdapter
    {
        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        private IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// The Threat Detection endpoints communicator used by this adapter
        /// </summary>
        private SqlThreatDetectionAdapter SqlThreatDetectionAdapter { get; set; }

        /// <summary>
        /// The Azure endpoints communicator used by this adapter
        /// </summary>
        private AzureEndpointsCommunicator AzureCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public SqlAdvancedThreatProtectionAdapter(IAzureContext context)
        {
            Context = context;
            Subscription = context?.Subscription;
            SqlThreatDetectionAdapter = new SqlThreatDetectionAdapter(Context);
        }

        /// <summary>
        /// Provides a server Advanced Threat Protection policy model for the given server
        /// </summary>
        public ServerAdvancedThreatProtectionPolicyModel GetServerAdvancedThreatProtectionPolicy(string resourceGroup, string serverName)
        {
            // Currently Advanced Threat Protection policy is a TD policy until the backend will support Advanced Threat Protection APIs
            var threatDetectionPolicy = SqlThreatDetectionAdapter.GetServerThreatDetectionPolicy(resourceGroup, serverName);
            var serverAdvancedThreatProtectionPolicyModel = new ServerAdvancedThreatProtectionPolicyModel()
            {
                ResourceGroupName = resourceGroup,
                ServerName = serverName,
                IsEnabled = (threatDetectionPolicy.ThreatDetectionState == ThreatDetectionStateType.Enabled)
            };

            return serverAdvancedThreatProtectionPolicyModel;
        }

        /// <summary>
        /// Provides a managed instance Advanced Data Security policy model for the given managed instance
        /// </summary>
        public ManagedInstanceAdvancedDataSecurityPolicyModel GetManagedInstanceAdvancedDataSecurityPolicy(string resourceGroup, string managedInstanceName)
        {
            // Currently Advanced Threat Protection policy is a TD policy until the backend will support Advanced Threat Protection APIs
            var threatDetectionPolicy = SqlThreatDetectionAdapter.GetManagedInstanceThreatDetectionPolicy(resourceGroup, managedInstanceName);
            var managedInstanceAdvancedDataSecurityPolicy = new ManagedInstanceAdvancedDataSecurityPolicyModel()
            {
                ResourceGroupName = resourceGroup,
                ManagedInstanceName = managedInstanceName,
                IsEnabled = (threatDetectionPolicy.ThreatDetectionState == ThreatDetectionStateType.Enabled)
            };

            return managedInstanceAdvancedDataSecurityPolicy;
        }

        /// <summary>
        /// Sets a server Advanced Threat Protection policy model for the given server
        /// </summary>
        public ServerAdvancedThreatProtectionPolicyModel SetServerAdvancedThreatProtection(ServerAdvancedThreatProtectionPolicyModel model)
        {
            // Currently Advanced Threat Protection policy is a TD policy until the backend will support Advanced Threat Protection APIs
            var threatDetectionPolicy = SqlThreatDetectionAdapter.GetServerThreatDetectionPolicy(model.ResourceGroupName, model.ServerName);

            threatDetectionPolicy.ThreatDetectionState = model.IsEnabled ? ThreatDetectionStateType.Enabled : ThreatDetectionStateType.Disabled;

            SqlThreatDetectionAdapter.SetServerThreatDetectionPolicy(threatDetectionPolicy, AzureEnvironment.Endpoint.StorageEndpointSuffix);

            return model;
        }

        /// <summary>
        /// Sets a managed instance Advanced Threat Protection policy model for the given managed instance
        /// </summary>
        public ManagedInstanceAdvancedDataSecurityPolicyModel SetManagedInstanceAdvancedThreatProtection(ManagedInstanceAdvancedDataSecurityPolicyModel model)
        {
            // Currently Advanced Threat Protection policy is a TD policy until the backend will support Advanced Threat Protection APIs
            var threatDetectionPolicy = SqlThreatDetectionAdapter.GetManagedInstanceThreatDetectionPolicy(model.ResourceGroupName, model.ManagedInstanceName);

            threatDetectionPolicy.ThreatDetectionState = model.IsEnabled ? ThreatDetectionStateType.Enabled : ThreatDetectionStateType.Disabled;

            SqlThreatDetectionAdapter.SetManagedInstanceThreatDetectionPolicy(threatDetectionPolicy, AzureEnvironment.Endpoint.StorageEndpointSuffix);

            return model;
        }
    }
}
