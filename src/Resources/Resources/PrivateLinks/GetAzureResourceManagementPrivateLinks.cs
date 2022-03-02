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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models.PrivateLinks;
using Microsoft.Azure.Commands.Resources.PrivateLinks.Common;
using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Azure.Commands.Resources.PrivateLinks
{
    /// <summary>
    /// Get-AzResourceManagementPrivateLinks Cmdlet
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ResourceManagementPrivateLinks",
        DefaultParameterSetName = Constants.ParameterSetNames.ListParameterSet,
        SupportsShouldProcess = true), OutputType(typeof(PSResourceManagementPrivateLink))]
    public class GetAzureResourceManagementPrivateLinks : PrivateLinksCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            try
            {
                //List all the private links in a subscription no parameters needed
                var response = ResourceManagementPrivateLinkClient.ResourceManagementPrivateLink.List();
                var items = response.Value.Select(resourceManagementPrivateLink => new PSResourceManagementPrivateLink(resourceManagementPrivateLink))
                    .ToList();
                WriteObject(items);
            }
            catch (Exception ex)
            {
                this.WriteExceptionError(ex);
            }
        }
    }
}
