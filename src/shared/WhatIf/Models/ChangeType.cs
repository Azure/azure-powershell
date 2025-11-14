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

namespace Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models
{
    /// <summary>
    /// The type of change that will occur in the deployment.
    /// </summary>
    public enum ChangeType
    {
        /// <summary>
        /// The resource will be created.
        /// </summary>
        Create,

        /// <summary>
        /// The resource will be deleted.
        /// </summary>
        Delete,

        /// <summary>
        /// The resource will be deployed without any changes.
        /// </summary>
        Deploy,

        /// <summary>
        /// The resource will be ignored during deployment.
        /// </summary>
        Ignore,

        /// <summary>
        /// The resource will be modified.
        /// </summary>
        Modify,

        /// <summary>
        /// The resource will not be changed.
        /// </summary>
        NoChange,

        /// <summary>
        /// The resource type is not supported for WhatIf.
        /// </summary>
        Unsupported
    }
}
