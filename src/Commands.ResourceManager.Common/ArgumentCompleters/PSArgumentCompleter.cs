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

namespace Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters
{
    public class PSArgumentCompleterAttribute : ArgumentCompleterAttribute
    {
        public PSArgumentCompleterAttribute(params string[] argumentList) : base(CreateScriptBlock(argumentList))
        {
        }

        public static ScriptBlock CreateScriptBlock(string[] resourceTypes)
        {
            string scriptResourceTypeList = "'" + String.Join("' , '", resourceTypes) + "'";
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                String.Format("$values = {0}\n", scriptResourceTypeList) +
                "$values | Where-Object { $_ -Like \"$wordToComplete*\" } | Sort-Object | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            ScriptBlock scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }
    }
}
