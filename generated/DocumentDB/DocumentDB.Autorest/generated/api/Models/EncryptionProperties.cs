// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>The encryption configuration for the mongo cluster.</summary>
    public partial class EncryptionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CustomerManagedKeyEncryption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionProperties _customerManagedKeyEncryption;

        /// <summary>Customer managed key encryption settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionProperties CustomerManagedKeyEncryption { get => (this._customerManagedKeyEncryption = this._customerManagedKeyEncryption ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.CustomerManagedKeyEncryptionProperties()); set => this._customerManagedKeyEncryption = value; }

        /// <summary>The URI of the key vault key used for encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string CustomerManagedKeyEncryptionKeyUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionPropertiesInternal)CustomerManagedKeyEncryption).KeyEncryptionKeyUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionPropertiesInternal)CustomerManagedKeyEncryption).KeyEncryptionKeyUrl = value ?? null; }

        /// <summary>The type of identity. Only 'UserAssignedIdentity' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string KeyEncryptionKeyIdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionPropertiesInternal)CustomerManagedKeyEncryption).KeyEncryptionKeyIdentityType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionPropertiesInternal)CustomerManagedKeyEncryption).KeyEncryptionKeyIdentityType = value ?? null; }

        /// <summary>The user assigned identity resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string KeyEncryptionKeyIdentityUserAssignedIdentityResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionPropertiesInternal)CustomerManagedKeyEncryption).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionPropertiesInternal)CustomerManagedKeyEncryption).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId = value ?? null; }

        /// <summary>Internal Acessors for CustomerManagedKeyEncryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal.CustomerManagedKeyEncryption { get => (this._customerManagedKeyEncryption = this._customerManagedKeyEncryption ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.CustomerManagedKeyEncryptionProperties()); set { {_customerManagedKeyEncryption = value;} } }

        /// <summary>Internal Acessors for CustomerManagedKeyEncryptionKeyIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IKeyEncryptionKeyIdentity Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal.CustomerManagedKeyEncryptionKeyIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionPropertiesInternal)CustomerManagedKeyEncryption).KeyEncryptionKeyIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionPropertiesInternal)CustomerManagedKeyEncryption).KeyEncryptionKeyIdentity = value ?? null /* model class */; }

        /// <summary>Creates an new <see cref="EncryptionProperties" /> instance.</summary>
        public EncryptionProperties()
        {

        }
    }
    /// The encryption configuration for the mongo cluster.
    public partial interface IEncryptionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>The URI of the key vault key used for encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The URI of the key vault key used for encryption.",
        SerializedName = @"keyEncryptionKeyUrl",
        PossibleTypes = new [] { typeof(string) })]
        string CustomerManagedKeyEncryptionKeyUrl { get; set; }
        /// <summary>The type of identity. Only 'UserAssignedIdentity' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of identity. Only 'UserAssignedIdentity' is supported.",
        SerializedName = @"identityType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("UserAssignedIdentity")]
        string KeyEncryptionKeyIdentityType { get; set; }
        /// <summary>The user assigned identity resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The user assigned identity resource id.",
        SerializedName = @"userAssignedIdentityResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyEncryptionKeyIdentityUserAssignedIdentityResourceId { get; set; }

    }
    /// The encryption configuration for the mongo cluster.
    internal partial interface IEncryptionPropertiesInternal

    {
        /// <summary>Customer managed key encryption settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionProperties CustomerManagedKeyEncryption { get; set; }
        /// <summary>The identity used to access the key encryption key.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IKeyEncryptionKeyIdentity CustomerManagedKeyEncryptionKeyIdentity { get; set; }
        /// <summary>The URI of the key vault key used for encryption.</summary>
        string CustomerManagedKeyEncryptionKeyUrl { get; set; }
        /// <summary>The type of identity. Only 'UserAssignedIdentity' is supported.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("UserAssignedIdentity")]
        string KeyEncryptionKeyIdentityType { get; set; }
        /// <summary>The user assigned identity resource id.</summary>
        string KeyEncryptionKeyIdentityUserAssignedIdentityResourceId { get; set; }

    }
}