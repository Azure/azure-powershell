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

            if (ParameterSetName == SearchParameterSet)
            {
                IEnumerable<AutoRestProject> projects = Codebase.FilterProjects(Search)
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
