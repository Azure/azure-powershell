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
    internal class PowershellCmdletSequence : PowershellEnvironment
    {
        private List<CmdletsInfo> cmdlets;

        public PowershellCmdletSequence(List<CmdletsInfo> cmdlets, PowershellModule[] modules) : base(modules)
        {
            this.cmdlets = cmdlets;
        }

        public PowershellCmdletSequence(List<CmdletsInfo> cmdlets) : base()
        {
            this.cmdlets = cmdlets;
        }

        public PowershellCmdletSequence(PowershellModule[] modules) : base(modules)
        {
            this.cmdlets = new List<CmdletsInfo>();
        }

        public PowershellCmdletSequence() : base()
        {
            this.cmdlets = new List<CmdletsInfo>();
        }

        public void Add(CmdletsInfo cmdlet)
        {
            this.cmdlets.Add(cmdlet);
        }

        public Collection<PSObject> RunPipeline()
        {
            Collection<PSObject> result = null;
            runspace.Open();
            using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
            {
                powershell.Runspace = runspace;
                for (int i = 0; i < cmdlets.Count; i++)
                {
                    powershell.AddCommand(cmdlets[i].name);
                    if (cmdlets[i].parameters.Count > 0)
                    {
                        Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
                        foreach (CmdletParam cmdletparam in cmdlets[i].parameters)
                        {
                            paramDictionary.Add(cmdletparam.name, cmdletparam.value);
                        }
                        powershell.AddParameters(paramDictionary);
                    }
                }
                result = powershell.Invoke();

                if (powershell.Streams.Error.Count > 0)
                {
                    runspace.Close();
                    List<Exception> exceptions = new List<Exception>();
                    foreach (ErrorRecord error in powershell.Streams.Error)
                    {
                        exceptions.Add(new Exception(error.Exception.Message));
                    }

                    throw new AggregateException(exceptions);
                }
            }
            runspace.Close();

            return result;
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

                    powershell.AddCommand(cmdlets[i].name);
                    if (cmdlets[i].parameters.Count > 0)
                    {
                        var paramDictionary = new Dictionary<string, object>();
                        foreach (CmdletParam cmdletparam in cmdlets[i].parameters)
                        {
                            paramDictionary.Add(cmdletparam.name, cmdletparam.value);
                        }
                        powershell.AddParameters(paramDictionary);
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
