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

namespace Microsoft.Azure.Commands.PolicyInsights.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using System.Threading;
    using Microsoft.Azure.Commands.PolicyInsights.Models.Remediation;
    using Microsoft.Azure.Commands.PolicyInsights.Properties;
    using Microsoft.Azure.Management.PolicyInsights;
    using Microsoft.Azure.Management.PolicyInsights.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Base class for Azure Policy Insights cmdlets
    /// </summary>
    public abstract class RemediationCmdletBase : PolicyInsightsCmdletBase
    {
        /// <summary>
        /// The terminal provisioning states.
        /// </summary>
        private static readonly HashSet<string> TerminalStates = new HashSet<string>(new[] { "Canceled", "Failed", "Succeeded" }, StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// The interval between polling attempts when waiting for operations to complete.
        /// </summary>
        private static readonly TimeSpan StatePollingInterval = TimeSpan.FromSeconds(30);

        /// <summary>
        /// The fully qualified resource type of the remediations resource.
        /// </summary>
        protected const string RemediationsFullyQualifiedResourceType = "Microsoft.PolicyInsights/remediations";

        /// <summary>
        /// The cancellation source.
        /// </summary>
        private CancellationTokenSource cancellationSource;

        /// <summary>
        /// Gets the cancellation source.
        /// </summary>
        protected CancellationToken CancellationToken
        {
            get
            {
                return this.cancellationSource != null ? this.cancellationSource.Token : CancellationToken.None;
            }
        }

        /// <summary>
        /// Gets the root scope of the remediation that is being acted upon.
        /// </summary>
        /// <param name="scope">The full scope</param>
        /// <param name="resourceId">The full resource ID of the remediation resource</param>
        /// <param name="managementGroupId">The management group ID</param>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="inputObject">The remediation input object</param>
        protected string GetRootScope(string scope = null, string resourceId = null, string managementGroupId = null, string resourceGroupName = null, PSRemediation inputObject = null)
        {
            string rootScope = null;
            if (!string.IsNullOrEmpty(resourceId))
            {
                rootScope = ResourceIdHelper.GetRootScope(resourceId: resourceId, fullyQualifiedResourceType: RemediationCmdletBase.RemediationsFullyQualifiedResourceType);
                if (rootScope == null)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.Error_InvalidResourceId, RemediationCmdletBase.RemediationsFullyQualifiedResourceType), paramName: "ResourceId");
                }
            }
            else if (!string.IsNullOrEmpty(scope))
            {
                rootScope = scope.TrimEnd('/');
            }
            else if (!string.IsNullOrEmpty(managementGroupId))
            {
                rootScope = ResourceIdHelper.GetManagementGroupScope(managementGroupId: managementGroupId);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName))
            {
                rootScope = ResourceIdHelper.GetResourceGroupScope(subscriptionId: this.DefaultContext.Subscription.Id, resourceGroupName: resourceGroupName);
            }
            else if (inputObject != null)
            {
                rootScope = ResourceIdHelper.GetRootScope(resourceId: inputObject.Id, fullyQualifiedResourceType: RemediationCmdletBase.RemediationsFullyQualifiedResourceType);
            }
            else
            {
                // Subscription based retrieval is the default, pulls the subscription ID from context
                rootScope = ResourceIdHelper.GetSubscriptionScope(subscriptionId: this.DefaultContext.Subscription.Id);
            }

            return rootScope;
        }

        /// <summary>
        /// Gets the name of the remediation that is being acted upon.
        /// </summary>
        /// <param name="name">The provided remediation name</param>
        /// <param name="resourceId">The full resource ID of the remediation resource</param>
        /// <param name="inputObject">The remediation input object</param>
        protected string GetRemediationName(string name = null, string resourceId = null, PSRemediation inputObject = null)
        {
            string remediationName = null;
            if (!string.IsNullOrEmpty(name))
            {
                remediationName = name;
            }
            else if (!string.IsNullOrEmpty(resourceId))
            {
                remediationName = ResourceIdHelper.GetResourceName(resourceId: resourceId);
                if (remediationName == null)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.Error_InvalidResourceId, RemediationCmdletBase.RemediationsFullyQualifiedResourceType), paramName: "ResourceId");
                }
            }
            else if (inputObject != null)
            {
                remediationName = inputObject.Name;
            }

            return remediationName;
        }

        /// <summary>
        /// Waits for the remediation to transition to a terminal state.
        /// </summary>
        /// <param name="remediation">The remediation to wait on.</param>
        /// <returns>The final terminal remediation object</returns>
        protected Remediation WaitForTerminalState(Remediation remediation)
        {
            var rootScope = this.GetRootScope(resourceId: remediation.Id);
            var remediationName = remediation.Name;

            while (!this.CancellationToken.IsCancellationRequested && !this.IsComplete(remediation))
            {
                var progress = new ProgressRecord(0, string.Format(CultureInfo.InvariantCulture, Resources.WaitingForRemediationCompletion, rootScope, remediationName), remediation.ProvisioningState)
                {
                    PercentComplete = remediation.DeploymentStatus.TotalDeployments > 0
                        ? ((remediation.DeploymentStatus.FailedDeployments.GetValueOrDefault(0) + remediation.DeploymentStatus.SuccessfulDeployments.GetValueOrDefault(0)) / remediation.DeploymentStatus.TotalDeployments.Value) * 100
                        : 0
                };

                this.WriteProgress(progress);

                TestMockSupport.Delay(RemediationCmdletBase.StatePollingInterval);
                remediation = this.PolicyInsightsClient.Remediations.GetAtResource(resourceId: rootScope, remediationName: remediationName);
            }

            return remediation;
        }

        /// <summary>
        /// Checks whether a remediation is complete.
        /// </summary>
        /// <param name="remediation">The remediation to check.</param>
        /// <returns>True if the remediation is complete.</returns>
        protected bool IsComplete(Remediation remediation)
        {
            return RemediationCmdletBase.TerminalStates.Contains(remediation.ProvisioningState);
        }

        /// <summary>
        /// The <c>BeginProcessing</c> method.
        /// </summary>
        protected override void BeginProcessing()
        {
            try
            {
                if (this.cancellationSource == null)
                {
                    this.cancellationSource = new CancellationTokenSource();
                }

                base.BeginProcessing();
            }
            finally
            {
                this.DisposeOfCancellationSource();
            }
        }

        /// <summary>
        /// The <c>StopProcessing</c> method.
        /// </summary>
        protected override void StopProcessing()
        {
            try
            {
                if (this.cancellationSource != null && !this.cancellationSource.IsCancellationRequested)
                {
                    this.cancellationSource.Cancel();
                }
                
                base.StopProcessing();
            }
            finally
            {
                this.DisposeOfCancellationSource();
            }
        }

        /// <summary>
        /// Disposes of the <see cref="CancellationTokenSource"/>.
        /// </summary>
        private void DisposeOfCancellationSource()
        {
            if (this.cancellationSource != null)
            {
                if (!this.cancellationSource.IsCancellationRequested)
                {
                    this.cancellationSource.Cancel();
                }

                this.cancellationSource.Dispose();
                this.cancellationSource = null;
            }
        }
    }
}
