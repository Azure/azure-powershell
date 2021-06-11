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

using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Commands.Common.Authentication;
using AzureEnvironment = Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.CosmosDB
{
    /// <summary>
    /// Base class of Azure CosmosDB Cmdlet.
    /// </summary>
    public class AzureCosmosDBCmdletBase : AzureRMCmdlet
    {
        private Dictionary<string, List<string>> _defaultRequestHeaders;
        private CosmosDBManagementClient _cosmosDBManagementClient;
        public const string NameParameterSet = "ByNameParameterSet";
        public const string ObjectParameterSet = "ByObjectParameterSet";
        public const string ResourceIdParameterSet = "ByResourceIdParameterSet";
        public const string ParentObjectParameterSet = "ByParentObjectParameterSet";
        public const string FieldsParameterSet = "ByFieldsParameterSet";
        public const string ParentObjectDataActionsParameterSet = "ByParentObjectDataActionsParameterSet";
        public const string FieldsDataActionsParameterSet = "ByFieldsDataActionsParameterSet";
        public const string ParentObjectPermissionsParameterSet = "ByParentObjectPermissionsParameterSet";
        public const string FieldsPermissionsParameterSet = "ByFieldsPermissionsParameterSet";

        /// <summary>
        /// Gets or sets the CosmosDB Client
        /// </summary>
        public CosmosDBManagementClient CosmosDBManagementClient
        {
            get
            {
                return _cosmosDBManagementClient ??
                    (_cosmosDBManagementClient =
                    AzureSession.Instance.ClientFactory.CreateArmClient<CosmosDBManagementClient>(DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }

            set { _cosmosDBManagementClient = value; }
        }

        /// <summary>
        /// Gets or sets the default headers send with rest requests.
        /// </summary>
        public Dictionary<string, List<string>> DefaultRequestHeaders
        {
            get
            {
                return _defaultRequestHeaders ??
                       (_defaultRequestHeaders =
                           new Dictionary<string, List<string>> { { "UserAgent", new List<string> { "PowerShell" } } });
            }
            set { _defaultRequestHeaders = value; }
        }

        public void ConfirmAction(bool force, string actionMessage, Action action)
        {
            if (force || ShouldContinue(actionMessage, ""))
            {
                action();
            }
        }
    }
}