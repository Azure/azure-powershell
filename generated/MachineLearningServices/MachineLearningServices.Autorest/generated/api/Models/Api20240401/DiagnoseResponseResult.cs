// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Extensions;

    public partial class DiagnoseResponseResult :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResult,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValue Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultInternal.Value { get => (this._value = this._value ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.DiagnoseResponseResultValue()); set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValue _value;

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValue Value { get => (this._value = this._value ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.DiagnoseResponseResultValue()); set => this._value = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueApplicationInsightsResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).ApplicationInsightsResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).ApplicationInsightsResult = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueContainerRegistryResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).ContainerRegistryResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).ContainerRegistryResult = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueDnsResolutionResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).DnsResolutionResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).DnsResolutionResult = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueKeyVaultResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).KeyVaultResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).KeyVaultResult = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueNetworkSecurityRuleResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).NetworkSecurityRuleResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).NetworkSecurityRuleResult = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueOtherResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).OtherResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).OtherResult = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueResourceLockResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).ResourceLockResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).ResourceLockResult = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueStorageAccountResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).StorageAccountResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).StorageAccountResult = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueUserDefinedRouteResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).UserDefinedRouteResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValueInternal)Value).UserDefinedRouteResult = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="DiagnoseResponseResult" /> instance.</summary>
        public DiagnoseResponseResult()
        {

        }
    }
    public partial interface IDiagnoseResponseResult :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"applicationInsightsResults",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueApplicationInsightsResult { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"containerRegistryResults",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueContainerRegistryResult { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"dnsResolutionResults",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueDnsResolutionResult { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"keyVaultResults",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueKeyVaultResult { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"networkSecurityRuleResults",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueNetworkSecurityRuleResult { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"otherResults",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueOtherResult { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceLockResults",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueResourceLockResult { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"storageAccountResults",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueStorageAccountResult { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"userDefinedRouteResults",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueUserDefinedRouteResult { get; set; }

    }
    internal partial interface IDiagnoseResponseResultInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResponseResultValue Value { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueApplicationInsightsResult { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueContainerRegistryResult { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueDnsResolutionResult { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueKeyVaultResult { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueNetworkSecurityRuleResult { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueOtherResult { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueResourceLockResult { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueStorageAccountResult { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDiagnoseResult[] ValueUserDefinedRouteResult { get; set; }

    }
}