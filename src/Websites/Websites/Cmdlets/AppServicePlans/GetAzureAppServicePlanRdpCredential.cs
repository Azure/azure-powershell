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

using Microsoft.Azure.Management.WebSites;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.AppServicePlans
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AppServicePlanRdpCredential", DefaultParameterSetName = "S1")]
    [OutputType(typeof(PSCredential))]
    public class GetAzureAppServicePlanRdpCredential : AppServicePlanBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var details = WebsitesClient.WrappedWebsitesClient.AppServicePlans.GetServerFarmRdpPassword(ResourceGroupName, Name);
            if (string.IsNullOrEmpty(details?.RdpPassword))
            {
                throw new InvalidOperationException("The service did not return an RDP password. Enable RDP access on the Managed Instance plan and try again.");
            }

            WriteObject(new PSCredential("Administrator", SecureStringExtensions.ConvertToSecureString(details.RdpPassword)));
        }
    }
}
