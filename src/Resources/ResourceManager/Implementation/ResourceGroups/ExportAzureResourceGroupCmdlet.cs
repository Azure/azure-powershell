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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Commands.Common.Authentication.Abstractions;
    using Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ErrorResponses;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ResourceGroups;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ResourceIds;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// Captures the specifies resource group as a template and saves it to a file on disk.
    /// </summary>
    [Cmdlet("Export", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ResourceGroup", SupportsShouldProcess = true), OutputType(typeof(PSObject))]
    public class ExportAzureResourceGroupCmdlet : ResourceManagerCmdletBaseWithApiVersion
    {
        /// <summary>
        /// Gets or sets the resource group name parameter.
        /// </summary>
        [Alias("ResourceGroup")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The output path of the template file.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        /// <summary>
        /// Export template parameter with default value.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Export template parameter with default value.")]
        public SwitchParameter IncludeParameterDefaultValue { get; set; }

        /// <summary>
        /// Export template with comments.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Export template with comments.")]
        public SwitchParameter IncludeComments { get; set; }

        /// <summary>
        /// Export template without resource name parameterization.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Skip resource name parameterization.")]
        public SwitchParameter SkipResourceNameParameterization { get; set; }

        /// <summary>
        /// Export template without any parameterization.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Skip all parameterization.")]
        public SwitchParameter SkipAllParameterization { get; set; }

        /// <summary>
        /// List of resourceIds to filter the results by.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "A list of resourceIds to filter the results by.")]
        public string[] Resource { get; set; }

        /// <summary>
        /// Gets or sets the force parameter.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        [CmdletParameterBreakingChange("ApiVersion", ChangeDescription = "Parameter is being deprecated without being replaced. Using the lastest possible API version will become the default behavior.")]
        [Parameter(Mandatory = false, HelpMessage = "When set, indicates the version of the resource provider API to use. If not specified, the API version is automatically determined as the latest available.")]
        [ValidateNotNullOrEmpty]
        public override string ApiVersion { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            string contents;

            if (ShouldProcess(ResourceGroupName, VerbsData.Export))
            {

                var resourceGroupId = this.GetResourceGroupId();

                if (! this.IsParameterBound(c => c.ApiVersion))
                {
                    var parameters = new ExportTemplateRequest
                    {
                        Resources = this.GetResourcesFilter(resourceGroupId: resourceGroupId),
                        Options = this.GetExportOptions(),
                    };

                    var exportedTemplate = ResourceManagerSdkClient.ExportResourceGroup(ResourceGroupName, parameters);

                    var template = exportedTemplate.Template;
                    contents = template.ToString();

                    var error = exportedTemplate.Error;

                    if(error != null)
                    {
                        WriteWarning(string.Format("{0} : {1}", error.Code, error.Message));
                        foreach (var detail in error.Details)
                        {
                            WriteWarning(string.Format("{0} : {1}", detail.Code, detail.Message));
                        }
                    }
                }
                else
                {
                    var parameters = new ExportTemplateParameters
                    {
                        Resources = this.GetResourcesFilter(resourceGroupId: resourceGroupId),
                        Options = this.GetExportOptions(),
                    };
                    var apiVersion = this.ApiVersion;
                    var operationResult = this.GetResourcesClient()
                       .InvokeActionOnResource<JObject>(
                           resourceId: resourceGroupId,
                           action: Constants.ExportTemplate,
                           parameters: parameters.ToJToken(),
                           apiVersion: apiVersion,
                           cancellationToken: this.CancellationToken.Value)
                       .Result;

                    var managementUri = this.GetResourcesClient()
                        .GetResourceManagementRequestUri(
                            resourceId: resourceGroupId,
                            apiVersion: apiVersion,
                            action: Constants.ExportTemplate);

                    var activity = string.Format("POST {0}", managementUri.PathAndQuery);
                    var resultString = this.GetLongRunningOperationTracker(activityName: activity,
                        isResourceCreateOrUpdate: false)
                        .WaitOnOperation(operationResult: operationResult);

                    var template = JToken.FromObject(JObject.Parse(resultString)["template"]);
                    contents = template.ToString();

                    if (JObject.Parse(resultString)["error"] != null)
                    {
                        if (JObject.Parse(resultString)["error"].TryConvertTo(out ExtendedErrorInfo error))
                        {
                            WriteWarning(string.Format("{0} : {1}", error.Code, error.Message));
                            foreach (var detail in error.Details)
                            {
                                WriteWarning(string.Format("{0} : {1}", detail.Code, detail.Message));
                            }
                        }
                    }
                }

                string path = FileUtility.SaveTemplateFile(
                    templateName: this.ResourceGroupName,
                    contents: contents,
                    outputPath:
                        string.IsNullOrEmpty(this.Path)
                            ? System.IO.Path.Combine(CurrentPath(), this.ResourceGroupName)
                            : this.TryResolvePath(this.Path),
                    overwrite: Force.IsPresent,
                    shouldContinue: ShouldContinue);

                WriteObject(PowerShellUtilities.ConstructPSObject(null, "Path", path));
            }
        }

        /// <summary>
        /// Gets the export template options
        /// </summary>
        private string GetExportOptions()
        {
            var options = new List<string>();
            if (this.IncludeComments.IsPresent)
            {
                options.Add("IncludeComments");
            }

            if (this.IncludeParameterDefaultValue.IsPresent)
            {
                options.Add("IncludeParameterDefaultValue");
            }

            if (this.SkipResourceNameParameterization.IsPresent)
            {
                options.Add("SkipResourceNameParameterization");
            }

            if (this.SkipAllParameterization.IsPresent)
            {
                options.Add("SkipAllParameterization");
            }

            return options.Any() ? string.Join(",", options) : null;
        }

        /// <summary>
        /// Gets the resources filter
        /// </summary>
        /// <param name="resourceGroupId"></param>
        private string[] GetResourcesFilter(string resourceGroupId)
        {
            if (this.Resource?.Any() != true)
            {
                return new[] { "*" };
            }

            var resourceIds = new List<ResourceGroupLevelResourceId>();
            var subscriptionId = DefaultContext.Subscription.GetId().ToString();
            foreach (var filteredResourceId in this.Resource)
            {
                if (!ResourceGroupLevelResourceId.TryParse(filteredResourceId, out var resourceId))
                {
                    throw new ArgumentException($"Unable to parse resourceId '{filteredResourceId}'");
                }

                if (!resourceId.SubscriptionId.EqualsInsensitively(subscriptionId) ||
                    !resourceId.ResourceGroup.EqualsInsensitively(this.ResourceGroupName))
                {
                    throw new ArgumentException($"ResourceId '{filteredResourceId}' does not belong to scope '{resourceGroupId}'");
                }

                resourceIds.Add(resourceId);
            }

            return resourceIds.Select(x => x.FullyQualifiedId).ToArray();
        }

        /// <summary>
        /// Gets the resource group Id from the supplied PowerShell parameters.
        /// </summary>
        protected string GetResourceGroupId()
        {
            return ResourceIdUtility.GetResourceId(
                subscriptionId: DefaultContext.Subscription.GetId(),
                resourceGroupName: this.ResourceGroupName,
                resourceType: null,
                resourceName: null);
        }
    }
}
