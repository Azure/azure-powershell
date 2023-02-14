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
using Microsoft.Azure.Management.IotCentral;
using Microsoft.Azure.Management.IotCentral.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using ResourceProperties = Microsoft.Azure.Commands.Management.IotCentral.Properties;

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
                var iotCentralApp = new App()
                {
                    DisplayName = this.GetDisplayName(),
                    Subdomain = this.Subdomain,
                    Template = this.Template,
                    Sku = new AppSkuInfo() { Name = this.GetAppSkuName() },
                    Location = this.GetLocation(),
                    Tags = this.GetTags(),
                    Identity = new SystemAssignedServiceIdentity(this.GetIdentity()),
                };

                this.IotCentralClient.Apps.CreateOrUpdate(this.ResourceGroupName, this.Name, iotCentralApp);
                App createdIotCentralApp = this.IotCentralClient.Apps.Get(this.ResourceGroupName, this.Name);
                this.WriteObject(IotCentralUtils.ToPSIotCentralApp(createdIotCentralApp), false);
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
            return this.Identity ?? SystemAssignedServiceIdentityType.None;
        }
    }
}