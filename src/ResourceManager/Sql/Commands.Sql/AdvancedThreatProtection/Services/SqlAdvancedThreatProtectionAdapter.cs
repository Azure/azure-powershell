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
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.Azure.Management.Sql.Models;

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
        private ThreatDetectionEndpointsCommunicator ThreatDetectionCommunicator { get; set; }

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
            Subscription = context.Subscription;
            ThreatDetectionCommunicator = new ThreatDetectionEndpointsCommunicator(Context);
        }

        /// <summary>
        /// Provides a server Advanced Threat Protection policy model for the given database
        /// </summary>
        public ServerAdvancedThreatProtectionPolicyModel GetServerAdvancedThreatProtectionPolicy(string resourceGroup, string serverName)
        {
            // Currently Advanced Threat Protection policy is a TD policy until the backend will support Advanced Threat Protection APIs
            var threatDetectionPolicy = ThreatDetectionCommunicator.GetServerSecurityAlertPolicy(resourceGroup, serverName);
            var serverAdvancedThreatProtectionPolicyModel = new ServerAdvancedThreatProtectionPolicyModel()
            {
                ResourceGroupName = resourceGroup,
                ServerName = serverName,
                IsEnabled = (threatDetectionPolicy.State == SecurityAlertPolicyState.Enabled)
            };

            return serverAdvancedThreatProtectionPolicyModel;
        }

        /// <summary>
        /// Sets a server Advanced Threat Protection policy model for the given database
        /// </summary>
        public ServerAdvancedThreatProtectionPolicyModel EnableServerAdvancedThreatProtection(ServerAdvancedThreatProtectionPolicyModel model)
        {
            // Currently Advanced Threat Protection policy is a TD policy until the backend will support Advanced Threat Protection APIs
            var policy = new Management.Sql.Models.ServerSecurityAlertPolicy()
            {
                State = SecurityAlertPolicyState.Enabled,
                EmailAccountAdmins = true                
            };

            ThreatDetectionCommunicator.SetServerSecurityAlertPolicy(model.ResourceGroupName, model.ServerName, policy);

            return model;
        }

        /// <summary>
        /// Disables the server Advanced Threat Protection policy model for the given database
        /// </summary>
        public ServerAdvancedThreatProtectionPolicyModel DisableServerAdvancedThreatProtection(ServerAdvancedThreatProtectionPolicyModel model)
        {
            // Currently Advanced Threat Protection policy is a TD policy until the backend will support Advanced Threat Protection APIs
            var policy = new Management.Sql.Models.ServerSecurityAlertPolicy()
            {
                State = SecurityAlertPolicyState.Disabled
            };

            ThreatDetectionCommunicator.SetServerSecurityAlertPolicy(model.ResourceGroupName, model.ServerName, policy);

            return model;
        }
    }
}
