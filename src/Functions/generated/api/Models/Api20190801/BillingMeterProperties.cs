namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>BillingMeter resource specific properties</summary>
    public partial class BillingMeterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBillingMeterProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBillingMeterPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BillingLocation" /> property.</summary>
        private string _billingLocation;

        /// <summary>Azure Location of billable resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string BillingLocation { get => this._billingLocation; set => this._billingLocation = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>Friendly name of the meter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="MeterId" /> property.</summary>
        private string _meterId;

        /// <summary>Meter GUID onboarded in Commerce</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MeterId { get => this._meterId; set => this._meterId = value; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>App Service OS type meter used for</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>App Service ResourceType meter used for</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; set => this._resourceType = value; }

        /// <summary>Backing field for <see cref="ShortName" /> property.</summary>
        private string _shortName;

        /// <summary>Short Name from App Service Azure pricing Page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ShortName { get => this._shortName; set => this._shortName = value; }

        /// <summary>Creates an new <see cref="BillingMeterProperties" /> instance.</summary>
        public BillingMeterProperties()
        {

        }
    }
    /// BillingMeter resource specific properties
    public partial interface IBillingMeterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Azure Location of billable resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Azure Location of billable resource",
        SerializedName = @"billingLocation",
        PossibleTypes = new [] { typeof(string) })]
        string BillingLocation { get; set; }
        /// <summary>Friendly name of the meter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of the meter",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>Meter GUID onboarded in Commerce</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Meter GUID onboarded in Commerce",
        SerializedName = @"meterId",
        PossibleTypes = new [] { typeof(string) })]
        string MeterId { get; set; }
        /// <summary>App Service OS type meter used for</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"App Service OS type meter used for",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get; set; }
        /// <summary>App Service ResourceType meter used for</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"App Service ResourceType meter used for",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get; set; }
        /// <summary>Short Name from App Service Azure pricing Page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Short Name from App Service Azure pricing Page",
        SerializedName = @"shortName",
        PossibleTypes = new [] { typeof(string) })]
        string ShortName { get; set; }

    }
    /// BillingMeter resource specific properties
    internal partial interface IBillingMeterPropertiesInternal

    {
        /// <summary>Azure Location of billable resource</summary>
        string BillingLocation { get; set; }
        /// <summary>Friendly name of the meter</summary>
        string FriendlyName { get; set; }
        /// <summary>Meter GUID onboarded in Commerce</summary>
        string MeterId { get; set; }
        /// <summary>App Service OS type meter used for</summary>
        string OSType { get; set; }
        /// <summary>App Service ResourceType meter used for</summary>
        string ResourceType { get; set; }
        /// <summary>Short Name from App Service Azure pricing Page</summary>
        string ShortName { get; set; }

    }
}