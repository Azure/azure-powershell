namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>BizTalkServer in the guest virtual machine.</summary>
    public partial class BizTalkServer :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServerInternal
    {

        /// <summary>Internal Acessors for ProductName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServerInternal.ProductName { get => this._productName; set { {_productName = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServerInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Backing field for <see cref="ProductName" /> property.</summary>
        private string _productName;

        /// <summary>ProductName of the BizTalkServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProductName { get => this._productName; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Status of the BizTalkServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Creates an new <see cref="BizTalkServer" /> instance.</summary>
        public BizTalkServer()
        {

        }
    }
    /// BizTalkServer in the guest virtual machine.
    public partial interface IBizTalkServer :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>ProductName of the BizTalkServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ProductName of the BizTalkServer.",
        SerializedName = @"productName",
        PossibleTypes = new [] { typeof(string) })]
        string ProductName { get;  }
        /// <summary>Status of the BizTalkServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the BizTalkServer.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }

    }
    /// BizTalkServer in the guest virtual machine.
    internal partial interface IBizTalkServerInternal

    {
        /// <summary>ProductName of the BizTalkServer.</summary>
        string ProductName { get; set; }
        /// <summary>Status of the BizTalkServer.</summary>
        string Status { get; set; }

    }
}