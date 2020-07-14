namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Deleted vault information with extended details.</summary>
    public partial class DeletedVault :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVault,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultInternal
    {

        /// <summary>The deleted date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public global::System.DateTime? DeletionDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).DeletionDate; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The resource ID for the deleted key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>The location of the original vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).Location; }

        /// <summary>Internal Acessors for DeletionDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultInternal.DeletionDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).DeletionDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).DeletionDate = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Location</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultInternal.Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).Location = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultProperties Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.DeletedVaultProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ScheduledPurgeDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultInternal.ScheduledPurgeDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).ScheduledPurgeDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).ScheduledPurgeDate = value; }

        /// <summary>Internal Acessors for Tag</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTags Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultInternal.Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).Tag = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for VaultId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultInternal.VaultId { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).VaultId; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).VaultId = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultProperties _property;

        /// <summary>Properties of the vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.DeletedVaultProperties()); set => this._property = value; }

        /// <summary>The scheduled purged date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public global::System.DateTime? ScheduledPurgeDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).ScheduledPurgeDate; }

        /// <summary>Tags of the original vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).Tag; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The resource type of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>The resource id of the original vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string VaultId { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)Property).VaultId; }

        /// <summary>Creates an new <see cref="DeletedVault" /> instance.</summary>
        public DeletedVault()
        {

        }
    }
    /// Deleted vault information with extended details.
    public partial interface IDeletedVault :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>The deleted date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The deleted date.",
        SerializedName = @"deletionDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? DeletionDate { get;  }
        /// <summary>The resource ID for the deleted key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource ID for the deleted key vault.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The location of the original vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The location of the original vault.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get;  }
        /// <summary>The name of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the key vault.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The scheduled purged date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The scheduled purged date.",
        SerializedName = @"scheduledPurgeDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ScheduledPurgeDate { get;  }
        /// <summary>Tags of the original vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Tags of the original vault.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTags Tag { get;  }
        /// <summary>The resource type of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource type of the key vault.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
        /// <summary>The resource id of the original vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource id of the original vault.",
        SerializedName = @"vaultId",
        PossibleTypes = new [] { typeof(string) })]
        string VaultId { get;  }

    }
    /// Deleted vault information with extended details.
    internal partial interface IDeletedVaultInternal

    {
        /// <summary>The deleted date.</summary>
        global::System.DateTime? DeletionDate { get; set; }
        /// <summary>The resource ID for the deleted key vault.</summary>
        string Id { get; set; }
        /// <summary>The location of the original vault.</summary>
        string Location { get; set; }
        /// <summary>The name of the key vault.</summary>
        string Name { get; set; }
        /// <summary>Properties of the vault</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultProperties Property { get; set; }
        /// <summary>The scheduled purged date.</summary>
        global::System.DateTime? ScheduledPurgeDate { get; set; }
        /// <summary>Tags of the original vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTags Tag { get; set; }
        /// <summary>The resource type of the key vault.</summary>
        string Type { get; set; }
        /// <summary>The resource id of the original vault.</summary>
        string VaultId { get; set; }

    }
}