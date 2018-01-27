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

using Microsoft.Azure.Commands.ApplicationInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ApplicationInsights.Management.Models;
using Microsoft.Rest.Azure;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ApplicationInsights
{
    [Cmdlet(VerbsCommon.New, ApplicationInsightsNounStr, SupportsShouldProcess = true), OutputType(typeof(PSApplicationInsightsComponent))]
    public class NewAzureApplicationInsights : ApplicationInsightsBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Application Insights Resource Name.")]
        [Alias(ApplicationInsightsComponentNameAlias, ComponentNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "Application Insights Resource Location.")]
        [LocationCompleter("Microsoft.Insights/components")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Application kind.")]
        [Alias(ApplicationKindAlias)]
        [ValidateSet(ApplicationType.WEB,
            ApplicationType.General,
            ApplicationType.NodeJs,
            ApplicationType.JAVA,
            IgnoreCase = true)]
        [PSDefaultValue(Value = ApplicationType.WEB)]
        public string Kind
        {
            get
            {
                return kind;
            }
            set
            {
                this.kind = value;
            }
        }
        private string kind = ApplicationType.WEB;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Component Tags.")]
        [ValidateNotNull]
        [Alias(TagsAlias)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ApplicationInsightsComponent existingComponent = null;
            try
            {
                existingComponent = this.AppInsightsManagementClient
                                               .Components
                                               .GetWithHttpMessagesAsync(ResourceGroupName, Name)
                                               .GetAwaiter()
                                               .GetResult()
                                               .Body;
            }
            catch (CloudException)
            {
                existingComponent = null;
            }

            if (existingComponent != null)
            {
                throw new System.ArgumentException($"component {Name} already existing in Resource Group {ResourceGroupName}");
            }

            ApplicationInsightsComponent newComponentProperties = new ApplicationInsightsComponent()
            {
                Location = this.Location,
                Kind = this.Kind,
                ApplicationType = Kind,
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true),
                RequestSource = "AzurePowerShell",
            };

            if (this.ShouldProcess(this.ResourceGroupName, $"Create Application Insights Component {this.Name}"))
            {
                var newComponentResponse = this.AppInsightsManagementClient
                                                    .Components
                                                    .CreateOrUpdateWithHttpMessagesAsync(
                                                        ResourceGroupName,
                                                        Name,
                                                        newComponentProperties)
                                                    .Result;

                this.WriteComponent(newComponentResponse.Body);
            }
        }
    }
}
