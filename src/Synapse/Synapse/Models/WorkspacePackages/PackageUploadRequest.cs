namespace Microsoft.Azure.Commands.Synapse.Models.WorkspacePackages
{
    /// <summary>
    /// Element of <see cref="PackageUploadRequestQueue">
    /// </summary>
    public class PackageUploadRequest
    {
        /// <summary>
        /// Local file path to the workspace package
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Package name.
        /// </summary>
        public string PackageName { get; set; }
    }
}
