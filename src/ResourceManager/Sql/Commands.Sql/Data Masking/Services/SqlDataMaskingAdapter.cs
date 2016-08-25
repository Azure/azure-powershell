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
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataMasking.Model;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Sql.DataMasking.Services
{
    /// <summary>
    /// The SqlDataMaskingClient class is responsible for transforming the data that was received form the endpoints to the cmdlets model of data masking policy and vice versa
    /// </summary>
    public class SqlDataMaskingAdapter
    {
        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        private AzureSubscription Subscription { get; set; }

        /// <summary>
        /// The communicator that this adapter uses
        /// </summary>
        private DataMaskingEndpointsCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        public SqlDataMaskingAdapter(AzureContext context)
        {
            Context = context;
            Subscription = context.Subscription;
            Communicator = new DataMaskingEndpointsCommunicator(Context);
        }

        /// <summary>
        ///  Checks whether the server is applicable for dynamic data masking
        /// </summary>
        private bool IsRightServerVersionForDataMasking(string resourceGroupName, string serverName, string clientId)
        {
            AzureSqlServerCommunicator dbCommunicator = new AzureSqlServerCommunicator(Context);
            Management.Sql.Models.Server server = dbCommunicator.Get(resourceGroupName, serverName, clientId);
            return server.Properties.Version == "12.0";
        }

        /// <summary>
        /// Provides a cmdlet model representation of a specific database's data making policy
        /// </summary>
        public DatabaseDataMaskingPolicyModel GetDatabaseDataMaskingPolicy(string resourceGroup, string serverName, string databaseName, string requestId)
        {
            if (!IsRightServerVersionForDataMasking(resourceGroup, serverName, requestId))
            {
                throw new Exception(Properties.Resources.ServerNotApplicableForDataMasking);
            }
            DataMaskingPolicy policy = Communicator.GetDatabaseDataMaskingPolicy(resourceGroup, serverName, databaseName, requestId);
            DatabaseDataMaskingPolicyModel dbPolicyModel = ModelizeDatabaseDataMaskingPolicy(policy);
            dbPolicyModel.ResourceGroupName = resourceGroup;
            dbPolicyModel.ServerName = serverName;
            dbPolicyModel.DatabaseName = databaseName;
            return dbPolicyModel;
        }

        /// <summary>
        /// Sets the data masking policy of a specific database to be based on the information provided by the model object
        /// </summary>
        public void SetDatabaseDataMaskingPolicy(DatabaseDataMaskingPolicyModel model, String clientId)
        {
            if (!IsRightServerVersionForDataMasking(model.ResourceGroupName, model.ServerName, clientId))
            {
                throw new Exception(Properties.Resources.ServerNotApplicableForDataMasking);
            }
            DataMaskingPolicyCreateOrUpdateParameters parameters = PolicizeDatabaseDataMaskingModel(model);
            Communicator.SetDatabaseDataMaskingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId, parameters);
        }

        /// <summary>
        /// Provides the data masking rule model for a specific data masking rule
        /// </summary>
        public IList<DatabaseDataMaskingRuleModel> GetDatabaseDataMaskingRules(string resourceGroup, string serverName, string databaseName, string requestId)
        {
            return Communicator.ListDataMaskingRules(resourceGroup, serverName, databaseName, requestId).
                Select(r => ModelizeDatabaseDataMaskingRule(r, resourceGroup, serverName, databaseName)).
                ToList();
        }

        /// <summary>
        /// Sets a data masking rule based on the information provided by the model object
        /// </summary>
        public void SetDatabaseDataMaskingRule(DatabaseDataMaskingRuleModel model, String clientId)
        {
            if (!IsRightServerVersionForDataMasking(model.ResourceGroupName, model.ServerName, clientId))
            {
                throw new Exception(Properties.Resources.ServerNotApplicableForDataMasking);
            }

            DatabaseDataMaskingPolicyModel policyModel = GetDatabaseDataMaskingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId);
            if (policyModel.DataMaskingState == DataMaskingStateType.Uninitialized)
            {
                policyModel.DataMaskingState = DataMaskingStateType.Enabled;
                SetDatabaseDataMaskingPolicy(policyModel, clientId);
            }
            DataMaskingRuleCreateOrUpdateParameters parameters = PolicizeDatabaseDataRuleModel(model);
            Communicator.SetDatabaseDataMaskingRule(model.ResourceGroupName, model.ServerName, model.DatabaseName, ExtractDataMaskingRuleId(model), clientId, parameters);
        }

        /// <summary>
        /// Removes a data masking rule based on the information provided by the model object
        /// </summary>
        public void RemoveDatabaseDataMaskingRule(DatabaseDataMaskingRuleModel model, String clientId)
        {
            if (!IsRightServerVersionForDataMasking(model.ResourceGroupName, model.ServerName, clientId))
            {
                throw new Exception(Properties.Resources.ServerNotApplicableForDataMasking);
            }
            DataMaskingRuleCreateOrUpdateParameters parameters = PolicizeDatabaseDataRuleModel(model);
            parameters.Properties.RuleState = SecurityConstants.Disabled;
            string ruleId = ExtractDataMaskingRuleId(model);
            Communicator.SetDatabaseDataMaskingRule(model.ResourceGroupName, model.ServerName, model.DatabaseName, ruleId, clientId, parameters);
        }

        private string ExtractDataMaskingRuleId(DatabaseDataMaskingRuleModel model)
        {
            var baseId = string.Format("{0}_{1}_{2}", model.SchemaName, model.TableName, model.ColumnName);
            Regex rgx = new Regex("[/\\\\#+=<>*%&:?.]");
            return rgx.Replace(baseId, "");
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="model">The data masking Policy model object</param>
        /// <returns>The communication model object</returns>
        private DataMaskingRuleCreateOrUpdateParameters PolicizeDatabaseDataRuleModel(DatabaseDataMaskingRuleModel model)
        {
            DataMaskingRuleCreateOrUpdateParameters updateParameters = new DataMaskingRuleCreateOrUpdateParameters();
            DataMaskingRuleProperties properties = new DataMaskingRuleProperties();
            updateParameters.Properties = properties;
            properties.Id = ExtractDataMaskingRuleId(model);
            properties.TableName = model.TableName;
            properties.SchemaName = model.SchemaName;
            properties.ColumnName = model.ColumnName;
            properties.MaskingFunction = PolicizeMaskingFunction(model.MaskingFunction);
            properties.PrefixSize = (model.PrefixSize == null) ? null : model.PrefixSize.ToString();
            properties.ReplacementString = model.ReplacementString;
            properties.SuffixSize = (model.SuffixSize == null) ? null : model.SuffixSize.ToString();
            properties.NumberFrom = (model.NumberFrom == null) ? null : model.NumberFrom.ToString();
            properties.NumberTo = (model.NumberTo == null) ? null : model.NumberTo.ToString();
            properties.RuleState = SecurityConstants.Enabled;
            return updateParameters;
        }

        /// <summary>
        /// Transforms a masking function in its model representation to its string representation
        /// </summary>
        private string PolicizeMaskingFunction(MaskingFunction maskingFunction)
        {
            switch (maskingFunction)
            {
                case MaskingFunction.NoMasking: return SecurityConstants.DataMaskingEndpoint.NoMasking;
                case MaskingFunction.Default: return SecurityConstants.DataMaskingEndpoint.Default;
                case MaskingFunction.CreditCardNumber: return SecurityConstants.DataMaskingEndpoint.CCN;
                case MaskingFunction.SocialSecurityNumber: return SecurityConstants.DataMaskingEndpoint.SSN;
                case MaskingFunction.Number: return SecurityConstants.DataMaskingEndpoint.Number;
                case MaskingFunction.Text: return SecurityConstants.DataMaskingEndpoint.Text;
                case MaskingFunction.Email: return SecurityConstants.DataMaskingEndpoint.Email;
            }
            return null;
        }

        /// <summary>
        /// Transforms a data masking rule to its cmdlet model representation
        /// </summary>
        private DatabaseDataMaskingRuleModel ModelizeDatabaseDataMaskingRule(DataMaskingRule rule, string resourceGroup, string serverName, string databaseName)
        {
            DatabaseDataMaskingRuleModel dbRuleModel = new DatabaseDataMaskingRuleModel();
            DataMaskingRuleProperties properties = rule.Properties;
            dbRuleModel.ResourceGroupName = resourceGroup;
            dbRuleModel.ServerName = serverName;
            dbRuleModel.DatabaseName = databaseName;
            dbRuleModel.ColumnName = properties.ColumnName;
            dbRuleModel.TableName = properties.TableName;
            dbRuleModel.SchemaName = properties.SchemaName;
            dbRuleModel.MaskingFunction = ModelizeMaskingFunction(properties.MaskingFunction);
            dbRuleModel.PrefixSize = ModelizeNullableUint(properties.PrefixSize);
            dbRuleModel.ReplacementString = properties.ReplacementString;
            dbRuleModel.SuffixSize = ModelizeNullableUint(properties.SuffixSize);
            dbRuleModel.NumberFrom = ModelizeNullableDouble(properties.NumberFrom);
            dbRuleModel.NumberTo = ModelizeNullableDouble(properties.NumberTo);
            return dbRuleModel;

        }

        /// <summary>
        /// Transforms a data masking function from its string representation to its model representation
        /// </summary>
        private MaskingFunction ModelizeMaskingFunction(string maskingFunction)
        {
            if (maskingFunction == SecurityConstants.DataMaskingEndpoint.Text) return MaskingFunction.Text;
            if (maskingFunction == SecurityConstants.DataMaskingEndpoint.Default) return MaskingFunction.Default;
            if (maskingFunction == SecurityConstants.DataMaskingEndpoint.Number) return MaskingFunction.Number;
            if (maskingFunction == SecurityConstants.DataMaskingEndpoint.SSN) return MaskingFunction.SocialSecurityNumber;
            if (maskingFunction == SecurityConstants.DataMaskingEndpoint.CCN) return MaskingFunction.CreditCardNumber;
            if (maskingFunction == SecurityConstants.DataMaskingEndpoint.Email) return MaskingFunction.Email;
            return MaskingFunction.NoMasking;
        }

        /// <summary>
        /// Transforms a value from its string representation to its nullable uint representation
        /// </summary>
        private uint? ModelizeNullableUint(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return Convert.ToUInt32(value);
        }

        /// <summary>
        /// Transforms a value from its string representation to its nullable double representation
        /// </summary>
        private double? ModelizeNullableDouble(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Transforms a data masking policy state from its string representation to its model representation
        /// </summary>
        private DataMaskingStateType ModelizePolicyState(string policyState)
        {
            if (SecurityConstants.DataMaskingEndpoint.Enabled == policyState)
            {
                return DataMaskingStateType.Enabled;
            }

            if (SecurityConstants.DataMaskingEndpoint.Disabled == policyState)
            {
                return DataMaskingStateType.Disabled;
            }

            return DataMaskingStateType.Uninitialized;
        }

        /// <summary>
        /// Transforms a data masking policy to its cmdlet model representation
        /// </summary>
        private DatabaseDataMaskingPolicyModel ModelizeDatabaseDataMaskingPolicy(DataMaskingPolicy policy)
        {
            DatabaseDataMaskingPolicyModel dbPolicyModel = new DatabaseDataMaskingPolicyModel();
            DataMaskingPolicyProperties properties = policy.Properties;
            dbPolicyModel.DataMaskingState = ModelizePolicyState(properties.DataMaskingState);
            dbPolicyModel.PrivilegedUsers = properties.ExemptPrincipals;
            return dbPolicyModel;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="model">The data masking Policy model object</param>
        /// <returns>The communication model object</returns>
        private DataMaskingPolicyCreateOrUpdateParameters PolicizeDatabaseDataMaskingModel(DatabaseDataMaskingPolicyModel model)
        {
            DataMaskingPolicyCreateOrUpdateParameters updateParameters = new DataMaskingPolicyCreateOrUpdateParameters();
            DataMaskingPolicyProperties properties = new DataMaskingPolicyProperties();
            updateParameters.Properties = properties;
            properties.DataMaskingState = (model.DataMaskingState == DataMaskingStateType.Disabled) ? SecurityConstants.DataMaskingEndpoint.Disabled : SecurityConstants.DataMaskingEndpoint.Enabled;
            properties.ExemptPrincipals = model.PrivilegedUsers ?? "";
            return updateParameters;
        }
    }
}