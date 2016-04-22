using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.ServerManagement;
using Microsoft.Azure.Management.ServerManagement.Models;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.PowerShell
{
    [Cmdlet(VerbsLifecycle.Invoke, "AzureRmServerManagementPowerShellCommand"), OutputType(typeof(PowerShellCommandResult))]
    public class InvokeAzureRmServerManagementPowerShellCommand : ServerManagementCmdlet
    {
        #region ByName
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the node.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the session.", ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName")]
        [ValidateNotNullOrEmpty]
        public string SessionName { get; set; }
        #endregion

        #region BySession
        [Parameter(Mandatory = true, HelpMessage = "The session.", ValueFromPipeline = true, ParameterSetName = "BySession")]
        [ValidateNotNullOrEmpty]
        public Model.Session Session { get; set; }
        #endregion

        [Parameter(Mandatory = true, HelpMessage = "The script to execute.")]
        [ValidateNotNull]
        public ScriptBlock Command { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the powershell session to use. (defaults to last PS Session used, or creates a new PS session)")]
        public string PowerShellSessionName { get; set; }

        private PowerShellSessionResource PSSession
        {
            get
            {
                PowerShellSessionResource ps = null;
                try
                {
                    if (PowerShellSessionName != null)
                    {
                        WriteVerbose($"Checking for PowerShell Session with {ResourceGroupName}/{NodeName}/{SessionName}");

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
                    PowerShellSessionName = new Guid().ToString();
                    WriteVerbose($"Generating PowerShell Session name {PowerShellSessionName}");

                }

                if (ps == null)
                {
                    WriteVerbose($"Can't find existing PowerShell Session, creating new one.");
                    ps = Client.PowerShell.CreateSession(ResourceGroupName, NodeName, SessionName, PowerShellSessionName);
                }

                return ps;
            }
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Session != null)
            {
                WriteVerbose($"Using Session object for resource group/node name/session name");
                ResourceGroupName = Session.ResourceGroupName;
                NodeName = Session.NodeName;
                SessionName = Session.Name;
                if (PowerShellSessionName == null && Session.LastPowerShellSessionName != null)
                {
                    PowerShellSessionName = Session.LastPowerShellSessionName;
                    WriteVerbose($"Using previous PowerShell Session {Session.LastPowerShellSessionName}");
                }
            }

            PowerShellSessionResource ps = PSSession;
            if (Session != null)
            {
                Session.LastPowerShellSessionName = ps.Name;
            }

            WriteVerbose($"Invoking PowerShell command on {ResourceGroupName}/{NodeName}/{SessionName}/{ps.Name}");
            // call powershell on node.
            var results = Client.PowerShell.InvokeCommand(ResourceGroupName, NodeName, SessionName, ps.Name,
                Command.ToString());
            do
            {
                WriteVerbose($"Iterating on results ");
                // spit out results.
                foreach (var r in results.Results)
                {
                    WriteObject(r);
                }
                if (results.Completed ?? false)
                {
                    break;
                }
                WriteVerbose($"Command is still executing, getting updates.");
                results = Client.PowerShell.GetCommandStatus(ResourceGroupName, NodeName, SessionName, SessionName, PowerShellExpandOption.Output);

            } while (true);
        }
    }
}