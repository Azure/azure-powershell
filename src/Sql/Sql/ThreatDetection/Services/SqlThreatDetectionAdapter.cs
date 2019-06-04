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
using Microsoft.Azure.Management.Sql.Models;
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
        /// Provides a server threat detection policy model for the given server
        /// </summary>
        public ServerThreatDetectionPolicyModel GetServerThreatDetectionPolicy(string resourceGroup, string serverName)
        {
            if (!IsRightServerVersionForThreatDetection(resourceGroup, serverName))
            {
                throw new Exception(Properties.Resources.ServerNotApplicableForThreatDetection);
            }

            var threatDetectionPolicy = ThreatDetectionCommunicator.GetServerSecurityAlertPolicy(resourceGroup, serverName);

            var serverThreatDetectionPolicyModel = new ServerThreatDetectionPolicyModel()
            {
                ThreatDetectionState = ModelizeThreatDetectionState(threatDetectionPolicy.State.ToString()),
                NotificationRecipientsEmails = string.Join(";", threatDetectionPolicy.EmailAddresses.ToArray()),
                EmailAdmins = threatDetectionPolicy.EmailAccountAdmins == null ? false : threatDetectionPolicy.EmailAccountAdmins.Value,
                RetentionInDays = (uint)threatDetectionPolicy.RetentionDays,
            };

            serverThreatDetectionPolicyModel.ExcludedDetectionTypes = threatDetectionPolicy.DisabledAlerts.Where(alert => !string.IsNullOrEmpty(alert)).ToArray() ?? new string[] { };
            serverThreatDetectionPolicyModel.ResourceGroupName = resourceGroup;
            serverThreatDetectionPolicyModel.ServerName = serverName;

            ModelizeStorageAccount(serverThreatDetectionPolicyModel, threatDetectionPolicy.StorageEndpoint);

            return serverThreatDetectionPolicyModel;
        }

        /// <summary>
        /// Provides a managed instance threat detection policy model for the given managed instance
        /// </summary>
        public ManagedInstanceThreatDetectionPolicyModel GetManagedInstanceThreatDetectionPolicy(string resourceGroup, string managedInstanceName)
        {
            var threatDetectionPolicy = ThreatDetectionCommunicator.GetManageInstanceSecurityAlertPolicy(resourceGroup, managedInstanceName);

            var managedInstanceThreatDetectionPolicyModel = new ManagedInstanceThreatDetectionPolicyModel()
            {
                ThreatDetectionState = ModelizeThreatDetectionState(threatDetectionPolicy.State.ToString()),
                NotificationRecipientsEmails = string.Join(";", threatDetectionPolicy.EmailAddresses.ToArray()),
                EmailAdmins = threatDetectionPolicy.EmailAccountAdmins == null ? false : threatDetectionPolicy.EmailAccountAdmins.Value,
                RetentionInDays = (uint)threatDetectionPolicy.RetentionDays,
            };
            managedInstanceThreatDetectionPolicyModel.ExcludedDetectionTypes = threatDetectionPolicy.DisabledAlerts.Where(alert => !string.IsNullOrEmpty(alert)).ToArray() ?? new string[] { };
            managedInstanceThreatDetectionPolicyModel.ResourceGroupName = resourceGroup;
            managedInstanceThreatDetectionPolicyModel.ServerName = managedInstanceName;

            ModelizeStorageAccount(managedInstanceThreatDetectionPolicyModel, threatDetectionPolicy.StorageEndpoint);

            return managedInstanceThreatDetectionPolicyModel;
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
            model.ExcludedDetectionTypes = threatDetectionProperties.DisabledAlerts.Split(';').Where(alert => !string.IsNullOrEmpty(alert)).ToArray() ?? new string[] { };
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
        /// Transforms the given model to its endpoints acceptable structure and sends it to the endpoint
        /// </summary>
        public void SetManagedInstanceThreatDetectionPolicy(ManagedInstanceThreatDetectionPolicyModel model, string storageEndpointSuffix)
        {
            var managedInstanceSecurityAlertPolicyParameters = PolicizeManagedInstanceSecurityAlertModel(model, storageEndpointSuffix);
            ThreatDetectionCommunicator.SetManagedInstanceSecurityAlertPolicy(model.ResourceGroupName, model.ServerName, managedInstanceSecurityAlertPolicyParameters);
        }

        /// <summary>
        /// Extracts the detection types from the given model
        /// </summary>
        private static string[] ExtractExcludedDetectionType(BaseThreatDetectionPolicyModel model)
        {
            if (model.ExcludedDetectionTypes == null)
            {
                return null;
            }
            if (model.ExcludedDetectionTypes.Any(t => t == DetectionType.None))
            {
                if (model.ExcludedDetectionTypes.Count() == 1)
                {
                    return new string[0];
                }
                if (model.ExcludedDetectionTypes.Any(t => t != DetectionType.None))
                {
                    throw new Exception(Properties.Resources.InvalidDetectionTypeList);
                }  
            }
            return model.ExcludedDetectionTypes;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        private Management.Sql.Models.ServerSecurityAlertPolicy PolicizeServerSecurityAlertModel(BaseThreatDetectionPolicyModel model, string storageEndpointSuffix)
        {
            var policy = new Management.Sql.Models.ServerSecurityAlertPolicy()
            {
                State = model.ThreatDetectionState == ThreatDetectionStateType.Enabled
                    ? SecurityAlertPolicyState.Enabled
                    : SecurityAlertPolicyState.Disabled,
                DisabledAlerts = ExtractExcludedDetectionType(model),
                EmailAddresses = model.NotificationRecipientsEmails.Split(';').Where(mail => !string.IsNullOrEmpty(mail)).ToList(),
                EmailAccountAdmins = model.EmailAdmins,
                RetentionDays = Convert.ToInt32(model.RetentionInDays),
            };

            if (policy.State == SecurityAlertPolicyState.Enabled && !policy.EmailAccountAdmins.Value && !policy.EmailAddresses.Any())
            {
                // For new TD policy, make sure EmailAccountAdmins is true
                policy.EmailAccountAdmins = true;
            }

            if (string.IsNullOrEmpty(model.StorageAccountName))
            {
                policy.StorageEndpoint = null;
                policy.StorageAccountAccessKey = null;
            }
            else
            {
                BaseSecurityAlertPolicyProperties legacyProperties = new BaseSecurityAlertPolicyProperties();
                PopulateStoragePropertiesInPolicy(model, legacyProperties, storageEndpointSuffix);
                policy.StorageEndpoint = legacyProperties.StorageEndpoint;
                policy.StorageAccountAccessKey = legacyProperties.StorageAccountAccessKey;
            }

            return policy;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        private Management.Sql.Models.ManagedServerSecurityAlertPolicy PolicizeManagedInstanceSecurityAlertModel(BaseThreatDetectionPolicyModel model, string storageEndpointSuffix)
        {
            var policy = new Management.Sql.Models.ManagedServerSecurityAlertPolicy()
            {
                State = model.ThreatDetectionState == ThreatDetectionStateType.Enabled
                    ? SecurityAlertPolicyState.Enabled
                    : SecurityAlertPolicyState.Disabled,
                DisabledAlerts = ExtractExcludedDetectionType(model),
                EmailAddresses = model.NotificationRecipientsEmails.Split(';').Where(mail => !string.IsNullOrEmpty(mail)).ToList(),
                EmailAccountAdmins = model.EmailAdmins,
                RetentionDays = Convert.ToInt32(model.RetentionInDays),
            };

            if (policy.State == SecurityAlertPolicyState.Enabled && !policy.EmailAccountAdmins.Value && !policy.EmailAddresses.Any())
            {
                // For new TD policy, make sure EmailAccountAdmins is true
                policy.EmailAccountAdmins = true;
            }

            if (string.IsNullOrEmpty(model.StorageAccountName))
            {
                policy.StorageEndpoint = null;
                policy.StorageAccountAccessKey = null;
            }
            else
            {
                BaseSecurityAlertPolicyProperties legacyProperties = new BaseSecurityAlertPolicyProperties();
                PopulateStoragePropertiesInPolicy(model, legacyProperties, storageEndpointSuffix);
                policy.StorageEndpoint = legacyProperties.StorageEndpoint;
                policy.StorageAccountAccessKey = legacyProperties.StorageAccountAccessKey;
            }

            return policy;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        private DatabaseSecurityAlertPolicyCreateOrUpdateParameters PolicizeDatabaseSecurityAlertModel(BaseThreatDetectionPolicyModel model, string storageEndpointSuffix)
        {
            var updateParameters = new DatabaseSecurityAlertPolicyCreateOrUpdateParameters();
            var properties = PopulateDatabasePolicyProperties(model, storageEndpointSuffix, new DatabaseSecurityAlertPolicyProperties()) as DatabaseSecurityAlertPolicyProperties;
            updateParameters.Properties = properties;
            return updateParameters;
        }

        private BaseSecurityAlertPolicyProperties PopulateDatabasePolicyProperties(BaseThreatDetectionPolicyModel model, string storageEndpointSuffix, BaseSecurityAlertPolicyProperties properties)
        {
            properties.State = model.ThreatDetectionState.ToString();
            properties.EmailAddresses = model.NotificationRecipientsEmails ?? "";
            properties.EmailAccountAdmins = model.EmailAdmins ?
                ThreatDetectionStateType.Enabled.ToString() :
                ThreatDetectionStateType.Disabled.ToString();
            properties.DisabledAlerts = string.Join(";", ExtractExcludedDetectionType(model));
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
            properties.StorageAccountAccessKey = AzureCommunicator.GetStorageKeys(model.StorageAccountName)[StorageKeyKind.Primary];
        }
    }
}
