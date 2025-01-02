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
