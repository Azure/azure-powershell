using System.Management.Automation;
using Microsoft.Azure.Commands.DataLakeStore.DataPlaneModels;
using Microsoft.Azure.Commands.DataLakeStore.Models;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Get, "AzureRmDataLakeStoreChildItemSummary", SupportsShouldProcess = true), OutputType(typeof(DataLakeStoreChildItemSummary))]
    [Alias("Get-AdlStoreChildItemSummary")]
    public class GetAzureRmDataLakeStoreChildItemSummary : DataLakeStoreFileSystemCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The Data Lake Store account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage =
                "The path in the specified Data Lake account that should be retrieve. Can be a file or folder " +
                "In the format '/folder/file.txt', " +
                "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Indicates the number of files/directories processed in parallel. Default will be computed as a best effort based on system specification."
        )]
        public int Concurrency { get; set; } = -1;

        public override void ExecuteCmdlet()
        {
            var toReturn = DataLakeStoreFileSystemClient.GetContentSummary(Path.TransformedPath, Account, Concurrency, CmdletCancellationToken);
            WriteObject(new DataLakeStoreChildItemSummary(toReturn));
        }
    }
}