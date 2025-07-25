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

using System;
using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Cmdlets.Ssh.Common
{
    internal class SshResourceNameCompleterAttribute : ArgumentCompleterAttribute
    {
        public SshResourceNameCompleterAttribute(string [] resourceTypes, params string [] parentResourceParameterNames): base(CreateScriptBlock(resourceTypes, parentResourceParameterNames))
        {
        }

        public static ScriptBlock CreateScriptBlock(string [] resourceTypes, string [] parentResourceNames)
        {
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                "$parentResources = @()\n";
            foreach (var parentResourceName in parentResourceNames)
            {
                script += String.Format("$parentResources += $fakeBoundParameter[\"{0}\"]\n", parentResourceName);
            }
            script += "$resources = @()\n";
            foreach (var resourceType in resourceTypes)
            {
                script += String.Format("$resourceType = \"{0}\"\n", resourceType) +
                "$resources = $resources + [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ResourceNameCompleterAttribute]::FindResources($resourceType, $parentResources)\n";
            }
            script += "$resources | Where-Object { $_ -Like \"$wordToComplete*\" } | Sort-Object | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            ScriptBlock scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }
    }
}
