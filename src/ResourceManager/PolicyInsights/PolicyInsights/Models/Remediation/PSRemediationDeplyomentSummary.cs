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
    using System.Collections.Generic;
    using Microsoft.Azure.Management.PolicyInsights.Models;

    /// <summary>
    /// The remediation deployment summary.
    /// </summary>
    public class PSRemediationDeploymentSummary
    {
        /// <summary>
        /// Gets the total number of deployments required by the remediation.
        /// </summary>
        public int TotalDeployments { get; }

        /// <summary>
        /// Gets the number of successful deployments.
        /// </summary>
        public int SuccessfulDeployments { get; }

        /// <summary>
        /// Gets the number of failed deployments.
        /// </summary>
        public int FailedDeployments { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSRemediationDeploymentSummary" /> class.
        /// </summary>
        /// <param name="deploymentSummary">The raw remediation deployment summary.</param>
        public PSRemediationDeploymentSummary(RemediationDeploymentSummary deploymentSummary)
        {
            if (deploymentSummary == null)
            {
                return;
            }

            this.TotalDeployments = deploymentSummary.TotalDeployments.GetValueOrDefault(0);
            this.FailedDeployments = deploymentSummary.FailedDeployments.GetValueOrDefault(0);
            this.SuccessfulDeployments = deploymentSummary.SuccessfulDeployments.GetValueOrDefault(0);
        }
    }
}
