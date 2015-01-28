using System.Management.Automation;
using Microsoft.Azure.Commands.ApiManagement.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ApiManagement
{
    [Cmdlet("Restore", "AzureApiManagement"), OutputType(typeof(ApiManagementAttributes))]
    public class RestoreAzureApiManagement : AzurePSCmdlet
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
            Mandatory = true,
            HelpMessage = "Name of Azure Storage blob.")]
        [ValidateNotNullOrEmpty]
        public string Blob { get; set; }
    }
}