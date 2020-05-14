namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>HybridConnectionLimits resource specific properties</summary>
    public partial class HybridConnectionLimitsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnectionLimitsProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnectionLimitsPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Current" /> property.</summary>
        private int? _current;

        /// <summary>The current number of Hybrid Connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Current { get => this._current; }

        /// <summary>Backing field for <see cref="Maximum" /> property.</summary>
        private int? _maximum;

        /// <summary>The maximum number of Hybrid Connections allowed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Maximum { get => this._maximum; }

        /// <summary>Internal Acessors for Current</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnectionLimitsPropertiesInternal.Current { get => this._current; set { {_current = value;} } }

        /// <summary>Internal Acessors for Maximum</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnectionLimitsPropertiesInternal.Maximum { get => this._maximum; set { {_maximum = value;} } }

        /// <summary>Creates an new <see cref="HybridConnectionLimitsProperties" /> instance.</summary>
        public HybridConnectionLimitsProperties()
        {

        }
    }
    /// HybridConnectionLimits resource specific properties
    public partial interface IHybridConnectionLimitsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The current number of Hybrid Connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current number of Hybrid Connections.",
        SerializedName = @"current",
        PossibleTypes = new [] { typeof(int) })]
        int? Current { get;  }
        /// <summary>The maximum number of Hybrid Connections allowed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The maximum number of Hybrid Connections allowed.",
        SerializedName = @"maximum",
        PossibleTypes = new [] { typeof(int) })]
        int? Maximum { get;  }

    }
    /// HybridConnectionLimits resource specific properties
    internal partial interface IHybridConnectionLimitsPropertiesInternal

    {
        /// <summary>The current number of Hybrid Connections.</summary>
        int? Current { get; set; }
        /// <summary>The maximum number of Hybrid Connections allowed.</summary>
        int? Maximum { get; set; }

    }
}