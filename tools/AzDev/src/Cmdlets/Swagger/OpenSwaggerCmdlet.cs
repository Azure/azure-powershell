using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AzDev.Models.Inventory;
using AzDev.Services;

namespace AzDev.Cmdlets.Swagger
{
    /// <summary>
    /// Open-DevSwagger -Search "Graph"
    /// Get-AzDevModule -Name "Graph" | Get-AzDevProject | Get-AzDevSwagger | Open-DevSwagger ?
    /// </summary>
    [Cmdlet("Open", "DevSwagger")]
    public class OpenSwaggerCmdlet : DevCmdletBase
    {
        public const string SearchParameterSet = "Search";

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = SearchParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Search { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            Codebase codebase = AzDevModule.GetComponent<ICodebaseProvider>(nameof(ICodebaseProvider)).GetCodebase()
                ?? throw new PSInvalidOperationException("Codebase is not loaded. Please run Set-DevContext first.");

            if (ParameterSetName == SearchParameterSet)
            {
                IEnumerable<AutoRestProject> projects = codebase.FilterProjects(Search)
                    .Where(p => p is AutoRestProject)
                    .Cast<AutoRestProject>();
                if (!projects.Any())
                {
                    WriteWarning($"No projects found for search term '{Search}'.");
                    return;
                } else {
                    WriteDebug($"Found {projects.Count()} projects for search term '{Search}'. They are: {string.Join(", ", projects.Select(p => p.Name))}");
                }
                AutoRestProject project = SelectFrom($"Multiple projects matching [{Search}]", projects);
                IEnumerable<SwaggerReference> swaggers = project.Swaggers;
                SwaggerReference swagger = SelectFrom($"Multiple swagger references found in [{project.Name}]", swaggers);
                Host.UI.WriteLine($"Opening {swagger.Uri} in default browser...");
                swagger.OpenOnline();
            }
        }
    }
}
