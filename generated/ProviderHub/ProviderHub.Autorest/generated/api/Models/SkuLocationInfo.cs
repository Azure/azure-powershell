// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class SkuLocationInfo :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuLocationInfo,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuLocationInfoInternal
    {

        /// <summary>Backing field for <see cref="ExtendedLocation" /> property.</summary>
        private System.Collections.Generic.List<string> _extendedLocation;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> ExtendedLocation { get => this._extendedLocation; set => this._extendedLocation = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private System.Collections.Generic.List<string> _zone;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> Zone { get => this._zone; set => this._zone = value; }

        /// <summary>Backing field for <see cref="ZoneDetail" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuZoneDetail> _zoneDetail;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuZoneDetail> ZoneDetail { get => this._zoneDetail; set => this._zoneDetail = value; }

        /// <summary>Creates an new <see cref="SkuLocationInfo" /> instance.</summary>
        public SkuLocationInfo()
        {

        }
    }
    public partial interface ISkuLocationInfo :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"extendedLocations",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> ExtendedLocation { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "EdgeZone", "ArcZone")]
        string Type { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Zone { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"zoneDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuZoneDetail) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuZoneDetail> ZoneDetail { get; set; }

    }
    internal partial interface ISkuLocationInfoInternal

    {
        System.Collections.Generic.List<string> ExtendedLocation { get; set; }

        string Location { get; set; }

        [global::Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "EdgeZone", "ArcZone")]
        string Type { get; set; }

        System.Collections.Generic.List<string> Zone { get; set; }

        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuZoneDetail> ZoneDetail { get; set; }

    }
}