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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// Cmdlet to get existing resources.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmResource", DefaultParameterSetName = ByTagNameValueParameterSet), OutputType(typeof(PSResource))]
    public sealed class GetAzureResourceCmdlet : ResourceManagerCmdletBase
    {
        public const string ByResourceIdParameterSet = "ByResourceId";
        public const string ByTagObjectParameterSet = "ByTagObjectParameterSet";
        public const string ByTagNameValueParameterSet = "ByTagNameValueParameterSet";

        /// <summary>
        /// Gets or sets the resource name parameter.
        /// </summary>
        [Alias("Id")]
        [Parameter(ParameterSetName = ByResourceIdParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource name parameter.
        /// </summary>
        [Alias("ResourceName")]
        [Parameter(ParameterSetName = ByTagObjectParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource type parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByTagObjectParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        [ResourceTypeCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the OData query parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByTagObjectParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(ParameterSetName = ByTagObjectParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ByTagObjectParameterSet, Mandatory = true)]
        public Hashtable Tag { get; set; }

        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        public string TagName { get; set; }

        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        public string TagValue { get; set; }

        /// <summary>
        /// Collects subscription ids from the pipeline.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
        }

        /// <summary>
        /// Finishes the pipeline execution and runs the cmdlet.
        /// </summary>
        protected override void OnEndProcessing()
        {
            base.OnEndProcessing();

            this.RunCmdlet();
        }

        private void RunCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
                this.ResourceType = resourceIdentifier.ResourceType;
            }

            if (this.IsParameterBound(c => c.Tag))
            {
                this.TagName = TagsHelper.GetTagNameFromParameters(this.Tag, null);
                this.TagValue = TagsHelper.GetTagValueFromParameters(this.Tag, null);
            }

            var expression = QueryFilterBuilder.CreateFilter(
                subscriptionId: null,
                resourceGroup: null,
                resourceType: this.ResourceType,
                resourceName: null,
                tagName: this.TagName,
                tagValue: null,
                filter: this.ODataQuery);

            var odataQuery = new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(expression);
            var result = Enumerable.Empty<PSResource>();
            if (!string.IsNullOrEmpty(this.ResourceGroupName) && !this.ResourceGroupName.Contains('*'))
            {
                result = this.ResourceManagerSdkClient.ListByResourceGroup(this.ResourceGroupName, odataQuery);
            }
            else
            {
                result = this.ResourceManagerSdkClient.ListResources(odataQuery);
                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    result = FilterResourceGroupByWildcard(result);
                }
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                result = FilterResourceByWildcard(result);
            }

            if (!string.IsNullOrEmpty(this.TagValue))
            {
                result = result.Where(r => r.Tags != null && r.Tags.Values != null && r.Tags.Values.Contains(this.TagValue));
            }

            WriteObject(result, true);
        }

        private IEnumerable<PSResource> FilterResourceGroupByWildcard(IEnumerable<PSResource> result)
        {
            if (this.ResourceGroupName.StartsWith("*"))
            {
                this.ResourceGroupName = this.ResourceGroupName.TrimStart('*');
                if (this.ResourceGroupName.EndsWith("*"))
                {
                    this.ResourceGroupName = this.ResourceGroupName.TrimEnd('*');
                    result = result.Where(r => r.ResourceGroupName.IndexOf(this.ResourceGroupName, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else
                {
                    result = result.Where(r => r.ResourceGroupName.EndsWith(this.ResourceGroupName, StringComparison.OrdinalIgnoreCase));
                }
            }
            else if (this.ResourceGroupName.EndsWith("*"))
            {
                this.ResourceGroupName = this.ResourceGroupName.TrimEnd('*');
                result = result.Where(r => r.ResourceGroupName.StartsWith(this.ResourceGroupName, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        private IEnumerable<PSResource> FilterResourceByWildcard(IEnumerable<PSResource> result)
        {
            if (this.Name.StartsWith("*"))
            {
                this.Name = this.Name.TrimStart('*');
                if (this.Name.EndsWith("*"))
                {
                    this.Name = this.Name.TrimEnd('*');
                    result = result.Where(r => r.Name.IndexOf(this.Name, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else
                {
                    result = result.Where(r => r.Name.EndsWith(this.Name, StringComparison.OrdinalIgnoreCase));
                }
            }
            else if (this.Name.EndsWith("*"))
            {
                this.Name = this.Name.TrimEnd('*');
                result = result.Where(r => r.Name.StartsWith(this.Name, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                result = result.Where(r => string.Equals(r.Name, this.Name, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }
    }
}