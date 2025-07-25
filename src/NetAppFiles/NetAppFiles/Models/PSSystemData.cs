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


namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    using System;
    /// <summary>
    /// Metadata pertaining to creation and last modification of the resource.
    /// Wrapper of SDK type SystemData,
    /// </summary>
    public class PSSystemData
    {
        /// <summary>
        /// The identity that created the resource
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// The type of identity that created the resource.
        /// </summary>
        public string CreatedByType { get; set; }

        /// <summary>
        /// The timestamp of resource creation (UTC).
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// The identity that last modified the resource.
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// The type of identity that last modified the resource.
        /// </summary>
        public string LastModifiedByType { get; set; }

        /// <summary>
        /// The timestamp of resource last modification (UTC)
        /// </summary>
        public DateTime? LastModifiedAt { get; set; }

    }
}
