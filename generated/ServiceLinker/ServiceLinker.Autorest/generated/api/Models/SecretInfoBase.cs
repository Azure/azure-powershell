// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Runtime.Extensions;

    /// <summary>The secret info</summary>
    public partial class SecretInfoBase :
        Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.ISecretInfoBase,
        Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.ISecretInfoBaseInternal
    {

        /// <summary>Backing field for <see cref="SecretType" /> property.</summary>
        private string _secretType;

        /// <summary>The secret type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.PropertyOrigin.Owned)]
        public string SecretType { get => this._secretType; set => this._secretType = value; }

        /// <summary>Creates an new <see cref="SecretInfoBase" /> instance.</summary>
        public SecretInfoBase()
        {

        }
    }
    /// The secret info
    public partial interface ISecretInfoBase :
        Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Runtime.IJsonSerializable
    {
        /// <summary>The secret type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The secret type.",
        SerializedName = @"secretType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.PSArgumentCompleterAttribute("rawValue", "keyVaultSecretUri", "keyVaultSecretReference")]
        string SecretType { get; set; }

    }
    /// The secret info
    internal partial interface ISecretInfoBaseInternal

    {
        /// <summary>The secret type.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.PSArgumentCompleterAttribute("rawValue", "keyVaultSecretUri", "keyVaultSecretReference")]
        string SecretType { get; set; }

    }
}