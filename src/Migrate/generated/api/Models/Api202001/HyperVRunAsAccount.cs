namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Run as account REST Resource.</summary>
    public partial class HyperVRunAsAccount :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccount,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountInternal
    {

        /// <summary>Timestamp marking run as account creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CreatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal)Property).CreatedTimestamp; }

        /// <summary>Credential type of the run as account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.CredentialType? CredentialType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal)Property).CredentialType; }

        /// <summary>Display name of the run as account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal)Property).DisplayName; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for CreatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountInternal.CreatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal)Property).CreatedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal)Property).CreatedTimestamp = value; }

        /// <summary>Internal Acessors for CredentialType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.CredentialType? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountInternal.CredentialType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal)Property).CredentialType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal)Property).CredentialType = value; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountInternal.DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal)Property).DisplayName = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.RunAsAccountProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for UpdatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountInternal.UpdatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal)Property).UpdatedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal)Property).UpdatedTimestamp = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the Sites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountProperties _property;

        /// <summary>Nested properties of run as account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.RunAsAccountProperties()); }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of resource. Type = Microsoft.OffAzure/HyperVSites/RunAsAccounts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Timestamp marking last updated on the run as account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string UpdatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountPropertiesInternal)Property).UpdatedTimestamp; }

        /// <summary>Creates an new <see cref="HyperVRunAsAccount" /> instance.</summary>
        public HyperVRunAsAccount()
        {

        }
    }
    /// Run as account REST Resource.
    public partial interface IHyperVRunAsAccount :
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
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Name of the Sites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the Sites.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Type of resource. Type = Microsoft.OffAzure/HyperVSites/RunAsAccounts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of resource. Type = Microsoft.OffAzure/HyperVSites/RunAsAccounts.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
        /// <summary>Timestamp marking last updated on the run as account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking last updated on the run as account.",
        SerializedName = @"updatedTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatedTimestamp { get;  }

    }
    /// Run as account REST Resource.
    internal partial interface IHyperVRunAsAccountInternal

    {
        /// <summary>Timestamp marking run as account creation.</summary>
        string CreatedTimestamp { get; set; }
        /// <summary>Credential type of the run as account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.CredentialType? CredentialType { get; set; }
        /// <summary>Display name of the run as account.</summary>
        string DisplayName { get; set; }
        /// <summary>Resource Id.</summary>
        string Id { get; set; }
        /// <summary>Name of the Sites.</summary>
        string Name { get; set; }
        /// <summary>Nested properties of run as account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IRunAsAccountProperties Property { get; set; }
        /// <summary>Type of resource. Type = Microsoft.OffAzure/HyperVSites/RunAsAccounts.</summary>
        string Type { get; set; }
        /// <summary>Timestamp marking last updated on the run as account.</summary>
        string UpdatedTimestamp { get; set; }

    }
}