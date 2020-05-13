namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The status of the last successful slot swap operation.</summary>
    public partial class SlotSwapStatus :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatus,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal
    {

        /// <summary>Backing field for <see cref="DestinationSlotName" /> property.</summary>
        private string _destinationSlotName;

        /// <summary>The destination slot of the last swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DestinationSlotName { get => this._destinationSlotName; }

        /// <summary>Internal Acessors for DestinationSlotName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal.DestinationSlotName { get => this._destinationSlotName; set { {_destinationSlotName = value;} } }

        /// <summary>Internal Acessors for SourceSlotName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal.SourceSlotName { get => this._sourceSlotName; set { {_sourceSlotName = value;} } }

        /// <summary>Internal Acessors for TimestampUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal.TimestampUtc { get => this._timestampUtc; set { {_timestampUtc = value;} } }

        /// <summary>Backing field for <see cref="SourceSlotName" /> property.</summary>
        private string _sourceSlotName;

        /// <summary>The source slot of the last swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SourceSlotName { get => this._sourceSlotName; }

        /// <summary>Backing field for <see cref="TimestampUtc" /> property.</summary>
        private global::System.DateTime? _timestampUtc;

        /// <summary>The time the last successful slot swap completed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? TimestampUtc { get => this._timestampUtc; }

        /// <summary>Creates an new <see cref="SlotSwapStatus" /> instance.</summary>
        public SlotSwapStatus()
        {

        }
    }
    /// The status of the last successful slot swap operation.
    public partial interface ISlotSwapStatus :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The destination slot of the last swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The destination slot of the last swap operation.",
        SerializedName = @"destinationSlotName",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationSlotName { get;  }
        /// <summary>The source slot of the last swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The source slot of the last swap operation.",
        SerializedName = @"sourceSlotName",
        PossibleTypes = new [] { typeof(string) })]
        string SourceSlotName { get;  }
        /// <summary>The time the last successful slot swap completed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time the last successful slot swap completed.",
        SerializedName = @"timestampUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimestampUtc { get;  }

    }
    /// The status of the last successful slot swap operation.
    internal partial interface ISlotSwapStatusInternal

    {
        /// <summary>The destination slot of the last swap operation.</summary>
        string DestinationSlotName { get; set; }
        /// <summary>The source slot of the last swap operation.</summary>
        string SourceSlotName { get; set; }
        /// <summary>The time the last successful slot swap completed.</summary>
        global::System.DateTime? TimestampUtc { get; set; }

    }
}