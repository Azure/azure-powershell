namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>The properties associated with the system assigned identity.</summary>
    public partial class SystemAssignedIdentityProperties :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityProperties,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ClientId" /> property.</summary>
        private string _clientId;

        /// <summary>
        /// The id of the app associated with the identity. This is a random generated UUID by MSI.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string ClientId { get => this._clientId; }

        /// <summary>Backing field for <see cref="ClientSecretUrl" /> property.</summary>
        private string _clientSecretUrl;

        /// <summary>
        /// The ManagedServiceIdentity DataPlane URL that can be queried to obtain the identity credentials.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string ClientSecretUrl { get => this._clientSecretUrl; }

        /// <summary>Internal Acessors for ClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal.ClientId { get => this._clientId; set { {_clientId = value;} } }

        /// <summary>Internal Acessors for ClientSecretUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal.ClientSecretUrl { get => this._clientSecretUrl; set { {_clientSecretUrl = value;} } }

        /// <summary>Internal Acessors for PrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal.PrincipalId { get => this._principalId; set { {_principalId = value;} } }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20181130.ISystemAssignedIdentityPropertiesInternal.TenantId { get => this._tenantId; set { {_tenantId = value;} } }

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>The id of the service principal object associated with the created identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>The id of the tenant which the identity belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; }

        /// <summary>Creates an new <see cref="SystemAssignedIdentityProperties" /> instance.</summary>
        public SystemAssignedIdentityProperties()
        {

        }
    }
    /// The properties associated with the system assigned identity.
    public partial interface ISystemAssignedIdentityProperties :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The id of the app associated with the identity. This is a random generated UUID by MSI.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The id of the app associated with the identity. This is a random generated UUID by MSI.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get;  }
        /// <summary>
        /// The ManagedServiceIdentity DataPlane URL that can be queried to obtain the identity credentials.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @" The ManagedServiceIdentity DataPlane URL that can be queried to obtain the identity credentials.",
        SerializedName = @"clientSecretUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ClientSecretUrl { get;  }
        /// <summary>The id of the service principal object associated with the created identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The id of the service principal object associated with the created identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get;  }
        /// <summary>The id of the tenant which the identity belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The id of the tenant which the identity belongs to.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get;  }

    }
    /// The properties associated with the system assigned identity.
    internal partial interface ISystemAssignedIdentityPropertiesInternal

    {
        /// <summary>
        /// The id of the app associated with the identity. This is a random generated UUID by MSI.
        /// </summary>
        string ClientId { get; set; }
        /// <summary>
        /// The ManagedServiceIdentity DataPlane URL that can be queried to obtain the identity credentials.
        /// </summary>
        string ClientSecretUrl { get; set; }
        /// <summary>The id of the service principal object associated with the created identity.</summary>
        string PrincipalId { get; set; }
        /// <summary>The id of the tenant which the identity belongs to.</summary>
        string TenantId { get; set; }

    }
}