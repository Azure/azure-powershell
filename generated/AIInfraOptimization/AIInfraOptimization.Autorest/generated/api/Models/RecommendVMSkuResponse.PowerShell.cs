// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.PowerShell;

    /// <summary>
    /// The recommended Azure virtual machine sizes for the workload, with the sizing calculation they were derived from.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(RecommendVMSkuResponseTypeConverter))]
    public partial class RecommendVMSkuResponse
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RecommendVMSkuResponse(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RecommendVMSkuResponse(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RecommendVMSkuResponse" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="RecommendVMSkuResponse" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RecommendVMSkuResponse(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Sizing"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).Sizing = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizing) content.GetValueForProperty("Sizing",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).Sizing, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingTypeConverter.ConvertFrom);
            }
            if (content.Contains("Option"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).Option = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption>) content.GetValueForProperty("Option",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).Option, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption>(__y, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuOptionTypeConverter.ConvertFrom));
            }
            if (content.Contains("SizingModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingModel = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModel) content.GetValueForProperty("SizingModel",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingModel, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingModelTypeConverter.ConvertFrom);
            }
            if (content.Contains("SizingWorkload"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingWorkload = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkload) content.GetValueForProperty("SizingWorkload",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingWorkload, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingWorkloadTypeConverter.ConvertFrom);
            }
            if (content.Contains("SizingMemory"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingMemory = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemory) content.GetValueForProperty("SizingMemory",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingMemory, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuMemoryTypeConverter.ConvertFrom);
            }
            if (content.Contains("SizingBasis"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingBasis = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasis) content.GetValueForProperty("SizingBasis",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingBasis, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingBasisTypeConverter.ConvertFrom);
            }
            if (content.Contains("ModelParameterCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).ModelParameterCount = (long) content.GetValueForProperty("ModelParameterCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).ModelParameterCount, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("ModelWeightPrecision"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).ModelWeightPrecision = (string) content.GetValueForProperty("ModelWeightPrecision",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).ModelWeightPrecision, global::System.Convert.ToString);
            }
            if (content.Contains("WorkloadContextLength"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).WorkloadContextLength = (int) content.GetValueForProperty("WorkloadContextLength",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).WorkloadContextLength, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ModelHuggingFaceModelId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).ModelHuggingFaceModelId = (string) content.GetValueForProperty("ModelHuggingFaceModelId",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).ModelHuggingFaceModelId, global::System.Convert.ToString);
            }
            if (content.Contains("WorkloadMaxConcurrentRequestsPerReplica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).WorkloadMaxConcurrentRequestsPerReplica = (int) content.GetValueForProperty("WorkloadMaxConcurrentRequestsPerReplica",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).WorkloadMaxConcurrentRequestsPerReplica, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MemoryModelWeightsGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryModelWeightsGiB = (double) content.GetValueForProperty("MemoryModelWeightsGiB",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryModelWeightsGiB, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("MemoryKvCacheGiBPerRequest"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryKvCacheGiBPerRequest = (double) content.GetValueForProperty("MemoryKvCacheGiBPerRequest",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryKvCacheGiBPerRequest, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("MemoryKvCacheGiBTotal"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryKvCacheGiBTotal = (double) content.GetValueForProperty("MemoryKvCacheGiBTotal",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryKvCacheGiBTotal, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("MemoryModelAndKvCacheGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryModelAndKvCacheGiB = (double) content.GetValueForProperty("MemoryModelAndKvCacheGiB",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryModelAndKvCacheGiB, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("BasisParameterCountSource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).BasisParameterCountSource = (string) content.GetValueForProperty("BasisParameterCountSource",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).BasisParameterCountSource, global::System.Convert.ToString);
            }
            if (content.Contains("BasisModelWeightsCalculation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).BasisModelWeightsCalculation = (string) content.GetValueForProperty("BasisModelWeightsCalculation",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).BasisModelWeightsCalculation, global::System.Convert.ToString);
            }
            if (content.Contains("BasisContextLengthSource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).BasisContextLengthSource = (string) content.GetValueForProperty("BasisContextLengthSource",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).BasisContextLengthSource, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RecommendVMSkuResponse(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Sizing"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).Sizing = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizing) content.GetValueForProperty("Sizing",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).Sizing, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingTypeConverter.ConvertFrom);
            }
            if (content.Contains("Option"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).Option = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption>) content.GetValueForProperty("Option",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).Option, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOption>(__y, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuOptionTypeConverter.ConvertFrom));
            }
            if (content.Contains("SizingModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingModel = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingModel) content.GetValueForProperty("SizingModel",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingModel, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingModelTypeConverter.ConvertFrom);
            }
            if (content.Contains("SizingWorkload"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingWorkload = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingWorkload) content.GetValueForProperty("SizingWorkload",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingWorkload, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingWorkloadTypeConverter.ConvertFrom);
            }
            if (content.Contains("SizingMemory"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingMemory = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuMemory) content.GetValueForProperty("SizingMemory",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingMemory, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuMemoryTypeConverter.ConvertFrom);
            }
            if (content.Contains("SizingBasis"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingBasis = (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSizingBasis) content.GetValueForProperty("SizingBasis",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).SizingBasis, Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSizingBasisTypeConverter.ConvertFrom);
            }
            if (content.Contains("ModelParameterCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).ModelParameterCount = (long) content.GetValueForProperty("ModelParameterCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).ModelParameterCount, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("ModelWeightPrecision"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).ModelWeightPrecision = (string) content.GetValueForProperty("ModelWeightPrecision",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).ModelWeightPrecision, global::System.Convert.ToString);
            }
            if (content.Contains("WorkloadContextLength"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).WorkloadContextLength = (int) content.GetValueForProperty("WorkloadContextLength",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).WorkloadContextLength, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ModelHuggingFaceModelId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).ModelHuggingFaceModelId = (string) content.GetValueForProperty("ModelHuggingFaceModelId",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).ModelHuggingFaceModelId, global::System.Convert.ToString);
            }
            if (content.Contains("WorkloadMaxConcurrentRequestsPerReplica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).WorkloadMaxConcurrentRequestsPerReplica = (int) content.GetValueForProperty("WorkloadMaxConcurrentRequestsPerReplica",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).WorkloadMaxConcurrentRequestsPerReplica, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MemoryModelWeightsGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryModelWeightsGiB = (double) content.GetValueForProperty("MemoryModelWeightsGiB",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryModelWeightsGiB, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("MemoryKvCacheGiBPerRequest"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryKvCacheGiBPerRequest = (double) content.GetValueForProperty("MemoryKvCacheGiBPerRequest",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryKvCacheGiBPerRequest, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("MemoryKvCacheGiBTotal"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryKvCacheGiBTotal = (double) content.GetValueForProperty("MemoryKvCacheGiBTotal",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryKvCacheGiBTotal, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("MemoryModelAndKvCacheGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryModelAndKvCacheGiB = (double) content.GetValueForProperty("MemoryModelAndKvCacheGiB",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).MemoryModelAndKvCacheGiB, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("BasisParameterCountSource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).BasisParameterCountSource = (string) content.GetValueForProperty("BasisParameterCountSource",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).BasisParameterCountSource, global::System.Convert.ToString);
            }
            if (content.Contains("BasisModelWeightsCalculation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).BasisModelWeightsCalculation = (string) content.GetValueForProperty("BasisModelWeightsCalculation",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).BasisModelWeightsCalculation, global::System.Convert.ToString);
            }
            if (content.Contains("BasisContextLengthSource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).BasisContextLengthSource = (string) content.GetValueForProperty("BasisContextLengthSource",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponseInternal)this).BasisContextLengthSource, global::System.Convert.ToString);
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
    /// The recommended Azure virtual machine sizes for the workload, with the sizing calculation they were derived from.
    [System.ComponentModel.TypeConverter(typeof(RecommendVMSkuResponseTypeConverter))]
    public partial interface IRecommendVMSkuResponse

    {

    }
}