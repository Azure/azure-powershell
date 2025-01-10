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
using System.Management.Automation;
using AzDev.Models.PSModels;
using AzDev.Models.Inventory;

namespace AzDev.Cmdlets.Inventory
{
    [Cmdlet("Get", "DevProject")]
    [OutputType(typeof(PSProject))]
    public class GetProjectCmdlet : DevCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false)]
        [Alias("ProjectName")]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false)]
        public string ModuleName { get; set; }

        [Parameter(Mandatory = false)]
        public ProjectType Type { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var modules = MyInvocation.BoundParameters.ContainsKey(nameof(ModuleName))
                ? Codebase.Modules.Where(x => x.Name.Equals(ModuleName, System.StringComparison.InvariantCultureIgnoreCase))
                : Codebase.Modules;
            var projects = modules.SelectMany(x => x.Projects);

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
            {
                // filter by name
                projects = projects.Where(x => x.Name.Equals(Name, System.StringComparison.InvariantCultureIgnoreCase));
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Type)))
            {
                // filter by type
                projects = projects.Where(x => x.Type == Type);
            }

            WriteObject(projects.Select(p => new PSProject(p)), true);
        }
    }
}
