// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.PowerShell;

    /// <summary>The external benchmark evidence selected for one virtual machine size option.</summary>
    [System.ComponentModel.TypeConverter(typeof(RecommendVMSkuBenchmarkTypeConverter))]
    public partial class RecommendVMSkuBenchmark
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuBenchmark"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RecommendVMSkuBenchmark(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuBenchmark"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RecommendVMSkuBenchmark(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RecommendVMSkuBenchmark" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="RecommendVMSkuBenchmark" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmark FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuBenchmark"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RecommendVMSkuBenchmark(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Level"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Level = (string) content.GetValueForProperty("Level",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Level, global::System.Convert.ToString);
            }
            if (content.Contains("ModelClass"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).ModelClass = (string) content.GetValueForProperty("ModelClass",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).ModelClass, global::System.Convert.ToString);
            }
            if (content.Contains("Scenario"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Scenario = (string) content.GetValueForProperty("Scenario",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Scenario, global::System.Convert.ToString);
            }
            if (content.Contains("SubmitterCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).SubmitterCount = (int) content.GetValueForProperty("SubmitterCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).SubmitterCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SubmissionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).SubmissionId = (string) content.GetValueForProperty("SubmissionId",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).SubmissionId, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).BenchmarkModel = (string) content.GetValueForProperty("BenchmarkModel",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).BenchmarkModel, global::System.Convert.ToString);
            }
            if (content.Contains("Submitter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Submitter = (string) content.GetValueForProperty("Submitter",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Submitter, global::System.Convert.ToString);
            }
            if (content.Contains("System"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).System = (string) content.GetValueForProperty("System",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).System, global::System.Convert.ToString);
            }
            if (content.Contains("Throughput"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Throughput = (double?) content.GetValueForProperty("Throughput",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Throughput, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("ThroughputUnit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).ThroughputUnit = (string) content.GetValueForProperty("ThroughputUnit",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).ThroughputUnit, global::System.Convert.ToString);
            }
            if (content.Contains("Software"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Software = (string) content.GetValueForProperty("Software",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Software, global::System.Convert.ToString);
            }
            if (content.Contains("OperatingSystem"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).OperatingSystem = (string) content.GetValueForProperty("OperatingSystem",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).OperatingSystem, global::System.Convert.ToString);
            }
            if (content.Contains("WeightDataType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).WeightDataType = (string) content.GetValueForProperty("WeightDataType",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).WeightDataType, global::System.Convert.ToString);
            }
            if (content.Contains("P99TtftMS"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).P99TtftMS = (double?) content.GetValueForProperty("P99TtftMS",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).P99TtftMS, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("P99TpotMS"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).P99TpotMS = (double?) content.GetValueForProperty("P99TpotMS",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).P99TpotMS, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuBenchmark"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RecommendVMSkuBenchmark(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Level"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Level = (string) content.GetValueForProperty("Level",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Level, global::System.Convert.ToString);
            }
            if (content.Contains("ModelClass"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).ModelClass = (string) content.GetValueForProperty("ModelClass",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).ModelClass, global::System.Convert.ToString);
            }
            if (content.Contains("Scenario"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Scenario = (string) content.GetValueForProperty("Scenario",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Scenario, global::System.Convert.ToString);
            }
            if (content.Contains("SubmitterCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).SubmitterCount = (int) content.GetValueForProperty("SubmitterCount",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).SubmitterCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SubmissionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).SubmissionId = (string) content.GetValueForProperty("SubmissionId",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).SubmissionId, global::System.Convert.ToString);
            }
            if (content.Contains("BenchmarkModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).BenchmarkModel = (string) content.GetValueForProperty("BenchmarkModel",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).BenchmarkModel, global::System.Convert.ToString);
            }
            if (content.Contains("Submitter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Submitter = (string) content.GetValueForProperty("Submitter",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Submitter, global::System.Convert.ToString);
            }
            if (content.Contains("System"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).System = (string) content.GetValueForProperty("System",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).System, global::System.Convert.ToString);
            }
            if (content.Contains("Throughput"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Throughput = (double?) content.GetValueForProperty("Throughput",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Throughput, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("ThroughputUnit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).ThroughputUnit = (string) content.GetValueForProperty("ThroughputUnit",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).ThroughputUnit, global::System.Convert.ToString);
            }
            if (content.Contains("Software"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Software = (string) content.GetValueForProperty("Software",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).Software, global::System.Convert.ToString);
            }
            if (content.Contains("OperatingSystem"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).OperatingSystem = (string) content.GetValueForProperty("OperatingSystem",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).OperatingSystem, global::System.Convert.ToString);
            }
            if (content.Contains("WeightDataType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).WeightDataType = (string) content.GetValueForProperty("WeightDataType",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).WeightDataType, global::System.Convert.ToString);
            }
            if (content.Contains("P99TtftMS"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).P99TtftMS = (double?) content.GetValueForProperty("P99TtftMS",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).P99TtftMS, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("P99TpotMS"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).P99TpotMS = (double?) content.GetValueForProperty("P99TpotMS",((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuBenchmarkInternal)this).P99TpotMS, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
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
    /// The external benchmark evidence selected for one virtual machine size option.
    [System.ComponentModel.TypeConverter(typeof(RecommendVMSkuBenchmarkTypeConverter))]
    public partial interface IRecommendVMSkuBenchmark

    {

    }
}