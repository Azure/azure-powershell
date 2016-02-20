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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Commands.Sql.ThreatDetection.Model;

namespace Microsoft.Azure.Commands.Sql.ThreatDetection.Services
{
    /// <summary>
    /// The SqlThreatDetectionAdapter class is responsible for transforming the data that was received form the endpoints to the cmdlets model of auditing policy and vice versa
    /// </summary>
    public class SqlThreatDetectionAdapter
    {
        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        private AzureSubscription Subscription { get; set; }

        /// <summary>
        /// The Threat Detection endpoints communicator used by this adapter
        /// </summary>
        private ThreatDetectionEndpointsCommunicator ThreatDetectionCommunicator { get; set; }
       
        /// <summary>
        /// The Azure endpoints communicator used by this adapter
        /// </summary>
        private AzureEndpointsCommunicator AzureCommunicator { get; set; }

        /// <summary>
        /// The Sql Auditing Adapter
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
            AuditingAdapter = new SqlAuditAdapter(context);
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
        public DatabaseThreatDetectionPolicyModel GetDatabaseThreatDetectionPolicy(string resourceGroup, string serverName, string databaseName, string requestId)
        {
            if (!IsRightServerVersionForThreatDetection(resourceGroup, serverName, requestId))
            {
                throw new Exception(Properties.Resources.ServerNotApplicableForThreatDetection);
            }

            DatabaseSecurityAlertPolicy threatDetectionPolicy = ThreatDetectionCommunicator.GetDatabaseSecurityAlertPolicy(resourceGroup, serverName, databaseName, requestId);

            DatabaseThreatDetectionPolicyModel databaseThreatDetectionPolicyModel = ModelizeDatabaseThreatDetectionPolicy(threatDetectionPolicy);
            databaseThreatDetectionPolicyModel.ResourceGroupName = resourceGroup;
            databaseThreatDetectionPolicyModel.ServerName = serverName;
            databaseThreatDetectionPolicyModel.DatabaseName = databaseName;
            return databaseThreatDetectionPolicyModel;
        }

        /// <summary>
        /// Transforms the given database policy object to its cmdlet model representation
        /// </summary>
        private DatabaseThreatDetectionPolicyModel ModelizeDatabaseThreatDetectionPolicy(DatabaseSecurityAlertPolicy threatDetectionPolicy)
        {
            DatabaseThreatDetectionPolicyModel databaseThreatDetectionPolicyModel = new DatabaseThreatDetectionPolicyModel();
            DatabaseSecurityAlertPolicyProperties threatDetectionProperties = threatDetectionPolicy.Properties;
            databaseThreatDetectionPolicyModel.ThreatDetectionState = ModelizeThreatDetectionState(threatDetectionProperties.State);
            databaseThreatDetectionPolicyModel.NotificationRecipientsEmails = threatDetectionProperties.EmailAddresses;
            databaseThreatDetectionPolicyModel.EmailAdmins = ModelizeThreatDetectionEmailAdmins(threatDetectionProperties.EmailAccountAdmins);
            ModelizeDisabledAlerts(databaseThreatDetectionPolicyModel, threatDetectionProperties.DisabledAlerts);
            return databaseThreatDetectionPolicyModel;
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
        private void ModelizeDisabledAlerts(DatabaseThreatDetectionPolicyModel model, string disabledAlerts)
        {
            List<string> disabledAlertsArray = disabledAlerts.Split(';').Select(p => p.Trim()).ToList();

            HashSet<DetectionType> detectionTypes = new HashSet<DetectionType>();
            if (disabledAlertsArray.Contains(SecurityConstants.Sql_Injection)) detectionTypes.Add(DetectionType.Sql_Injection);
            if (disabledAlertsArray.Contains(SecurityConstants.Sql_Injection_Vulnerability)) detectionTypes.Add(DetectionType.Sql_Injection_Vulnerability);
            if (disabledAlertsArray.Contains(SecurityConstants.Access_Anomaly)) detectionTypes.Add(DetectionType.Access_Anomaly);
            if (disabledAlertsArray.Contains(SecurityConstants.Usage_Anomaly)) detectionTypes.Add(DetectionType.Usage_Anomaly);
            model.ExcludedDetectionTypes = detectionTypes.ToArray();
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
        public void SetDatabaseThreatDetectionPolicy(DatabaseThreatDetectionPolicyModel model, String clientId)
        {
            if (model.ThreatDetectionState == ThreatDetectionStateType.Enabled)
            {
                if (!IsRightServerVersionForThreatDetection(model.ResourceGroupName, model.ServerName, clientId))
                {
                    throw new Exception(Properties.Resources.ServerNotApplicableForThreatDetection);
                }

                // Check that auditing is turned on:
                DatabaseAuditingPolicyModel databaseAuditingPolicyModel = AuditingAdapter.GetDatabaseAuditingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId);
                AuditStateType auditingState = databaseAuditingPolicyModel.AuditState;
                if (databaseAuditingPolicyModel.UseServerDefault == UseServerDefaultOptions.Enabled)
                {
                    ServerAuditingPolicyModel serverAuditingPolicyModel = AuditingAdapter.GetServerAuditingPolicy(model.ResourceGroupName, model.ServerName, clientId);
                    auditingState = serverAuditingPolicyModel.AuditState;
                }
                if (auditingState != AuditStateType.Enabled)
                {
                    throw new Exception(Properties.Resources.AuditingIsTurnedOff);
                }
            }

            DatabaseSecurityAlertPolicyCreateOrUpdateParameters databaseSecurityAlertPolicyParameters = PolicizeDatabaseSecurityAlertModel(model);
            ThreatDetectionCommunicator.SetDatabaseSecurityAlertPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId, databaseSecurityAlertPolicyParameters);
        }

        /// <summary>
        /// Checks whether the given alert type was used
        /// </summary>
        private bool IsDetectionTypeOn(DetectionType lookedForType, DetectionType[] userSelectedTypes)
        {
            if (userSelectedTypes.Contains(lookedForType))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Extracts the detection types from the given model
        /// </summary>
        private string ExtractExcludedDetectionType(BaseThreatDetectionPolicyModel model)
        {
            if (model.ExcludedDetectionTypes == null)
            {
                return null;
            }

            StringBuilder detectionTypes = new StringBuilder();
            if (IsDetectionTypeOn(DetectionType.Sql_Injection, model.ExcludedDetectionTypes))
            {
                detectionTypes.Append(SecurityConstants.Sql_Injection).Append(";");
            }
            if (IsDetectionTypeOn(DetectionType.Sql_Injection_Vulnerability, model.ExcludedDetectionTypes))
            {
                detectionTypes.Append(SecurityConstants.Sql_Injection_Vulnerability).Append(";");
            }
            if (IsDetectionTypeOn(DetectionType.Access_Anomaly, model.ExcludedDetectionTypes))
            {
                detectionTypes.Append(SecurityConstants.Access_Anomaly).Append(";");
            }
            if (IsDetectionTypeOn(DetectionType.Usage_Anomaly, model.ExcludedDetectionTypes))
            {
                detectionTypes.Append(SecurityConstants.Usage_Anomaly).Append(";");
            }
            if (detectionTypes.Length != 0)
            {
                detectionTypes.Remove(detectionTypes.Length - 1, 1); // remove trailing semi-colon
            }
            return detectionTypes.ToString();
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="model">The SecurityAlert model object</param>
        /// <returns>The communication model object</returns>
        private DatabaseSecurityAlertPolicyCreateOrUpdateParameters PolicizeDatabaseSecurityAlertModel(DatabaseThreatDetectionPolicyModel model)
        {
            DatabaseSecurityAlertPolicyCreateOrUpdateParameters updateParameters = new DatabaseSecurityAlertPolicyCreateOrUpdateParameters();
            DatabaseSecurityAlertPolicyProperties properties = new DatabaseSecurityAlertPolicyProperties();
            updateParameters.Properties = properties;
            properties.State = PolicizeThreatDetectionState(model.ThreatDetectionState);
            properties.EmailAddresses = model.NotificationRecipientsEmails ?? "";
            properties.EmailAccountAdmins = model.EmailAdmins
                ? SecurityConstants.ThreatDetectionEndpoint.Enabled
                : SecurityConstants.ThreatDetectionEndpoint.Disabled;
            properties.DisabledAlerts = ExtractExcludedDetectionType(model);
            return updateParameters;
        }
    }
}