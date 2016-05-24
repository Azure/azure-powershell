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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.DevTestLabs;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DevTestLabs
{
    public class DevTestLabsCmdletBase : AzureRMCmdlet
    {
        internal IDevTestLabsClient _dataServiceClient;

        #region Input Parameter Definitions

        /// <summary>
        /// Lab name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Specifies a name an existing DevTest lab."
            )]
        [ValidateNotNullOrEmpty]
        public string LabName { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of an existing resource group that contains the lab.")]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        #endregion Input Parameter Definitions

        internal IDevTestLabsClient DataServiceClient
        {
            get
            {
                if (_dataServiceClient == null)
                {
                    _dataServiceClient = AzureSession.ClientFactory.CreateArmClient<DevTestLabsClient>(DefaultContext,
                        AzureEnvironment.Endpoint.ResourceManager);
                }

                return _dataServiceClient;
            }
            set
            {
                _dataServiceClient = value;
            }
        }
    }
}
