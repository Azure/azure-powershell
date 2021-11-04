using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Bicep
{
    [Cmdlet(VerbsData.Publish, AzureRMConstants.AzureRMPrefix + "BicepModule", SupportsShouldProcess = true), OutputType(typeof(void))]
    public class PublishAzureBicepModuleCmdlet : AzureRMCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Local path to the bicep file to publish.")]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target location where the bicep file will be published.")]
        [ValidateNotNullOrEmpty]
        public string Target { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            BicepUtility.PublishFile(this.TryResolvePath(this.FilePath), this.Target, this.WriteVerbose, this.WriteWarning);

            if (this.PassThru.IsPresent)
            {
                this.WriteObject(true);
            }
        }
    }
}
