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
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// Gets the deleted Azure Web Apps in a subscription
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeletedWebApp"), OutputType(typeof(PSAzureDeletedWebApp))]
    public class GetAzureDeletedWebApp : WebAppBaseClientCmdLet
    {
        [Parameter(Position = 0, Mandatory = false, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = "The name of the web app.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            IEnumerable<PSAzureDeletedWebApp> deletedSites = WebsitesClient.GetDeletedSites()
                .Where(ds => ds.DeletedSiteId.HasValue)
                .Select(ds =>
                new PSAzureDeletedWebApp()
                {
                    DeletedSiteId = ds.DeletedSiteId.Value,
                    DeletionTime = DateTime.Parse(ds.DeletedTimestamp),
                    SubscriptionId = DefaultContext.Subscription.Id,
                    ResourceGroupName = ds.ResourceGroup,
                    Name = ds.DeletedSiteName,
                    Slot = ds.Slot
                }
            );

            // Filter out deleted sites older than 30 days.
            // They can't be restored and eventually will not be returned by the GetDeletedSites API.
            deletedSites = deletedSites.Where(ds => ds.DeletionTime >= DateTime.UtcNow.AddDays(-30)).OrderBy(ds => ds.DeletionTime);

            if (!string.IsNullOrEmpty(ResourceGroupName))
            {

                deletedSites = deletedSites.Where(ds => string.Equals(ResourceGroupName, ds.ResourceGroupName, StringComparison.InvariantCultureIgnoreCase));
            }
            if (!string.IsNullOrEmpty(Name))
            {
                deletedSites = deletedSites.Where(ds => string.Equals(Name, ds.Name, StringComparison.InvariantCultureIgnoreCase));
            }
            if (!string.IsNullOrEmpty(Slot))
            {
                deletedSites = deletedSites.Where(ds => string.Equals(Slot, ds.Slot, StringComparison.InvariantCultureIgnoreCase));
            }

            WriteObject(deletedSites, true);
        }
    }
}
