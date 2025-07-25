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

namespace Microsoft.Azure.Commands.PolicyInsights.Models.Remediation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.PolicyInsights.Models;

    /// <summary>
    /// Remediation resource.
    /// </summary>
    public class PSRemediation
    {
        /// <summary>
        /// Gets the resource ID of the remediation.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the remediation resource type.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the name of the remediation.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the ID of the policy assignment that is being remediated.
        /// </summary>
        public string PolicyAssignmentId { get; }

        /// <summary>
        /// Gets the policy definition reference ID of the individual definition that is being remediated.
        /// Required when the policy assignment being remediated assigns a policy set definition.
        /// </summary>
        public string PolicyDefinitionReferenceId { get; }

        /// <summary>
        /// Gets the time at which the remediation was created.
        /// </summary>
        public DateTime? CreatedOn { get; }

        /// <summary>
        /// Gets the time at which the remediation was last updated.
        /// </summary>
        public DateTime? LastUpdatedOn { get; }

        /// <summary>
        /// Gets the provisioning state of the remediation.
        /// </summary>
        public string ProvisioningState { get; }

        /// <summary>
        /// Gets the filters applied to the remediation.
        /// </summary>
        public PSRemediationFilter Filters { get; }

        /// <summary>
        /// Gets the summarized status of the deployments required for this remediation.
        /// </summary>
        public PSRemediationDeploymentSummary DeploymentSummary { get; }

        /// <summary>
        /// Gets the details of the deployments created by this remediation.
        /// </summary>
        public PSRemediationDeployment[] Deployments { get; }

        /// <summary>
        /// Gets a value indicating how the remediation task discovers resources that need to be remediated.
        /// </summary>
        public string ResourceDiscoveryMode { get; }

        /// <summary>
        /// The number of non-compliant resources to be remediated.
        /// </summary>
        public int? ResourceCount { get; }

        /// <summary>
        /// The number of resources to remediate at any given time.
        /// </summary>
        public int? ParallelDeployments { get;  }

        /// <summary>
        /// The remediation failure threshold.
        /// </summary>
        public double? FailureThreshold { get; }

        /// <summary>
        /// The remediation correlation Id.
        /// </summary>
        public string CorrelationId { get; }

        /// <summary>
        /// The remediation status message.
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSRemediation" /> class.
        /// </summary>
        /// <param name="remediation">The raw remediation model.</param>
        /// <param name="deployments">The remediation deployments.</param>
        public PSRemediation(Remediation remediation, IEnumerable<RemediationDeployment> deployments = null)
        {
            if (remediation == null)
            {
                return;
            }

            this.Id = remediation.Id;
            this.Type = remediation.Type;
            this.Name = remediation.Name;
            this.PolicyAssignmentId = remediation.PolicyAssignmentId;
            this.PolicyDefinitionReferenceId = remediation.PolicyDefinitionReferenceId;
            this.CreatedOn = remediation.CreatedOn;
            this.LastUpdatedOn = remediation.LastUpdatedOn;
            this.ProvisioningState = remediation.ProvisioningState;
            this.Filters = remediation.Filters != null ? new PSRemediationFilter(remediation.Filters) : null;
            this.DeploymentSummary = remediation.DeploymentStatus != null ? new PSRemediationDeploymentSummary(remediation.DeploymentStatus) : null;
            this.ResourceDiscoveryMode = remediation.ResourceDiscoveryMode;
            this.ResourceCount = remediation.ResourceCount;
            this.ParallelDeployments = remediation.ParallelDeployments;
            this.FailureThreshold = remediation.FailureThreshold?.Percentage;
            this.CorrelationId = remediation.CorrelationId;
            this.StatusMessage = remediation.StatusMessage;

            if (deployments != null)
            {
                this.Deployments = deployments.Select(d => new PSRemediationDeployment(d)).ToArray();
            }
        }
    }
}
