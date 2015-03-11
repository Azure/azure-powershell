namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using Microsoft.WindowsAzure.Commands.Common.Storage;

    [Cmdlet("Backup", "AzureApiManagement"), OutputType(typeof(ApiManagementAttributes))]
    public class BackupAzureApiManagement : ApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true, 
            HelpMessage = "Name of resource group under which API Management exists.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true, 
            HelpMessage = "Name of API Management.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the storage context
        /// </summary>
        [Parameter(
            Mandatory = true, 
            Position = 1,
            HelpMessage = "The storage connection context.")]
        [ValidateNotNull]
        public AzureStorageContext StorageContext { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true, 
            Mandatory = true, 
            HelpMessage = "Name of Azure Storage container.")]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Name of Azure Storage blob.")]
        [ValidateNotNullOrEmpty]
        public string Blob { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecuteCmdLetWrap(() =>
            {
                ApiManagementLongRunningOperation longRunningOperation =
                    this.Client.BeginBackupApiManagement(
                        this.ResourceGroupName,
                        this.Name,
                        this.StorageContext.StorageAccount.Credentials.AccountName,
                        this.StorageContext.StorageAccount.Credentials.ExportBase64EncodedKey(),
                        this.Container,
                        this.Blob);

                longRunningOperation = WaitForOperationToComplete(longRunningOperation);
                bool success = string.IsNullOrWhiteSpace(longRunningOperation.Error);
                if (!success)
                {
                    WriteErrorWithTimestamp(longRunningOperation.Error);
                }

                if (this.PassThru.IsPresent)
                {
                    WriteObject(success);
                }
            });
        }
    }
}