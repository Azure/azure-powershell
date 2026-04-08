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
using AzDev.Services;
using AzDev.Services.Dep;

namespace AzDev.Cmdlets.Dep
{
    [Cmdlet("Compare", "DevPackageDep")]
    [OutputType(typeof(PSPackageDepDiff))]
    public class ComparePackageDepCmdlet : DevCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string PackageName { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        public string OldVersion { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public string NewVersion { get; set; }

        [Parameter(Mandatory = false, Position = 3)]
        [ArgumentCompleter(typeof(TargetFrameworkCompleter))]
        public string TargetFramework { get; set; } = "netstandard2.0";

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var packageComparisonService = AzDevModule.GetService<IDepComparisonService>();

            WriteDebug($"Comparing {PackageName} from {OldVersion} to {NewVersion} for {TargetFramework}");

            var differences = packageComparisonService.ComparePackageDependencies(
                PackageName,
                OldVersion,
                NewVersion,
                TargetFramework);

            WriteObject(differences.Select(d => new PSPackageDepDiff(d)), true);
        }
    }

    public class TargetFrameworkCompleter : IArgumentCompleter
    {
        public System.Collections.Generic.IEnumerable<CompletionResult> CompleteArgument(
            string commandName,
            string parameterName,
            string wordToComplete,
            System.Management.Automation.Language.CommandAst commandAst,
            System.Collections.IDictionary fakeBoundParameters)
        {
            var frameworks = new[] { "netstandard2.0", "net45", "net46", "net47", "net461", "net462" };
            return frameworks
                .Where(f => f.StartsWith(wordToComplete, System.StringComparison.OrdinalIgnoreCase))
                .Select(f => new CompletionResult(f, f, CompletionResultType.ParameterValue, f));
        }
    }
}
