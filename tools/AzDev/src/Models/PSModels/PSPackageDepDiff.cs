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

using AzDev.Models.Dep;

namespace AzDev.Models.PSModels
{
    /// <summary>
    /// PowerShell output model for package dependency differences.
    /// </summary>
    public class PSPackageDepDiff
    {
        public string DepName { get; set; }
        public string OldVersion { get; set; }
        public string NewVersion { get; set; }
        public string ParentDep { get; set; }

        public PSPackageDepDiff(PackageDepDiff diff)
        {
            DepName = diff.DepName;
            OldVersion = diff.OldVersion;
            NewVersion = diff.NewVersion;
            ParentDep = diff.ParentDep;
        }
    }
}
