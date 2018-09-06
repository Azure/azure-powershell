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
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public class PSStepResource : PSResource
    {
        public PSStepResource(): base()
        {

        }

        public PSStepResource(string resourceGroupName, StepResource stepResource) : base(stepResource)
        {
            this.ResourceGroupName = resourceGroupName;
            this.StepType = stepResource.StepType;
            this.Attributes = stepResource.Attributes;
        }

        /// <summary>
        /// Gets or sets the resource group to which the service unit belongs.
        /// </summary>
        public string ResourceGroupName { get; set; }

		/// <summary>
		/// Gets or sets the type of step.
		/// </summary>
		public string StepType
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets provides the input parameters that correspond to the
		/// stepType.
		/// </summary>
		public object Attributes
		{
			get;
			set;
		}

        internal StepResource ToSdkType()
        {
            return new StepResource(
                this.Location,
                this.StepType,
                this.Attributes,
                this.Name,
                this.Type,
                this.Id,
                TagsConversionHelper.CreateTagDictionary(this.Tags, validate: true));
        }
    }
}
