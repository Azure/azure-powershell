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
    public class PSSecurityAdaptiveApplicationControlsProperties
    {
        /// <summary>
        /// The recommendation status of the VM/server group or VM/server.
        /// </summary>
        public string RecommendationStatus { get; set; }

        /// <summary>
        /// The application control policy enforcement/protection mode of the VM/server group.
        /// </summary>
        public string EnforcementMode { get; set; }

        /// <summary>
        /// The protection mode of the collection/file types. Exe/Msi/Script are used for Windows, Executable is used for Linux.
        /// </summary>
        public PSSecurityAdaptiveApplicationControlsProtectionMode ProtectionMode { get; set; }

        /// <summary>
        /// Represents a machine that is part of a VM/server group.
        /// </summary>
        public IList<PSSecurityAdaptiveApplicationControlsVmRecommendation> VmRecommendations { get; set; }

        /// <summary>
        /// Represents a path that is recommended to be allowed and its properties.
        /// </summary>
        public IList<PSSecurityAdaptiveApplicationControlsPathRecommendation> PathRecommendations { get; set; }

        /// <summary>
        /// The configuration status of the VM/server group or machine or rule on the machine.
        /// </summary>
        public string ConfigurationStatus { get; set; }

        /// <summary>
        /// Represents a summary of the alerts of the VM/server group.
        /// </summary>
        public IList<PSSecurityAdaptiveApplicationControlsIssueSummary> Issues { get; set; }

        /// <summary>
        /// The source type of the VM/server group.
        /// </summary>
        public string SourceSystem { get; set; }
    }
}
