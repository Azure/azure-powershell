namespace Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Extensions;

    /// <summary>The properties of a Windows IoT Device Service.</summary>
    public partial class DeviceServiceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AdminDomainName" /> property.</summary>
        private string _adminDomainName;

        /// <summary>Windows IoT Device Service OEM AAD domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public string AdminDomainName { get => this._adminDomainName; set => this._adminDomainName = value; }

        /// <summary>Backing field for <see cref="BillingDomainName" /> property.</summary>
        private string _billingDomainName;

        /// <summary>Windows IoT Device Service ODM AAD domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public string BillingDomainName { get => this._billingDomainName; set => this._billingDomainName = value; }

        /// <summary>Internal Acessors for StartDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal.StartDate { get => this._startDate; set { {_startDate = value;} } }

        /// <summary>Backing field for <see cref="Note" /> property.</summary>
        private string _note;

        /// <summary>Windows IoT Device Service notes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public string Note { get => this._note; set => this._note = value; }

        /// <summary>Backing field for <see cref="Quantity" /> property.</summary>
        private long? _quantity;

        /// <summary>Windows IoT Device Service device allocation,</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public long? Quantity { get => this._quantity; set => this._quantity = value; }

        /// <summary>Backing field for <see cref="StartDate" /> property.</summary>
        private global::System.DateTime? _startDate;

        /// <summary>Windows IoT Device Service start date,</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public global::System.DateTime? StartDate { get => this._startDate; }

        /// <summary>Creates an new <see cref="DeviceServiceProperties" /> instance.</summary>
        public DeviceServiceProperties()
        {

        }
    }
    /// The properties of a Windows IoT Device Service.
    public partial interface IDeviceServiceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IJsonSerializable
    {
        /// <summary>Windows IoT Device Service OEM AAD domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Windows IoT Device Service OEM AAD domain",
        SerializedName = @"adminDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string AdminDomainName { get; set; }
        /// <summary>Windows IoT Device Service ODM AAD domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Windows IoT Device Service ODM AAD domain",
        SerializedName = @"billingDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string BillingDomainName { get; set; }
        /// <summary>Windows IoT Device Service notes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Windows IoT Device Service notes.",
        SerializedName = @"notes",
        PossibleTypes = new [] { typeof(string) })]
        string Note { get; set; }
        /// <summary>Windows IoT Device Service device allocation,</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Windows IoT Device Service device allocation,",
        SerializedName = @"quantity",
        PossibleTypes = new [] { typeof(long) })]
        long? Quantity { get; set; }
        /// <summary>Windows IoT Device Service start date,</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Windows IoT Device Service start date,",
        SerializedName = @"startDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartDate { get;  }

    }
    /// The properties of a Windows IoT Device Service.
    internal partial interface IDeviceServicePropertiesInternal

    {
        /// <summary>Windows IoT Device Service OEM AAD domain</summary>
        string AdminDomainName { get; set; }
        /// <summary>Windows IoT Device Service ODM AAD domain</summary>
        string BillingDomainName { get; set; }
        /// <summary>Windows IoT Device Service notes.</summary>
        string Note { get; set; }
        /// <summary>Windows IoT Device Service device allocation,</summary>
        long? Quantity { get; set; }
        /// <summary>Windows IoT Device Service start date,</summary>
        global::System.DateTime? StartDate { get; set; }

    }
}