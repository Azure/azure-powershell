﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ApplicationInsights.ApplicationInsights
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationInsightsLinkedStorageAccount", DefaultParameterSetName = ByResourceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveApplicationInsightsLinkedStorageAccount : ApplicationInsightsBaseCmdlet
    {
        internal const string ByResourceNameParameterSet = "ByResourceNameParameterSet";
        internal const string ByInputObjectParameterSet = "ByInputObjectParameterSet";
        internal const string ByResourceIdParameterSet = "ByResourceIdParameterSet";

        #region Cmdlet parameters

        [Parameter(
            ParameterSetName = ByResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ByResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "Component Name")]
        [ValidateNotNullOrEmpty]
        public string ComponentName { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "PSApplicationInsightsComponent")]
        [ValidateNotNullOrEmpty]
        public PSApplicationInsightsComponent InputObject { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "Component ResourceId")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceId = this.InputObject.Id;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                ResourceIdentifier identifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = identifier.ResourceGroupName;
                this.ComponentName = identifier.ResourceName;
            }

            if (this.ShouldProcess(this.ResourceGroupName, $"Remove Linked Storage Account for Application Insights Component {this.ComponentName}"))
            {
                var response = this.AppInsightsManagementClient
                                                             .ComponentLinkedStorageAccounts
                                                             .DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.ComponentName)
                                                             .GetAwaiter()
                                                             .GetResult();
                                                             
                WriteObject(true);
            }     
        }
    }
}
