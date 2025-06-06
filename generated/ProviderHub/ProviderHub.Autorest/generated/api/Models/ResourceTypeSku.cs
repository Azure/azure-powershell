// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeSku :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceTypeSku,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceTypeSkuInternal
    {

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="SkuSetting" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuSetting> _skuSetting;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuSetting> SkuSetting { get => this._skuSetting; set => this._skuSetting = value; }

        /// <summary>Creates an new <see cref="ResourceTypeSku" /> instance.</summary>
        public ResourceTypeSku()
        {

        }
    }
    public partial interface IResourceTypeSku :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "Accepted", "Running", "Creating", "Created", "Deleting", "Deleted", "Canceled", "Failed", "Succeeded", "MovingResources", "TransientFailure", "RolloutInProgress")]
        string ProvisioningState { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"skuSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuSetting) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuSetting> SkuSetting { get; set; }

    }
    internal partial interface IResourceTypeSkuInternal

    {
        [global::Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "Accepted", "Running", "Creating", "Created", "Deleting", "Deleted", "Canceled", "Failed", "Succeeded", "MovingResources", "TransientFailure", "RolloutInProgress")]
        string ProvisioningState { get; set; }

        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuSetting> SkuSetting { get; set; }

    }
}