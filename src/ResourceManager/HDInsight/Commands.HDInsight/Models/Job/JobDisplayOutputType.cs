namespace Microsoft.Azure.Commands.HDInsight.Models.Job
{
    public enum JobDisplayOutputType
    {
        /// <summary>
        /// Specifies that the jobDetails output file to download is the stdout file.
        /// </summary>
        StandardOutput,

        /// <summary>
        /// Specifies that the jobDetails output file to download is the stderr file.
        /// </summary>
        StandardError,
    }

    public enum JobDownloadOutputType
    {
        /// <summary>
        /// Specifies that the jobDetails files under logs/ folder should be downloaded.
        /// </summary>
        TaskLogs
    }
}
