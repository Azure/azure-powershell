// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>Definition of Mongo user resource on a cluster.</summary>
    public partial class UserProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IUserProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IUserPropertiesInternal
    {

        /// <summary>Backing field for <see cref="IdentityProvider" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProvider _identityProvider;

        /// <summary>The user's identity provider definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProvider IdentityProvider { get => (this._identityProvider = this._identityProvider ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IdentityProvider()); set => this._identityProvider = value; }

        /// <summary>The type of identity provider that the user belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string IdentityProviderType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProviderInternal)IdentityProvider).Type; }

        /// <summary>Internal Acessors for IdentityProvider</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProvider Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IUserPropertiesInternal.IdentityProvider { get => (this._identityProvider = this._identityProvider ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IdentityProvider()); set { {_identityProvider = value;} } }

        /// <summary>Internal Acessors for IdentityProviderType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IUserPropertiesInternal.IdentityProviderType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProviderInternal)IdentityProvider).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProviderInternal)IdentityProvider).Type = value ?? null; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IUserPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Role" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDatabaseRole> _role;

        /// <summary>Database roles that are assigned to the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDatabaseRole> Role { get => this._role; set => this._role = value; }

        /// <summary>Creates an new <see cref="UserProperties" /> instance.</summary>
        public UserProperties()
        {

        }
    }
    /// Definition of Mongo user resource on a cluster.
    public partial interface IUserProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>The type of identity provider that the user belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of identity provider that the user belongs to.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityProviderType { get;  }
        /// <summary>The provisioning state of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The provisioning state of the user.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "InProgress", "Updating", "Dropping")]
        string ProvisioningState { get;  }
        /// <summary>Database roles that are assigned to the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Database roles that are assigned to the user.",
        SerializedName = @"roles",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDatabaseRole) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDatabaseRole> Role { get; set; }

    }
    /// Definition of Mongo user resource on a cluster.
    internal partial interface IUserPropertiesInternal

    {
        /// <summary>The user's identity provider definition.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProvider IdentityProvider { get; set; }
        /// <summary>The type of identity provider that the user belongs to.</summary>
        string IdentityProviderType { get; set; }
        /// <summary>The provisioning state of the user.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "InProgress", "Updating", "Dropping")]
        string ProvisioningState { get; set; }
        /// <summary>Database roles that are assigned to the user.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDatabaseRole> Role { get; set; }

    }
}