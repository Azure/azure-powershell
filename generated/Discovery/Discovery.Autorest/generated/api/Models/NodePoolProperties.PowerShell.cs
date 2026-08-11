// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.PowerShell;

    /// <summary>NodePool properties</summary>
    [System.ComponentModel.TypeConverter(typeof(NodePoolPropertiesTypeConverter))]
    public partial class NodePoolProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.NodePoolProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NodePoolProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.NodePoolProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NodePoolProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NodePoolProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="NodePoolProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.NodePoolProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NodePoolProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("SubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).SubnetId = (string) content.GetValueForProperty("SubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).SubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("VMSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).VMSize = (string) content.GetValueForProperty("VMSize",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).VMSize, global::System.Convert.ToString);
            }
            if (content.Contains("MaxNodeCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).MaxNodeCount = (int) content.GetValueForProperty("MaxNodeCount",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).MaxNodeCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MinNodeCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).MinNodeCount = (int?) content.GetValueForProperty("MinNodeCount",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).MinNodeCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ScaleSetPriority"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ScaleSetPriority = (string) content.GetValueForProperty("ScaleSetPriority",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ScaleSetPriority, global::System.Convert.ToString);
            }
            if (content.Contains("OSDiskSizeGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).OSDiskSizeGb = (int?) content.GetValueForProperty("OSDiskSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).OSDiskSizeGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ImageCacheLowerThreshold"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ImageCacheLowerThreshold = (int?) content.GetValueForProperty("ImageCacheLowerThreshold",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ImageCacheLowerThreshold, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ImageCacheUpperThreshold"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ImageCacheUpperThreshold = (int?) content.GetValueForProperty("ImageCacheUpperThreshold",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ImageCacheUpperThreshold, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.NodePoolProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NodePoolProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("SubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).SubnetId = (string) content.GetValueForProperty("SubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).SubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("VMSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).VMSize = (string) content.GetValueForProperty("VMSize",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).VMSize, global::System.Convert.ToString);
            }
            if (content.Contains("MaxNodeCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).MaxNodeCount = (int) content.GetValueForProperty("MaxNodeCount",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).MaxNodeCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MinNodeCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).MinNodeCount = (int?) content.GetValueForProperty("MinNodeCount",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).MinNodeCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ScaleSetPriority"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ScaleSetPriority = (string) content.GetValueForProperty("ScaleSetPriority",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ScaleSetPriority, global::System.Convert.ToString);
            }
            if (content.Contains("OSDiskSizeGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).OSDiskSizeGb = (int?) content.GetValueForProperty("OSDiskSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).OSDiskSizeGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ImageCacheLowerThreshold"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ImageCacheLowerThreshold = (int?) content.GetValueForProperty("ImageCacheLowerThreshold",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ImageCacheLowerThreshold, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ImageCacheUpperThreshold"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ImageCacheUpperThreshold = (int?) content.GetValueForProperty("ImageCacheUpperThreshold",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolPropertiesInternal)this).ImageCacheUpperThreshold, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// NodePool properties
    [System.ComponentModel.TypeConverter(typeof(NodePoolPropertiesTypeConverter))]
    public partial interface INodePoolProperties

    {

    }
}