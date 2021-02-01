namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for run as account properties.</summary>
    public partial class RunAsAccountProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreatedTimestamp" /> property.</summary>
        private string _createdTimestamp;

        /// <summary>Timestamp marking run as account creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CreatedTimestamp { get => this._createdTimestamp; }

        /// <summary>Backing field for <see cref="CredentialType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.CredentialType? _credentialType;

        /// <summary>Credential type of the run as account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.CredentialType? CredentialType { get => this._credentialType; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display name of the run as account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; }

        /// <summary>Internal Acessors for CreatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal.CreatedTimestamp { get => this._createdTimestamp; set { {_createdTimestamp = value;} } }

        /// <summary>Internal Acessors for CredentialType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.CredentialType? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal.CredentialType { get => this._credentialType; set { {_credentialType = value;} } }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal.DisplayName { get => this._displayName; set { {_displayName = value;} } }

        /// <summary>Internal Acessors for UpdatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal.UpdatedTimestamp { get => this._updatedTimestamp; set { {_updatedTimestamp = value;} } }

        /// <summary>Backing field for <see cref="UpdatedTimestamp" /> property.</summary>
        private string _updatedTimestamp;

        /// <summary>Timestamp marking last updated on the run as account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string UpdatedTimestamp { get => this._updatedTimestamp; }

        /// <summary>Creates an new <see cref="RunAsAccountProperties" /> instance.</summary>
        public RunAsAccountProperties()
        {

        }
    }
    /// Class for run as account properties.
    public partial interface IRunAsAccountProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Timestamp marking run as account creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking run as account creation.",
        SerializedName = @"createdTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedTimestamp { get;  }
        /// <summary>Credential type of the run as account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Credential type of the run as account.",
        SerializedName = @"credentialType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.CredentialType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.CredentialType? CredentialType { get;  }
        /// <summary>Display name of the run as account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display name of the run as account.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>Timestamp marking last updated on the run as account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking last updated on the run as account.",
        SerializedName = @"updatedTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatedTimestamp { get;  }

    }
    /// Class for run as account properties.
    internal partial interface IRunAsAccountPropertiesInternal

    {
        /// <summary>Timestamp marking run as account creation.</summary>
        string CreatedTimestamp { get; set; }
        /// <summary>Credential type of the run as account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.CredentialType? CredentialType { get; set; }
        /// <summary>Display name of the run as account.</summary>
        string DisplayName { get; set; }
        /// <summary>Timestamp marking last updated on the run as account.</summary>
        string UpdatedTimestamp { get; set; }

    }
}