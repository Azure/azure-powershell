namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Usage details for subnet.</summary>
    public partial class VirtualNetworkUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsage,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageInternal
    {

        /// <summary>Backing field for <see cref="CurrentValue" /> property.</summary>
        private double? _currentValue;

        /// <summary>Indicates number of IPs used from the Subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public double? CurrentValue { get => this._currentValue; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Subnet identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private double? _limit;

        /// <summary>Indicates the size of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public double? Limit { get => this._limit; }

        /// <summary>Internal Acessors for CurrentValue</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageInternal.CurrentValue { get => this._currentValue; set { {_currentValue = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Limit</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageInternal.Limit { get => this._limit; set { {_limit = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageName Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageInternal.Name { get => (this._name = this._name ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualNetworkUsageName()); set { {_name = value;} } }

        /// <summary>Internal Acessors for NameLocalizedValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageInternal.NameLocalizedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageNameInternal)Name).LocalizedValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageNameInternal)Name).LocalizedValue = value; }

        /// <summary>Internal Acessors for NameValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageInternal.NameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageNameInternal)Name).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageNameInternal)Name).Value = value; }

        /// <summary>Internal Acessors for Unit</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageInternal.Unit { get => this._unit; set { {_unit = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageName _name;

        /// <summary>The name containing common and localized value for usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageName Name { get => (this._name = this._name ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualNetworkUsageName()); }

        /// <summary>Localized subnet size and usage string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NameLocalizedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageNameInternal)Name).LocalizedValue; }

        /// <summary>Subnet size and usage string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageNameInternal)Name).Value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>Usage units. Returns 'Count'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; }

        /// <summary>Creates an new <see cref="VirtualNetworkUsage" /> instance.</summary>
        public VirtualNetworkUsage()
        {

        }
    }
    /// Usage details for subnet.
    public partial interface IVirtualNetworkUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Indicates number of IPs used from the Subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Indicates number of IPs used from the Subnet.",
        SerializedName = @"currentValue",
        PossibleTypes = new [] { typeof(double) })]
        double? CurrentValue { get;  }
        /// <summary>Subnet identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Subnet identifier.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Indicates the size of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Indicates the size of the subnet.",
        SerializedName = @"limit",
        PossibleTypes = new [] { typeof(double) })]
        double? Limit { get;  }
        /// <summary>Localized subnet size and usage string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Localized subnet size and usage string.",
        SerializedName = @"localizedValue",
        PossibleTypes = new [] { typeof(string) })]
        string NameLocalizedValue { get;  }
        /// <summary>Subnet size and usage string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Subnet size and usage string.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string NameValue { get;  }
        /// <summary>Usage units. Returns 'Count'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Usage units. Returns 'Count'",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get;  }

    }
    /// Usage details for subnet.
    internal partial interface IVirtualNetworkUsageInternal

    {
        /// <summary>Indicates number of IPs used from the Subnet.</summary>
        double? CurrentValue { get; set; }
        /// <summary>Subnet identifier.</summary>
        string Id { get; set; }
        /// <summary>Indicates the size of the subnet.</summary>
        double? Limit { get; set; }
        /// <summary>The name containing common and localized value for usage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkUsageName Name { get; set; }
        /// <summary>Localized subnet size and usage string.</summary>
        string NameLocalizedValue { get; set; }
        /// <summary>Subnet size and usage string.</summary>
        string NameValue { get; set; }
        /// <summary>Usage units. Returns 'Count'</summary>
        string Unit { get; set; }

    }
}