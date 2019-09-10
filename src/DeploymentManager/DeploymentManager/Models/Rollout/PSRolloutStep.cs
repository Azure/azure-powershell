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

    public class PSRolloutStep
    {
        public PSRolloutStep(RolloutStep rolloutStep)
        {
            this.Name = rolloutStep.Name;
            this.Status = rolloutStep.Status;
            this.StepGroup = rolloutStep.StepGroup;
            this.OperationInfo = rolloutStep.OperationInfo != null ? new PSStepOperationInfo(rolloutStep.OperationInfo) : null;
            this.ResourceOperations = rolloutStep.ResourceOperations?.Select(ro => new PSResourceOperation(ro)).ToList();
            this.Messages = rolloutStep.Messages?.Select(m => new PSMessage(m)).ToList();
        }

		/// <summary>
		/// Gets or sets name of the step as specified in the rollout
		/// specification input artifact.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Gets current state of the step.
		/// </summary>
		public string Status
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the step group the current step is part of.
		/// </summary>
		public string StepGroup
		{
			get;
			set;
		}

		/// <summary>
		/// Gets detailed information of specific action execution.
		/// </summary>
		public PSStepOperationInfo OperationInfo
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets set of resource operations that were performed on the Azure
		/// resource that the action acted upon.
		/// </summary>
		public IList<PSResourceOperation> ResourceOperations
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets supplementary informative messages during rollout.
		/// </summary>
		public IList<PSMessage> Messages
		{
			get;
			private set;
		}

    }
}
