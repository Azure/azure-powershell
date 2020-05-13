namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Usage resource specific properties</summary>
    public partial class UsageProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal
    {

        /// <summary>Backing field for <see cref="ComputeMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? _computeMode;

        /// <summary>Compute mode used for this usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get => this._computeMode; }

        /// <summary>Backing field for <see cref="CurrentValue" /> property.</summary>
        private long? _currentValue;

        /// <summary>The current value of the resource counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? CurrentValue { get => this._currentValue; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Friendly name shown in the UI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; }

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private long? _limit;

        /// <summary>The resource limit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? Limit { get => this._limit; }

        /// <summary>Internal Acessors for ComputeMode</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal.ComputeMode { get => this._computeMode; set { {_computeMode = value;} } }

        /// <summary>Internal Acessors for CurrentValue</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal.CurrentValue { get => this._currentValue; set { {_currentValue = value;} } }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal.DisplayName { get => this._displayName; set { {_displayName = value;} } }

        /// <summary>Internal Acessors for Limit</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal.Limit { get => this._limit; set { {_limit = value;} } }

        /// <summary>Internal Acessors for NextResetTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal.NextResetTime { get => this._nextResetTime; set { {_nextResetTime = value;} } }

        /// <summary>Internal Acessors for ResourceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal.ResourceName { get => this._resourceName; set { {_resourceName = value;} } }

        /// <summary>Internal Acessors for SiteMode</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal.SiteMode { get => this._siteMode; set { {_siteMode = value;} } }

        /// <summary>Internal Acessors for Unit</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal.Unit { get => this._unit; set { {_unit = value;} } }

        /// <summary>Backing field for <see cref="NextResetTime" /> property.</summary>
        private global::System.DateTime? _nextResetTime;

        /// <summary>Next reset time for the resource counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? NextResetTime { get => this._nextResetTime; }

        /// <summary>Backing field for <see cref="ResourceName" /> property.</summary>
        private string _resourceName;

        /// <summary>Name of the quota resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceName { get => this._resourceName; }

        /// <summary>Backing field for <see cref="SiteMode" /> property.</summary>
        private string _siteMode;

        /// <summary>Site mode used for this usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SiteMode { get => this._siteMode; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>Units of measurement for the quota resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; }

        /// <summary>Creates an new <see cref="UsageProperties" /> instance.</summary>
        public UsageProperties()
        {

        }
    }
    /// Usage resource specific properties
    public partial interface IUsageProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Compute mode used for this usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Compute mode used for this usage.",
        SerializedName = @"computeMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get;  }
        /// <summary>The current value of the resource counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current value of the resource counter.",
        SerializedName = @"currentValue",
        PossibleTypes = new [] { typeof(long) })]
        long? CurrentValue { get;  }
        /// <summary>Friendly name shown in the UI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Friendly name shown in the UI.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>The resource limit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource limit.",
        SerializedName = @"limit",
        PossibleTypes = new [] { typeof(long) })]
        long? Limit { get;  }
        /// <summary>Next reset time for the resource counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Next reset time for the resource counter.",
        SerializedName = @"nextResetTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? NextResetTime { get;  }
        /// <summary>Name of the quota resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the quota resource.",
        SerializedName = @"resourceName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceName { get;  }
        /// <summary>Site mode used for this usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Site mode used for this usage.",
        SerializedName = @"siteMode",
        PossibleTypes = new [] { typeof(string) })]
        string SiteMode { get;  }
        /// <summary>Units of measurement for the quota resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Units of measurement for the quota resource.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get;  }

    }
    /// Usage resource specific properties
    internal partial interface IUsagePropertiesInternal

    {
        /// <summary>Compute mode used for this usage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get; set; }
        /// <summary>The current value of the resource counter.</summary>
        long? CurrentValue { get; set; }
        /// <summary>Friendly name shown in the UI.</summary>
        string DisplayName { get; set; }
        /// <summary>The resource limit.</summary>
        long? Limit { get; set; }
        /// <summary>Next reset time for the resource counter.</summary>
        global::System.DateTime? NextResetTime { get; set; }
        /// <summary>Name of the quota resource.</summary>
        string ResourceName { get; set; }
        /// <summary>Site mode used for this usage.</summary>
        string SiteMode { get; set; }
        /// <summary>Units of measurement for the quota resource.</summary>
        string Unit { get; set; }

    }
}