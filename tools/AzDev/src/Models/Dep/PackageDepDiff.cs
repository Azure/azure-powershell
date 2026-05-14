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

namespace AzDev.Models.Dep
{
    /// <summary>
    /// Represents a difference in package dependencies between two versions.
    /// </summary>
    public class PackageDepDiff
    {
        /// <summary>
        /// The name of the dependency that changed.
        /// </summary>
        public string DepName { get; set; }

        /// <summary>
        /// The old version of the dependency (null if newly added).
        /// </summary>
        public string OldVersion { get; set; }

        /// <summary>
        /// The new version of the dependency (null if removed).
        /// </summary>
        public string NewVersion { get; set; }

        /// <summary>
        /// The parent dependency that caused this change.
        /// </summary>
        public string ParentDep { get; set; }
    }
}
