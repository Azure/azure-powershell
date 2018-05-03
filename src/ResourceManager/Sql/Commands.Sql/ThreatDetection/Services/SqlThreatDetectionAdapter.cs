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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Commands.Sql.ThreatDetection.Model;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System;
using System.Linq;

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
        /// The Sql Auditing Adapter
        /// </summary>
        private SqlAuditAdapter AuditingAdapter { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public SqlThreatDetectionAdapter(IAzureContext context)
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
        private bool IsRightServerVersionForThreatDetection(string resourceGroupName, string serverName)
        {
            AzureSqlServerCommunicator dbCommunicator = new AzureSqlServerCommunicator(Context);
            Management.Sql.Models.Server server = dbCommunicator.Get(resourceGroupName, serverName);
            return server.Version == "12.0";
        }

        /// <summary>
        /// Provides a database threat detection policy model for the given database
        /// </summary>
        public DatabaseThreatDetectionPolicyModel GetDatabaseThreatDetectionPolicy(string resourceGroup, string serverName, string databaseName)
        {
            if (!IsRightServerVersionForThreatDetection(resourceGroup, serverName))
            {
                throw new Exception(Properties.Resources.ServerNotApplicableForThreatDetection);
            }

            var threatDetectionPolicy = ThreatDetectionCommunicator.GetDatabaseSecurityAlertPolicy(resourceGroup, serverName, databaseName);

            var databaseThreatDetectionPolicyModel = ModelizeThreatDetectionPolicy(threatDetectionPolicy.Properties, new DatabaseThreatDetectionPolicyModel()) as DatabaseThreatDetectionPolicyModel;
            databaseThreatDetectionPolicyModel.ResourceGroupName = resourceGroup;
            databaseThreatDetectionPolicyModel.ServerName = serverName;
            databaseThreatDetectionPolicyModel.DatabaseName = databaseName;
            return databaseThreatDetectionPolicyModel;
        }

        /// <summary>
        /// Provides a database threat detection policy model for the given database
        /// </summary>
        public ServerThreatDetectionPolicyModel GetServerThreatDetectionPolicy(string resourceGroup, string serverName)
        {
            if (!IsRightServerVersionForThreatDetection(resourceGroup, serverName))
            {
                throw new Exception(Properties.Resources.ServerNotApplicableForThreatDetection);
            }

            var threatDetectionPolicy = ThreatDetectionCommunicator.GetServerSecurityAlertPolicy(resourceGroup, serverName);

            var serverThreatDetectionPolicyModel = ModelizeThreatDetectionPolicy(threatDetectionPolicy.Properties, new ServerThreatDetectionPolicyModel()) as ServerThreatDetectionPolicyModel;
            serverThreatDetectionPolicyModel.ResourceGroupName = resourceGroup;
            serverThreatDetectionPolicyModel.ServerName = serverName;
            return serverThreatDetectionPolicyModel;
        }


        /// <summary>
        /// Transforms the given database policy object to its cmdlet model representation
        /// </summary>
        private static BaseThreatDetectionPolicyModel ModelizeThreatDetectionPolicy(BaseSecurityAlertPolicyProperties threatDetectionProperties, BaseThreatDetectionPolicyModel model)
        {  
            model.ThreatDetectionState = ModelizeThreatDetectionState(threatDetectionProperties.State);
            model.NotificationRecipientsEmails = threatDetectionProperties.EmailAddresses;
            model.EmailAdmins = ModelizeThreatDetectionEmailAdmins(threatDetectionProperties.EmailAccountAdmins);
            ModelizeStorageAccount(model, threatDetectionProperties.StorageEndpoint);
            ModelizeDisabledAlerts(model, threatDetectionProperties.DisabledAlerts);
            model.RetentionInDays = (uint)threatDetectionProperties.RetentionDays;
            return model;
        }

        private static void ModelizeStorageAccount(BaseThreatDetectionPolicyModel model, string storageEndpoint)
        {
            if (string.IsNullOrEmpty(storageEndpoint))
            {
                model.StorageAccountName = string.Empty;
                return;
            }
            var accountNameStartIndex = storageEndpoint.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase) ? 8 : 7; // https:// or http://
            var accountNameEndIndex = storageEndpoint.IndexOf(".blob", StringComparison.InvariantCultureIgnoreCase);
            model.StorageAccountName = storageEndpoint.Substring(accountNameStartIndex, accountNameEndIndex - accountNameStartIndex);
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
            if (string.IsNullOrEmpty(emailAccountAdminsState))
            {
                return false;
            }

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
        public void SetDatabaseThreatDetectionPolicy(DatabaseThreatDetectionPolicyModel model, string storageEndpointSuffix)
        {
            if (model.ThreatDetectionState == ThreatDetectionStateType.Enabled && 
                !IsRightServerVersionForThreatDetection(model.ResourceGroupName, model.ServerName))
            {
                    throw new Exception(Properties.Resources.ServerNotApplicableForThreatDetection);
            }

            var databaseSecurityAlertPolicyParameters = PolicizeDatabaseSecurityAlertModel(model, storageEndpointSuffix);
            ThreatDetectionCommunicator.SetDatabaseSecurityAlertPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, databaseSecurityAlertPolicyParameters);
        }

        /// <summary>
        /// Transforms the given model to its endpoints acceptable structure and sends it to the endpoint
        /// </summary>
        public void SetServerThreatDetectionPolicy(ServerThreatDetectionPolicyModel model, string storageEndpointSuffix)
        {
            if (model.ThreatDetectionState == ThreatDetectionStateType.Enabled && 
                !IsRightServerVersionForThreatDetection(model.ResourceGroupName, model.ServerName))
            {
                throw new Exception(Properties.Resources.ServerNotApplicableForThreatDetection);
            }

            var serverSecurityAlertPolicyParameters = PolicizeServerSecurityAlertModel(model, storageEndpointSuffix);
            ThreatDetectionCommunicator.SetServerSecurityAlertPolicy(model.ResourceGroupName, model.ServerName, serverSecurityAlertPolicyParameters);
        }

        /// <summary>
        /// Extracts the detection types from the given model
        /// </summary>
        private static string ExtractExcludedDetectionType(BaseThreatDetectionPolicyModel model)
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
        private ServerSecurityAlertPolicyCreateOrUpdateParameters PolicizeServerSecurityAlertModel(BaseThreatDetectionPolicyModel model, string storageEndpointSuffix)
        {
            var updateParameters = new ServerSecurityAlertPolicyCreateOrUpdateParameters();
            var properties = PopulatePolicyProperties(model, storageEndpointSuffix, new ServerSecurityAlertPolicyProperties()) as ServerSecurityAlertPolicyProperties;
            updateParameters.Properties = properties;
            return updateParameters;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        private DatabaseSecurityAlertPolicyCreateOrUpdateParameters PolicizeDatabaseSecurityAlertModel(BaseThreatDetectionPolicyModel model, string storageEndpointSuffix)
        {
            var updateParameters = new DatabaseSecurityAlertPolicyCreateOrUpdateParameters();
            var properties = PopulatePolicyProperties(model, storageEndpointSuffix, new DatabaseSecurityAlertPolicyProperties()) as DatabaseSecurityAlertPolicyProperties;
            updateParameters.Properties = properties;
            return updateParameters;
        }

        private BaseSecurityAlertPolicyProperties PopulatePolicyProperties(BaseThreatDetectionPolicyModel model, string storageEndpointSuffix, BaseSecurityAlertPolicyProperties properties)
        {
            properties.State = model.ThreatDetectionState.ToString();
            properties.EmailAddresses = model.NotificationRecipientsEmails ?? "";
            properties.EmailAccountAdmins = model.EmailAdmins ?
                ThreatDetectionStateType.Enabled.ToString() :
                ThreatDetectionStateType.Disabled.ToString();
            properties.DisabledAlerts = ExtractExcludedDetectionType(model);
            PopulateStoragePropertiesInPolicy(model, properties, storageEndpointSuffix);
            properties.RetentionDays = Convert.ToInt32(model.RetentionInDays);
            return properties;
        }

        private void PopulateStoragePropertiesInPolicy(BaseThreatDetectionPolicyModel model, BaseSecurityAlertPolicyProperties properties, string storageEndpointSuffix)
        {
            if (string.IsNullOrEmpty(model.StorageAccountName)) // can happen if the user didn't provide account name for a policy that lacked it 
            {
                throw new Exception(string.Format(Properties.Resources.NoStorageAccountWhenConfiguringThreatDetectionPolicy));
            }

            properties.StorageEndpoint = string.Format("https://{0}.blob.{1}", model.StorageAccountName, storageEndpointSuffix);
            properties.StorageAccountAccessKey =  AzureCommunicator.GetStorageKeys(model.StorageAccountName)[StorageKeyKind.Primary];
        }
    }
}
