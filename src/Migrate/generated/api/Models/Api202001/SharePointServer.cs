namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>SharePointServer in the guest virtual machine.</summary>
    public partial class SharePointServer :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServerInternal
    {

        /// <summary>Backing field for <see cref="IsEnterprise" /> property.</summary>
        private bool? _isEnterprise;

        /// <summary>Value indicating whether the SharePointServer is Enterprise.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsEnterprise { get => this._isEnterprise; }

        /// <summary>Internal Acessors for IsEnterprise</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServerInternal.IsEnterprise { get => this._isEnterprise; set { {_isEnterprise = value;} } }

        /// <summary>Internal Acessors for ProductName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServerInternal.ProductName { get => this._productName; set { {_productName = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServerInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServerInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="ProductName" /> property.</summary>
        private string _productName;

        /// <summary>ProductName of the SharePointServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProductName { get => this._productName; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Status of the SharePointServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>Version of the SharePointServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="SharePointServer" /> instance.</summary>
        public SharePointServer()
        {

        }
    }
    /// SharePointServer in the guest virtual machine.
    public partial interface ISharePointServer :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Value indicating whether the SharePointServer is Enterprise.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value indicating whether the SharePointServer is Enterprise.",
        SerializedName = @"isEnterprise",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsEnterprise { get;  }
        /// <summary>ProductName of the SharePointServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ProductName of the SharePointServer.",
        SerializedName = @"productName",
        PossibleTypes = new [] { typeof(string) })]
        string ProductName { get;  }
        /// <summary>Status of the SharePointServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the SharePointServer.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }
        /// <summary>Version of the SharePointServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the SharePointServer.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// SharePointServer in the guest virtual machine.
    internal partial interface ISharePointServerInternal

    {
        /// <summary>Value indicating whether the SharePointServer is Enterprise.</summary>
        bool? IsEnterprise { get; set; }
        /// <summary>ProductName of the SharePointServer.</summary>
        string ProductName { get; set; }
        /// <summary>Status of the SharePointServer.</summary>
        string Status { get; set; }
        /// <summary>Version of the SharePointServer.</summary>
        string Version { get; set; }

    }
}