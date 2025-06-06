// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class SkuSettingCapacity :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuSettingCapacity,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuSettingCapacityInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuCapacity" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuCapacity __skuCapacity = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.SkuCapacity();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public int? Default { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuCapacityInternal)__skuCapacity).Default; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuCapacityInternal)__skuCapacity).Default = value ?? default(int); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public int? Maximum { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuCapacityInternal)__skuCapacity).Maximum; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuCapacityInternal)__skuCapacity).Maximum = value ?? default(int); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public int Minimum { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuCapacityInternal)__skuCapacity).Minimum; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuCapacityInternal)__skuCapacity).Minimum = value ; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string ScaleType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuCapacityInternal)__skuCapacity).ScaleType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuCapacityInternal)__skuCapacity).ScaleType = value ?? null; }

        /// <summary>Creates an new <see cref="SkuSettingCapacity" /> instance.</summary>
        public SkuSettingCapacity()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__skuCapacity), __skuCapacity);
            await eventListener.AssertObjectIsValid(nameof(__skuCapacity), __skuCapacity);
        }
    }
    public partial interface ISkuSettingCapacity :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuCapacity
    {

    }
    internal partial interface ISkuSettingCapacityInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuCapacityInternal
    {

    }
}