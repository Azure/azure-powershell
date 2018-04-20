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

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NetCorePsd1Sync.Model
{
    public class PsData
    {
        [DisplayName("Tags")]
        [Description("Tags applied to this module. These help with module discovery in online galleries.")]
        public List<string> Tags { get; set; }

        [DisplayName("LicenseUri")]
        [Description("A URL to the license for this module.")]
        public Uri LicenseUri { get; set; }

        [DisplayName("ProjectUri")]
        [Description("A URL to the main website for this project.")]
        public Uri ProjectUri { get; set; }

        [DisplayName("IconUri")]
        [Description("A URL to an icon representing this module.")]
        public Uri IconUri { get; set; }

        [DisplayName("ReleaseNotes")]
        [Description("ReleaseNotes of this module")]
        public string ReleaseNotes { get; set; }

        [DisplayName("Prerelease")]
        [Description("Prerelease string of this module")]
        public string Prerelease { get; set; }

        [DisplayName("RequireLicenseAcceptance")]
        [Description("Flag to indicate whether the module requires explicit user acceptance for install/update/save")]
        public bool? RequireLicenseAcceptance { get; set; }

        [DisplayName("ExternalModuleDependencies")]
        [Description("External dependent modules of this module")]
        public List<ModuleReference> ExternalModuleDependencies { get; set; }
    }
}
