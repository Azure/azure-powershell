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

using Microsoft.Azure.Commands.Resources.Models.PrivateLinks;
using Microsoft.Azure.Commands.Resources.PrivateLinks.Common;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources.PrivateLinks
{
    /// <summary>
    /// New-AzResourceManagementPrivateLink Cmdlet
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ResourceManagementPrivateLink",
        DefaultParameterSetName = Constants.ParameterSetNames.PutParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSResourceManagementPrivateLink))]
    public class NewAzureResourceManagementPrivateLink : PrivateLinksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.PutParameterSet,
            Mandatory = false,
            HelpMessage = Constants.HelpMessages.ResourceGroupName,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; } = null;

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.PutParameterSet,
            Mandatory = true,
            HelpMessage = Constants.HelpMessages.PrivateLinkName,
            Position = 1)]
        [Alias("PrivateLinkName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.PutParameterSet,
            Mandatory = true,
            HelpMessage = Constants.HelpMessages.PrivateLinkLocation,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(Name))
                {
                    var response = ResourceManagementPrivateLinkClient.ResourceManagementPrivateLink.Put(
                        resourceGroupName: ResourceGroupName,
                        rmplName: Name,
                        parameters: new ResourceManagementPrivateLinkLocation(Location));
                    WriteObject(new PSResourceManagementPrivateLink(response));
                }
            }
            catch (Exception ex)
            {
                this.WriteExceptionError(ex);
            }
        }
    }
}
