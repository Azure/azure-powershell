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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Commands.Sql.ThreatDetection.Model;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

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

            var threatDetectionPolicy = ThreatDetectionCommunicator.GetDatabaseSecurityAlertPolicy(resourceGroup, serverName, databaseName, requestId);

            var databaseThreatDetectionPolicyModel = ModelizeThreatDetectionPolicy(threatDetectionPolicy.Properties, new DatabaseThreatDetectionPolicyModel()) as DatabaseThreatDetectionPolicyModel;
            databaseThreatDetectionPolicyModel.ResourceGroupName = resourceGroup;
            databaseThreatDetectionPolicyModel.ServerName = serverName;
            databaseThreatDetectionPolicyModel.DatabaseName = databaseName;
            return databaseThreatDetectionPolicyModel;
        }

        /// <summary>
        /// Provides a database threat detection policy model for the given database
        /// </summary>
        public ServerThreatDetectionPolicyModel GetServerThreatDetectionPolicy(string resourceGroup, string serverName, string requestId)
        {
            if (!IsRightServerVersionForThreatDetection(resourceGroup, serverName, requestId))
            {
                throw new Exception(Properties.Resources.ServerNotApplicableForThreatDetection);
            }

            var threatDetectionPolicy = ThreatDetectionCommunicator.GetServerSecurityAlertPolicy(resourceGroup, serverName, requestId);

            var serverThreatDetectionPolicyModel = ModelizeThreatDetectionPolicy(threatDetectionPolicy.Properties, new ServerThreatDetectionPolicyModel()) as ServerThreatDetectionPolicyModel;
            serverThreatDetectionPolicyModel.ResourceGroupName = resourceGroup;
            serverThreatDetectionPolicyModel.ServerName = serverName;
            return serverThreatDetectionPolicyModel;
        }


        /// <summary>
        /// Transforms the given database policy object to its cmdlet model representation
        /// </summary>
        private BaseThreatDetectionPolicyModel ModelizeThreatDetectionPolicy(BaseSecurityAlertPolicyProperties threatDetectionProperties, BaseThreatDetectionPolicyModel model)
        {  
            model.ThreatDetectionState = ModelizeThreatDetectionState(threatDetectionProperties.State);
            model.NotificationRecipientsEmails = threatDetectionProperties.EmailAddresses;
            model.EmailAdmins = ModelizeThreatDetectionEmailAdmins(threatDetectionProperties.EmailAccountAdmins);
            ModelizeDisabledAlerts(model, threatDetectionProperties.DisabledAlerts);
            return model;
        }

        /// <summary>
        /// Transforms the given policy state in a string form to its cmdlet model representation
        /// </summary>
        private static ThreatDetectionStateType ModelizeThreatDetectionState(string threatDetectionState)
        {
            ThreatDetectionStateType value;
            Enum.TryParse(threatDetectionState, true, out value);
            return value;
        }

        /// <summary>
        /// Transforms the given policy EmailAccountAdmins in a boolean form to its cmdlet model representation
        /// </summary>
        private static bool ModelizeThreatDetectionEmailAdmins(string emailAccountAdminsState)
        {
            return emailAccountAdminsState.Equals(ThreatDetectionStateType.Enabled.ToString(), StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Updates the given model with all the disabled alerts information
        /// </summary>
        private static void ModelizeDisabledAlerts(BaseThreatDetectionPolicyModel model, string disabledAlerts)
        {
            Func<string, DetectionType> toDetectionType = (s) =>
            {
                DetectionType value;
                Enum.TryParse(s.Trim(), true, out value);
                return value;
            };
            if (string.IsNullOrEmpty(disabledAlerts))
            {
                model.ExcludedDetectionTypes = new DetectionType[] {};
            }
            else
            {
                model.ExcludedDetectionTypes = disabledAlerts.Split(';').Select(toDetectionType).ToArray();
            }        
        }

        /// <summary>
        /// Transforms the given model to its endpoints acceptable structure and sends it to the endpoint
        /// </summary>
        public void SetDatabaseThreatDetectionPolicy(DatabaseThreatDetectionPolicyModel model, string clientId)
        {
            if (model.ThreatDetectionState == ThreatDetectionStateType.Enabled)
            {
                if (!IsRightServerVersionForThreatDetection(model.ResourceGroupName, model.ServerName, clientId))
                {
                    throw new Exception(Properties.Resources.ServerNotApplicableForThreatDetection);
                }

                // Check that auditing is turned on:
                DatabaseAuditingPolicyModel databaseAuditingPolicyModel;
                AuditingAdapter.GetDatabaseAuditingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId, out databaseAuditingPolicyModel);
                AuditStateType auditingState = databaseAuditingPolicyModel.AuditState;
                if (databaseAuditingPolicyModel.UseServerDefault == UseServerDefaultOptions.Enabled)
                {
                    ServerAuditingPolicyModel serverAuditingPolicyModel;
                    AuditingAdapter.GetServerAuditingPolicy(model.ResourceGroupName, model.ServerName, clientId, out serverAuditingPolicyModel);
                    auditingState = serverAuditingPolicyModel.AuditState;
                }
                if (auditingState != AuditStateType.Enabled)
                {
                    throw new Exception(Properties.Resources.AuditingIsTurnedOff);
                }
            }

            var databaseSecurityAlertPolicyParameters = PolicizeDatabaseSecurityAlertModel(model);
            ThreatDetectionCommunicator.SetDatabaseSecurityAlertPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId, databaseSecurityAlertPolicyParameters);
        }

        /// <summary>
        /// Transforms the given model to its endpoints acceptable structure and sends it to the endpoint
        /// </summary>
        public void SetServerThreatDetectionPolicy(ServerThreatDetectionPolicyModel model, string clientId)
        {
            if (model.ThreatDetectionState == ThreatDetectionStateType.Enabled)
            {
                if (!IsRightServerVersionForThreatDetection(model.ResourceGroupName, model.ServerName, clientId))
                {
                    throw new Exception(Properties.Resources.ServerNotApplicableForThreatDetection);
                }

                // Check that auditing is turned on:
                ServerAuditingPolicyModel serverAuditingPolicyModel;
                AuditingAdapter.GetServerAuditingPolicy(model.ResourceGroupName, model.ServerName, clientId, out serverAuditingPolicyModel);
                if (serverAuditingPolicyModel.AuditState != AuditStateType.Enabled)
                {
                    throw new Exception(Properties.Resources.AuditingIsTurnedOff);
                }
            }

            var serverSecurityAlertPolicyParameters = PolicizeServerSecurityAlertModel(model);
            ThreatDetectionCommunicator.SetServerSecurityAlertPolicy(model.ResourceGroupName, model.ServerName, clientId, serverSecurityAlertPolicyParameters);
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
            if (model.ExcludedDetectionTypes.Any(t => t == DetectionType.None))
            {
                if (model.ExcludedDetectionTypes.Count() == 1)
                {
                    return string.Empty;
                }
                if (model.ExcludedDetectionTypes.Any(t => t != DetectionType.None))
                {
                    throw new Exception(Properties.Resources.InvalidDetectionTypeList);
                }  
            }
            return string.Join(";", model.ExcludedDetectionTypes.Select(t => t.ToString()));
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="model">The SecurityAlert model object</param>
        /// <returns>The communication model object</returns>
        private ServerSecurityAlertPolicyCreateOrUpdateParameters PolicizeServerSecurityAlertModel(ServerThreatDetectionPolicyModel model)
        {
            var updateParameters = new ServerSecurityAlertPolicyCreateOrUpdateParameters();
            var properties = PopulatePolicyProperties(model, new ServerSecurityAlertPolicyProperties()) as ServerSecurityAlertPolicyProperties;
            updateParameters.Properties = properties;
            return updateParameters;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="model">The SecurityAlert model object</param>
        /// <returns>The communication model object</returns>
        private DatabaseSecurityAlertPolicyCreateOrUpdateParameters PolicizeDatabaseSecurityAlertModel(DatabaseThreatDetectionPolicyModel model)
        {
            var updateParameters = new DatabaseSecurityAlertPolicyCreateOrUpdateParameters();
            var properties = PopulatePolicyProperties(model, new DatabaseSecurityAlertPolicyProperties()) as DatabaseSecurityAlertPolicyProperties;
            updateParameters.Properties = properties;
            return updateParameters;
        }

        private BaseSecurityAlertPolicyProperties PopulatePolicyProperties(BaseThreatDetectionPolicyModel model, BaseSecurityAlertPolicyProperties properties)
        {
            properties.State = model.ThreatDetectionState.ToString();
            properties.EmailAddresses = model.NotificationRecipientsEmails ?? "";
            properties.EmailAccountAdmins = model.EmailAdmins ?
                ThreatDetectionStateType.Enabled.ToString() :
                ThreatDetectionStateType.Disabled.ToString();
            properties.DisabledAlerts = ExtractExcludedDetectionType(model);
            return properties;
        }
    }


}