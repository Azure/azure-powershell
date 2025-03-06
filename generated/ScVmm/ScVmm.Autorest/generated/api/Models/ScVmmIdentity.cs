// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Extensions;

    public partial class ScVmmIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentityInternal
    {

        /// <summary>Backing field for <see cref="AvailabilitySetResourceName" /> property.</summary>
        private string _availabilitySetResourceName;

        /// <summary>Name of the AvailabilitySet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string AvailabilitySetResourceName { get => this._availabilitySetResourceName; set => this._availabilitySetResourceName = value; }

        /// <summary>Backing field for <see cref="CloudResourceName" /> property.</summary>
        private string _cloudResourceName;

        /// <summary>Name of the Cloud.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string CloudResourceName { get => this._cloudResourceName; set => this._cloudResourceName = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource identity path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="InventoryItemResourceName" /> property.</summary>
        private string _inventoryItemResourceName;

        /// <summary>Name of the inventoryItem.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string InventoryItemResourceName { get => this._inventoryItemResourceName; set => this._inventoryItemResourceName = value; }

        /// <summary>Backing field for <see cref="ResourceGroupName" /> property.</summary>
        private string _resourceGroupName;

        /// <summary>The name of the resource group. The name is case insensitive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => this._resourceGroupName; set => this._resourceGroupName = value; }

        /// <summary>Backing field for <see cref="ResourceUri" /> property.</summary>
        private string _resourceUri;

        /// <summary>The fully qualified Azure Resource manager identifier of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string ResourceUri { get => this._resourceUri; set => this._resourceUri = value; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string SubscriptionId { get => this._subscriptionId; set => this._subscriptionId = value; }

        /// <summary>Backing field for <see cref="VirtualMachineTemplateName" /> property.</summary>
        private string _virtualMachineTemplateName;

        /// <summary>Name of the VirtualMachineTemplate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string VirtualMachineTemplateName { get => this._virtualMachineTemplateName; set => this._virtualMachineTemplateName = value; }

        /// <summary>Backing field for <see cref="VirtualNetworkName" /> property.</summary>
        private string _virtualNetworkName;

        /// <summary>Name of the VirtualNetwork.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string VirtualNetworkName { get => this._virtualNetworkName; set => this._virtualNetworkName = value; }

        /// <summary>Backing field for <see cref="VmmServerName" /> property.</summary>
        private string _vmmServerName;

        /// <summary>Name of the VmmServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string VmmServerName { get => this._vmmServerName; set => this._vmmServerName = value; }

        /// <summary>Creates an new <see cref="ScVmmIdentity" /> instance.</summary>
        public ScVmmIdentity()
        {

        }
    }
    public partial interface IScVmmIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.IJsonSerializable
    {
        /// <summary>Name of the AvailabilitySet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the AvailabilitySet.",
        SerializedName = @"availabilitySetResourceName",
        PossibleTypes = new [] { typeof(string) })]
        string AvailabilitySetResourceName { get; set; }
        /// <summary>Name of the Cloud.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the Cloud.",
        SerializedName = @"cloudResourceName",
        PossibleTypes = new [] { typeof(string) })]
        string CloudResourceName { get; set; }
        /// <summary>Resource identity path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource identity path",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Name of the inventoryItem.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the inventoryItem.",
        SerializedName = @"inventoryItemResourceName",
        PossibleTypes = new [] { typeof(string) })]
        string InventoryItemResourceName { get; set; }
        /// <summary>The name of the resource group. The name is case insensitive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the resource group. The name is case insensitive.",
        SerializedName = @"resourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGroupName { get; set; }
        /// <summary>The fully qualified Azure Resource manager identifier of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The fully qualified Azure Resource manager identifier of the resource.",
        SerializedName = @"resourceUri",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceUri { get; set; }
        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ID of the target subscription. The value must be an UUID.",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        string SubscriptionId { get; set; }
        /// <summary>Name of the VirtualMachineTemplate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the VirtualMachineTemplate.",
        SerializedName = @"virtualMachineTemplateName",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualMachineTemplateName { get; set; }
        /// <summary>Name of the VirtualNetwork.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the VirtualNetwork.",
        SerializedName = @"virtualNetworkName",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkName { get; set; }
        /// <summary>Name of the VmmServer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the VmmServer.",
        SerializedName = @"vmmServerName",
        PossibleTypes = new [] { typeof(string) })]
        string VmmServerName { get; set; }

    }
    internal partial interface IScVmmIdentityInternal

    {
        /// <summary>Name of the AvailabilitySet.</summary>
        string AvailabilitySetResourceName { get; set; }
        /// <summary>Name of the Cloud.</summary>
        string CloudResourceName { get; set; }
        /// <summary>Resource identity path</summary>
        string Id { get; set; }
        /// <summary>Name of the inventoryItem.</summary>
        string InventoryItemResourceName { get; set; }
        /// <summary>The name of the resource group. The name is case insensitive.</summary>
        string ResourceGroupName { get; set; }
        /// <summary>The fully qualified Azure Resource manager identifier of the resource.</summary>
        string ResourceUri { get; set; }
        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        string SubscriptionId { get; set; }
        /// <summary>Name of the VirtualMachineTemplate.</summary>
        string VirtualMachineTemplateName { get; set; }
        /// <summary>Name of the VirtualNetwork.</summary>
        string VirtualNetworkName { get; set; }
        /// <summary>Name of the VmmServer.</summary>
        string VmmServerName { get; set; }

    }
}