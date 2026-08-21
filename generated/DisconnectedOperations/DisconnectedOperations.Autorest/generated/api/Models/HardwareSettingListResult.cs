// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The response of a HardwareSetting list operation.</summary>
    public partial class HardwareSettingListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingListResult,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting> _value;

        /// <summary>The HardwareSetting items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting> Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="HardwareSettingListResult" /> instance.</summary>
        public HardwareSettingListResult()
        {

        }
    }
    /// The response of a HardwareSetting list operation.
    public partial interface IHardwareSettingListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The link to the next page of items",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The HardwareSetting items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The HardwareSetting items on this page",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting> Value { get; set; }

    }
    /// The response of a HardwareSetting list operation.
    internal partial interface IHardwareSettingListResultInternal

    {
        /// <summary>The link to the next page of items</summary>
        string NextLink { get; set; }
        /// <summary>The HardwareSetting items on this page</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting> Value { get; set; }

    }
}