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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SharedVMExtensionVersionDeprecation", DefaultParameterSetName = DefaultParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSharedVMExtensionVersion))]
    public class SetAzSharedVMExtensionVersionDeprecation : ComputeAutomationBaseCmdlet
    {
        protected const string DefaultParameterSet = "DefaultParameter";
        protected const string ResourceIdParameterSet = "ResourceIdParameter";
        protected const string InputObjectParameterSet = "InputObjectParameter";

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the shared VM extension.")]
        public string SharedVMExtensionName { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The version of the shared VM extension.")]
        public string Version { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the shared VM extension version.")]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = InputObjectParameterSet,
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The shared VM extension version object, typically piped in from Get-AzSharedVMExtensionVersion.")]
        [ValidateNotNull]
        public PSSharedVMExtensionVersion InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The deprecation state to apply to the shared VM extension version.")]
        [ValidateSet(ExtensionState.Active, ExtensionState.ScheduledForDeprecation, ExtensionState.Deprecated, IgnoreCase = true)]
        public string DeprecationState { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The number of days from now after which the shared VM extension version is considered deprecated. Required when -DeprecationState is 'ScheduledForDeprecation' and no deprecation time is already set. When reactivating (-DeprecationState 'Active') with new deprecation data, must be specified together with -DeprecationType.")]
        [ValidateRange(0, int.MaxValue)]
        public int? DaysUntilDeprecation { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The scope of deprecation, indicating which set of versions are affected.")]
        [ValidateSet(DeprecationType.Hotfix, DeprecationType.Patch, DeprecationType.Minor, DeprecationType.Major, IgnoreCase = true)]
        public string DeprecationType { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName;
                string sharedVMExtensionName;
                string version;
                switch (this.ParameterSetName)
                {
                    case ResourceIdParameterSet:
                        ParseSharedVMExtensionVersionResourceId(this.ResourceId, out resourceGroupName, out sharedVMExtensionName, out version);
                        break;
                    case InputObjectParameterSet:
                        ParseSharedVMExtensionVersionResourceId(this.InputObject.Id, out resourceGroupName, out sharedVMExtensionName, out version);
                        break;
                    default:
                        resourceGroupName = this.ResourceGroupName;
                        sharedVMExtensionName = this.SharedVMExtensionName;
                        version = this.Version;
                        break;
                }

                if (ShouldProcess(version, "Update deprecation state for shared VM extension version"))
                {
                    var existing = SharedVMExtensionVersionClient.GetWithHttpMessagesAsync(resourceGroupName, sharedVMExtensionName, version).GetAwaiter().GetResult().Body;

                    existing.DeprecationStatus = ComputeDeprecationStatus(
                        existing.DeprecationStatus,
                        this.DeprecationState,
                        this.IsParameterBound(c => c.DaysUntilDeprecation) ? this.DaysUntilDeprecation : null,
                        this.IsParameterBound(c => c.DeprecationType) ? this.DeprecationType : null,
                        DateTime.UtcNow);

                    var result = SharedVMExtensionVersionClient.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, sharedVMExtensionName, version, existing).GetAwaiter().GetResult();

                    var psObject = new PSSharedVMExtensionVersion();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<SharedVMExtensionVersion, PSSharedVMExtensionVersion>(result.Body, psObject);
                    WriteObject(psObject);
                }
            });
        }

        /// <summary>
        /// Computes the updated <see cref="ExtensionDeprecationStatus"/> for a shared VM extension version based on
        /// the requested deprecation state and the (optionally bound) day count / type overrides.
        /// </summary>
        internal static ExtensionDeprecationStatus ComputeDeprecationStatus(
            ExtensionDeprecationStatus existing,
            string deprecationState,
            int? daysUntilDeprecation,
            string deprecationType,
            DateTime utcNow)
        {
            var deprecationStatus = existing ?? new ExtensionDeprecationStatus();
            deprecationStatus.State = deprecationState;

            if (string.Equals(deprecationState, ExtensionState.ScheduledForDeprecation, StringComparison.OrdinalIgnoreCase)
                && daysUntilDeprecation == null
                && deprecationStatus.DeprecationTime == null)
            {
                throw new PSArgumentException(
                    "-DaysUntilDeprecation must be specified when -DeprecationState is 'ScheduledForDeprecation' and no deprecation time is already set.");
            }

            bool isReactivating = string.Equals(deprecationState, ExtensionState.Active, StringComparison.OrdinalIgnoreCase);
            bool overrideSupplied = daysUntilDeprecation.HasValue || deprecationType != null;
            bool partialOverride = daysUntilDeprecation.HasValue != (deprecationType != null);

            if (isReactivating && partialOverride)
            {
                throw new PSArgumentException(
                    "-DaysUntilDeprecation and -DeprecationType must be specified together when reactivating (-DeprecationState 'Active') with new deprecation data.");
            }

            if (isReactivating && !overrideSupplied)
            {
                // Clear any previously scheduled deprecation data when the version is reactivated,
                // unless the caller explicitly supplied new values for both.
                deprecationStatus.DeprecationTime = null;
                deprecationStatus.DeprecationType = null;
            }
            else
            {
                deprecationStatus.DeprecationTime = daysUntilDeprecation.HasValue
                    ? (DateTime?)utcNow.AddDays(daysUntilDeprecation.Value)
                    : (isReactivating ? null : deprecationStatus.DeprecationTime);
                deprecationStatus.DeprecationType = deprecationType ?? (isReactivating ? null : deprecationStatus.DeprecationType);
            }

            return deprecationStatus;
        }
    }
}
