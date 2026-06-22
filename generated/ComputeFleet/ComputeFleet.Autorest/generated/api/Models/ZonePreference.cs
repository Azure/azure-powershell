// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Extensions;

    /// <summary>Zone preferences for Compute Fleet zone allocation policy.</summary>
    public partial class ZonePreference :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference,
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreferenceInternal
    {

        /// <summary>Backing field for <see cref="Rank" /> property.</summary>
        private int? _rank;

        /// <summary>
        /// The rank of the zone. This is used with 'Prioritized' ZoneDistributionStrategy.
        /// The lower the number, the higher the priority, starting with 0.
        /// 0 is the highest rank. If not specified, defaults to lowest rank.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public int? Rank { get => this._rank; set => this._rank = value; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private string _zone;

        /// <summary>Name of the zone.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public string Zone { get => this._zone; set => this._zone = value; }

        /// <summary>Creates an new <see cref="ZonePreference" /> instance.</summary>
        public ZonePreference()
        {

        }
    }
    /// Zone preferences for Compute Fleet zone allocation policy.
    public partial interface IZonePreference :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The rank of the zone. This is used with 'Prioritized' ZoneDistributionStrategy.
        /// The lower the number, the higher the priority, starting with 0.
        /// 0 is the highest rank. If not specified, defaults to lowest rank.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The rank of the zone. This is used with 'Prioritized' ZoneDistributionStrategy.
        The lower the number, the higher the priority, starting with 0.
        0 is the highest rank. If not specified, defaults to lowest rank.",
        SerializedName = @"rank",
        PossibleTypes = new [] { typeof(int) })]
        int? Rank { get; set; }
        /// <summary>Name of the zone.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the zone.",
        SerializedName = @"zone",
        PossibleTypes = new [] { typeof(string) })]
        string Zone { get; set; }

    }
    /// Zone preferences for Compute Fleet zone allocation policy.
    internal partial interface IZonePreferenceInternal

    {
        /// <summary>
        /// The rank of the zone. This is used with 'Prioritized' ZoneDistributionStrategy.
        /// The lower the number, the higher the priority, starting with 0.
        /// 0 is the highest rank. If not specified, defaults to lowest rank.
        /// </summary>
        int? Rank { get; set; }
        /// <summary>Name of the zone.</summary>
        string Zone { get; set; }

    }
}