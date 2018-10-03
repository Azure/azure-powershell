﻿// ----------------------------------------------------------------------------------
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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will create remote ps session with site
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppContainerPSSession", DefaultParameterSetName = ParameterSet1Name, SupportsShouldProcess = true)]
    [OutputType(typeof(System.Management.Automation.Runspaces.PSSession))]
    public class NewAzureRmWebAppContainerPSSession : WebAppBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSet1Name, Position = 1, Mandatory = false, HelpMessage = "The name of the web app slot.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SlotName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Create the PowerShell session without prompting for confirmation.")]
        public SwitchParameter Force { get; set; }
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ParameterSet2Name)
            {
                string rg, name, slot;
                Utilities.CmdletHelpers.TryParseWebAppMetadataFromResourceId(WebApp.Id, out rg, out name, out slot);
                ResourceGroupName = rg;
                Name = name;
                SlotName = slot;
            }

            if (this.Force.IsPresent || ShouldProcess(Properties.Resources.EnterContainerPSSessionConfirmation))
            {
                WebsitesClient.RunWebAppContainerPSSessionScript(this, ResourceGroupName, Name, SlotName, true);
            }
        }
    }
}