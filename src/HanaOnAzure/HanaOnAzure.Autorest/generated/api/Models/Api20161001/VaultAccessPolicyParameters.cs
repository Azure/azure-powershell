namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Parameters for updating the access policy in a vault</summary>
    public partial class VaultAccessPolicyParameters :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyParameters,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyParametersInternal
    {

        /// <summary>
        /// An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant
        /// ID as the key vault's tenant ID.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[] AccessPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyPropertiesInternal)Property).AccessPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyPropertiesInternal)Property).AccessPolicy = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The resource id of the access policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The resource type of the access policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Location { get => this._location; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyParametersInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Location</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyParametersInternal.Location { get => this._location; set { {_location = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyParametersInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyProperties Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultAccessPolicyProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyParametersInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The resource name of the access policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyProperties _property;

        /// <summary>Properties of the access policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultAccessPolicyProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The resource name of the access policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="VaultAccessPolicyParameters" /> instance.</summary>
        public VaultAccessPolicyParameters()
        {

        }
    }
    /// Parameters for updating the access policy in a vault
    public partial interface IVaultAccessPolicyParameters :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>
        /// An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant
        /// ID as the key vault's tenant ID.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID.",
        SerializedName = @"accessPolicies",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[] AccessPolicy { get; set; }
        /// <summary>The resource id of the access policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource id of the access policy.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The resource type of the access policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource type of the access policy.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get;  }
        /// <summary>The resource name of the access policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource name of the access policy.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The resource name of the access policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource name of the access policy.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Parameters for updating the access policy in a vault
    internal partial interface IVaultAccessPolicyParametersInternal

    {
        /// <summary>
        /// An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant
        /// ID as the key vault's tenant ID.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[] AccessPolicy { get; set; }
        /// <summary>The resource id of the access policy.</summary>
        string Id { get; set; }
        /// <summary>The resource type of the access policy.</summary>
        string Location { get; set; }
        /// <summary>The resource name of the access policy.</summary>
        string Name { get; set; }
        /// <summary>Properties of the access policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyProperties Property { get; set; }
        /// <summary>The resource name of the access policy.</summary>
        string Type { get; set; }

    }
}