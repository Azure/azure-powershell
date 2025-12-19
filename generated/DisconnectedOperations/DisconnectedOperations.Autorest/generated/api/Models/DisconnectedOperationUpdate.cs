// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The type used for update operations of the DisconnectedOperation.</summary>
    public partial class DisconnectedOperationUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal
    {

        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string ConnectionIntent { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).ConnectionIntent; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).ConnectionIntent = value ?? null; }

        /// <summary>The device version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string DeviceVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).DeviceVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).DeviceVersion = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties()); set => this._property = value; }

        /// <summary>The registration intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string RegistrationStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).RegistrationStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).RegistrationStatus = value ?? null; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationUpdateTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="DisconnectedOperationUpdate" /> instance.</summary>
        public DisconnectedOperationUpdate()
        {

        }
    }
    /// The type used for update operations of the DisconnectedOperation.
    public partial interface IDisconnectedOperationUpdate :
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
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateTags Tag { get; set; }

    }
    /// The type used for update operations of the DisconnectedOperation.
    internal partial interface IDisconnectedOperationUpdateInternal

    {
        /// <summary>The connection intent</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionIntent { get; set; }
        /// <summary>The device version</summary>
        string DeviceVersion { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateProperties Property { get; set; }
        /// <summary>The registration intent</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Registered", "Unregistered")]
        string RegistrationStatus { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateTags Tag { get; set; }

    }
}