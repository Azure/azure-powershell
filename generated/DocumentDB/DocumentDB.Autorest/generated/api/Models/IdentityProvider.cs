// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>Defines a user's identity provider definition.</summary>
    public partial class IdentityProvider :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProvider,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProviderInternal
    {

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProviderInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type= @"MicrosoftEntraID";

        /// <summary>The type of identity provider that the user belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="IdentityProvider" /> instance.</summary>
        public IdentityProvider()
        {

        }
    }
    /// Defines a user's identity provider definition.
    public partial interface IIdentityProvider :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>The type of identity provider that the user belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of identity provider that the user belongs to.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Defines a user's identity provider definition.
    internal partial interface IIdentityProviderInternal

    {
        /// <summary>The type of identity provider that the user belongs to.</summary>
        string Type { get; set; }

    }
}