// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.PowerShell;

    /// <summary>
    /// The parameters used to request an Azure virtual machine size recommendation for an AI workload.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(RecommendVMSkuRequestTypeConverter))]
    public partial class RecommendVMSkuRequest
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RecommendVMSkuRequest(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RecommendVMSkuRequest(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RecommendVMSkuRequest" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="RecommendVMSkuRequest" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RecommendVMSkuRequest(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Model"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Model = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModel) content.GetValueForProperty("Model",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Model, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuModelTypeConverter.ConvertFrom);
            }
            if (content.Contains("Workload"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Workload = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkload) content.GetValueForProperty("Workload",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Workload, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuWorkloadTypeConverter.ConvertFrom);
            }
            if (content.Contains("Deployment"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Deployment = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuDeployment) content.GetValueForProperty("Deployment",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Deployment, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuDeploymentTypeConverter.ConvertFrom);
            }
            if (content.Contains("Optimization"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Optimization = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimization) content.GetValueForProperty("Optimization",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Optimization, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuOptimizationTypeConverter.ConvertFrom);
            }
            if (content.Contains("SubscriptionOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOption = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptions) content.GetValueForProperty("SubscriptionOption",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOption, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSubscriptionOptionsTypeConverter.ConvertFrom);
            }
            if (content.Contains("TargetVMSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).TargetVMSize = (System.Collections.Generic.List<string>) content.GetValueForProperty("TargetVMSize",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).TargetVMSize, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("ModelParameterCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelParameterCount = (long?) content.GetValueForProperty("ModelParameterCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelParameterCount, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("ModelWeightPrecision"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelWeightPrecision = (string) content.GetValueForProperty("ModelWeightPrecision",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelWeightPrecision, global::System.Convert.ToString);
            }
            if (content.Contains("DeploymentProcurementOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).DeploymentProcurementOption = (string) content.GetValueForProperty("DeploymentProcurementOption",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).DeploymentProcurementOption, global::System.Convert.ToString);
            }
            if (content.Contains("OptimizationRankingPreference"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).OptimizationRankingPreference = (string) content.GetValueForProperty("OptimizationRankingPreference",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).OptimizationRankingPreference, global::System.Convert.ToString);
            }
            if (content.Contains("ModelHuggingFaceModelId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelHuggingFaceModelId = (string) content.GetValueForProperty("ModelHuggingFaceModelId",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelHuggingFaceModelId, global::System.Convert.ToString);
            }
            if (content.Contains("ModelNumLayer"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelNumLayer = (int?) content.GetValueForProperty("ModelNumLayer",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelNumLayer, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ModelNumKeyValueHead"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelNumKeyValueHead = (int?) content.GetValueForProperty("ModelNumKeyValueHead",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelNumKeyValueHead, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ModelHeadDim"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelHeadDim = (int?) content.GetValueForProperty("ModelHeadDim",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelHeadDim, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ModelMaxContextLength"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelMaxContextLength = (int?) content.GetValueForProperty("ModelMaxContextLength",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelMaxContextLength, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("WorkloadTokenBudget"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).WorkloadTokenBudget = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudget) content.GetValueForProperty("WorkloadTokenBudget",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).WorkloadTokenBudget, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuTokenBudgetTypeConverter.ConvertFrom);
            }
            if (content.Contains("WorkloadMaxConcurrentRequestsPerReplica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).WorkloadMaxConcurrentRequestsPerReplica = (int?) content.GetValueForProperty("WorkloadMaxConcurrentRequestsPerReplica",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).WorkloadMaxConcurrentRequestsPerReplica, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("DeploymentReplicaCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).DeploymentReplicaCount = (int?) content.GetValueForProperty("DeploymentReplicaCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).DeploymentReplicaCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("OptimizationMaxDeploymentCostPerHour"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).OptimizationMaxDeploymentCostPerHour = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCost) content.GetValueForProperty("OptimizationMaxDeploymentCostPerHour",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).OptimizationMaxDeploymentCostPerHour, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuHourlyCostTypeConverter.ConvertFrom);
            }
            if (content.Contains("SubscriptionOptionIncludeQuota"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOptionIncludeQuota = (bool?) content.GetValueForProperty("SubscriptionOptionIncludeQuota",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOptionIncludeQuota, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("SubscriptionOptionIncludePlacement"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOptionIncludePlacement = (bool?) content.GetValueForProperty("SubscriptionOptionIncludePlacement",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOptionIncludePlacement, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("SubscriptionOptionIncludePricing"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOptionIncludePricing = (bool?) content.GetValueForProperty("SubscriptionOptionIncludePricing",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOptionIncludePricing, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("TokenBudgetPromptToken"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).TokenBudgetPromptToken = (int?) content.GetValueForProperty("TokenBudgetPromptToken",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).TokenBudgetPromptToken, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("TokenBudgetMaxOutputToken"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).TokenBudgetMaxOutputToken = (int?) content.GetValueForProperty("TokenBudgetMaxOutputToken",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).TokenBudgetMaxOutputToken, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxDeploymentCostPerHourAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).MaxDeploymentCostPerHourAmount = (double?) content.GetValueForProperty("MaxDeploymentCostPerHourAmount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).MaxDeploymentCostPerHourAmount, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("MaxDeploymentCostPerHourCurrencyCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).MaxDeploymentCostPerHourCurrencyCode = (string) content.GetValueForProperty("MaxDeploymentCostPerHourCurrencyCode",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).MaxDeploymentCostPerHourCurrencyCode, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RecommendVMSkuRequest(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Model"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Model = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModel) content.GetValueForProperty("Model",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Model, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuModelTypeConverter.ConvertFrom);
            }
            if (content.Contains("Workload"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Workload = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkload) content.GetValueForProperty("Workload",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Workload, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuWorkloadTypeConverter.ConvertFrom);
            }
            if (content.Contains("Deployment"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Deployment = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuDeployment) content.GetValueForProperty("Deployment",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Deployment, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuDeploymentTypeConverter.ConvertFrom);
            }
            if (content.Contains("Optimization"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Optimization = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimization) content.GetValueForProperty("Optimization",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).Optimization, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuOptimizationTypeConverter.ConvertFrom);
            }
            if (content.Contains("SubscriptionOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOption = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptions) content.GetValueForProperty("SubscriptionOption",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOption, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSubscriptionOptionsTypeConverter.ConvertFrom);
            }
            if (content.Contains("TargetVMSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).TargetVMSize = (System.Collections.Generic.List<string>) content.GetValueForProperty("TargetVMSize",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).TargetVMSize, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("ModelParameterCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelParameterCount = (long?) content.GetValueForProperty("ModelParameterCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelParameterCount, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("ModelWeightPrecision"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelWeightPrecision = (string) content.GetValueForProperty("ModelWeightPrecision",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelWeightPrecision, global::System.Convert.ToString);
            }
            if (content.Contains("DeploymentProcurementOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).DeploymentProcurementOption = (string) content.GetValueForProperty("DeploymentProcurementOption",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).DeploymentProcurementOption, global::System.Convert.ToString);
            }
            if (content.Contains("OptimizationRankingPreference"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).OptimizationRankingPreference = (string) content.GetValueForProperty("OptimizationRankingPreference",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).OptimizationRankingPreference, global::System.Convert.ToString);
            }
            if (content.Contains("ModelHuggingFaceModelId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelHuggingFaceModelId = (string) content.GetValueForProperty("ModelHuggingFaceModelId",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelHuggingFaceModelId, global::System.Convert.ToString);
            }
            if (content.Contains("ModelNumLayer"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelNumLayer = (int?) content.GetValueForProperty("ModelNumLayer",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelNumLayer, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ModelNumKeyValueHead"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelNumKeyValueHead = (int?) content.GetValueForProperty("ModelNumKeyValueHead",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelNumKeyValueHead, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ModelHeadDim"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelHeadDim = (int?) content.GetValueForProperty("ModelHeadDim",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelHeadDim, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ModelMaxContextLength"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelMaxContextLength = (int?) content.GetValueForProperty("ModelMaxContextLength",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).ModelMaxContextLength, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("WorkloadTokenBudget"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).WorkloadTokenBudget = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudget) content.GetValueForProperty("WorkloadTokenBudget",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).WorkloadTokenBudget, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuTokenBudgetTypeConverter.ConvertFrom);
            }
            if (content.Contains("WorkloadMaxConcurrentRequestsPerReplica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).WorkloadMaxConcurrentRequestsPerReplica = (int?) content.GetValueForProperty("WorkloadMaxConcurrentRequestsPerReplica",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).WorkloadMaxConcurrentRequestsPerReplica, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("DeploymentReplicaCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).DeploymentReplicaCount = (int?) content.GetValueForProperty("DeploymentReplicaCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).DeploymentReplicaCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("OptimizationMaxDeploymentCostPerHour"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).OptimizationMaxDeploymentCostPerHour = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCost) content.GetValueForProperty("OptimizationMaxDeploymentCostPerHour",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).OptimizationMaxDeploymentCostPerHour, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuHourlyCostTypeConverter.ConvertFrom);
            }
            if (content.Contains("SubscriptionOptionIncludeQuota"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOptionIncludeQuota = (bool?) content.GetValueForProperty("SubscriptionOptionIncludeQuota",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOptionIncludeQuota, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("SubscriptionOptionIncludePlacement"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOptionIncludePlacement = (bool?) content.GetValueForProperty("SubscriptionOptionIncludePlacement",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOptionIncludePlacement, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("SubscriptionOptionIncludePricing"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOptionIncludePricing = (bool?) content.GetValueForProperty("SubscriptionOptionIncludePricing",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).SubscriptionOptionIncludePricing, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("TokenBudgetPromptToken"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).TokenBudgetPromptToken = (int?) content.GetValueForProperty("TokenBudgetPromptToken",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).TokenBudgetPromptToken, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("TokenBudgetMaxOutputToken"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).TokenBudgetMaxOutputToken = (int?) content.GetValueForProperty("TokenBudgetMaxOutputToken",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).TokenBudgetMaxOutputToken, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxDeploymentCostPerHourAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).MaxDeploymentCostPerHourAmount = (double?) content.GetValueForProperty("MaxDeploymentCostPerHourAmount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).MaxDeploymentCostPerHourAmount, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("MaxDeploymentCostPerHourCurrencyCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).MaxDeploymentCostPerHourCurrencyCode = (string) content.GetValueForProperty("MaxDeploymentCostPerHourCurrencyCode",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal)this).MaxDeploymentCostPerHourCurrencyCode, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// The parameters used to request an Azure virtual machine size recommendation for an AI workload.
    [System.ComponentModel.TypeConverter(typeof(RecommendVMSkuRequestTypeConverter))]
    public partial interface IRecommendVMSkuRequest

    {

    }
}