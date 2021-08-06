namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>
    /// Information about a service principal identity for the cluster to use for manipulating Azure APIs.
    /// </summary>
    public partial class ManagedClusterServicePrincipalProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterServicePrincipalProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterServicePrincipalProfileInternal
    {

        /// <summary>Backing field for <see cref="ClientId" /> property.</summary>
        private string _clientId;

        /// <summary>The ID for the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ClientId { get => this._clientId; set => this._clientId = value; }

        /// <summary>Backing field for <see cref="Secret" /> property.</summary>
        private string _secret;

        /// <summary>The secret password associated with the service principal in plain text.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Secret { get => this._secret; set => this._secret = value; }

        /// <summary>Creates an new <see cref="ManagedClusterServicePrincipalProfile" /> instance.</summary>
        public ManagedClusterServicePrincipalProfile()
        {

        }
    }
    /// Information about a service principal identity for the cluster to use for manipulating Azure APIs.
    public partial interface IManagedClusterServicePrincipalProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>The ID for the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID for the service principal.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get; set; }
        /// <summary>The secret password associated with the service principal in plain text.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secret password associated with the service principal in plain text.",
        SerializedName = @"secret",
        PossibleTypes = new [] { typeof(string) })]
        string Secret { get; set; }

    }
    /// Information about a service principal identity for the cluster to use for manipulating Azure APIs.
    internal partial interface IManagedClusterServicePrincipalProfileInternal

    {
        /// <summary>The ID for the service principal.</summary>
        string ClientId { get; set; }
        /// <summary>The secret password associated with the service principal in plain text.</summary>
        string Secret { get; set; }

    }
}