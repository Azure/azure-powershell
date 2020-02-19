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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Support;
using System;
using System.Collections.Generic;
using static Microsoft.Azure.Commands.Support.Helpers.ResourceIdentifierHelper;

namespace Microsoft.Azure.Commands.Support.Common
{
    /// <summary>
    /// Base class of Azure Support Cmdlet.
    /// </summary>
    public class AzSupportCmdletBase : AzureRMCmdlet
    {
        private MicrosoftSupportClient supportClient;

        private Dictionary<string, List<string>> _defaultRequestHeaders;

        public const string GetByNameParameterSet = "GetByNameParameterSet";
        public const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";
        public const string ListParameterSet = "ListParameterSet";
        public const string CreateByNameParameterSet = "CreateByNameParameterSet";
        public const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";
        public const string UpdateByNameWithContactObjectParameterSet = "UpdateByNameWithContactObjectParameterSet";
        public const string UpdateByNameWithContactDetailParameterSet = "UpdateByNameWithContactDetailParameterSet";
        public const string UpdateByInputObjectWithContactObjectParameterSet = "UpdateByInputObjectWithContactObjectParameterSet";
        public const string UpdateByInputObjectWithContactDetailParameterSet = "UpdateByInputObjectWithContactDetailParameterSet";

        /// <summary>
        /// Gets or sets the Cdn management client.
        /// </summary>
        public MicrosoftSupportClient SupportClient
        {
            get
            {
                return supportClient ??
                       (supportClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<MicrosoftSupportClient>(DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { supportClient = value; }
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

        protected string GetId(string inputId, ResourceType resourceType)
        {
            var parsedId = inputId;
            if (!Guid.TryParse(parsedId, out _))
            {
                var resourceIdentifier = BuildResourceIdentifier(parsedId, resourceType);
                parsedId = resourceIdentifier.ResourceName;
            }

            return parsedId;
        }
    }
}