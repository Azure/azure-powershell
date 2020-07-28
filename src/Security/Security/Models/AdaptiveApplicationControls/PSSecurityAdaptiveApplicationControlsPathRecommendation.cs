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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SecurityCenter.Models.AdaptiveApplicationControls
{
    public class PSSecurityAdaptiveApplicationControlsPathRecommendation
    {
        /// <summary>
        /// The full path to whitelist.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The type of the rule to be allowed.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Represents the publisher information of a process/rule.
        /// </summary>
        public PSSecurityAdaptiveApplicationControlsPublisherInfo PublisherInfo { get; set; }

        /// <summary>
        /// Whether the path is commonly run on the machine.
        /// </summary>
        public bool? Common { get; set; }

        /// <summary>
        /// The recommendation action of the VM/server or rule.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Represents a user that is recommended to be allowed for a certain rule.
        /// </summary>
        public IList<PSSecurityAdaptiveApplicationControlsUserRecommendation> Usernames { get; set; }

        /// <summary>
        /// A security identifier.
        /// </summary>
        public IList<string> UserSids { get; set; }

        /// <summary>
        /// The type of the file (for Linux files - Executable is used).
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// The configuration status of the VM/server group or machine or rule on the machine.
        /// </summary>
        public string ConfigurationStatus { get; set; }
    }
}
