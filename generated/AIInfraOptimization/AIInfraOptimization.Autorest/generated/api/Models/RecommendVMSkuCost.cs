// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>The deployment cost for one virtual machine size option.</summary>
    public partial class RecommendVMSkuCost :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCost,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal
    {

        /// <summary>The reason the stage did not complete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal)Error).Code = value ?? null; }

        /// <summary>Backing field for <see cref="CurrencyCode" /> property.</summary>
        private string _currencyCode;

        /// <summary>The ISO 4217 currency code all amounts in this object are expressed in.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string CurrencyCode { get => this._currencyCode; set => this._currencyCode = value; }

        /// <summary>Backing field for <see cref="DeploymentHourly" /> property.</summary>
        private double _deploymentHourly;

        /// <summary>The price per hour for the whole deployment, in the stated currency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public double DeploymentHourly { get => this._deploymentHourly; set => this._deploymentHourly = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError _error;

        /// <summary>
        /// The error that prevented subscription-scoped pricing from being resolved, if any.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageError()); set => this._error = value; }

        /// <summary>A human-readable description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageErrorInternal)Error).Message = value ?? null; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuCostInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuStageError()); set { {_error = value;} } }

        /// <summary>Backing field for <see cref="PriceAsOf" /> property.</summary>
        private global::System.DateTime? _priceAsOf;

        /// <summary>The date and time the price was observed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public global::System.DateTime? PriceAsOf { get => this._priceAsOf; set => this._priceAsOf = value; }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private string _source;

        /// <summary>The source the price was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string Source { get => this._source; set => this._source = value; }

        /// <summary>Backing field for <see cref="VMHourly" /> property.</summary>
        private double _vMHourly;

        /// <summary>The price per hour for a single virtual machine, in the stated currency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public double VMHourly { get => this._vMHourly; set => this._vMHourly = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuCost" /> instance.</summary>
        public RecommendVMSkuCost()
        {

        }
    }
    /// The deployment cost for one virtual machine size option.
    public partial interface IRecommendVMSkuCost :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>The reason the stage did not complete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The reason the stage did not complete.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("TimedOut", "Throttled", "PartitionCapacityExceeded", "DependencyError", "DataUnavailable", "EvaluationBudgetExceeded")]
        string Code { get; set; }
        /// <summary>The ISO 4217 currency code all amounts in this object are expressed in.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ISO 4217 currency code all amounts in this object are expressed in.",
        SerializedName = @"currencyCode",
        PossibleTypes = new [] { typeof(string) })]
        string CurrencyCode { get; set; }
        /// <summary>The price per hour for the whole deployment, in the stated currency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The price per hour for the whole deployment, in the stated currency.",
        SerializedName = @"deploymentHourly",
        PossibleTypes = new [] { typeof(double) })]
        double DeploymentHourly { get; set; }
        /// <summary>A human-readable description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A human-readable description of the error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>The date and time the price was observed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The date and time the price was observed.",
        SerializedName = @"priceAsOf",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? PriceAsOf { get; set; }
        /// <summary>The source the price was resolved from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The source the price was resolved from.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("AzureRetail", "AzureSubscription", "StaticPreview")]
        string Source { get; set; }
        /// <summary>The price per hour for a single virtual machine, in the stated currency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The price per hour for a single virtual machine, in the stated currency.",
        SerializedName = @"vmHourly",
        PossibleTypes = new [] { typeof(double) })]
        double VMHourly { get; set; }

    }
    /// The deployment cost for one virtual machine size option.
    internal partial interface IRecommendVMSkuCostInternal

    {
        /// <summary>The reason the stage did not complete.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("TimedOut", "Throttled", "PartitionCapacityExceeded", "DependencyError", "DataUnavailable", "EvaluationBudgetExceeded")]
        string Code { get; set; }
        /// <summary>The ISO 4217 currency code all amounts in this object are expressed in.</summary>
        string CurrencyCode { get; set; }
        /// <summary>The price per hour for the whole deployment, in the stated currency.</summary>
        double DeploymentHourly { get; set; }
        /// <summary>
        /// The error that prevented subscription-scoped pricing from being resolved, if any.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuStageError Error { get; set; }
        /// <summary>A human-readable description of the error.</summary>
        string Message { get; set; }
        /// <summary>The date and time the price was observed.</summary>
        global::System.DateTime? PriceAsOf { get; set; }
        /// <summary>The source the price was resolved from.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("AzureRetail", "AzureSubscription", "StaticPreview")]
        string Source { get; set; }
        /// <summary>The price per hour for a single virtual machine, in the stated currency.</summary>
        double VMHourly { get; set; }

    }
}