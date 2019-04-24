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

using Microsoft.Azure.Management.DeploymentManager.Models;

namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    public class PSResourceOperation
    {
        public PSResourceOperation(ResourceOperation resourceOperation)
        {
            this.ResourceName = resourceOperation?.ResourceName;
            this.OperationId = resourceOperation?.OperationId;
            this.ResourceType = resourceOperation?.ResourceType;
            this.ProvisioningState = resourceOperation?.ProvisioningState;
            this.StatusCode = resourceOperation?.StatusCode;
            this.StatusMessage = resourceOperation?.StatusMessage;
        }

		/// <summary>
		/// Gets or sets name of the resource as specified in the artifacts.
		/// For ARM resources, this is the name of the resource specified in
		/// the template.
		/// </summary>
		public string ResourceName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets unique identifier of the operation. For ARM resources, this is
		/// the operationId obtained from ARM service.
		/// </summary>
		public string OperationId
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets type of the resource as specified in the artifacts.
		/// For ARM resources, this is the type of the resource specified in
		/// the template.
		/// </summary>
		public string ResourceType
		{
			get;
			set;
		}

		/// <summary>
		/// Gets state of the resource deployment. For ARM resources, this is
		/// the current provisioning state of the resource.
		/// </summary>
		public string ProvisioningState
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets descriptive information of the resource operation.
		/// </summary>
		public string StatusMessage
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets http status code of the operation.
		/// </summary>
		public string StatusCode
		{
			get;
			private set;
		}
    }
}
