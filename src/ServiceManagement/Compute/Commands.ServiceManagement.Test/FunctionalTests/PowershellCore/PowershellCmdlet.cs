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
using System.Linq;
using System.Management.Automation;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore
{
    public class PowershellCmdlet : PowershellEnvironment
    {
        private readonly CmdletsInfo cmdlet;

        public string Name
        {
            get
            {
                return cmdlet.name;
            }
        }

        public List<CmdletParam> Params
        {
            get
            {
                return cmdlet.parameters;
            }
        }

        public PowershellCmdlet(CmdletsInfo cmdlet, params PowershellModule[] modules) : base(modules)
        {
            this.cmdlet = cmdlet;
        }

        public PowershellCmdlet(CmdletsInfo cmdlet) : base()
        {
            this.cmdlet = cmdlet;
        }

        public override Collection<PSObject> Run(bool debug)
        {
            Collection<PSObject> result;
            runspace.Open();
            using (var powershell = System.Management.Automation.PowerShell.Create())
            {
                powershell.Runspace = runspace;
                powershell.AddCommand(cmdlet.name);
                if (cmdlet.parameters.Count > 0)
                {
                    foreach (var cmdletparam in cmdlet.parameters)
                    {
                        if(cmdletparam.isSwitch)
                        {
                            powershell.AddParameter(cmdletparam.name);
                        }
                        else
                        {
                            powershell.AddParameter(cmdletparam.name, cmdletparam.value);
                        }
                    }
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

                    var exceptions = powershell.Streams.Error.Select(error => error.Exception).ToList();
                    throw new AggregateException(exceptions);
                }
            }
            runspace.Close();

            return result;  
        }

        public PSInvocationState RunAndStop(int ms)
        {
            PSInvocationState result = 0;
            runspace.Open();
            using (var powershell = System.Management.Automation.PowerShell.Create())
            {
                powershell.Runspace = runspace;
                powershell.AddCommand(cmdlet.name);
                if (cmdlet.parameters.Count > 0)
                {
                    foreach (var cmdletparam in cmdlet.parameters)
                    {
                        if (cmdletparam.value == null)
                        {
                            powershell.AddParameter(cmdletparam.name);
                        }
                        else
                        {
                            powershell.AddParameter(cmdletparam.name, cmdletparam.value);
                        }
                    }
                }

                PrintPSCommand(powershell);

                powershell.BeginInvoke();
                Thread.Sleep(ms);
                powershell.Stop();

                result = powershell.InvocationStateInfo.State;
            }
            runspace.Close();

            return result;
        }
    }
}
