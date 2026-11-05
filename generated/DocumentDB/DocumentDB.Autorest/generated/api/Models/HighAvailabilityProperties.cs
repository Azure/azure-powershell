// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>The high availability properties of the cluster.</summary>
    public partial class HighAvailabilityProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityPropertiesInternal
    {

        /// <summary>Backing field for <see cref="TargetMode" /> property.</summary>
        private string _targetMode;

        /// <summary>The target high availability mode requested for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string TargetMode { get => this._targetMode; set => this._targetMode = value; }

        /// <summary>Creates an new <see cref="HighAvailabilityProperties" /> instance.</summary>
        public HighAvailabilityProperties()
        {

        }
    }
    /// The high availability properties of the cluster.
    public partial interface IHighAvailabilityProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>The target high availability mode requested for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The target high availability mode requested for the cluster.",
        SerializedName = @"targetMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Disabled", "SameZone", "ZoneRedundantPreferred")]
        string TargetMode { get; set; }

    }
    /// The high availability properties of the cluster.
    internal partial interface IHighAvailabilityPropertiesInternal

    {
        /// <summary>The target high availability mode requested for the cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Disabled", "SameZone", "ZoneRedundantPreferred")]
        string TargetMode { get; set; }

    }
}