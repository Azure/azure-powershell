namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>An access key for the storage account.</summary>
    public partial class StorageAccountKey :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountKey,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountKeyInternal
    {

        /// <summary>Backing field for <see cref="KeyName" /> property.</summary>
        private string _keyName;

        /// <summary>Name of the key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string KeyName { get => this._keyName; }

        /// <summary>Internal Acessors for KeyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountKeyInternal.KeyName { get => this._keyName; set { {_keyName = value;} } }

        /// <summary>Internal Acessors for Permission</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyPermission? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountKeyInternal.Permission { get => this._permission; set { {_permission = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountKeyInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Permission" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyPermission? _permission;

        /// <summary>Permissions for the key -- read-only or full permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyPermission? Permission { get => this._permission; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>Base 64-encoded value of the key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Value { get => this._value; }

        /// <summary>Creates an new <see cref="StorageAccountKey" /> instance.</summary>
        public StorageAccountKey()
        {

        }
    }
    /// An access key for the storage account.
    public partial interface IStorageAccountKey :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Name of the key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the key.",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyName { get;  }
        /// <summary>Permissions for the key -- read-only or full permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Permissions for the key -- read-only or full permissions.",
        SerializedName = @"permissions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyPermission) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyPermission? Permission { get;  }
        /// <summary>Base 64-encoded value of the key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Base 64-encoded value of the key.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get;  }

    }
    /// An access key for the storage account.
    internal partial interface IStorageAccountKeyInternal

    {
        /// <summary>Name of the key.</summary>
        string KeyName { get; set; }
        /// <summary>Permissions for the key -- read-only or full permissions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyPermission? Permission { get; set; }
        /// <summary>Base 64-encoded value of the key.</summary>
        string Value { get; set; }

    }
}