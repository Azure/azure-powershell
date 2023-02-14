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

namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public class PSRollout : PSResource
    {
        public PSRollout() : base()
        {
        }

        public PSRollout(string resourceGroupName, Rollout rollout) : base(rollout)
        {
            this.ResourceGroupName = resourceGroupName;
            this.BuildVersion = rollout.BuildVersion;
            this.ArtifactSourceId = rollout.ArtifactSourceId;
            this.TargetServiceTopologyId = rollout.TargetServiceTopologyId;
            this.Identity = rollout.Identity != null ? new PSIdentity(rollout.Identity) : null;
            this.OperationInfo = rollout.OperationInfo != null ?  new PSRolloutOperationInfo(rollout.OperationInfo) : null;
            this.Status = rollout.Status;
            this.TotalRetryAttempts = rollout.TotalRetryAttempts;
            this.Services = rollout.Services?.Select(s=> new PSService(s)).ToList();
        }

        /// <summary>
        /// Gets or sets the resource group to which the service unit belongs.
        /// </summary>
        public string ResourceGroupName { get; set; }

		/// <summary>
		/// Gets or sets the version of the build being deployed.
		/// </summary>
		public string BuildVersion
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the reference to the ARM resource Id where the payload
		/// is located.
		/// </summary>
		public string ArtifactSourceId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the reference to the ARM resource Id where the payload
		/// is located.
		/// </summary>
		public string TargetServiceTopologyId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the list of steps that define the orchestration.
		/// </summary>
		public string Status
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the cardinal count of total number of retries performed on the
		/// rollout at a given time.
		/// </summary>
		public int? TotalRetryAttempts
		{
			get;
			private set;
		}

        /// <summary>
        /// Gets or sets the identity information for the rollout.
        /// </summary>
        public PSIdentity Identity
        {
            get;
            set;
        }

		/// <summary>
		/// Gets or sets operational information of the rollout.
		/// </summary>
		public PSRolloutOperationInfo OperationInfo
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets set of detailed step result information on target
		/// resource groups.
		/// </summary>
		public IList<PSService> Services 
		{
			get;
			set;
		}

    }
}
