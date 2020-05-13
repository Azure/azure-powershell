namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Usage of the quota resource.</summary>
    public partial class CsmUsageQuota :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmUsageQuota,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmUsageQuotaInternal
    {

        /// <summary>Backing field for <see cref="CurrentValue" /> property.</summary>
        private long? _currentValue;

        /// <summary>The current value of the resource counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? CurrentValue { get => this._currentValue; set => this._currentValue = value; }

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private long? _limit;

        /// <summary>The resource limit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? Limit { get => this._limit; set => this._limit = value; }

        /// <summary>Internal Acessors for Name</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILocalizableString Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmUsageQuotaInternal.Name { get => (this._name = this._name ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.LocalizableString()); set { {_name = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILocalizableString _name;

        /// <summary>Quota name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILocalizableString Name { get => (this._name = this._name ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.LocalizableString()); set => this._name = value; }

        /// <summary>Localized name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string NameLocalizedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILocalizableStringInternal)Name).LocalizedValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILocalizableStringInternal)Name).LocalizedValue = value; }

        /// <summary>Non-localized name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string NameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILocalizableStringInternal)Name).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILocalizableStringInternal)Name).Value = value; }

        /// <summary>Backing field for <see cref="NextResetTime" /> property.</summary>
        private global::System.DateTime? _nextResetTime;

        /// <summary>Next reset time for the resource counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? NextResetTime { get => this._nextResetTime; set => this._nextResetTime = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>Units of measurement for the quota resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; set => this._unit = value; }

        /// <summary>Creates an new <see cref="CsmUsageQuota" /> instance.</summary>
        public CsmUsageQuota()
        {

        }
    }
    /// Usage of the quota resource.
    public partial interface ICsmUsageQuota :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The current value of the resource counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The current value of the resource counter.",
        SerializedName = @"currentValue",
        PossibleTypes = new [] { typeof(long) })]
        long? CurrentValue { get; set; }
        /// <summary>The resource limit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource limit.",
        SerializedName = @"limit",
        PossibleTypes = new [] { typeof(long) })]
        long? Limit { get; set; }
        /// <summary>Localized name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized name.",
        SerializedName = @"localizedValue",
        PossibleTypes = new [] { typeof(string) })]
        string NameLocalizedValue { get; set; }
        /// <summary>Non-localized name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Non-localized name.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string NameValue { get; set; }
        /// <summary>Next reset time for the resource counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Next reset time for the resource counter.",
        SerializedName = @"nextResetTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? NextResetTime { get; set; }
        /// <summary>Units of measurement for the quota resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Units of measurement for the quota resource.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get; set; }

    }
    /// Usage of the quota resource.
    internal partial interface ICsmUsageQuotaInternal

    {
        /// <summary>The current value of the resource counter.</summary>
        long? CurrentValue { get; set; }
        /// <summary>The resource limit.</summary>
        long? Limit { get; set; }
        /// <summary>Quota name.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILocalizableString Name { get; set; }
        /// <summary>Localized name.</summary>
        string NameLocalizedValue { get; set; }
        /// <summary>Non-localized name.</summary>
        string NameValue { get; set; }
        /// <summary>Next reset time for the resource counter.</summary>
        global::System.DateTime? NextResetTime { get; set; }
        /// <summary>Units of measurement for the quota resource.</summary>
        string Unit { get; set; }

    }
}