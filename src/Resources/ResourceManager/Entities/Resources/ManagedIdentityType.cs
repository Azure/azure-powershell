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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources
{
    /// <summary>
    /// The type of resource identity that is assigned to a resource.
    /// </summary>
    public enum ManagedIdentityType
    {
        /// <summary>
        /// Indicates that a system assigned identity is associated with the resource.
        /// </summary>
        SystemAssigned = 1,

        /// <summary>
        /// Indicates that a user assigned identity is associated with the resource.
        /// </summary>
        UserAssigned,

        /// <summary>
        /// Indicates that no identity is associated with the resource or that the existing identity should be removed.
        /// </summary>
        None
    }
}

