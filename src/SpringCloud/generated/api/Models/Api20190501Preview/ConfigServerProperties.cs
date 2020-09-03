namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Config server git properties payload</summary>
    public partial class ConfigServerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerProperties,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal
    {

        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IErrorInternal)Error).Code = value; }

        /// <summary>Backing field for <see cref="ConfigServer" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettings _configServer;

        /// <summary>Settings of config server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettings ConfigServer { get => (this._configServer = this._configServer ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ConfigServerSettings()); set => this._configServer = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError _error;

        /// <summary>Error when apply config server settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.Error()); set => this._error = value; }

        /// <summary>Public sshKey of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyHostKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyHostKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyHostKey = value; }

        /// <summary>SshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyHostKeyAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyHostKeyAlgorithm; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyHostKeyAlgorithm = value; }

        /// <summary>Label of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyLabel = value; }

        /// <summary>Password of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyPassword = value; }

        /// <summary>Private sshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyPrivateKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyPrivateKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyPrivateKey = value; }

        /// <summary>Repositories of git.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository[] GitPropertyRepository { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyRepository; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyRepository = value; }

        /// <summary>Searching path of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string[] GitPropertySearchPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertySearchPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertySearchPath = value; }

        /// <summary>Strict host key checking or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public bool? GitPropertyStrictHostKeyChecking { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyStrictHostKeyChecking; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyStrictHostKeyChecking = value; }

        /// <summary>URI of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyUri = value; }

        /// <summary>Username of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitPropertyUsername = value; }

        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IErrorInternal)Error).Message = value; }

        /// <summary>Internal Acessors for ConfigServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettings Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal.ConfigServer { get => (this._configServer = this._configServer ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ConfigServerSettings()); set { {_configServer = value;} } }

        /// <summary>Internal Acessors for ConfigServerGitProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerGitProperty Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal.ConfigServerGitProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettingsInternal)ConfigServer).GitProperty = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.Error()); set { {_error = value;} } }

        /// <summary>Internal Acessors for State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? _state;

        /// <summary>State of the config server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? State { get => this._state; }

        /// <summary>Creates an new <see cref="ConfigServerProperties" /> instance.</summary>
        public ConfigServerProperties()
        {

        }
    }
    /// Config server git properties payload
    public partial interface IConfigServerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The code of error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Public sshKey of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Public sshKey of git repository.",
        SerializedName = @"hostKey",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyHostKey { get; set; }
        /// <summary>SshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SshKey algorithm of git repository.",
        SerializedName = @"hostKeyAlgorithm",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyHostKeyAlgorithm { get; set; }
        /// <summary>Label of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Label of the repository",
        SerializedName = @"label",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyLabel { get; set; }
        /// <summary>Password of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password of git repository basic auth.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyPassword { get; set; }
        /// <summary>Private sshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private sshKey algorithm of git repository.",
        SerializedName = @"privateKey",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyPrivateKey { get; set; }
        /// <summary>Repositories of git.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Repositories of git.",
        SerializedName = @"repositories",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository[] GitPropertyRepository { get; set; }
        /// <summary>Searching path of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Searching path of the repository",
        SerializedName = @"searchPaths",
        PossibleTypes = new [] { typeof(string) })]
        string[] GitPropertySearchPath { get; set; }
        /// <summary>Strict host key checking or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Strict host key checking or not.",
        SerializedName = @"strictHostKeyChecking",
        PossibleTypes = new [] { typeof(bool) })]
        bool? GitPropertyStrictHostKeyChecking { get; set; }
        /// <summary>URI of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"URI of the repository",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyUri { get; set; }
        /// <summary>Username of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Username of git repository basic auth.",
        SerializedName = @"username",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyUsername { get; set; }
        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The message of error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>State of the config server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the config server.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? State { get;  }

    }
    /// Config server git properties payload
    public partial interface IConfigServerPropertiesInternal

    {
        /// <summary>The code of error.</summary>
        string Code { get; set; }
        /// <summary>Settings of config server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettings ConfigServer { get; set; }
        /// <summary>Property of git environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerGitProperty ConfigServerGitProperty { get; set; }
        /// <summary>Error when apply config server settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError Error { get; set; }
        /// <summary>Public sshKey of git repository.</summary>
        string GitPropertyHostKey { get; set; }
        /// <summary>SshKey algorithm of git repository.</summary>
        string GitPropertyHostKeyAlgorithm { get; set; }
        /// <summary>Label of the repository</summary>
        string GitPropertyLabel { get; set; }
        /// <summary>Password of git repository basic auth.</summary>
        string GitPropertyPassword { get; set; }
        /// <summary>Private sshKey algorithm of git repository.</summary>
        string GitPropertyPrivateKey { get; set; }
        /// <summary>Repositories of git.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository[] GitPropertyRepository { get; set; }
        /// <summary>Searching path of the repository</summary>
        string[] GitPropertySearchPath { get; set; }
        /// <summary>Strict host key checking or not.</summary>
        bool? GitPropertyStrictHostKeyChecking { get; set; }
        /// <summary>URI of the repository</summary>
        string GitPropertyUri { get; set; }
        /// <summary>Username of git repository basic auth.</summary>
        string GitPropertyUsername { get; set; }
        /// <summary>The message of error.</summary>
        string Message { get; set; }
        /// <summary>State of the config server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? State { get; set; }

    }
}