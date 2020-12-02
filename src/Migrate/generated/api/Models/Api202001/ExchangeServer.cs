namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>ExchangeServer in the guest virtual machine.</summary>
    public partial class ExchangeServer :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServerInternal
    {

        /// <summary>Backing field for <see cref="Edition" /> property.</summary>
        private string _edition;

        /// <summary>Edition of the ExchangeServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Edition { get => this._edition; }

        /// <summary>Internal Acessors for Edition</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServerInternal.Edition { get => this._edition; set { {_edition = value;} } }

        /// <summary>Internal Acessors for ProductName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServerInternal.ProductName { get => this._productName; set { {_productName = value;} } }

        /// <summary>Internal Acessors for Role</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServerInternal.Role { get => this._role; set { {_role = value;} } }

        /// <summary>Internal Acessors for ServicePack</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServerInternal.ServicePack { get => this._servicePack; set { {_servicePack = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServerInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="ProductName" /> property.</summary>
        private string _productName;

        /// <summary>ProductName of the ExchangeServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProductName { get => this._productName; }

        /// <summary>Backing field for <see cref="Role" /> property.</summary>
        private string _role;

        /// <summary>Roles of the ExchangeServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Role { get => this._role; }

        /// <summary>Backing field for <see cref="ServicePack" /> property.</summary>
        private string _servicePack;

        /// <summary>ServicePack of the ExchangeServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ServicePack { get => this._servicePack; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>Version of the ExchangeServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="ExchangeServer" /> instance.</summary>
        public ExchangeServer()
        {

        }
    }
    /// ExchangeServer in the guest virtual machine.
    public partial interface IExchangeServer :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Edition of the ExchangeServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Edition of the ExchangeServer.",
        SerializedName = @"edition",
        PossibleTypes = new [] { typeof(string) })]
        string Edition { get;  }
        /// <summary>ProductName of the ExchangeServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ProductName of the ExchangeServer.",
        SerializedName = @"productName",
        PossibleTypes = new [] { typeof(string) })]
        string ProductName { get;  }
        /// <summary>Roles of the ExchangeServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Roles of the ExchangeServer.",
        SerializedName = @"roles",
        PossibleTypes = new [] { typeof(string) })]
        string Role { get;  }
        /// <summary>ServicePack of the ExchangeServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ServicePack of the ExchangeServer.",
        SerializedName = @"servicePack",
        PossibleTypes = new [] { typeof(string) })]
        string ServicePack { get;  }
        /// <summary>Version of the ExchangeServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the ExchangeServer.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// ExchangeServer in the guest virtual machine.
    internal partial interface IExchangeServerInternal

    {
        /// <summary>Edition of the ExchangeServer.</summary>
        string Edition { get; set; }
        /// <summary>ProductName of the ExchangeServer.</summary>
        string ProductName { get; set; }
        /// <summary>Roles of the ExchangeServer.</summary>
        string Role { get; set; }
        /// <summary>ServicePack of the ExchangeServer.</summary>
        string ServicePack { get; set; }
        /// <summary>Version of the ExchangeServer.</summary>
        string Version { get; set; }

    }
}