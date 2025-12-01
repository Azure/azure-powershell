// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The disconnected operation properties</summary>
    public partial class DisconnectedOperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BillingModel" /> property.</summary>
        private string _billingModel= @"Capacity";

        /// <summary>The billing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string BillingModel { get => this._billingModel; }

        /// <summary>Backing field for <see cref="ConnectionIntent" /> property.</summary>
        private string _connectionIntent;

        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ConnectionIntent { get => this._connectionIntent; set => this._connectionIntent = value; }

        /// <summary>Backing field for <see cref="ConnectionStatus" /> property.</summary>
        private string _connectionStatus;

        /// <summary>The connection status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ConnectionStatus { get => this._connectionStatus; }

        /// <summary>Backing field for <see cref="DeviceVersion" /> property.</summary>
        private string _deviceVersion;

        /// <summary>The device version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string DeviceVersion { get => this._deviceVersion; set => this._deviceVersion = value; }

        /// <summary>Internal Acessors for BillingModel</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.BillingModel { get => this._billingModel; set { {_billingModel = value;} } }

        /// <summary>Internal Acessors for ConnectionStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.ConnectionStatus { get => this._connectionStatus; set { {_connectionStatus = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for StampId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.StampId { get => this._stampId; set { {_stampId = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="RegistrationStatus" /> property.</summary>
        private string _registrationStatus;

        /// <summary>The registration intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string RegistrationStatus { get => this._registrationStatus; set => this._registrationStatus = value; }

        /// <summary>Backing field for <see cref="StampId" /> property.</summary>
        private string _stampId;

        /// <summary>The unique GUID of the stamp</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string StampId { get => this._stampId; }

        /// <summary>Creates an new <see cref="DisconnectedOperationProperties" /> instance.</summary>
        public DisconnectedOperationProperties()
        {

        }
    }
    /// The disconnected operation properties
    public partial interface IDisconnectedOperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
        /// <summary>The billing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The billing model",
        SerializedName = @"billingModel",
        PossibleTypes = new [] { typeof(string) })]
        string BillingModel { get;  }
        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The connection intent",
        SerializedName = @"connectionIntent",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionIntent { get; set; }
        /// <summary>The connection status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The connection status",
        SerializedName = @"connectionStatus",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionStatus { get;  }
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
        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource provisioning state",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get;  }
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
        /// <summary>The unique GUID of the stamp</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The unique GUID of the stamp",
        SerializedName = @"stampId",
        PossibleTypes = new [] { typeof(string) })]
        string StampId { get;  }

    }
    /// The disconnected operation properties
    internal partial interface IDisconnectedOperationPropertiesInternal

    {
        /// <summary>The billing model</summary>
        string BillingModel { get; set; }
        /// <summary>The connection intent</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionIntent { get; set; }
        /// <summary>The connection status</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionStatus { get; set; }
        /// <summary>The device version</summary>
        string DeviceVersion { get; set; }
        /// <summary>The resource provisioning state</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get; set; }
        /// <summary>The registration intent</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Registered", "Unregistered")]
        string RegistrationStatus { get; set; }
        /// <summary>The unique GUID of the stamp</summary>
        string StampId { get; set; }

    }
}