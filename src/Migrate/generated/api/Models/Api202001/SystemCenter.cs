namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>SystemCenter in the guest virtual machine.</summary>
    public partial class SystemCenter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenterInternal
    {

        /// <summary>Internal Acessors for ProductName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenterInternal.ProductName { get => this._productName; set { {_productName = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenterInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenterInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="ProductName" /> property.</summary>
        private string _productName;

        /// <summary>ProductName of the SystemCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProductName { get => this._productName; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Status of the SystemCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>Version of the SystemCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="SystemCenter" /> instance.</summary>
        public SystemCenter()
        {

        }
    }
    /// SystemCenter in the guest virtual machine.
    public partial interface ISystemCenter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>ProductName of the SystemCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ProductName of the SystemCenter.",
        SerializedName = @"productName",
        PossibleTypes = new [] { typeof(string) })]
        string ProductName { get;  }
        /// <summary>Status of the SystemCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the SystemCenter.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }
        /// <summary>Version of the SystemCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the SystemCenter.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// SystemCenter in the guest virtual machine.
    internal partial interface ISystemCenterInternal

    {
        /// <summary>ProductName of the SystemCenter.</summary>
        string ProductName { get; set; }
        /// <summary>Status of the SystemCenter.</summary>
        string Status { get; set; }
        /// <summary>Version of the SystemCenter.</summary>
        string Version { get; set; }

    }
}