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
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore
{
    public class PowershellCmdletScript : PowershellEnvironment
    {
        private readonly List<string> cmdlets;
                
        public PowershellCmdletScript(List<string> cmdlet, params PowershellModule[] modules) : base(modules)
        {
            this.cmdlets = cmdlet;            
        }
              
        public PowershellCmdletScript(List<string> cmdlet) : base()
        {
            this.cmdlets = cmdlet;
        }

        public PowershellCmdletScript(PowershellModule[] modules) : base(modules)
        {
            this.cmdlets = new List<string>();
        }
         
        public PowershellCmdletScript() : base()
        {
            this.cmdlets = new List<string>();
        }


        public void Add(string cmdlet)
        {
            this.cmdlets.Add(cmdlet);
        }
        public override Collection<PSObject> Run(bool debug)
        {
            Collection<PSObject> result = null;
            runspace.Open();
            for (int i = 0; i < cmdlets.Count; i++)
            {

                using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
                {
                    powershell.Runspace = runspace;

                    if (!String.IsNullOrWhiteSpace(cmdlets[i]))
                    {
                        powershell.AddScript(cmdlets[i]);
                    }

                    if (debug)
                    {
                        powershell.AddParameter("Debug");
                    }

                    PrintPSCommand(powershell);

                    result = powershell.Invoke();

                    if (debug)
                    {
                        Console.WriteLine(string.Join("", powershell.Streams.Debug));
                    }

                    if (powershell.Streams.Error.Count > 0)
                    {
                        runspace.Close();

                        var exceptions = new List<Exception>();
                        foreach (ErrorRecord error in powershell.Streams.Error)
                        {
                            exceptions.Add(new Exception(error.Exception.Message));
                        }

                        throw new AggregateException(exceptions);
                    }
                }
            }
            runspace.Close();

            return result;
        }        
    }
}
