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

using Microsoft.Azure.Commands.ContainerRegistry.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet("Connect", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContainerRegistry", DefaultParameterSetName = WithoutNameAndPasswordParameterSet)]
    [OutputType(typeof(bool))]
    public class ConnectAzureContainerRegistry : ContainerRegistryDataPlaneCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Azure Container Registry Name.", ParameterSetName = WithoutNameAndPasswordParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Azure Container Registry Name.", ParameterSetName = WithNameAndPasswordParameterSet)]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        new public string RegistryName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "User Name For Azure Container Registry.", ParameterSetName = WithNameAndPasswordParameterSet)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Password For Azure Container Registry.", ParameterSetName = WithNameAndPasswordParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        public override void ExecuteCmdlet() {

            this.RegistryDataPlaneClient.SetEndPoint(this.RegistryName);

            if (ParameterSetName.Equals(WithoutNameAndPasswordParameterSet))
            {
                this.UserName = new Guid().ToString();
                this.Password = this.RegistryDataPlaneClient.GetToken(DataPlaneConstants.RefreshTokenKey);
            }

            string LoginScript = string.Format("'{2}' | docker login {0} -u {1} --password-stdin", this.RegistryDataPlaneClient.GetEndPoint(), this.UserName, this.Password);
            WriteObject(this.ExecuteScript<object>(LoginScript));
        }
    }
}
