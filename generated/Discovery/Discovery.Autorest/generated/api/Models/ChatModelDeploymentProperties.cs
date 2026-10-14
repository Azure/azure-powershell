// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>
    /// Defines a deployment binding a specific model family to a user-defined deployment name for chat inference.
    /// </summary>
    public partial class ChatModelDeploymentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private int? _capacity;

        /// <summary>Provisioned SKU capacity units for this chat model deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public int? Capacity { get => this._capacity; set => this._capacity = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ModelFormat" /> property.</summary>
        private string _modelFormat;

        /// <summary>
        /// Model format as published by the provider. Verify supported formats per region using the Model Catalog API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ModelFormat { get => this._modelFormat; set => this._modelFormat = value; }

        /// <summary>Backing field for <see cref="ModelName" /> property.</summary>
        private string _modelName;

        /// <summary>
        /// Canonical provider model name available in the selected region. Verify supported values per region using the Model Catalog
        /// API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ModelName { get => this._modelName; set => this._modelName = value; }

        /// <summary>Backing field for <see cref="ModelVersion" /> property.</summary>
        private string _modelVersion;

        /// <summary>Provider-published version of the selected model.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ModelVersion { get => this._modelVersion; set => this._modelVersion = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="SkuName" /> property.</summary>
        private string _skuName;

        /// <summary>SKU tier used by this chat model deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string SkuName { get => this._skuName; set => this._skuName = value; }

        /// <summary>Creates an new <see cref="ChatModelDeploymentProperties" /> instance.</summary>
        public ChatModelDeploymentProperties()
        {

        }
    }
    /// Defines a deployment binding a specific model family to a user-defined deployment name for chat inference.
    public partial interface IChatModelDeploymentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>Provisioned SKU capacity units for this chat model deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Provisioned SKU capacity units for this chat model deployment.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get; set; }
        /// <summary>
        /// Model format as published by the provider. Verify supported formats per region using the Model Catalog API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Model format as published by the provider. Verify supported formats per region using the Model Catalog API.",
        SerializedName = @"modelFormat",
        PossibleTypes = new [] { typeof(string) })]
        string ModelFormat { get; set; }
        /// <summary>
        /// Canonical provider model name available in the selected region. Verify supported values per region using the Model Catalog
        /// API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Canonical provider model name available in the selected region. Verify supported values per region using the Model Catalog API.",
        SerializedName = @"modelName",
        PossibleTypes = new [] { typeof(string) })]
        string ModelName { get; set; }
        /// <summary>Provider-published version of the selected model.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Provider-published version of the selected model.",
        SerializedName = @"modelVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ModelVersion { get; set; }
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get;  }
        /// <summary>SKU tier used by this chat model deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"SKU tier used by this chat model deployment.",
        SerializedName = @"skuName",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }

    }
    /// Defines a deployment binding a specific model family to a user-defined deployment name for chat inference.
    internal partial interface IChatModelDeploymentPropertiesInternal

    {
        /// <summary>Provisioned SKU capacity units for this chat model deployment.</summary>
        int? Capacity { get; set; }
        /// <summary>
        /// Model format as published by the provider. Verify supported formats per region using the Model Catalog API.
        /// </summary>
        string ModelFormat { get; set; }
        /// <summary>
        /// Canonical provider model name available in the selected region. Verify supported values per region using the Model Catalog
        /// API.
        /// </summary>
        string ModelName { get; set; }
        /// <summary>Provider-published version of the selected model.</summary>
        string ModelVersion { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get; set; }
        /// <summary>SKU tier used by this chat model deployment.</summary>
        string SkuName { get; set; }

    }
}