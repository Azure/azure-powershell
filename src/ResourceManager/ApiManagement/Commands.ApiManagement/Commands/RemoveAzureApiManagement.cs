namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.Properties;

    [Cmdlet(VerbsCommon.Remove, "AzureApiManagement"), OutputType(typeof(bool))]
    public class RemoveAzureApiManagement : ApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which API Management service exists.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of API Management service.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the switch to not confirm on the removal API Management service.
        /// </summary>
        [Parameter(HelpMessage = "Do not confirm on the removal of the API Management service.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecuteCmdLetWrap(() =>
            {
                string actionDescription = string.Format(
                CultureInfo.InvariantCulture,
                Resources.RemoveAzureApiManagementDescription,
                this.Name);

                string actionWarning = string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.RemoveAzureApiManagementWarning,
                    this.Name);

                // Do nothing if force is not specified and user cancelled the operation
                if (!this.Force.IsPresent &&
                    !this.ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
                {
                    return;
                }

                this.Client.DeleteApiManagement(
                    this.ResourceGroupName,
                    this.Name);

                if (this.PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            });
        }
    }
}