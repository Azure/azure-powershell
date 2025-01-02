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
