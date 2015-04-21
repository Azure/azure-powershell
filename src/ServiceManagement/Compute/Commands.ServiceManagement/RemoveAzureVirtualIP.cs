using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;


    [Cmdlet(VerbsCommon.Remove, "AzureVirtualIP"), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureVirtualIP : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string VirtualIPName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Do not confirm removal of Virtual IP")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            if (this.Force.IsPresent || this.ShouldContinue(Resources.VirtualIPWillBeRemoved, Resources.RemoveVirtualIP))
            {
                this.ProcessRemoveAzureVirtualIP();
            }
        }

        public void ProcessRemoveAzureVirtualIP()
        {
            ServiceManagementProfile.Initialize();

            string deploymentName = this.ComputeClient.Deployments.GetBySlot(
                        this.ServiceName,
                        DeploymentSlot.Production).Name;

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.NetworkClient.VirtualIPs.Remove(this.ServiceName, deploymentName, this.VirtualIPName));
        }
    }
}
