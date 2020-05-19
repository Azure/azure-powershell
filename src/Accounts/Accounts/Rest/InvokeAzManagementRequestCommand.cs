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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using Microsoft.Azure.Internal.Common;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagementRequest", DefaultParameterSetName = ByUri),OutputType(typeof(string))]
    public class InvokeAzManagementRequestCommand : AzureRMCmdlet
    {
        #region Parameter Set

        public const string ByUri = "ByUri";

        #endregion



        #region Parameter

        [Parameter(ParameterSetName = ByUri, Mandatory = true, HelpMessage = "Target Uri")]
        public string Uri { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Api Version")]
        public string ApiVersion { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Http Method")]
        public string Method { get; set; }

        #endregion

        private IAzureRestClient _client;
        private IAzureRestClient ServiceClient
        {
            get
            {
                if (_client == null)
                {
                    IAzureContext context = DefaultContext;
                    var clientFactory = AzureSession.Instance.ClientFactory;
                    _client = clientFactory.CreateArmClient<AzureRestClient>(context, AzureEnvironment.Endpoint.ResourceManager);
                }

                return _client;
            }
        }

        public override void ExecuteCmdlet()
        {
            string response = ServiceClient
                .Operations
                .BeginHttpGetMessagesAsyncGeneric(Uri, ApiVersion)
                .GetAwaiter()
                .GetResult();

            WriteObject(response);
        }
    } 

}