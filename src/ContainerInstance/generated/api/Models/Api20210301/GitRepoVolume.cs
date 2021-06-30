namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>Represents a volume that is populated with the contents of a git repository</summary>
    public partial class GitRepoVolume :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGitRepoVolume,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGitRepoVolumeInternal
    {

        /// <summary>Backing field for <see cref="Directory" /> property.</summary>
        private string _directory;

        /// <summary>
        /// Target directory name. Must not contain or start with '..'. If '.' is supplied, the volume directory will be the git repository.
        /// Otherwise, if specified, the volume will contain the git repository in the subdirectory with the given name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Directory { get => this._directory; set => this._directory = value; }

        /// <summary>Backing field for <see cref="Repository" /> property.</summary>
        private string _repository;

        /// <summary>Repository URL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Repository { get => this._repository; set => this._repository = value; }

        /// <summary>Backing field for <see cref="Revision" /> property.</summary>
        private string _revision;

        /// <summary>Commit hash for the specified revision.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Revision { get => this._revision; set => this._revision = value; }

        /// <summary>Creates an new <see cref="GitRepoVolume" /> instance.</summary>
        public GitRepoVolume()
        {

        }
    }
    /// Represents a volume that is populated with the contents of a git repository
    public partial interface IGitRepoVolume :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Target directory name. Must not contain or start with '..'. If '.' is supplied, the volume directory will be the git repository.
        /// Otherwise, if specified, the volume will contain the git repository in the subdirectory with the given name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target directory name. Must not contain or start with '..'.  If '.' is supplied, the volume directory will be the git repository.  Otherwise, if specified, the volume will contain the git repository in the subdirectory with the given name.",
        SerializedName = @"directory",
        PossibleTypes = new [] { typeof(string) })]
        string Directory { get; set; }
        /// <summary>Repository URL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Repository URL",
        SerializedName = @"repository",
        PossibleTypes = new [] { typeof(string) })]
        string Repository { get; set; }
        /// <summary>Commit hash for the specified revision.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Commit hash for the specified revision.",
        SerializedName = @"revision",
        PossibleTypes = new [] { typeof(string) })]
        string Revision { get; set; }

    }
    /// Represents a volume that is populated with the contents of a git repository
    internal partial interface IGitRepoVolumeInternal

    {
        /// <summary>
        /// Target directory name. Must not contain or start with '..'. If '.' is supplied, the volume directory will be the git repository.
        /// Otherwise, if specified, the volume will contain the git repository in the subdirectory with the given name.
        /// </summary>
        string Directory { get; set; }
        /// <summary>Repository URL</summary>
        string Repository { get; set; }
        /// <summary>Commit hash for the specified revision.</summary>
        string Revision { get; set; }

    }
}