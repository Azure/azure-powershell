// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>A currency-qualified deployment-wide hourly cost.</summary>
    public partial class RecommendVMSkuHourlyCost :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCost,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCostInternal
    {

        /// <summary>Backing field for <see cref="Amount" /> property.</summary>
        private double? _amount;

        /// <summary>
        /// The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public double? Amount { get => this._amount; set => this._amount = value; }

        /// <summary>Backing field for <see cref="CurrencyCode" /> property.</summary>
        private string _currencyCode;

        /// <summary>
        /// The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public string CurrencyCode { get => this._currencyCode; set => this._currencyCode = value; }

        /// <summary>Creates an new <see cref="RecommendVMSkuHourlyCost" /> instance.</summary>
        public RecommendVMSkuHourlyCost()
        {

        }
    }
    /// A currency-qualified deployment-wide hourly cost.
    public partial interface IRecommendVMSkuHourlyCost :
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
        double? Amount { get; set; }
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
        string CurrencyCode { get; set; }

    }
    /// A currency-qualified deployment-wide hourly cost.
    internal partial interface IRecommendVMSkuHourlyCostInternal

    {
        /// <summary>
        /// The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.
        /// </summary>
        double? Amount { get; set; }
        /// <summary>
        /// The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.
        /// </summary>
        string CurrencyCode { get; set; }

    }
}