// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>Ranking preference and optional deployment-wide hourly cost limit.</summary>
    public partial class RecommendVMSkuOptimization :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimization,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimizationInternal
    {

        /// <summary>Backing field for <see cref="MaxDeploymentCostPerHour" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCost _maxDeploymentCostPerHour;

        /// <summary>The deployment-wide hourly cost ceiling.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCost MaxDeploymentCostPerHour { get => (this._maxDeploymentCostPerHour = this._maxDeploymentCostPerHour ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuHourlyCost()); set => this._maxDeploymentCostPerHour = value; }

        /// <summary>
        /// The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double? MaxDeploymentCostPerHourAmount { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCostInternal)MaxDeploymentCostPerHour).Amount; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCostInternal)MaxDeploymentCostPerHour).Amount = value ?? default(double); }

        /// <summary>
        /// The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string MaxDeploymentCostPerHourCurrencyCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCostInternal)MaxDeploymentCostPerHour).CurrencyCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCostInternal)MaxDeploymentCostPerHour).CurrencyCode = value ?? null; }

        /// <summary>Internal Acessors for MaxDeploymentCostPerHour</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCost Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimizationInternal.MaxDeploymentCostPerHour { get => (this._maxDeploymentCostPerHour = this._maxDeploymentCostPerHour ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuHourlyCost()); set { {_maxDeploymentCostPerHour = value;} } }

        /// <summary>Backing field for <see cref="RankingPreference" /> property.</summary>
        private string _rankingPreference;

        /// <summary>The preference used to rank the recommended options.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string RankingPreference { get => this._rankingPreference; set => this._rankingPreference = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuOptimization" /> instance.</summary>
        public RecommendVMSkuOptimization()
        {

        }
    }
    /// Ranking preference and optional deployment-wide hourly cost limit.
    public partial interface IRecommendVMSkuOptimization :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.",
        SerializedName = @"amount",
        PossibleTypes = new [] { typeof(double) })]
        double? MaxDeploymentCostPerHourAmount { get; set; }
        /// <summary>
        /// The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.",
        SerializedName = @"currencyCode",
        PossibleTypes = new [] { typeof(string) })]
        string MaxDeploymentCostPerHourCurrencyCode { get; set; }
        /// <summary>The preference used to rank the recommended options.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The preference used to rank the recommended options.",
        SerializedName = @"rankingPreference",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Cost", "Latency")]
        string RankingPreference { get; set; }

    }
    /// Ranking preference and optional deployment-wide hourly cost limit.
    internal partial interface IRecommendVMSkuOptimizationInternal

    {
        /// <summary>The deployment-wide hourly cost ceiling.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCost MaxDeploymentCostPerHour { get; set; }
        /// <summary>
        /// The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.
        /// </summary>
        double? MaxDeploymentCostPerHourAmount { get; set; }
        /// <summary>
        /// The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.
        /// </summary>
        string MaxDeploymentCostPerHourCurrencyCode { get; set; }
        /// <summary>The preference used to rank the recommended options.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Cost", "Latency")]
        string RankingPreference { get; set; }

    }
}