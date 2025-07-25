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
    /// Get-AzResourceManagementPrivateLink Cmdlet
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ResourceManagementPrivateLink",
        DefaultParameterSetName = Constants.ParameterSetNames.GetParameterSet), OutputType(typeof(PSResourceManagementPrivateLink))]
    public class GetAzureResourceManagementPrivateLink : PrivateLinksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.GetParameterSet,
            Mandatory = false,
            HelpMessage = Constants.HelpMessages.ResourceGroupName,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; } = null;

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.GetParameterSet,
            Mandatory = false,
            HelpMessage = Constants.HelpMessages.PrivateLinkName,
            Position = 1)]
        [Alias("PrivateLinkName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(Name))
                {
                    var response = ResourceManagementPrivateLinkClient.ResourceManagementPrivateLink.Get(
                        resourceGroupName: ResourceGroupName,
                        rmplName: Name);
                    WriteObject(new PSResourceManagementPrivateLink(response));
                }
                else if (string.IsNullOrEmpty(ResourceGroupName) && string.IsNullOrEmpty(Name))
                {
                    //List all the private links in a subscription no parameters needed
                    var response = ResourceManagementPrivateLinkClient.ResourceManagementPrivateLink.List();
                    var items = response.Value.Select(resourceManagementPrivateLink => new PSResourceManagementPrivateLink(resourceManagementPrivateLink))
                        .ToList();
                    WriteObject(items);
                }
                else if (!string.IsNullOrEmpty(ResourceGroupName) && string.IsNullOrEmpty(Name))
                {
                    //List all the private links in a resource group
                    var response = ResourceManagementPrivateLinkClient.ResourceManagementPrivateLink.ListByResourceGroup(resourceGroupName: ResourceGroupName);
                    var items = response.Value.Select(resourceManagementPrivateLink => new PSResourceManagementPrivateLink(resourceManagementPrivateLink))
                        .Where(psResourceManagementPrivateLink => psResourceManagementPrivateLink.Id.Contains($"/resourceGroups/{ResourceGroupName}/"))
                        .ToList();
                    WriteObject(items);
                }
            }
            catch (Exception ex)
            {
                this.WriteExceptionError(ex);
            }
        }
    }
}
