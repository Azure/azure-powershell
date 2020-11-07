namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Class Representing Solution for problems detected.</summary>
    [System.ComponentModel.TypeConverter(typeof(SolutionTypeConverter))]
    public partial class Solution
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Solution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Solution(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Solution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Solution(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Solution" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Solution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Solution(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SolutionType?) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SolutionType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Data = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][]) content.GetValueForProperty("Data",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Data, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]>(__y, __w => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair>(__w, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePairTypeConverter.ConvertFrom)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Id = (double?) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Id, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][]) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Metadata, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]>(__y, __w => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair>(__w, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePairTypeConverter.ConvertFrom)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Order = (double?) content.GetValueForProperty("Order",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Order, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Solution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Solution(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SolutionType?) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SolutionType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Data = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][]) content.GetValueForProperty("Data",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Data, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]>(__y, __w => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair>(__w, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePairTypeConverter.ConvertFrom)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Id = (double?) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Id, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][]) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Metadata, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]>(__y, __w => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair>(__w, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePairTypeConverter.ConvertFrom)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Order = (double?) content.GetValueForProperty("Order",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal)this).Order, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class Representing Solution for problems detected.
    [System.ComponentModel.TypeConverter(typeof(SolutionTypeConverter))]
    public partial interface ISolution

    {

    }
}