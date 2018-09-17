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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities
{
    public enum ProvisioningState
    {
        /// <summary>
        /// The provisioning state is not specified.
        /// </summary>
        NotSpecified,

        /// <summary>
        /// The provisioning state is accepted.
        /// </summary>
        Accepted,

        /// <summary>
        /// The provisioning state is running.
        /// </summary>
        Running,

        /// <summary>
        /// The provisioning state is creating.
        /// </summary>
        Creating,

        /// <summary>
        /// The provisioning state is created.
        /// </summary>
        Created,

        /// <summary>
        /// The provisioning state is deleting.
        /// </summary>
        Deleting,

        /// <summary>
        /// The provisioning state is deleted.
        /// </summary>
        Deleted,

        /// <summary>
        /// The provisioning state is canceled.
        /// </summary>
        Canceled,

        /// <summary>
        /// The provisioning state is failed.
        /// </summary>
        Failed,

        /// <summary>
        /// The provisioning state is succeeded.
        /// </summary>
        Succeeded,

        /// <summary>
        /// The provisioning state is moving resources.
        /// </summary>
        MovingResources,
    }
}
