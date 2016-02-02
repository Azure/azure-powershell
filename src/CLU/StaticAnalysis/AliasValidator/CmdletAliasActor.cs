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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Threading.Tasks;

namespace StaticAnalysis.AliasValidator
{
    public class CmdletAliasActor : IAssemblyActor
    {
        public IToolsLogger Logger { get; set; }
        public string Name { get { return "CLU Alias Validator"; } }
        public void ExecuteAssemblyAction(string baseDirectory, string assemblyIdentity)
        {
            foreach (var cmdlet in Assembly.Load(new AssemblyName(assemblyIdentity)).GetCmdletTypes())
            {
                if (cmdlet.HasAttribute<CliCommandAliasAttribute>())
                {
                    // TODO: Per cmdlet validation of nouns and verbs in the alias
                }
                else
                {
                    Logger.LogRecord(new ValidationRecord()
                    {
                        Description="Missing CLI Command Alias Attribute",
                        Target = cmdlet.FullName,
                        Remediation = $"Add a CliCommand Alias attribute to cmdlet {cmdlet.FullName}",
                        Severity = 0

                    });
                }
            }
        }
    }
}
