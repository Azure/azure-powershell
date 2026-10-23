// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Extensions;

    /// <summary>The capacity details configuration that can be updated.</summary>
    public partial class CapacityDetailsUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ICapacityDetailsUpdateInternal
    {

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>The enablement status to update for the capacity details capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public string Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="CapacityDetailsUpdate" /> instance.</summary>
        public CapacityDetailsUpdate()
        {

        }
    }
    /// The capacity details configuration that can be updated.
    public partial interface ICapacityDetailsUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IJsonSerializable
    {
        /// <summary>The enablement status to update for the capacity details capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The enablement status to update for the capacity details capability.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string Status { get; set; }

    }
    /// The capacity details configuration that can be updated.
    internal partial interface ICapacityDetailsUpdateInternal

    {
        /// <summary>The enablement status to update for the capacity details capability.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string Status { get; set; }

    }
}