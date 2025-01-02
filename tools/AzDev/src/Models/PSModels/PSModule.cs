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

using System.Linq;
using AzDev.Models.Inventory;

namespace AzDev.Models.PSModels
{
    public class PSModule
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public PSProject[] Project { get; set; }
        public ModuleType Type { get; set; }
        internal PSModule(Module module)
        {
            Name = module.Name;
            Path = module.Path;
            Type = module.Type;
            Project = module.Projects.Select(p => new PSProject(p)).ToArray();
        }
        internal PSModule() { }
        public override string ToString() => Name;
    }
}
