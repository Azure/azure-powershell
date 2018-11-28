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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.IotCentral.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.IotCentral.Models
{
    public class PSIotCentralApp
    {
        private ResourceIdentifier identifier;

        private ResourceIdentifier Identifier
        {
            get
            {
                if (this.identifier == null)
                {
                    this.identifier = new ResourceIdentifier(this.ResourceId);
                }
                return this.identifier;
            }
            set
            {
                this.identifier = value;
            }
        }

        public PSIotCentralApp(App iotCentralApp){
            this.ResourceId = iotCentralApp.Id;
            this.Name = iotCentralApp.Name;
            this.Type = iotCentralApp.Type;
            this.Location = iotCentralApp.Location;
            this.Tag = iotCentralApp.Tags; 
            this.Sku = new PSIotCentralAppSkuInfo() { Name = iotCentralApp.Sku.Name };
            this.ApplicationId = iotCentralApp.ApplicationId;
            this.DisplayName = iotCentralApp.DisplayName;
            this.Subdomain = iotCentralApp.Subdomain;
            this.Template = iotCentralApp.Template;
        }
        
        /// <summary>
        /// The Resource name.
        /// </summary>
        [Ps1Xml(Label = "Resource Name", Target = ViewControl.Table)]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the subdomain of the application.
        /// </summary>
        [Ps1Xml(Label = "Subdomain", Target = ViewControl.Table)]
        public string Subdomain { get; set; }

        /// <summary>
        /// Gets or sets the display name of the application.
        /// </summary>
        [Ps1Xml(Label = "Display Name", Target = ViewControl.Table)]
        public string DisplayName { get; set; }

        /// <summary>
        /// The Resource location.
        /// </summary>
        [Ps1Xml(Label = "Location", Target = ViewControl.Table)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the ID of the application template, which is a
        /// blueprint that defines the characteristics and behaviors of an
        /// application. Optional; if not specified, defaults to a blank
        /// blueprint and allows the application to be defined from scratch.
        /// </summary>
        [Ps1Xml(Label = "Template", Target = ViewControl.Table)]
        public string Template { get; set; }

        /// <summary>
        /// The Resource tags.
        /// </summary>
        [Ps1Xml(Label = "Tags", Target = ViewControl.Table)]
        public IDictionary<string, string> Tag { get; set; }

        /// <summary>
        /// Gets or sets a valid instance SKU.
        /// </summary>
        [Ps1Xml(Label = "Sku Name", Target = ViewControl.Table, ScriptBlock = "$_.Sku.Name")]
        public PSIotCentralAppSkuInfo Sku { get; set; }

        /// <summary>
        /// The Resource type.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// The subscription identifier.
        /// </summary>
        public string SubscriptionId
        {
            get
            {
                return this.Identifier.Subscription;
            }
        }

        /// <summary>
        /// The resource group name
        /// </summary>
        [Ps1Xml(Label = "Resource Group Name", Target = ViewControl.Table)]
        public string ResourceGroupName
        {
            get
            {
                return this.Identifier.ResourceGroupName;
            }
        }

        /// <summary>
        /// The Resource Id.
        /// </summary>
        public string ResourceId { get; private set; }

        /// <summary>
        /// Gets the ID of the application.
        /// </summary>
        [Ps1Xml(Label = "Application Id", Target = ViewControl.Table)]
        public string ApplicationId { get; private set; }
    }
}
