// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>Defines a Microsoft Entra ID Mongo user.</summary>
    public partial class EntraIdentityProvider :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEntraIdentityProvider,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEntraIdentityProviderInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProvider"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProvider __identityProvider = new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IdentityProvider();

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEntraIdentityProviderProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEntraIdentityProviderInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.EntraIdentityProviderProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProviderInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProviderInternal)__identityProvider).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProviderInternal)__identityProvider).Type = value ; }

        /// <summary>The principal type of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string PrincipalType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEntraIdentityProviderPropertiesInternal)Property).PrincipalType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEntraIdentityProviderPropertiesInternal)Property).PrincipalType = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEntraIdentityProviderProperties _property;

        /// <summary>The Entra identity properties for the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEntraIdentityProviderProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.EntraIdentityProviderProperties()); set => this._property = value; }

        /// <summary>The type of identity provider that the user belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Constant]
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inherited)]
        public string Type { get => "MicrosoftEntraID"; }

        /// <summary>Creates an new <see cref="EntraIdentityProvider" /> instance.</summary>
        public EntraIdentityProvider()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__identityProvider), __identityProvider);
            await eventListener.AssertObjectIsValid(nameof(__identityProvider), __identityProvider);
        }
    }
    /// Defines a Microsoft Entra ID Mongo user.
    public partial interface IEntraIdentityProvider :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProvider
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
    /// Defines a Microsoft Entra ID Mongo user.
    internal partial interface IEntraIdentityProviderInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IIdentityProviderInternal
    {
        /// <summary>The principal type of the user.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("user", "servicePrincipal")]
        string PrincipalType { get; set; }
        /// <summary>The Entra identity properties for the user.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEntraIdentityProviderProperties Property { get; set; }

    }
}