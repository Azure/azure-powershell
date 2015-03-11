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

using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Security.Model;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.Security.Services
{
    /// <summary>
    /// The SqlDataMaskingClient class is resposible for transforming the data that was recevied form the ednpoints to the cmdlets model of data masking policy and vice versa
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
        public AzureProfile Profile { get; set; }

        public SqlDataMaskingAdapter(AzureProfile profile, AzureSubscription subscription)
        {
            Profile = profile;
            Subscription = subscription;
            Communicator = new DataMaskingEndpointsCommunicator(profile, subscription);
        }

        /// <summary>
        /// Provides a cmdlet model representation of a specific database's data making policy
        /// </summary>
        public DatabaseDataMaskingPolicyModel GetDatabaseDataMaskingPolicy(string resourceGroup, string serverName, string databaseName, string requestId)
        {
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
            DataMaskingPolicyCreateOrUpdateParameters parameters = PolicizeDatabaseDataMaskingModel(model);
            Communicator.SetDatabaseDataMaskingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId, parameters);
        }

        /// <summary>
        /// Provides the data masking rule model for a specific data masking rule
        /// </summary>
        public IList<DatabaseDataMaskingRuleModel> GetDatabaseDataMaskingRule(string resourceGroup, string serverName, string databaseName, string requestId, string ruleId = null)
        {
            IList<DatabaseDataMaskingRuleModel> rules = 
                (from r in Communicator.ListDataMaskingRules(resourceGroup, serverName, databaseName, requestId) 
                where ruleId == null || r.Properties.Id == ruleId 
                select ModelizeDatabaseDataMaskingRule(r, resourceGroup, serverName, databaseName)).ToList();
            if(ruleId != null && rules.Count == 0)
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, Resources.DataMaskingRuleDoesNotExist, ruleId));
            }
            return rules;
        }

        /// <summary>
        /// Sets a data masking rule based on the infromation provided by the model object
        /// </summary>
        public void SetDatabaseDataMaskingRule(DatabaseDataMaskingRuleModel model, String clientId)
        {
            DataMaskingRuleCreateOrUpdateParameters parameters = PolicizeDatabaseDataRuleModel(model);
            Communicator.SetDatabaseDataMaskingRule(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.RuleId, clientId, parameters);
        }

        /// <summary>
        /// Removes a data masking rule based on the infromation provided by the model object
        /// </summary>
        public void RemoveDatabaseDataMaskingRule(DatabaseDataMaskingRuleModel model, String clientId)
        {
            Communicator.DeleteDataMaskingRule(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.RuleId, clientId);
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="policy">The data masking Policy object</param>
        /// <returns>The communication model object</returns>
        private DataMaskingRuleCreateOrUpdateParameters PolicizeDatabaseDataRuleModel(DatabaseDataMaskingRuleModel model)
        {
            DataMaskingRuleCreateOrUpdateParameters updateParameters = new DataMaskingRuleCreateOrUpdateParameters();
            DataMaskingRuleProperties properties = new DataMaskingRuleProperties();
            updateParameters.Properties = properties;
            properties.Id = model.RuleId;
            properties.AliasName = model.AliasName;
            properties.TableName = model.TableName;
            properties.ColumnName = model.ColumnName;
            properties.MaskingFunction = PolicizeMaskingFunction(model.MaskingFunction);
            properties.PrefixSize = (model.PrefixSize == null) ? null : model.PrefixSize.ToString();
            properties.ReplacementString = model.ReplacementString;
            properties.SuffixSize = (model.SuffixSize == null) ? null : model.SuffixSize.ToString();
            properties.NumberFrom = (model.NumberFrom == null) ? null : model.NumberFrom.ToString();
            properties.NumberTo = (model.NumberTo == null) ? null : model.NumberTo.ToString();
            return updateParameters;
        }

        /// <summary>
        /// Transforms a masking function in its model representation to its string representation
        /// </summary>
        private string PolicizeMaskingFunction(MaskingFunction maskingFunction)
        {
            switch(maskingFunction)
            {
                case MaskingFunction.NoMasking: return Constants.DataMaskingEndpoint.NoMasking;
                case MaskingFunction.Default: return Constants.DataMaskingEndpoint.Default;
                case MaskingFunction.CreditCardNumber: return Constants.DataMaskingEndpoint.CCN;
                case MaskingFunction.SocialSecurityNumber: return Constants.DataMaskingEndpoint.SSN;
                case MaskingFunction.Number: return Constants.DataMaskingEndpoint.Number;
                case MaskingFunction.Text: return Constants.DataMaskingEndpoint.Text;
                case MaskingFunction.Email: return Constants.DataMaskingEndpoint.Email;
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
            dbRuleModel.RuleId = properties.Id;
            dbRuleModel.AliasName = properties.AliasName;
            dbRuleModel.ColumnName = properties.ColumnName;
            dbRuleModel.TableName = properties.TableName;
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
            if (maskingFunction == Constants.DataMaskingEndpoint.Text) return MaskingFunction.Text;
            if (maskingFunction == Constants.DataMaskingEndpoint.Default) return MaskingFunction.Default;
            if (maskingFunction == Constants.DataMaskingEndpoint.Number) return MaskingFunction.Number;
            if (maskingFunction == Constants.DataMaskingEndpoint.SSN) return MaskingFunction.SocialSecurityNumber;
            if (maskingFunction == Constants.DataMaskingEndpoint.CCN) return MaskingFunction.CreditCardNumber;
            if (maskingFunction == Constants.DataMaskingEndpoint.Email) return MaskingFunction.Email;
            return MaskingFunction.NoMasking;
        }

        /// <summary>
        /// Transforms a nullable uint element to its string representation
        /// </summary>
        private uint? ModelizeNullableUint(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return null;
            }
            return Convert.ToUInt32(value);
        }

        /// <summary>
        /// Transforms a nullable double element to its string representation
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
        /// Transforms a data masking policy to its cmdlet model representation
        /// </summary>
        private DatabaseDataMaskingPolicyModel ModelizeDatabaseDataMaskingPolicy(DataMaskingPolicy policy)
        {
            DatabaseDataMaskingPolicyModel dbPolicyModel = new DatabaseDataMaskingPolicyModel();
            DataMaskingPolicyProperties properties = policy.Properties;
            dbPolicyModel.DataMaskingState = (properties.DataMaskingState == Constants.DataMaskingEndpoint.Enabled) ? DataMaskingStateType.Enabled : DataMaskingStateType.Disabled;
            dbPolicyModel.MaskingLevel = (properties.MaskingLevel == Constants.DataMaskingEndpoint.Standard) ? MaskingLevelType.Standard : MaskingLevelType.Extended;
            dbPolicyModel.PrivilegedLogins = properties.ExemptPrincipals;
            return dbPolicyModel;
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="policy">The data masking Policy object</param>
        /// <returns>The communication model object</returns>
        private DataMaskingPolicyCreateOrUpdateParameters PolicizeDatabaseDataMaskingModel(DatabaseDataMaskingPolicyModel model)
        {
            DataMaskingPolicyCreateOrUpdateParameters updateParameters = new DataMaskingPolicyCreateOrUpdateParameters();
            DataMaskingPolicyProperties properties = new DataMaskingPolicyProperties();
            updateParameters.Properties = properties;
            properties.DataMaskingState = (model.DataMaskingState == DataMaskingStateType.Enabled) ? Constants.DataMaskingEndpoint.Enabled : Constants.DataMaskingEndpoint.Disabled;
            properties.MaskingLevel = (model.MaskingLevel == MaskingLevelType.Standard) ? Constants.DataMaskingEndpoint.Standard: Constants.DataMaskingEndpoint.Extended;
            properties.ExemptPrincipals = (model.PrivilegedLogins == null) ? "" : model.PrivilegedLogins;
            return updateParameters;
        }
    }
}