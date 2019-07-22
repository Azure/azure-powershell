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

using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.DataBox.Common
{
    /// <summary>
    /// Base class of Azure Databox Cmdlet.
    /// </summary>
    public class AzureDataBoxCmdletBase : AzureRMCmdlet
    {
        private DataBoxManagementClient _dataBoxManagementClient;

        private Dictionary<string, List<string>> _defaultRequestHeaders;

        public const string ObjectParameterSet = "ByObjectParameterSet";
        public const string FieldsParameterSet = "ByFieldsParameterSet";
        public const string ResourceIdParameterSet = "ByResourceIdParameterSet";
        public const string CacheExpirationActionParameterSet = "CacheExpirationActionParameterSet";
        public const string HeaderActionParameterSet = "HeaderActionParameterSet";
        public const string UrlRedirectActionParameterSet = "UrlRedirectActionParameterSet";


        /// <summary>
        /// Gets or sets the Databox management client.
        /// </summary>
        public DataBoxManagementClient DataBoxManagementClient
        {
            get
            {
                return _dataBoxManagementClient ??
                       (_dataBoxManagementClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<DataBoxManagementClient>(DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _dataBoxManagementClient = value; }
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