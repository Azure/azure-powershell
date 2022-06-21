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
using Microsoft.Azure.Management.Internal.Resources;
using Azure.ResourceManager.IotCentral;
using Azure.ResourceManager.IotCentral.Models;
using Azure.ResourceManager.Models;
using Azure.Core;
using Azure;
//using Microsoft.Azure.Management.IotCentral;
//using Microsoft.Azure.Management.IotCentral.Models;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using ResourceProperties = Microsoft.Azure.Commands.Management.IotCentral.Properties;
using System;

namespace Microsoft.Azure.Commands.Management.IotCentral
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotCentralApp", SupportsShouldProcess = true)]
    [OutputType(typeof(PSIotCentralApp))]
    public class NewAzureRmIotCentralApp : IotCentralBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Subdomain for the IoT Central URL. Each application must have a unique subdomain.",
            ParameterSetName = InteractiveIotCentralParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Subdomain { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Custom display name for the IoT Central application. Default is resource name.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IoT Central application template name. Default is a custom application.")]
        [ValidateNotNullOrEmpty]
        public string Template { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Pricing tier for IoT Central applications. Default value is ST2.")]
        [PSArgumentCompleter("ST2")]
        [ValidateNotNullOrEmpty]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location of your IoT Central application. Default is the location of target resource group.")]
        [LocationCompleter("Microsoft.IoTCentral/IotApps")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Iot Central Application Resource Tags.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet as a job in the background.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Managed Identity Type. Can be SystemAssigned or None.")]
        [ValidateNotNullOrEmpty]
        public string Identity { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, ResourceProperties.Resources.NewIotCentralApp))
            {
                var Location = this.GetLocation();
                var Sku = new AppSkuInfo(this.GetAppSkuName());
                //var networkRuleSets = new NetworkRuleSets
                //{
                //    ApplyToDevices = false,
                //    ApplyToIoTCentral = false,
                //    DefaultAction = NetworkAction.Allow,
                //};
                //networkRuleSets.IPRules.Add(new NetworkRuleSetIPRule() { 
                //    FilterName = " ",
                //    IPMask = " ",
                //});
                var iotCentralAppData = new IotCentralAppData(Location, Sku)
                {
                    DisplayName = this.GetDisplayName(),
                    Subdomain = this.Subdomain,
                    Template = this.Template,
                    Identity = new SystemAssignedServiceIdentity(this.GetIdentity()),
                    //PublicNetworkAccess = PublicNetworkAccess.Enabled,
                    //NetworkRuleSets = new NetworkRuleSets(),
                };

                var resourceGroup = this.IotCentralClient.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{DefaultContext.Subscription.Id}/resourceGroups/{ResourceGroupName}"));
                //var identifierString1 = $"/subscriptions/{DefaultContext.Subscription.Id}/resourceGroups/{ResourceGroupName}";

                try
                {
                    var appCollection = resourceGroup.GetIotCentralApps();
                    //var appCollectionResponse = await appCollection.CreateOrUpdateAsync(WaitUntil.Completed, Name, iotCentralAppData, CancellationToken.None); // ASYNC
                    
                    var appCollectionResponse = appCollection.CreateOrUpdate(WaitUntil.Completed, Name, iotCentralAppData, CancellationToken.None); // SYNCH
                    var iotCentralApp = appCollectionResponse.Value;
                    //var iotCentralApp = appCollection.Get(Name,CancellationToken.None);

                    //var tagResponse = iotCentralApp.Value.SetTags(this.GetTags(), CancellationToken.None); // SYNCH
                    //var tagResponse = await iotCentralApp.SetTagsAsync(this.GetTags(), CancellationToken.None); // ASYNCH

                    //Thread.Sleep(2000); 
                    //var tagResponse = iotCentralApp.SetTags(this.GetTags(), CancellationToken.None); // SYNCH

                    // above is resulting in exception, below is not
                    if (this.GetTags() != null) {
                        foreach (var tag in this.GetTags())
                        {
                            iotCentralApp.AddTag(tag.Key, tag.Value, CancellationToken.None);
                        }
                    }
                    this.WriteObject(IotCentralUtils.ToPSIotCentralApp(iotCentralApp), enumerateCollection: false);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

        private IDictionary<string, string> GetTags()
        {
            if (this.Tag != null)
            {
                return TagsConversionHelper.CreateTagDictionary(this.Tag, true);
            }
            return null;
        }

        private string GetAppSkuName()
        {
            return this.Sku ?? PSIotCentralAppSku.ST2.ToString();
        }

        private string GetDisplayName()
        {
            if (string.IsNullOrEmpty(this.DisplayName))
            {
                return this.Name;
            }
            return this.DisplayName;
        }

        private string GetLocation()
        {
            if (string.IsNullOrEmpty(this.Location))
            {
                return this.ResourceManagementClient.ResourceGroups.Get(ResourceGroupName).Location;
            }
            return this.Location;
        }

        private string GetIdentity()
        {
            return (this.Identity ?? SystemAssignedServiceIdentityType.None).ToString();
        }
    }
}