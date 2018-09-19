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
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore
{
    public abstract class PowershellEnvironment
    {
        protected InitialSessionState initialSessionState;
        protected Runspace runspace;

        public PowershellEnvironment(params PowershellModule[] modules)
        {
            if (modules == null)
            {
                runspace = RunspaceFactory.CreateRunspace();
            }
            else
            {
                initialSessionState = InitialSessionState.CreateDefault();
                string[] moduleFullPath = new string[modules.Length];
                for (int i = 0; i < modules.Length; i++)
                {
                    moduleFullPath[i] = modules[i].FullPath;
                    initialSessionState.Assemblies.Add(new SessionStateAssemblyEntry(modules[i].FullPath));
                }
                initialSessionState.ImportPSModule(moduleFullPath);

                runspace = RunspaceFactory.CreateRunspace(initialSessionState);
            }
        }

        public PowershellEnvironment()
        {
            initialSessionState = InitialSessionState.CreateDefault();
            runspace = RunspaceFactory.CreateRunspace(initialSessionState);
        }

        public abstract Collection<PSObject> Run(bool debug);

        protected void PrintPSCommand(System.Management.Automation.PowerShell powershell)
        {

            StringBuilder command = new StringBuilder();
            DateTime currentTime = DateTime.UtcNow;
            command.Append("[" + currentTime.ToShortDateString() + " " + currentTime.ToLongTimeString() + "] ");

            for (int i = 0; i < powershell.Commands.Commands.Count; i++)
            {

                command.Append(powershell.Commands.Commands[i].CommandText + " ");

                for (int j = 0; j < powershell.Commands.Commands[i].Parameters.Count; j++)
                {
                    command.Append("-" + powershell.Commands.Commands[i].Parameters[j].Name + " ");
                    var value = powershell.Commands.Commands[i].Parameters[j].Value;
                    if (value != null)
                    {
                        command.Append("\"" + value.ToString() + "\" ");
                    }
                    command.Append("\n");
                }
            }

            Console.WriteLine(command);

        }
    }
}
