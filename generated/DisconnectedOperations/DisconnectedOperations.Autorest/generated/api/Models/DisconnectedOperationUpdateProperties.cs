// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The updatable properties of the DisconnectedOperation.</summary>
    public partial class DisconnectedOperationUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="ConnectionIntent" /> property.</summary>
        private string _connectionIntent;

        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ConnectionIntent { get => this._connectionIntent; set => this._connectionIntent = value; }

        /// <summary>Backing field for <see cref="DeviceVersion" /> property.</summary>
        private string _deviceVersion;

        /// <summary>The device version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string DeviceVersion { get => this._deviceVersion; set => this._deviceVersion = value; }

        /// <summary>Backing field for <see cref="RegistrationStatus" /> property.</summary>
        private string _registrationStatus;

        /// <summary>The registration intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string RegistrationStatus { get => this._registrationStatus; set => this._registrationStatus = value; }

        /// <summary>Creates an new <see cref="DisconnectedOperationUpdateProperties" /> instance.</summary>
        public DisconnectedOperationUpdateProperties()
        {

        }
    }
    /// The updatable properties of the DisconnectedOperation.
    public partial interface IDisconnectedOperationUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The connection intent",
        SerializedName = @"connectionIntent",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionIntent { get; set; }
        /// <summary>The device version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = false,
        Update = true,
        Description = @"The device version",
        SerializedName = @"deviceVersion",
        PossibleTypes = new [] { typeof(string) })]
        string DeviceVersion { get; set; }
        /// <summary>The registration intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = false,
        Update = true,
        Description = @"The registration intent",
        SerializedName = @"registrationStatus",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Registered", "Unregistered")]
        string RegistrationStatus { get; set; }

    }
    /// The updatable properties of the DisconnectedOperation.
    internal partial interface IDisconnectedOperationUpdatePropertiesInternal

    {
        /// <summary>The connection intent</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionIntent { get; set; }
        /// <summary>The device version</summary>
        string DeviceVersion { get; set; }
        /// <summary>The registration intent</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Registered", "Unregistered")]
        string RegistrationStatus { get; set; }

    }
}