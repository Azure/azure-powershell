namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    public partial class UserAssignedIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal
    {

        /// <summary>Backing field for <see cref="ClientId" /> property.</summary>
        private string _clientId;

        /// <summary>The client id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ClientId { get => this._clientId; set => this._clientId = value; }

        /// <summary>Backing field for <see cref="ObjectId" /> property.</summary>
        private string _objectId;

        /// <summary>The object id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ObjectId { get => this._objectId; set => this._objectId = value; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>The resource id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Creates an new <see cref="UserAssignedIdentity" /> instance.</summary>
        public UserAssignedIdentity()
        {

        }
    }
    public partial interface IUserAssignedIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>The client id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client id of the user assigned identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get; set; }
        /// <summary>The object id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The object id of the user assigned identity.",
        SerializedName = @"objectId",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectId { get; set; }
        /// <summary>The resource id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource id of the user assigned identity.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }

    }
    internal partial interface IUserAssignedIdentityInternal

    {
        /// <summary>The client id of the user assigned identity.</summary>
        string ClientId { get; set; }
        /// <summary>The object id of the user assigned identity.</summary>
        string ObjectId { get; set; }
        /// <summary>The resource id of the user assigned identity.</summary>
        string ResourceId { get; set; }

    }
}