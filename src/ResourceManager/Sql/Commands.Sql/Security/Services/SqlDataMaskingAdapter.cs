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

using Microsoft.Azure.Commands.Sql.Security.Model;
using Microsoft.Azure.Common.Extensions.Models;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.Azure.Commands.Sql.Security.Services
{
    /// <summary>
    /// The SqlDataMaskingClient class is resposible for transforming the data that was recevied form the ednpoints to the cmdlets model of data masking policy and vice versa
    /// </summary>
    public class SqlDataMaskingAdapter
    {
        private AzureSubscription Subscription { get; set; }

        private DataMaskingEndpointsCommunicator Communicator { get; set; }

        public SqlDataMaskingAdapter(AzureSubscription subscription)
        {
            Subscription = subscription;
            Communicator = new DataMaskingEndpointsCommunicator(subscription);
        }

        public DatabaseDataMaskingPolicyModel GetDatabaseDataMaskingPolicy(string resourceGroup, string serverName, string databaseName, string requestId)
        {
            DataMaskingPolicy policy = Communicator.GetDatabaseDataMaskingPolicy(resourceGroup, serverName, databaseName, requestId);
            DatabaseDataMaskingPolicyModel dbPolicyModel = ModelizeDatabaseDataMaskingPolicy(policy);
            dbPolicyModel.ResourceGroupName = resourceGroup;
            dbPolicyModel.ServerName = serverName;
            dbPolicyModel.DatabaseName = databaseName;
            return dbPolicyModel;
        }

        public void SetDatabaseDataMaskingPolicy(DatabaseDataMaskingPolicyModel model, String clientId)
        {
            DataMaskingPolicyCreateOrUpdateParameters parameters = PolicizeDatabaseDataMaskingModel(model);
            Communicator.SetDatabaseDataMaskingPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId, parameters);
        }

        public IList<DatabaseDataMaskingRuleModel> GetDatabaseDataMaskingRule(string resourceGroup, string serverName, string databaseName, string requestId, string ruleId = null)
        {
            IList<DatabaseDataMaskingRuleModel> rules = 
                (from r in Communicator.ListDataMaskingRules(resourceGroup, serverName, databaseName, requestId) 
                where ruleId == null || r.Properties.Id == ruleId 
                select ModelizeDatabaseDataMaskingRule(r, resourceGroup, serverName, databaseName)).ToList();
            if(ruleId != null && rules.Count == 0)
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.DataMaskingRuleDoesNotExist, ruleId));
            }
            return rules;
        }

        public void SetDatabaseDataMaskingRule(DatabaseDataMaskingRuleModel model, String clientId)
        {
            DataMaskingRuleCreateOrUpdateParameters parameters = PolicizeDatabaseDataRuleModel(model);
            Communicator.SetDatabaseDataMaskingRule(model.ResourceGroupName, model.ServerName, model.DatabaseName, model.RuleId, clientId, parameters);
        }

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

        private uint? ModelizeNullableUint(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return null;
            }
            return Convert.ToUInt32(value);
        }

        private double? ModelizeNullableDouble(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return Convert.ToDouble(value);
        }

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
