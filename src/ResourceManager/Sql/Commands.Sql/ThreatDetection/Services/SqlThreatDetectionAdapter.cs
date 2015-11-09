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

using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Commands.Sql.ThreatDetection.Model;

namespace Microsoft.Azure.Commands.Sql.ThreatDetection.Services
{
    /// <summary>
    /// The SqlAuditClient class is responsible for transforming the data that was received form the endpoints to the cmdlets model of auditing policy and vice versa
    /// </summary>
    public class SqlThreatDetectionAdapter
    {
        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        private AzureSubscription Subscription { get; set; }

        /// <summary>
        /// The auditing endpoints communicator used by this adapter
        /// </summary>
        private ThreatDetectionEndpointsCommunicator ThreatDetectionCommunicator { get; set; }
       
        /// <summary>
        /// The Azure endpoints communicator used by this adapter
        /// </summary>
        private AzureEndpointsCommunicator AzureCommunicator { get; set; }

        /// <summary>
        /// The Sql Auditingn Adapter
        /// </summary>
        private SqlAuditAdapter AuditingAdapter { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        public SqlThreatDetectionAdapter(AzureContext context)
        {
            Context = context;
            Subscription = context.Subscription;
            ThreatDetectionCommunicator = new ThreatDetectionEndpointsCommunicator(Context);
            AzureCommunicator = new AzureEndpointsCommunicator(Context);
        }

        /// <summary>
        ///  Checks whether the server is applicable for threat detection
        /// </summary>
        private bool IsRightServerVersionForThreatDetection(string resourceGroupName, string serverName, string clientId)
        {
            AzureSqlServerCommunicator dbCommunicator = new AzureSqlServerCommunicator(Context);
            Management.Sql.Models.Server server = dbCommunicator.Get(resourceGroupName, serverName, clientId);
            return server.Properties.Version == "12.0";
        }

       
        /// <summary>
        /// Provides a database threat detection policy model for the given database
        /// </summary>
        public ThreatDetectionPolicyModel GetDatabaseThreatDetectionPolicy(string resourceGroup, string serverName, string databaseName, string requestId)
        {
            if (!IsRightServerVersionForThreatDetection(resourceGroup, serverName, requestId))
            {
                throw new Exception(Properties.Resources.ServerNotApplicableForThreatDetection);
            }

            DatabaseSecurityAlertPolicy threatDetectionPolicy = ThreatDetectionCommunicator.GetDatabaseSecurityAlertPolicy(resourceGroup, serverName, databaseName, requestId);

            ThreatDetectionPolicyModel threatDetectionPolicyModel = ModelizeDatabaseThreatDetectionPolicy(threatDetectionPolicy);
            threatDetectionPolicyModel.ResourceGroupName = resourceGroup;
            threatDetectionPolicyModel.ServerName = serverName;
            threatDetectionPolicyModel.DatabaseName = databaseName;
            return threatDetectionPolicyModel;
        }

        /// <summary>
        /// Transforms the given database policy object to its cmdlet model representation
        /// </summary>
        private ThreatDetectionPolicyModel ModelizeDatabaseThreatDetectionPolicy(DatabaseSecurityAlertPolicy threatDetectionPolicy)
        {
            ThreatDetectionPolicyModel threatDetectionPolicyModel = new ThreatDetectionPolicyModel();
            DatabaseSecurityAlertPolicyProperties threatDetectionProperties = threatDetectionPolicy.Properties;
            threatDetectionPolicyModel.ThreatDetectionState = ModelizeThreatDetectionState(threatDetectionProperties.State);
            threatDetectionPolicyModel.NotificationRecipientsEmail = threatDetectionProperties.EmailAddresses;
            threatDetectionPolicyModel.EmailAdmins = ModelizeThreatDetectionEmailAdmins(threatDetectionProperties.EmailAccountAdmins);
            ModelizeDisabledAlerts(threatDetectionPolicyModel, threatDetectionProperties.DisabledAlerts);
            return threatDetectionPolicyModel;
        }

        /// <summary>
        /// Transforms the given policy state in a string form to its cmdlet model representation
        /// </summary>
        private ThreatDetectionStateType ModelizeThreatDetectionState(string threatDetectionState)
        {
            if (threatDetectionState == SecurityConstants.ThreatDetectionEndpoint.New) return ThreatDetectionStateType.New;
            if (threatDetectionState == SecurityConstants.ThreatDetectionEndpoint.Enabled) return ThreatDetectionStateType.Enabled;
            return ThreatDetectionStateType.Disabled;
        }

        /// <summary>
        /// Transforms the given policy EmailAccountAdmins in a boolean form to its cmdlet model representation
        /// </summary>
        private bool ModelizeThreatDetectionEmailAdmins(string emailAccountAdminsState)
        {
            if (emailAccountAdminsState == SecurityConstants.ThreatDetectionEndpoint.Enabled) return true;
            return false;
        }

        /// <summary>
        /// Updates the given model with all the disabled alerts information
        /// </summary>
        private void ModelizeDisabledAlerts(ThreatDetectionPolicyModel model, string disabledAlerts)
        {
            HashSet<FilterDetectionType> events = new HashSet<FilterDetectionType>();
            if (disabledAlerts.IndexOf(SecurityConstants.Successful_SQLi) != -1) events.Add(FilterDetectionType.Successful_SQLi);
            if (disabledAlerts.IndexOf(SecurityConstants.Attempted_SQLi) != -1) events.Add(FilterDetectionType.Attempted_SQLi);
            if (disabledAlerts.IndexOf(SecurityConstants.Client_GEO_Anomaly) != -1) events.Add(FilterDetectionType.Client_GEO_Anomaly);
            if (disabledAlerts.IndexOf(SecurityConstants.Failed_Logins_Anomaly) != -1) events.Add(FilterDetectionType.Failed_Logins_Anomaly);
            if (disabledAlerts.IndexOf(SecurityConstants.Failed_Queries_Anomaly) != -1) events.Add(FilterDetectionType.Failed_Queries_Anomaly);
            if (disabledAlerts.IndexOf(SecurityConstants.Data_Extraction_Anomaly) != -1) events.Add(FilterDetectionType.Data_Extraction_Anomaly);
            if (disabledAlerts.IndexOf(SecurityConstants.Data_Alteration_Anomaly) != -1) events.Add(FilterDetectionType.Data_Alteration_Anomaly); 
            model.FilterDetectionTypes = events.ToArray();
        }

        /// <summary>
        /// Transforms the given policy state into a string representation
        /// </summary>
        private string PolicizeThreatDetectionState(ThreatDetectionStateType threatDetectionState)
        {
            switch (threatDetectionState)
            {
                case ThreatDetectionStateType.Enabled:
                    return SecurityConstants.ThreatDetectionEndpoint.Enabled;
                case ThreatDetectionStateType.New:
                    return SecurityConstants.ThreatDetectionEndpoint.New;
                default:
                    return SecurityConstants.ThreatDetectionEndpoint.Disabled;
            }
        }

        /// <summary>
        /// Transforms the given model to its endpoints acceptable structure and sends it to the endpoint
        /// </summary>
        public void SetDatabaseThreatDetectionPolicy(ThreatDetectionPolicyModel model, String clientId)
        {
            if (model.ThreatDetectionState == ThreatDetectionStateType.Enabled)
            {
                if (!IsRightServerVersionForThreatDetection(model.ResourceGroupName, model.ServerName, clientId))
                {
                    throw new Exception(Properties.Resources.ServerNotApplicableForThreatDetection);
                }

                DatabaseAuditingPolicyModel databaseAuditingPolicyModel = AuditingAdapter.GetDatabaseAuditingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId);
                if (databaseAuditingPolicyModel.AuditState != AuditStateType.Enabled)
                {
                    throw new Exception(Properties.Resources.AuditingIsTurnedOff);
                }
            }

            DatabaseSecurityAlertPolicyCreateOrUpdateParameters databaseSecurityAlertPolicyParameters = PolicizeDatabaseSecurityAlertModel(model);
            ThreatDetectionCommunicator.SetDatabaseSecurityAlertPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId, databaseSecurityAlertPolicyParameters);
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="model">The SecurityAlert model object</param>
        /// <returns>The communication model object</returns>
        private DatabaseSecurityAlertPolicyCreateOrUpdateParameters PolicizeDatabaseSecurityAlertModel(ThreatDetectionPolicyModel model)
        {
            DatabaseSecurityAlertPolicyCreateOrUpdateParameters updateParameters = new DatabaseSecurityAlertPolicyCreateOrUpdateParameters();
            DatabaseSecurityAlertPolicyProperties properties = new DatabaseSecurityAlertPolicyProperties();
            updateParameters.Properties = properties;
            properties.State = PolicizeThreatDetectionState(model.ThreatDetectionState);
            properties.EmailAddresses = model.NotificationRecipientsEmail ?? "";
            properties.EmailAccountAdmins = model.EmailAdmins
                ? SecurityConstants.ThreatDetectionEndpoint.Enabled
                : SecurityConstants.ThreatDetectionEndpoint.Disabled;
            return updateParameters;
        }
    }
}