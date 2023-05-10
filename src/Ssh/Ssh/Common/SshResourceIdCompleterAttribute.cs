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

using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Cmdlets.Ssh.Common
{
    internal class SshResourceIdCompleterAttribute : ArgumentCompleterAttribute
    {
        public SshResourceIdCompleterAttribute(string [] resourceTypes) : base(CreateScriptBlock(resourceTypes))
        {
        }

        public static ScriptBlock CreateScriptBlock(string [] resourceTypes)
        {
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n";
            script += "$resourceIds = @()\n";
            foreach (var resourceType in resourceTypes)
            {
                script += $"$resourceType = \"{resourceType}\"\n" +
                    "$resourceIds = $resourceIds + [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ResourceIdCompleterAttribute]::GetResourceIds($resourceType)\n";
            }
            script += "$resourceIds | Where-Object { $_ -Like \"*$wordToComplete*\" } | Sort-Object | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            var scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }
    }
}
