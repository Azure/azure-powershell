using System.Management.Automation;
using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [GenericBreakingChange("Export-AzDataLakeStoreChildItemProperties alias will be removed in an upcoming breaking change release", "2.0.0")]
    [Cmdlet("Export", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeStoreChildItemProperty", SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Export-AdlStoreChildItemProperties", "Export-AzDataLakeStoreChildItemProperties")]
    public class ExportAzureRmDataLakeStoreChildItemProperties : DataLakeStoreFileSystemCmdletBase
    {
        internal const string BaseParameterSetName = "GetDiskUsage";
        internal const string GetAclParameterSetName = "GetAclDump";
        internal const string GetBothParameterSetName = "GetAllProperties";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The Data Lake Store account to execute the filesystem operation in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage =
                "The path in the specified Data Lake account whose properties need to be retrieved. Can be a file or folder " +
                "In the format '/folder/file.txt', " +
                "where the first '/' after the DNS indicates the root of the file system.")]
        [ValidateNotNull]
        public DataLakeStorePathInstance Path { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "Path to output file. Can be a Local path or Adl Path. By default"+
                          " it is local. If SaveToAdl is pecified then it is an ADL path in the same account")]
        [ValidateNotNullOrEmpty]
        public string OutputPath { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Save output to ADL Store, in the same account. The OutputPath parameter should be the full ADL path to output to." + 
                "Default is to save to a local file. In that case, OutputPath specifies the pathto local file.")]
        public SwitchParameter SaveToAdl { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Show stats at file level (default is to show directory-level info only)")]
        public SwitchParameter IncludeFile { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Maximum depth from the Path specified, to which disk usage or acl is displayed")]
        public int MaximumDepth { get; set; } = int.MaxValue;

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Number of files/directories processed in parallel. Optional: a reasonable default will be selected")]
        public int Concurrency { get; set; } = -1;

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = BaseParameterSetName, Mandatory = true,
            HelpMessage = "Retrieves the disk usage starting from the Path specified")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = GetBothParameterSetName, Mandatory = true,
            HelpMessage = "Retrieves the disk usage starting from the Path specified")]
        public SwitchParameter GetDiskUsage { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = GetAclParameterSetName, Mandatory = true,
            HelpMessage = "Retrieves the acl starting from the Path specified")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = GetBothParameterSetName, Mandatory = true,
            HelpMessage = "Retrieves the acl starting from the Path specified")]
        public SwitchParameter GetAcl { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = GetAclParameterSetName, Mandatory = false,
            HelpMessage = "Do not show directory subtree if the ACLs are the same throughout the entire subtree. This " +
                          "makes it easier to see only the paths up to which the ACLs differ." +
                          "For example if all files and folders under /a/b are the same, do not show the subtree" +
                          "under /a/b, and just output /a/b with 'True' in the Consistent ACL column" +
                          "Cannot be set if IncludeFiles is not set, because consistent Acl cannot be determined without retrieving acls for the files.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = GetBothParameterSetName, Mandatory = false,
            HelpMessage = "Do not show directory subtree if the ACLs are the same throughout the entire subtree. This " +
                          "makes it easier to see only the paths up to which the ACLs differ." +
                          "For example if all files and folders under /a/b are the same, do not show the subtree" +
                          "under /a/b, and just output /a/b with 'True' in the Consistent ACL column" +
                          "Cannot be set if IncludeFiles is not set, because consistent Acl cannot be determined without retrieving acls for the files.")]
        public SwitchParameter HideConsistentAcl { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage =
                "Indicates a boolean response should be returned indicating the result of the delete operation."
        )]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            // Currently SDK default thread calculation is not correct, so pass a default thread count
            int threadCount = Concurrency == -1 ? DataLakeStoreFileSystemClient.ImportExportMaxThreads : Concurrency;

            DataLakeStoreFileSystemClient.GetFileProperties(Account, Path.TransformedPath, GetAcl, OutputPath,
                GetDiskUsage, !SaveToAdl, threadCount, IncludeFile, HideConsistentAcl, MaximumDepth, this, CmdletCancellationToken);
            if (PassThru)
            {
                WriteObject(true);
            }
        }

    }
}
