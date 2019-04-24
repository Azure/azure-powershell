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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.BackupRestore
{
    /// <summary>
    /// Restores a deleted Azure Web App's contents and settings to an existing web app
    /// </summary>
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeletedWebApp", SupportsShouldProcess = true, DefaultParameterSetName = FromDeletedResourceNameParameterSet), OutputType(typeof(PSSite))]
    public class RestoreAzureDeletedWebApp : WebAppBaseClientCmdLet
    {
        private const string FromDeletedAppParameterSet = "FromDeletedApp";
        private const string FromDeletedResourceNameParameterSet = "FromDeletedResourceName";

        // Note, there can be multiple deleted web apps with the same name and resource group. Internally each deleted app has a unique ID.
        [Parameter(Position = 0, ParameterSetName = FromDeletedAppParameterSet, Mandatory = true, HelpMessage = "The deleted Azure Web App.", ValueFromPipeline = true)]
        public PSAzureDeletedWebApp InputObject;

        [Parameter(Position = 0, ParameterSetName = FromDeletedResourceNameParameterSet, Mandatory = true, HelpMessage = "The resource group of the deleted Azure Web App.")]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ParameterSetName = FromDeletedResourceNameParameterSet, Mandatory = true, HelpMessage = "The name of the deleted Azure Web App.")]
        [ResourceNameCompleter("Microsoft.Web/deletedSites", "ResourceGroupName")]
        public string Name { get; set; }

        [Parameter(Position = 2, ParameterSetName = FromDeletedResourceNameParameterSet, Mandatory = false, HelpMessage = "The deleted Azure Web App slot.")]
        public string Slot { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The resource group containing the new Azure Web App.")]
        public string TargetResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the new Azure Web App.")]
        public string TargetName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the new Azure Web App slot.")]
        public string TargetSlot { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The App Service Plan for the new Azure Web App.")]
        public string TargetAppServicePlanName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Restore the web app's files, but do not restore the settings.")]
        public SwitchParameter RestoreContentOnly { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Use to recover a deleted app from a scale unit that is offline.")]
        public SwitchParameter UseDisasterRecovery { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do the restore without prompting for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            string deletedSiteId = GetDeletedSiteResourceId();
            ResolveTargetParameters();

            DeletedAppRestoreRequest restoreReq = new DeletedAppRestoreRequest()
            {
                DeletedSiteId = deletedSiteId,
                RecoverConfiguration = !this.RestoreContentOnly,
                UseDRSecondary = UseDisasterRecovery
            };

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

            PSSite restoredApp = new PSSite(WebsitesClient.GetWebApp(TargetResourceGroupName, TargetName, TargetSlot));
            WriteObject(restoredApp);
        }

        private string GetDeletedSiteResourceId()
        {
            switch (ParameterSetName)
            {
                case FromDeletedResourceNameParameterSet:
                    var deletedSites = WebsitesClient.GetDeletedSites().Where(ds =>
                    {
                        bool match = string.Equals(ds.ResourceGroup, ResourceGroupName, StringComparison.InvariantCultureIgnoreCase) &&
                            string.Equals(ds.Name, Name, StringComparison.InvariantCultureIgnoreCase);
                        if (!string.IsNullOrEmpty(Slot))
                        {
                            match = match && string.Equals(ds.Slot, Slot, StringComparison.InvariantCultureIgnoreCase);
                        }
                        return match;
                    });
                    if (!deletedSites.Any())
                    {
                        throw new Exception("Deleted app not found");
                    }
                    DeletedSite lastDeleted = deletedSites.OrderBy(ds => DateTime.Parse(ds.DeletedTimestamp)).Last();
                    if (deletedSites.Count() > 1)
                    {
                        WriteWarning("Found multiple matching deleted apps. Restoring the most recently deleted app, deleted at " + lastDeleted.DeletedTimestamp);
                    }
                    return "/subscriptions/" + DefaultContext.Subscription.Id + "/providers/Microsoft.Web/deletedSites/" + lastDeleted.DeletedSiteId;
                case FromDeletedAppParameterSet:
                    return "/subscriptions/" + InputObject.SubscriptionId + "/providers/Microsoft.Web/deletedSites/" + InputObject.DeletedSiteId;
                default:
                    throw new Exception("Parameter set error");
            }
        }

        private void ResolveTargetParameters()
        {
            switch (ParameterSetName)
            {
                case FromDeletedResourceNameParameterSet:
                    if (string.IsNullOrEmpty(TargetResourceGroupName))
                    {
                        TargetResourceGroupName = ResourceGroupName;
                    }
                    if (string.IsNullOrEmpty(TargetName))
                    {
                        TargetName = Name;
                    }
                    break;
                case FromDeletedAppParameterSet:
                    if (string.IsNullOrEmpty(TargetResourceGroupName))
                    {
                        TargetResourceGroupName = InputObject.ResourceGroupName;
                    }
                    if (string.IsNullOrEmpty(TargetName))
                    {
                        TargetName = InputObject.Name;
                    }
                    break;
            }
            if (string.IsNullOrEmpty(TargetSlot))
            {
                TargetSlot = string.Empty;
            }
        }
    }
}
