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

using Microsoft.Azure.Commands.ActiveDirectory.Models;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Creates a new service principal.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmADServicePrincipal"), OutputType(typeof(PSADServicePrincipal))]
    [CliCommandAlias("ad service principal create")]
    public class NewAzureADServicePrincipalCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The application id for which service principal is created.")]
        [Alias("id")]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Create the service principal with account disabled.")]
        [Alias("d")]
        public SwitchParameter DisableAccount { get; set; }

        protected override void ProcessRecord()
        {
            CreatePSServicePrincipalParameters createParameters = new CreatePSServicePrincipalParameters
            {
                ApplicationId = ApplicationId,
                AccountEnabled = !DisableAccount.IsPresent
            };

            WriteObject(ActiveDirectoryClient.CreateServicePrincipal(createParameters));
        }
    }
}
