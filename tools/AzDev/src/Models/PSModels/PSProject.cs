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

using AzDev.Models.Inventory;

namespace AzDev.Models.PSModels
{
    public class PSProject
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public ProjectType Type { get; set; }
        public string TypeDeductionReason { get; set; }
        internal PSProject(Project p)
        {
            Name = p.Name;
            Path = p.Path;
            Type = p.Type;
            TypeDeductionReason = p.TypeDeductionReason;
        }
        internal PSProject() { }
        public override string ToString() => Name;
    }
}
