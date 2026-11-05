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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    using PowerShell = System.Management.Automation.PowerShell;

    [Cmdlet("Connect", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContainerRegistry", DefaultParameterSetName = WithoutNameAndPasswordParameterSet)]
    [OutputType(typeof(bool))]
    public class ConnectAzureContainerRegistry : ContainerRegistryCmdletBase
    {
        protected const string WithoutNameAndPasswordParameterSet = "WithoutNameAndPasswordParameterSet";
        protected const string WithNameAndPasswordParameterSet = "WithNameAndPasswordParameterSet";

        [Parameter(Mandatory = true, HelpMessage = "Azure Container Registry Name.", ParameterSetName = WithoutNameAndPasswordParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Azure Container Registry Name.", ParameterSetName = WithNameAndPasswordParameterSet)]
        [Alias("RegistryName")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern(ContainerRegistryDataPlaneClient.RegistryNamePattern)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "User Name For Azure Container Registry.", ParameterSetName = WithNameAndPasswordParameterSet)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Password For Azure Container Registry.", ParameterSetName = WithNameAndPasswordParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithoutNameAndPasswordParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = WithNameAndPasswordParameterSet)]
        public SwitchParameter ExposeToken { get; set; }
        protected override void InitDebuggingFilter()
        {
            AddDebuggingFilter(new Regex("(\\s*access_token\\s*=\\s*)[^\"]+"));
            AddDebuggingFilter(new Regex("(\\s*refresh_token\\s*=\\s*)[^\"]+"));
            AddDebuggingFilter(new Regex("(\\s*\"refresh_token\"\\s*:\\s*)\"[^\"]+\""));
            base.InitDebuggingFilter();
        }

        public override void ExecuteCmdlet() {

            this.RegistryDataPlaneClient.SetEndPoint(this.Name);

            if (ParameterSetName.Equals(WithoutNameAndPasswordParameterSet))
            {
                this.UserName = new Guid().ToString();
                this.Password = this.RegistryDataPlaneClient.GetRefreshToken();
            }

            if (ExposeToken) {
                WriteWarning("You can perform manual login using the provided access token, for example: 'docker login <loginServer> -u 00000000-0000-0000-0000-000000000000 -p <accessToken>'");
                var cred = new
                {
                    loginServer = Name + ".azurecr.io",
                    accessToken = this.Password.ConvertToSecureString()
                };
                WriteObject(cred);
            } else
            {
                using (var powershell = PowerShell.Create(RunspaceMode.CurrentRunspace))
                {
                    powershell.AddCommand("docker")
                        .AddArgument("login")
                        .AddArgument(this.RegistryDataPlaneClient.GetEndPoint())
                        .AddArgument("-u")
                        .AddArgument(this.UserName)
                        .AddArgument("--password-stdin");
                    var output = powershell.Invoke<object>(new[] { this.Password });
                    foreach (var error in powershell.Streams.Error)
                    {
                        WriteError(error);
                    }
                    foreach (var verbose in powershell.Streams.Verbose)
                    {
                        WriteVerbose(verbose.Message);
                    }
                    foreach (var warning in powershell.Streams.Warning)
                    {
                        WriteWarning(warning.Message);
                    }
                    WriteObject(new List<object>(output));
                }
            }
        }
    }
}
