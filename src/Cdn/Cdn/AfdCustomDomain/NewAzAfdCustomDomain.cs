// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Cdn.AfdHelpers;
using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdCustomDomain
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AfdCustomDomain", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdCustomDomain))]
    public class NewAzAfdCustomDomain : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdCustomDomainName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string CustomDomainName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdCustomDomainHostName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(AfdResourceProcessMessage.AfdCustomDomainCreateMessage, this.CustomDomainName, this.CreateAfdCustomDomain);
        }

        private void CreateAfdCustomDomain()
        {
            try
            {
                AFDDomain afdCustomDomain = new AFDDomain
                {
                    HostName = this.HostName
                };

                PSAfdCustomDomain psAfdCustomDomain = this.CdnManagementClient.AFDCustomDomains.Create(this.ResourceGroupName, this.ProfileName, this.CustomDomainName, afdCustomDomain).ToPSAfdCustomDomain();
                
                WriteObject(psAfdCustomDomain);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }
    }
}
