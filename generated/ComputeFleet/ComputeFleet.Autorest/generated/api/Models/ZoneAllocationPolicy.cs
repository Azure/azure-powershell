// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Extensions;

    /// <summary>ZoneAllocationPolicy for Compute Fleet.</summary>
    public partial class ZoneAllocationPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicy,
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicyInternal
    {

        /// <summary>Backing field for <see cref="DistributionStrategy" /> property.</summary>
        private string _distributionStrategy;

        /// <summary>Distribution strategy used for zone allocation policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public string DistributionStrategy { get => this._distributionStrategy; set => this._distributionStrategy = value; }

        /// <summary>Backing field for <see cref="ZonePreference" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference> _zonePreference;

        /// <summary>Zone preferences, required when zone distribution strategy is Prioritized.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference> ZonePreference { get => this._zonePreference; set => this._zonePreference = value; }

        /// <summary>Creates an new <see cref="ZoneAllocationPolicy" /> instance.</summary>
        public ZoneAllocationPolicy()
        {

        }
    }
    /// ZoneAllocationPolicy for Compute Fleet.
    public partial interface IZoneAllocationPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IJsonSerializable
    {
        /// <summary>Distribution strategy used for zone allocation policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Distribution strategy used for zone allocation policy.",
        SerializedName = @"distributionStrategy",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("BestEffortSingleZone", "Prioritized")]
        string DistributionStrategy { get; set; }
        /// <summary>Zone preferences, required when zone distribution strategy is Prioritized.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Zone preferences, required when zone distribution strategy is Prioritized.",
        SerializedName = @"zonePreferences",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference> ZonePreference { get; set; }

    }
    /// ZoneAllocationPolicy for Compute Fleet.
    internal partial interface IZoneAllocationPolicyInternal

    {
        /// <summary>Distribution strategy used for zone allocation policy.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("BestEffortSingleZone", "Prioritized")]
        string DistributionStrategy { get; set; }
        /// <summary>Zone preferences, required when zone distribution strategy is Prioritized.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference> ZonePreference { get; set; }

    }
}