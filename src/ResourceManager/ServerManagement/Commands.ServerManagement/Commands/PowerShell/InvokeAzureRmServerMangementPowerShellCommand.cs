// Copyright Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.ServerManagement.Commands.PowerShell
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Base;
    using Management.ServerManagement;
    using Management.ServerManagement.Models;
    using Model;

    [Cmdlet(VerbsLifecycle.Invoke, "AzureRmServerManagementPowerShellCommand"), OutputType(typeof(object))]
    public class InvokeAzureRmServerManagementPowerShellCommand : ServerManagementCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName", Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the node.", ValueFromPipelineByPropertyName = true,
            ParameterSetName = "ByName", Position = 1)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the session.", ValueFromPipelineByPropertyName = true,
            ParameterSetName = "ByName", Position = 2)]
        [ValidateNotNullOrEmpty]
        public string SessionName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The session.", ValueFromPipeline = true,
            ParameterSetName = "BySession", Position = 0)]
        [ValidateNotNullOrEmpty]
        public Session Session { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The script to execute.", Position = 3)]
        [ValidateNotNull]
        public ScriptBlock Command { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage =
                "The name of the powershell session to use. (defaults to last PS Session used, or creates a new PS session)"
            )]
        public string PowerShellSessionName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "When specified, returns the raw PowerShellCommandResult objects instead of just the output.")
        ]
        public SwitchParameter RawOutput { get; set; }

        private PowerShellSessionResource PSSession
        {
            get
            {
                PowerShellSessionResource ps = null;
                try
                {
                    if (PowerShellSessionName != null)
                    {
                        WriteVerbose(
                            string.Format("Checking for PowerShell Session with {0}/{1}/{2}",
                                ResourceGroupName,
                                NodeName,
                                SessionName));

                        ps = Client.PowerShell.ListSession(ResourceGroupName, NodeName, SessionName)
                            .Value.FirstOrDefault(each => each.PowerShellSessionResourceName == PowerShellSessionName);
                    }
                }
                catch
                {
                    // didn't find it. 
                }

                if (PowerShellSessionName == null)
                {
                    PowerShellSessionName = Guid.NewGuid().ToString();
                    WriteVerbose(string.Format("Generating PowerShell Session name {0}", PowerShellSessionName));
                }

                if (ps == null)
                {
                    WriteVerbose("Can't find existing PowerShell Session, creating new one.");
                    ps = Client.PowerShell.CreateSession(ResourceGroupName, NodeName, SessionName, "00000000-0000-0000-0000-000000000000");
                    PowerShellSessionName = ps.SessionId;
                }

                return ps;
            }
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Session != null)
            {
                WriteVerbose("Using Session object for resource group/node name/session name");
                ResourceGroupName = Session.ResourceGroupName;
                NodeName = Session.NodeName;
                SessionName = Session.Name;
                if (PowerShellSessionName == null && Session.LastPowerShellSessionName != null)
                {
                    PowerShellSessionName = Session.LastPowerShellSessionName;
                    WriteVerbose(string.Format("Using previous PowerShell Session {0}",
                        Session.LastPowerShellSessionName));
                }
            }

            var ps = PSSession;
            if (Session != null)
            {
                Session.LastPowerShellSessionName = ps.SessionId;
            }

            WriteVerbose(string.Format("Invoking PowerShell command on {0}/{1}/{2}/{3}",
                ResourceGroupName,
                NodeName,
                SessionName,
                ps.SessionId));
            // call powershell on node.
            var results = Client.PowerShell.InvokeCommand(ResourceGroupName,
                NodeName,
                SessionName,
                ps.SessionId,
                Command.ToString());

            var items = results.Results;
            var done = results.Completed;

            do
            {
                WriteVerbose("Iterating on results ");
                // spit out results.
                foreach (var r in items)
                {
                    if (RawOutput)
                    {
                        WriteObject(r);
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(r.Value))
                        {
                            WriteObject(r.Value);
                        }
                    }
                }
                if (done ?? false)
                {
                    break;
                }
                WriteVerbose("Command is still executing, getting updates.");
                var more = Client.PowerShell.GetCommandStatus(ResourceGroupName,
                    NodeName,
                    SessionName,
                    ps.SessionId,
                    PowerShellExpandOption.Output);
                done = more.Completed;
                items = more.Results;
            } while (true);
        }
    }
}