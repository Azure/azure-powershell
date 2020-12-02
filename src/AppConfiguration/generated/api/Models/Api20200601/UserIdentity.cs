namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>A resource identity that is managed by the user of the service.</summary>
    public partial class UserIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IUserIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IUserIdentityInternal
    {

        /// <summary>Backing field for <see cref="ClientId" /> property.</summary>
        private string _clientId;

        /// <summary>The client ID of the user-assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string ClientId { get => this._clientId; }

        /// <summary>Internal Acessors for ClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IUserIdentityInternal.ClientId { get => this._clientId; set { {_clientId = value;} } }

        /// <summary>Internal Acessors for PrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IUserIdentityInternal.PrincipalId { get => this._principalId; set { {_principalId = value;} } }

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>The principal ID of the user-assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; }

        /// <summary>Creates an new <see cref="UserIdentity" /> instance.</summary>
        public UserIdentity()
        {

        }
    }
    /// A resource identity that is managed by the user of the service.
    public partial interface IUserIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>The client ID of the user-assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The client ID of the user-assigned identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get;  }
        /// <summary>The principal ID of the user-assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principal ID of the user-assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get;  }

    }
    /// A resource identity that is managed by the user of the service.
    internal partial interface IUserIdentityInternal

    {
        /// <summary>The client ID of the user-assigned identity.</summary>
        string ClientId { get; set; }
        /// <summary>The principal ID of the user-assigned identity.</summary>
        string PrincipalId { get; set; }

    }
}