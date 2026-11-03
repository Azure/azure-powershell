// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>Microsoft Entra ID provider properties.</summary>
    public partial class EntraIdentityProviderProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEntraIdentityProviderProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEntraIdentityProviderPropertiesInternal
    {

        /// <summary>Backing field for <see cref="PrincipalType" /> property.</summary>
        private string _principalType;

        /// <summary>The principal type of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string PrincipalType { get => this._principalType; set => this._principalType = value; }

        /// <summary>Creates an new <see cref="EntraIdentityProviderProperties" /> instance.</summary>
        public EntraIdentityProviderProperties()
        {

        }
    }
    /// Microsoft Entra ID provider properties.
    public partial interface IEntraIdentityProviderProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>The principal type of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The principal type of the user.",
        SerializedName = @"principalType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("user", "servicePrincipal")]
        string PrincipalType { get; set; }

    }
    /// Microsoft Entra ID provider properties.
    internal partial interface IEntraIdentityProviderPropertiesInternal

    {
        /// <summary>The principal type of the user.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("user", "servicePrincipal")]
        string PrincipalType { get; set; }

    }
}