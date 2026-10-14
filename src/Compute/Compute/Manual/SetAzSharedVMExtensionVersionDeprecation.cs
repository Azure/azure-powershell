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
            HelpMessage = "The number of days from now after which the shared VM extension version is scheduled for deprecation. Required together with -DeprecationType when -DeprecationState is 'ScheduledForDeprecation'. Not allowed when -DeprecationState is 'Active' or 'Deprecated'.")]
        [ValidateRange(0, int.MaxValue)]
        public int? DaysUntilDeprecation { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The scope of deprecation, indicating which set of versions are affected. Required when -DeprecationState is 'ScheduledForDeprecation' or 'Deprecated'. Not allowed when -DeprecationState is 'Active'.")]
        [ValidateSet(
            Microsoft.Azure.Management.Compute.Models.DeprecationType.Hotfix,
            Microsoft.Azure.Management.Compute.Models.DeprecationType.Patch,
            Microsoft.Azure.Management.Compute.Models.DeprecationType.Minor,
            Microsoft.Azure.Management.Compute.Models.DeprecationType.Major,
            IgnoreCase = true)]
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
        /// Builds a fresh <see cref="ExtensionDeprecationStatus"/> for a shared VM extension version from the
        /// requested deprecation state and parameters. The previous status is intentionally not considered; the
        /// returned status always reflects only the supplied inputs.
        /// </summary>
        /// <remarks>
        /// Validation rules:
        /// <list type="bullet">
        /// <item>'Active': neither -DaysUntilDeprecation nor -DeprecationType may be supplied; the status is cleared.</item>
        /// <item>'ScheduledForDeprecation': both -DaysUntilDeprecation and -DeprecationType are required; the
        /// deprecation time is set to <paramref name="utcNow"/> plus the supplied day count.</item>
        /// <item>'Deprecated': -DeprecationType is required and -DaysUntilDeprecation is not allowed; the version is
        /// deprecated immediately (deprecation time set to <paramref name="utcNow"/>).</item>
        /// </list>
        /// </remarks>
        internal static ExtensionDeprecationStatus ComputeDeprecationStatus(
            string deprecationState,
            int? daysUntilDeprecation,
            string deprecationType,
            DateTime utcNow)
        {
            bool daysSupplied = daysUntilDeprecation.HasValue;
            bool typeSupplied = deprecationType != null;

            var deprecationStatus = new ExtensionDeprecationStatus
            {
                State = deprecationState
            };

            if (string.Equals(deprecationState, ExtensionState.Active, StringComparison.OrdinalIgnoreCase))
            {
                if (daysSupplied || typeSupplied)
                {
                    throw new PSArgumentException(
                        "-DaysUntilDeprecation and -DeprecationType cannot be specified when -DeprecationState is 'Active'.");
                }

                deprecationStatus.DeprecationTime = null;
                deprecationStatus.DeprecationType = null;
            }
            else if (string.Equals(deprecationState, ExtensionState.ScheduledForDeprecation, StringComparison.OrdinalIgnoreCase))
            {
                if (!daysSupplied || !typeSupplied)
                {
                    throw new PSArgumentException(
                        "-DaysUntilDeprecation and -DeprecationType are both required when -DeprecationState is 'ScheduledForDeprecation'.");
                }

                deprecationStatus.DeprecationTime = utcNow.AddDays(daysUntilDeprecation.Value);
                deprecationStatus.DeprecationType = deprecationType;
            }
            else
            {
                if (!typeSupplied)
                {
                    throw new PSArgumentException(
                        "-DeprecationType is required when -DeprecationState is 'Deprecated'.");
                }

                if (daysSupplied)
                {
                    throw new PSArgumentException(
                        "-DaysUntilDeprecation cannot be specified when -DeprecationState is 'Deprecated'; the version is deprecated immediately.");
                }

                deprecationStatus.DeprecationTime = utcNow;
                deprecationStatus.DeprecationType = deprecationType;
            }

            return deprecationStatus;
        }
    }
}
