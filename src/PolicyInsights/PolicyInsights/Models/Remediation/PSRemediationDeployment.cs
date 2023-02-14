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
    using Microsoft.Azure.Management.PolicyInsights.Models;

    /// <summary>
    /// The remediation deployment.
    /// </summary>
    public class PSRemediationDeployment
    {
        /// <summary>
        /// Gets the resource ID of the resource that is being remediated.
        /// </summary>
        public string RemediatedResourceId { get; }

        /// <summary>
        /// Gets the ID of the deployment once it has been created.
        /// </summary>
        public string DeploymentId { get; }

        /// <summary>
        /// Gets the status of the deployment.
        /// </summary>
        public string Status { get; }

        /// <summary>
        /// Gets the location of the resource that is being remediated.
        /// </summary>
        public string ResourceLocation { get; }

        /// <summary>
        /// Gets the error that caused the remediation deployment to fail (if applicable).
        /// </summary>
        public PSErrorDefinition Error { get; }

        /// <summary>
        /// Gets the time at which the remediation deployment was created.
        /// </summary>
        public DateTime? CreatedOn { get; }

        /// <summary>
        /// Gets the time at which the remediation deployment was last updated.
        /// </summary>
        public DateTime? LastUpdatedOn { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSRemediationDeployment" /> class.
        /// </summary>
        /// <param name="deployment">The raw remediation deployment model.</param>
        public PSRemediationDeployment(RemediationDeployment deployment)
        {
            if (deployment == null)
            {
                return;
            }

            this.RemediatedResourceId = deployment.RemediatedResourceId;
            this.DeploymentId = deployment.DeploymentId;
            this.Status = deployment.Status;
            this.ResourceLocation = deployment.ResourceLocation;
            this.CreatedOn = deployment.CreatedOn;
            this.LastUpdatedOn = deployment.LastUpdatedOn;
            if (deployment.Error != null)
            {
                this.Error = new PSErrorDefinition(deployment.Error);
            }
        }
    }
}
