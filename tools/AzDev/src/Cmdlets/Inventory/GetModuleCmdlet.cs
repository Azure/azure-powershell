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
using ModuleType = AzDev.Models.Inventory.ModuleType;

namespace AzDev.Cmdlets.Inventory
{
    [Cmdlet("Get", "DevModule")]
    [OutputType(typeof(PSModule))]
    public class GetModuleCmdlet : DevCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false)]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public ModuleType Type { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var modules = Codebase.Modules;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
            {
                modules = modules.Where(x => x.Name.Equals(Name, System.StringComparison.InvariantCultureIgnoreCase));
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Type)))
            {
                modules = modules.Where(x => x.Type == Type);
            }

            WriteObject(modules.Select(m => new PSModule(m)), true);
        }
    }
}
