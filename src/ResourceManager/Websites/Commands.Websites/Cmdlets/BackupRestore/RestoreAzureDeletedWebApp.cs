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

using Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.BackupRestore
{
    /// <summary>
    /// Restores a deleted Azure Web App's contents and settings to an existing web app
    /// </summary>
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeletedWebApp"), OutputType(typeof(void))]
    public class RestoreAzureDeletedWebApp : WebAppBaseClientCmdLet
    {
        // Note, there can be multiple deleted web apps with the same name and resource group. Internally each deleted app has a unique ID.
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The deleted Azure Web App.", ValueFromPipeline = true)]
        public AzureDeletedWebApp InputObject;

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The resource group containing the new Azure Web App.", ValueFromPipelineByPropertyName = true)]
        public string TargetResourceGroupName { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The name of the new Azure Web App.", ValueFromPipelineByPropertyName = true)]
        public string TargetName { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The name of the new Azure Web App slot.", ValueFromPipelineByPropertyName = true)]
        public string TargetSlot { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The App Service Plan for the new Azure Web App.", ValueFromPipelineByPropertyName = true)]
        public string TargetAppServicePlanName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Restore the web app's files, but do not restore the settings.", ValueFromPipelineByPropertyName = true)]
        public SwitchParameter RestoreContentOnly { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do the restore without prompting for confirmation.", ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            DeletedAppRestoreRequest restoreReq = new DeletedAppRestoreRequest()
            {
                DeletedSiteId = "/subscriptions/" + InputObject.SubscriptionId + "/providers/Microsoft.Web/deletedSites/" + InputObject.DeletedSiteId,
                RecoverConfiguration = !this.RestoreContentOnly
            };

            if (string.IsNullOrEmpty(TargetName))
            {
                TargetName = InputObject.Name;
            }
            if (string.IsNullOrEmpty(TargetSlot))
            {
                TargetSlot = string.Empty;
            }

            Action restoreAction = () => WebsitesClient.RestoreDeletedWebApp(TargetResourceGroupName, TargetName, TargetSlot, restoreReq);

            if (WebsitesClient.WebAppExists(TargetResourceGroupName, TargetName, TargetSlot))
            {
                ConfirmAction(this.Force.IsPresent, "Target web app contents will be overwritten with the contents of the deleted app.",
                    "The deleted app has been restored.", TargetName, restoreAction);
            }
            else
            {
                if (string.IsNullOrEmpty(TargetAppServicePlanName))
                {
                    throw new Exception("Target app " + TargetName + " does not exist. Specify TargetAppServicePlanName for it to be created automatically.");
                }
                AppServicePlan plan = WebsitesClient.GetAppServicePlan(TargetResourceGroupName, TargetAppServicePlanName);
                if (plan == null)
                {
                    throw new Exception("Target App Service Plan " + TargetAppServicePlanName + " not found in target Resource Group " + TargetResourceGroupName);
                }
                Action createRestoreAction = () =>
                {
                    WebsitesClient.CreateWebApp(TargetResourceGroupName, TargetName, TargetSlot, plan.Location, TargetAppServicePlanName,
                        null, string.Empty, string.Empty);
                    restoreAction();
                };
                string confirmMsg = string.Format("This web app will be created. App Name: {0}, Resource Group: {1}", TargetResourceGroupName, TargetName);
                if (!string.IsNullOrEmpty(TargetSlot))
                {
                    confirmMsg += ", Slot: " + TargetSlot;
                }
                ConfirmAction(this.Force.IsPresent, confirmMsg, "The deleted app has been restored.", TargetName, createRestoreAction);
            }
        }
    }
}
