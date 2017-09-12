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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmApplicationSecurityGroup"), OutputType(typeof(PSApplicationSecurityGroup))]
    public class GetAzureApplicationSecurityGroupCommand : ApplicationSecurityGroupBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!string.IsNullOrEmpty(this.Name))
            {
                var applicationSecurityGroup = this.GetApplicationSecurityGroup(this.ResourceGroupName, this.Name);

                WriteObject(applicationSecurityGroup);
            }
            else
            {
                IPage<ApplicationSecurityGroup> asgPage;
                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    asgPage = this.ApplicationSecurityGroupClient.List(this.ResourceGroupName);
                }

                else
                {
                    asgPage = this.ApplicationSecurityGroupClient.ListAll();
                }

                // Get all resources by polling on next page link
                var asgList = ListNextLink<ApplicationSecurityGroup>.GetAllResourcesByPollingNextLink(asgPage, this.ApplicationSecurityGroupClient.ListNext);

                var psApplicationSecurityGroups = new List<PSApplicationSecurityGroup>();

                foreach (var asg in asgList)
                {
                    var psAsg = this.ToPsApplicationSecurityGroup(asg);
                    psAsg.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(asg.Id);
                    psApplicationSecurityGroups.Add(psAsg);
                }

                WriteObject(psApplicationSecurityGroups, true);
            }
        }
    }
}

