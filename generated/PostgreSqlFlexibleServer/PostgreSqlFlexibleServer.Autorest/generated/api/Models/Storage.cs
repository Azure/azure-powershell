// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Storage properties of a server.</summary>
    public partial class Storage :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorage,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal
    {

        /// <summary>Backing field for <see cref="AutoGrow" /> property.</summary>
        private string _autoGrow;

        /// <summary>
        /// Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions
        /// allow for automatically growing storage size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string AutoGrow { get => this._autoGrow; set => this._autoGrow = value; }

        /// <summary>Backing field for <see cref="Iop" /> property.</summary>
        private int? _iop;

        /// <summary>
        /// Maximum IOPS supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? Iop { get => this._iop; set => this._iop = value; }

        /// <summary>Backing field for <see cref="SizeGb" /> property.</summary>
        private int? _sizeGb;

        /// <summary>Size of storage assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? SizeGb { get => this._sizeGb; set => this._sizeGb = value; }

        /// <summary>Backing field for <see cref="Throughput" /> property.</summary>
        private int? _throughput;

        /// <summary>
        /// Maximum throughput supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? Throughput { get => this._throughput; set => this._throughput = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private string _tier;

        /// <summary>Storage tier of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Tier { get => this._tier; set => this._tier = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>
        /// Type of storage assigned to a server. Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS. If not specified,
        /// it defaults to Premium_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="Storage" /> instance.</summary>
        public Storage()
        {

        }
    }
    /// Storage properties of a server.
    public partial interface IStorage :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions
        /// allow for automatically growing storage size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions allow for automatically growing storage size.",
        SerializedName = @"autoGrow",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string AutoGrow { get; set; }
        /// <summary>
        /// Maximum IOPS supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Maximum IOPS supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.",
        SerializedName = @"iops",
        PossibleTypes = new [] { typeof(int) })]
        int? Iop { get; set; }
        /// <summary>Size of storage assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Size of storage assigned to a server.",
        SerializedName = @"storageSizeGB",
        PossibleTypes = new [] { typeof(int) })]
        int? SizeGb { get; set; }
        /// <summary>
        /// Maximum throughput supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Maximum throughput supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.",
        SerializedName = @"throughput",
        PossibleTypes = new [] { typeof(int) })]
        int? Throughput { get; set; }
        /// <summary>Storage tier of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Storage tier of a server.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("P1", "P2", "P3", "P4", "P6", "P10", "P15", "P20", "P30", "P40", "P50", "P60", "P70", "P80")]
        string Tier { get; set; }
        /// <summary>
        /// Type of storage assigned to a server. Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS. If not specified,
        /// it defaults to Premium_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type of storage assigned to a server. Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS. If not specified, it defaults to Premium_LRS.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Premium_LRS", "PremiumV2_LRS", "UltraSSD_LRS")]
        string Type { get; set; }

    }
    /// Storage properties of a server.
    internal partial interface IStorageInternal

    {
        /// <summary>
        /// Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions
        /// allow for automatically growing storage size.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string AutoGrow { get; set; }
        /// <summary>
        /// Maximum IOPS supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        int? Iop { get; set; }
        /// <summary>Size of storage assigned to a server.</summary>
        int? SizeGb { get; set; }
        /// <summary>
        /// Maximum throughput supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        int? Throughput { get; set; }
        /// <summary>Storage tier of a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("P1", "P2", "P3", "P4", "P6", "P10", "P15", "P20", "P30", "P40", "P50", "P60", "P70", "P80")]
        string Tier { get; set; }
        /// <summary>
        /// Type of storage assigned to a server. Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS. If not specified,
        /// it defaults to Premium_LRS.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Premium_LRS", "PremiumV2_LRS", "UltraSSD_LRS")]
        string Type { get; set; }

    }
}