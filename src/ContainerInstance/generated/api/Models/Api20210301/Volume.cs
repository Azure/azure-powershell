namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The properties of the volume.</summary>
    public partial class Volume :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeInternal
    {

        /// <summary>Backing field for <see cref="AzureFile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolume _azureFile;

        /// <summary>The Azure File volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolume AzureFile { get => (this._azureFile = this._azureFile ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.AzureFileVolume()); set => this._azureFile = value; }

        /// <summary>
        /// The flag indicating whether the Azure File shared mounted as a volume is read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public bool? AzureFileReadOnly { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)AzureFile).ReadOnly; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)AzureFile).ReadOnly = value ?? default(bool); }

        /// <summary>The name of the Azure File share to be mounted as a volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string AzureFileShareName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)AzureFile).ShareName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)AzureFile).ShareName = value ?? null; }

        /// <summary>The storage account access key used to access the Azure File share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string AzureFileStorageAccountKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)AzureFile).StorageAccountKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)AzureFile).StorageAccountKey = value ?? null; }

        /// <summary>The name of the storage account that contains the Azure File share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string AzureFileStorageAccountName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)AzureFile).StorageAccountName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)AzureFile).StorageAccountName = value ?? null; }

        /// <summary>Backing field for <see cref="EmptyDir" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IAny _emptyDir;

        /// <summary>The empty directory volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IAny EmptyDir { get => (this._emptyDir = this._emptyDir ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Any()); set => this._emptyDir = value; }

        /// <summary>Backing field for <see cref="GitRepo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGitRepoVolume _gitRepo;

        /// <summary>The git repo volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGitRepoVolume GitRepo { get => (this._gitRepo = this._gitRepo ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.GitRepoVolume()); set => this._gitRepo = value; }

        /// <summary>
        /// Target directory name. Must not contain or start with '..'. If '.' is supplied, the volume directory will be the git repository.
        /// Otherwise, if specified, the volume will contain the git repository in the subdirectory with the given name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string GitRepoDirectory { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGitRepoVolumeInternal)GitRepo).Directory; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGitRepoVolumeInternal)GitRepo).Directory = value ?? null; }

        /// <summary>Repository URL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string GitRepoRepository { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGitRepoVolumeInternal)GitRepo).Repository; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGitRepoVolumeInternal)GitRepo).Repository = value ?? null; }

        /// <summary>Commit hash for the specified revision.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string GitRepoRevision { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGitRepoVolumeInternal)GitRepo).Revision; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGitRepoVolumeInternal)GitRepo).Revision = value ?? null; }

        /// <summary>Internal Acessors for AzureFile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolume Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeInternal.AzureFile { get => (this._azureFile = this._azureFile ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.AzureFileVolume()); set { {_azureFile = value;} } }

        /// <summary>Internal Acessors for GitRepo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGitRepoVolume Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeInternal.GitRepo { get => (this._gitRepo = this._gitRepo ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.GitRepoVolume()); set { {_gitRepo = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Secret" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ISecretVolume _secret;

        /// <summary>The secret volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ISecretVolume Secret { get => (this._secret = this._secret ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.SecretVolume()); set => this._secret = value; }

        /// <summary>Creates an new <see cref="Volume" /> instance.</summary>
        public Volume()
        {

        }
    }
    /// The properties of the volume.
    public partial interface IVolume :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The flag indicating whether the Azure File shared mounted as a volume is read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The flag indicating whether the Azure File shared mounted as a volume is read-only.",
        SerializedName = @"readOnly",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AzureFileReadOnly { get; set; }
        /// <summary>The name of the Azure File share to be mounted as a volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Azure File share to be mounted as a volume.",
        SerializedName = @"shareName",
        PossibleTypes = new [] { typeof(string) })]
        string AzureFileShareName { get; set; }
        /// <summary>The storage account access key used to access the Azure File share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The storage account access key used to access the Azure File share.",
        SerializedName = @"storageAccountKey",
        PossibleTypes = new [] { typeof(string) })]
        string AzureFileStorageAccountKey { get; set; }
        /// <summary>The name of the storage account that contains the Azure File share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the storage account that contains the Azure File share.",
        SerializedName = @"storageAccountName",
        PossibleTypes = new [] { typeof(string) })]
        string AzureFileStorageAccountName { get; set; }
        /// <summary>The empty directory volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The empty directory volume.",
        SerializedName = @"emptyDir",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IAny EmptyDir { get; set; }
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
        string GitRepoDirectory { get; set; }
        /// <summary>Repository URL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Repository URL",
        SerializedName = @"repository",
        PossibleTypes = new [] { typeof(string) })]
        string GitRepoRepository { get; set; }
        /// <summary>Commit hash for the specified revision.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Commit hash for the specified revision.",
        SerializedName = @"revision",
        PossibleTypes = new [] { typeof(string) })]
        string GitRepoRevision { get; set; }
        /// <summary>The name of the volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the volume.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The secret volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secret volume.",
        SerializedName = @"secret",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ISecretVolume) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ISecretVolume Secret { get; set; }

    }
    /// The properties of the volume.
    internal partial interface IVolumeInternal

    {
        /// <summary>The Azure File volume.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolume AzureFile { get; set; }
        /// <summary>
        /// The flag indicating whether the Azure File shared mounted as a volume is read-only.
        /// </summary>
        bool? AzureFileReadOnly { get; set; }
        /// <summary>The name of the Azure File share to be mounted as a volume.</summary>
        string AzureFileShareName { get; set; }
        /// <summary>The storage account access key used to access the Azure File share.</summary>
        string AzureFileStorageAccountKey { get; set; }
        /// <summary>The name of the storage account that contains the Azure File share.</summary>
        string AzureFileStorageAccountName { get; set; }
        /// <summary>The empty directory volume.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IAny EmptyDir { get; set; }
        /// <summary>The git repo volume.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGitRepoVolume GitRepo { get; set; }
        /// <summary>
        /// Target directory name. Must not contain or start with '..'. If '.' is supplied, the volume directory will be the git repository.
        /// Otherwise, if specified, the volume will contain the git repository in the subdirectory with the given name.
        /// </summary>
        string GitRepoDirectory { get; set; }
        /// <summary>Repository URL</summary>
        string GitRepoRepository { get; set; }
        /// <summary>Commit hash for the specified revision.</summary>
        string GitRepoRevision { get; set; }
        /// <summary>The name of the volume.</summary>
        string Name { get; set; }
        /// <summary>The secret volume.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ISecretVolume Secret { get; set; }

    }
}