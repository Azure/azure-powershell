namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.PowerShell;

    /// <summary>A streaming job.</summary>
    [System.ComponentModel.TypeConverter(typeof(ClusterJobTypeConverter))]
    public partial class ClusterJob
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ClusterJob"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ClusterJob(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal)this).StreamingUnit = (int?) content.GetValueForProperty("StreamingUnit",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal)this).StreamingUnit, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal)this).JobState = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobState?) content.GetValueForProperty("JobState",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal)this).JobState, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobState.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ClusterJob"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ClusterJob(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal)this).StreamingUnit = (int?) content.GetValueForProperty("StreamingUnit",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal)this).StreamingUnit, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal)this).JobState = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobState?) content.GetValueForProperty("JobState",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal)this).JobState, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobState.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ClusterJob"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJob" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJob DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ClusterJob(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ClusterJob"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJob" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJob DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ClusterJob(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ClusterJob" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJob FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A streaming job.
    [System.ComponentModel.TypeConverter(typeof(ClusterJobTypeConverter))]
    public partial interface IClusterJob

    {

    }
}