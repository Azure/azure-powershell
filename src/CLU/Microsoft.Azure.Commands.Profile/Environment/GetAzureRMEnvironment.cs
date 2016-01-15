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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to get current Azure Environment from Profile.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmEnvironment")]
    [OutputType(typeof(PSAzureEnvironment))]
    [CliCommandAlias("env ls")]
    public class GetAzureRMEnvironmentCommand : AzureRMCmdlet
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The environment name")]
        [Alias("n")]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            // do not call begin processing there is no context needed for this cmdlet
            var sessionProfile = GetSessionVariableValue<PSAzureProfile>(AzurePowerShell.ProfileVariable, (PSAzureProfile)(new AzureRMProfile()));
            if (sessionProfile != null)
            {
                DefaultProfile = DefaultProfile ?? sessionProfile;
            }
        }


        protected override void ProcessRecord()
        {
            var profileClient = new RMProfileClient(AuthenticationFactory, ClientFactory, DefaultProfile);
            var result = profileClient.ListEnvironments(Name).Select(s => (PSAzureEnvironment)s).ToList();
            WriteObject(result, enumerateCollection: true);
        }
    }
}
