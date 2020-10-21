namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Git repository property payload</summary>
    public partial class GitPatternRepository :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IGitPatternRepository,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IGitPatternRepositoryInternal
    {

        /// <summary>Backing field for <see cref="HostKey" /> property.</summary>
        private string _hostKey;

        /// <summary>Public sshKey of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string HostKey { get => this._hostKey; set => this._hostKey = value; }

        /// <summary>Backing field for <see cref="HostKeyAlgorithm" /> property.</summary>
        private string _hostKeyAlgorithm;

        /// <summary>SshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string HostKeyAlgorithm { get => this._hostKeyAlgorithm; set => this._hostKeyAlgorithm = value; }

        /// <summary>Backing field for <see cref="Label" /> property.</summary>
        private string _label;

        /// <summary>Label of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Label { get => this._label; set => this._label = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>Password of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Backing field for <see cref="Pattern" /> property.</summary>
        private string[] _pattern;

        /// <summary>Collection of pattern of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string[] Pattern { get => this._pattern; set => this._pattern = value; }

        /// <summary>Backing field for <see cref="PrivateKey" /> property.</summary>
        private string _privateKey;

        /// <summary>Private sshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string PrivateKey { get => this._privateKey; set => this._privateKey = value; }

        /// <summary>Backing field for <see cref="SearchPath" /> property.</summary>
        private string[] _searchPath;

        /// <summary>Searching path of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string[] SearchPath { get => this._searchPath; set => this._searchPath = value; }

        /// <summary>Backing field for <see cref="StrictHostKeyChecking" /> property.</summary>
        private bool? _strictHostKeyChecking;

        /// <summary>Strict host key checking or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public bool? StrictHostKeyChecking { get => this._strictHostKeyChecking; set => this._strictHostKeyChecking = value; }

        /// <summary>Backing field for <see cref="Uri" /> property.</summary>
        private string _uri;

        /// <summary>URI of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Uri { get => this._uri; set => this._uri = value; }

        /// <summary>Backing field for <see cref="Username" /> property.</summary>
        private string _username;

        /// <summary>Username of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Username { get => this._username; set => this._username = value; }

        /// <summary>Creates an new <see cref="GitPatternRepository" /> instance.</summary>
        public GitPatternRepository()
        {

        }
    }
    /// Git repository property payload
    public partial interface IGitPatternRepository :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Public sshKey of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Public sshKey of git repository.",
        SerializedName = @"hostKey",
        PossibleTypes = new [] { typeof(string) })]
        string HostKey { get; set; }
        /// <summary>SshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SshKey algorithm of git repository.",
        SerializedName = @"hostKeyAlgorithm",
        PossibleTypes = new [] { typeof(string) })]
        string HostKeyAlgorithm { get; set; }
        /// <summary>Label of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Label of the repository",
        SerializedName = @"label",
        PossibleTypes = new [] { typeof(string) })]
        string Label { get; set; }
        /// <summary>Name of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name of the repository",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Password of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password of git repository basic auth.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }
        /// <summary>Collection of pattern of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of pattern of the repository",
        SerializedName = @"pattern",
        PossibleTypes = new [] { typeof(string) })]
        string[] Pattern { get; set; }
        /// <summary>Private sshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private sshKey algorithm of git repository.",
        SerializedName = @"privateKey",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateKey { get; set; }
        /// <summary>Searching path of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Searching path of the repository",
        SerializedName = @"searchPaths",
        PossibleTypes = new [] { typeof(string) })]
        string[] SearchPath { get; set; }
        /// <summary>Strict host key checking or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Strict host key checking or not.",
        SerializedName = @"strictHostKeyChecking",
        PossibleTypes = new [] { typeof(bool) })]
        bool? StrictHostKeyChecking { get; set; }
        /// <summary>URI of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"URI of the repository",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string Uri { get; set; }
        /// <summary>Username of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Username of git repository basic auth.",
        SerializedName = @"username",
        PossibleTypes = new [] { typeof(string) })]
        string Username { get; set; }

    }
    /// Git repository property payload
    public partial interface IGitPatternRepositoryInternal

    {
        /// <summary>Public sshKey of git repository.</summary>
        string HostKey { get; set; }
        /// <summary>SshKey algorithm of git repository.</summary>
        string HostKeyAlgorithm { get; set; }
        /// <summary>Label of the repository</summary>
        string Label { get; set; }
        /// <summary>Name of the repository</summary>
        string Name { get; set; }
        /// <summary>Password of git repository basic auth.</summary>
        string Password { get; set; }
        /// <summary>Collection of pattern of the repository</summary>
        string[] Pattern { get; set; }
        /// <summary>Private sshKey algorithm of git repository.</summary>
        string PrivateKey { get; set; }
        /// <summary>Searching path of the repository</summary>
        string[] SearchPath { get; set; }
        /// <summary>Strict host key checking or not.</summary>
        bool? StrictHostKeyChecking { get; set; }
        /// <summary>URI of the repository</summary>
        string Uri { get; set; }
        /// <summary>Username of git repository basic auth.</summary>
        string Username { get; set; }

    }
}