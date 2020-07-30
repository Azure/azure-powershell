namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Properties of the deleted vault.</summary>
    public partial class DeletedVaultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultProperties,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DeletionDate" /> property.</summary>
        private global::System.DateTime? _deletionDate;

        /// <summary>The deleted date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public global::System.DateTime? DeletionDate { get => this._deletionDate; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The location of the original vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Location { get => this._location; }

        /// <summary>Internal Acessors for DeletionDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal.DeletionDate { get => this._deletionDate; set { {_deletionDate = value;} } }

        /// <summary>Internal Acessors for Location</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal.Location { get => this._location; set { {_location = value;} } }

        /// <summary>Internal Acessors for ScheduledPurgeDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal.ScheduledPurgeDate { get => this._scheduledPurgeDate; set { {_scheduledPurgeDate = value;} } }

        /// <summary>Internal Acessors for Tag</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTags Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal.Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.DeletedVaultPropertiesTags()); set { {_tag = value;} } }

        /// <summary>Internal Acessors for VaultId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal.VaultId { get => this._vaultId; set { {_vaultId = value;} } }

        /// <summary>Backing field for <see cref="ScheduledPurgeDate" /> property.</summary>
        private global::System.DateTime? _scheduledPurgeDate;

        /// <summary>The scheduled purged date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public global::System.DateTime? ScheduledPurgeDate { get => this._scheduledPurgeDate; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTags _tag;

        /// <summary>Tags of the original vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.DeletedVaultPropertiesTags()); }

        /// <summary>Backing field for <see cref="VaultId" /> property.</summary>
        private string _vaultId;

        /// <summary>The resource id of the original vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string VaultId { get => this._vaultId; }

        /// <summary>Creates an new <see cref="DeletedVaultProperties" /> instance.</summary>
        public DeletedVaultProperties()
        {

        }
    }
    /// Properties of the deleted vault.
    public partial interface IDeletedVaultProperties :
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
        /// <summary>The location of the original vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The location of the original vault.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get;  }
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
        /// <summary>The resource id of the original vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource id of the original vault.",
        SerializedName = @"vaultId",
        PossibleTypes = new [] { typeof(string) })]
        string VaultId { get;  }

    }
    /// Properties of the deleted vault.
    internal partial interface IDeletedVaultPropertiesInternal

    {
        /// <summary>The deleted date.</summary>
        global::System.DateTime? DeletionDate { get; set; }
        /// <summary>The location of the original vault.</summary>
        string Location { get; set; }
        /// <summary>The scheduled purged date.</summary>
        global::System.DateTime? ScheduledPurgeDate { get; set; }
        /// <summary>Tags of the original vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTags Tag { get; set; }
        /// <summary>The resource id of the original vault.</summary>
        string VaultId { get; set; }

    }
}