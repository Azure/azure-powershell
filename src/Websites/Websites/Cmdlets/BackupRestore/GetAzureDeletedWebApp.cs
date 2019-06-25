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
        [ResourceNameCompleter("Microsoft.Web/deletedSites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The location of the deleted app.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            IEnumerable<string> locations;
            if (string.IsNullOrEmpty(Location))
            {
                locations = ResourcesClient.GetDeletedSitesLocations();
            }
            else
            {
                locations = new List<string> { Location };
            }

            IEnumerable<PSAzureDeletedWebApp> deletedSites = WebsitesClient.GetDeletedSitesFromLocations(locations)
                .Where(ds => ds.DeletedSiteId.HasValue)
                .Select(ds => new PSAzureDeletedWebApp(ds, DefaultContext.Subscription.Id));

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
