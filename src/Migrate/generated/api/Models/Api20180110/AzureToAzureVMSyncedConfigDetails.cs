namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Azure to Azure VM synced configuration details.</summary>
    public partial class AzureToAzureVMSyncedConfigDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal
    {

        /// <summary>Backing field for <see cref="InputEndpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint[] _inputEndpoint;

        /// <summary>The Azure VM input endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint[] InputEndpoint { get => this._inputEndpoint; set => this._inputEndpoint = value; }

        /// <summary>Backing field for <see cref="RoleAssignment" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment[] _roleAssignment;

        /// <summary>The Azure role assignments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment[] RoleAssignment { get => this._roleAssignment; set => this._roleAssignment = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsTags _tag;

        /// <summary>The Azure VM tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureToAzureVMSyncedConfigDetailsTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="AzureToAzureVMSyncedConfigDetails" /> instance.</summary>
        public AzureToAzureVMSyncedConfigDetails()
        {

        }
    }
    /// Azure to Azure VM synced configuration details.
    public partial interface IAzureToAzureVMSyncedConfigDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The Azure VM input endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Azure VM input endpoints.",
        SerializedName = @"inputEndpoints",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint[] InputEndpoint { get; set; }
        /// <summary>The Azure role assignments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Azure role assignments.",
        SerializedName = @"roleAssignments",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment[] RoleAssignment { get; set; }
        /// <summary>The Azure VM tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Azure VM tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsTags Tag { get; set; }

    }
    /// Azure to Azure VM synced configuration details.
    internal partial interface IAzureToAzureVMSyncedConfigDetailsInternal

    {
        /// <summary>The Azure VM input endpoints.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint[] InputEndpoint { get; set; }
        /// <summary>The Azure role assignments.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment[] RoleAssignment { get; set; }
        /// <summary>The Azure VM tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsTags Tag { get; set; }

    }
}