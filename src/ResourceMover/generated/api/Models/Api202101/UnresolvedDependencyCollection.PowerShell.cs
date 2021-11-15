namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.PowerShell;

    /// <summary>Unresolved dependency collection.</summary>
    [System.ComponentModel.TypeConverter(typeof(UnresolvedDependencyCollectionTypeConverter))]
    public partial class UnresolvedDependencyCollection
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UnresolvedDependencyCollection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollection"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollection DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new UnresolvedDependencyCollection(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UnresolvedDependencyCollection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollection"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollection DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new UnresolvedDependencyCollection(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UnresolvedDependencyCollection" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollection FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UnresolvedDependencyCollection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal UnresolvedDependencyCollection(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).SummaryCollection = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollection) content.GetValueForProperty("SummaryCollection",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).SummaryCollection, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.SummaryCollectionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).Value = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependency[]) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).Value, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependency>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UnresolvedDependencyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).NextLink = (string) content.GetValueForProperty("NextLink",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).NextLink, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).TotalCount = (long?) content.GetValueForProperty("TotalCount",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).TotalCount, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).SummaryCollectionFieldName = (string) content.GetValueForProperty("SummaryCollectionFieldName",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).SummaryCollectionFieldName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).SummaryCollectionSummary = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary[]) content.GetValueForProperty("SummaryCollectionSummary",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).SummaryCollectionSummary, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.SummaryTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UnresolvedDependencyCollection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal UnresolvedDependencyCollection(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).SummaryCollection = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollection) content.GetValueForProperty("SummaryCollection",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).SummaryCollection, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.SummaryCollectionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).Value = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependency[]) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).Value, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependency>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UnresolvedDependencyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).NextLink = (string) content.GetValueForProperty("NextLink",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).NextLink, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).TotalCount = (long?) content.GetValueForProperty("TotalCount",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).TotalCount, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).SummaryCollectionFieldName = (string) content.GetValueForProperty("SummaryCollectionFieldName",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).SummaryCollectionFieldName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).SummaryCollectionSummary = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary[]) content.GetValueForProperty("SummaryCollectionSummary",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal)this).SummaryCollectionSummary, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.SummaryTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }
    }
    /// Unresolved dependency collection.
    [System.ComponentModel.TypeConverter(typeof(UnresolvedDependencyCollectionTypeConverter))]
    public partial interface IUnresolvedDependencyCollection

    {

    }
}