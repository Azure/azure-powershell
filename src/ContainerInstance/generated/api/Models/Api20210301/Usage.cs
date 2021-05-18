namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>A single usage result</summary>
    public partial class Usage :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsage,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageInternal
    {

        /// <summary>Backing field for <see cref="CurrentValue" /> property.</summary>
        private int? _currentValue;

        /// <summary>The current usage of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int? CurrentValue { get => this._currentValue; }

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private int? _limit;

        /// <summary>The maximum permitted usage of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int? Limit { get => this._limit; }

        /// <summary>Internal Acessors for CurrentValue</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageInternal.CurrentValue { get => this._currentValue; set { {_currentValue = value;} } }

        /// <summary>Internal Acessors for Limit</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageInternal.Limit { get => this._limit; set { {_limit = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageName Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageInternal.Name { get => (this._name = this._name ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.UsageName()); set { {_name = value;} } }

        /// <summary>Internal Acessors for NameLocalizedValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageInternal.NameLocalizedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageNameInternal)Name).LocalizedValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageNameInternal)Name).LocalizedValue = value; }

        /// <summary>Internal Acessors for NameValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageInternal.NameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageNameInternal)Name).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageNameInternal)Name).Value = value; }

        /// <summary>Internal Acessors for Unit</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageInternal.Unit { get => this._unit; set { {_unit = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageName _name;

        /// <summary>The name object of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageName Name { get => (this._name = this._name ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.UsageName()); }

        /// <summary>The localized name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string NameLocalizedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageNameInternal)Name).LocalizedValue; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string NameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageNameInternal)Name).Value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>Unit of the usage result</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; }

        /// <summary>Creates an new <see cref="Usage" /> instance.</summary>
        public Usage()
        {

        }
    }
    /// A single usage result
    public partial interface IUsage :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The current usage of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current usage of the resource",
        SerializedName = @"currentValue",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentValue { get;  }
        /// <summary>The maximum permitted usage of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The maximum permitted usage of the resource.",
        SerializedName = @"limit",
        PossibleTypes = new [] { typeof(int) })]
        int? Limit { get;  }
        /// <summary>The localized name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The localized name of the resource",
        SerializedName = @"localizedValue",
        PossibleTypes = new [] { typeof(string) })]
        string NameLocalizedValue { get;  }
        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the resource",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string NameValue { get;  }
        /// <summary>Unit of the usage result</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Unit of the usage result",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get;  }

    }
    /// A single usage result
    internal partial interface IUsageInternal

    {
        /// <summary>The current usage of the resource</summary>
        int? CurrentValue { get; set; }
        /// <summary>The maximum permitted usage of the resource.</summary>
        int? Limit { get; set; }
        /// <summary>The name object of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageName Name { get; set; }
        /// <summary>The localized name of the resource</summary>
        string NameLocalizedValue { get; set; }
        /// <summary>The name of the resource</summary>
        string NameValue { get; set; }
        /// <summary>Unit of the usage result</summary>
        string Unit { get; set; }

    }
}