namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Describes Storage Resource Usage.</summary>
    public partial class Usage :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsage,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageInternal
    {

        /// <summary>Backing field for <see cref="CurrentValue" /> property.</summary>
        private int? _currentValue;

        /// <summary>Gets the current count of the allocated resources in the subscription.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? CurrentValue { get => this._currentValue; }

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private int? _limit;

        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in the subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Limit { get => this._limit; }

        /// <summary>Internal Acessors for CurrentValue</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageInternal.CurrentValue { get => this._currentValue; set { {_currentValue = value;} } }

        /// <summary>Internal Acessors for Limit</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageInternal.Limit { get => this._limit; set { {_limit = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageName Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageInternal.Name { get => (this._name = this._name ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.UsageName()); set { {_name = value;} } }

        /// <summary>Internal Acessors for NameLocalizedValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageInternal.NameLocalizedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageNameInternal)Name).LocalizedValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageNameInternal)Name).LocalizedValue = value; }

        /// <summary>Internal Acessors for NameValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageInternal.NameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageNameInternal)Name).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageNameInternal)Name).Value = value; }

        /// <summary>Internal Acessors for Unit</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageUnit? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageInternal.Unit { get => this._unit; set { {_unit = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageName _name;

        /// <summary>Gets the name of the type of usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageName Name { get => (this._name = this._name ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.UsageName()); }

        /// <summary>Gets a localized string describing the resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string NameLocalizedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageNameInternal)Name).LocalizedValue; }

        /// <summary>Gets a string describing the resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string NameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageNameInternal)Name).Value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageUnit? _unit;

        /// <summary>Gets the unit of measurement.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageUnit? Unit { get => this._unit; }

        /// <summary>Creates an new <see cref="Usage" /> instance.</summary>
        public Usage()
        {

        }
    }
    /// Describes Storage Resource Usage.
    public partial interface IUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Gets the current count of the allocated resources in the subscription.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the current count of the allocated resources in the subscription.",
        SerializedName = @"currentValue",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentValue { get;  }
        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in the subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the maximum count of the resources that can be allocated in the subscription.",
        SerializedName = @"limit",
        PossibleTypes = new [] { typeof(int) })]
        int? Limit { get;  }
        /// <summary>Gets a localized string describing the resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a localized string describing the resource name.",
        SerializedName = @"localizedValue",
        PossibleTypes = new [] { typeof(string) })]
        string NameLocalizedValue { get;  }
        /// <summary>Gets a string describing the resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a string describing the resource name.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string NameValue { get;  }
        /// <summary>Gets the unit of measurement.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the unit of measurement.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageUnit) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageUnit? Unit { get;  }

    }
    /// Describes Storage Resource Usage.
    internal partial interface IUsageInternal

    {
        /// <summary>Gets the current count of the allocated resources in the subscription.</summary>
        int? CurrentValue { get; set; }
        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in the subscription.
        /// </summary>
        int? Limit { get; set; }
        /// <summary>Gets the name of the type of usage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageName Name { get; set; }
        /// <summary>Gets a localized string describing the resource name.</summary>
        string NameLocalizedValue { get; set; }
        /// <summary>Gets a string describing the resource name.</summary>
        string NameValue { get; set; }
        /// <summary>Gets the unit of measurement.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageUnit? Unit { get; set; }

    }
}