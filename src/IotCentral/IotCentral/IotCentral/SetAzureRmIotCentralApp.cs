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

using Microsoft.Azure.Commands.IotCentral.Common;
using Microsoft.Azure.Commands.IotCentral.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Azure.ResourceManager.IotCentral;
using Azure.ResourceManager.IotCentral.Models;
using Azure.Core;
//using Microsoft.Azure.Management.IotCentral;
//using Microsoft.Azure.Management.IotCentral.Models;
using System.Collections;
using System.Management.Automation;
using ResourceProperties = Microsoft.Azure.Commands.Management.IotCentral.Properties;
using Azure;
using Azure.ResourceManager.Models;
using System.Threading;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.IotCentral
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotCentralApp", SupportsShouldProcess = true, DefaultParameterSetName = ResourceIdParameterSet)]
    [OutputType(typeof(PSIotCentralApp))]
    public class SetAzureRmIotCentralApp : IotCentralFullParameterSetCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "Custom Display Name of the Iot Central Application.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Subdomain of the IoT Central Application.")]
        [ValidateNotNullOrEmpty]
        public string Subdomain { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Iot Central Application Resource Tags.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Pricing tier for IoT Central applications. Default value is ST2.")]
        [PSArgumentCompleter("ST2")]
        [ValidateNotNullOrEmpty]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Managed Identity Type. Can be None or SystemAssigned.")]
        public string Identity { get; set; }

        public override void ExecuteCmdlet()
        {
            this.SetNameAndResourceGroup();
            if (ShouldProcess(Name, ResourceProperties.Resources.SetIotCentralApp))
            {
                var rg = IotCentralClient.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{DefaultContext.Subscription.Id}/resourceGroups/{ResourceGroupName}"));

                //var iotCentralAppResponse = await subscription.GetIotCentralAppAsync(Name, CancellationToken.None); // ASYNCH
                var appResourceResponse = rg.GetIotCentralApp(Name, CancellationToken.None);  // SYNCH

                var iotCentralAppResource = appResourceResponse.Value;
                IotCentralAppPatch applicationPatch = CreateApplicationPatch();

                //await iotCentralAppResource.UpdateAsync(WaitUntil.Completed, applicationPatch);  // ASYNCH
                iotCentralAppResource.Update(WaitUntil.Completed, applicationPatch);  // SYNCH
                
                this.WriteObject(IotCentralUtils.ToPSIotCentralApp(iotCentralAppResource));
            }
        }

        private IotCentralAppPatch CreateApplicationPatch()
        {
            var appPatch = new IotCentralAppPatch() {
                SkuName = this.Sku,
                DisplayName = this.DisplayName,
                Subdomain = this.Subdomain,
                //Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, true),
            };

            if (this.GetTags() != null)
            {
                foreach (var tag in this.GetTags())
                {
                    appPatch.Tags.Add(tag.Key, tag.Value);
                }
            }
            if (!string.IsNullOrEmpty(this.Identity))
            {
                appPatch.Identity = new SystemAssignedServiceIdentity(this.Identity);
            }

            return appPatch;
        }
        private IDictionary<string, string> GetTags() // considering moving this into utils along with the one in NewAzureRMIot
        {
            if (this.Tag != null)
            {
                return TagsConversionHelper.CreateTagDictionary(this.Tag, true);
            }
            return null;
        }
    }
}