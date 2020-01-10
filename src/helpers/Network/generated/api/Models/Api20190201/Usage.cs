namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Describes network resource usage.</summary>
    public partial class Usage :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsage,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsageInternal
    {

        /// <summary>Backing field for <see cref="CurrentValue" /> property.</summary>
        private long _currentValue;

        /// <summary>The current value of the usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long CurrentValue { get => this._currentValue; set => this._currentValue = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private long _limit;

        /// <summary>The limit of usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long Limit { get => this._limit; set => this._limit = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsageInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsageName Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsageInternal.Name { get => (this._name = this._name ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.UsageName()); set { {_name = value;} } }

        /// <summary>Internal Acessors for Unit</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsageInternal.Unit { get => this._unit; set { {_unit = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsageName _name;

        /// <summary>The name of the type of usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsageName Name { get => (this._name = this._name ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.UsageName()); set => this._name = value; }

        /// <summary>A localized string describing the resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NameLocalizedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsageNameInternal)Name).LocalizedValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsageNameInternal)Name).LocalizedValue = value; }

        /// <summary>A string describing the resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsageNameInternal)Name).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsageNameInternal)Name).Value = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit= @"Count";

        /// <summary>An enum describing the unit of measurement.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; }

        /// <summary>Creates an new <see cref="Usage" /> instance.</summary>
        public Usage()
        {

        }
    }
    /// Describes network resource usage.
    public partial interface IUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The current value of the usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The current value of the usage.",
        SerializedName = @"currentValue",
        PossibleTypes = new [] { typeof(long) })]
        long CurrentValue { get; set; }
        /// <summary>Resource identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource identifier.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The limit of usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The limit of usage.",
        SerializedName = @"limit",
        PossibleTypes = new [] { typeof(long) })]
        long Limit { get; set; }
        /// <summary>A localized string describing the resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A localized string describing the resource name.",
        SerializedName = @"localizedValue",
        PossibleTypes = new [] { typeof(string) })]
        string NameLocalizedValue { get; set; }
        /// <summary>A string describing the resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A string describing the resource name.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string NameValue { get; set; }
        /// <summary>An enum describing the unit of measurement.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"An enum describing the unit of measurement.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get;  }

    }
    /// Describes network resource usage.
    internal partial interface IUsageInternal

    {
        /// <summary>The current value of the usage.</summary>
        long CurrentValue { get; set; }
        /// <summary>Resource identifier.</summary>
        string Id { get; set; }
        /// <summary>The limit of usage.</summary>
        long Limit { get; set; }
        /// <summary>The name of the type of usage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IUsageName Name { get; set; }
        /// <summary>A localized string describing the resource name.</summary>
        string NameLocalizedValue { get; set; }
        /// <summary>A string describing the resource name.</summary>
        string NameValue { get; set; }
        /// <summary>An enum describing the unit of measurement.</summary>
        string Unit { get; set; }

    }
}