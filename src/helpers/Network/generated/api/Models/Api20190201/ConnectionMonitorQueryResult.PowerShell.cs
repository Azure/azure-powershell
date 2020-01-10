namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>List of connection states snapshots.</summary>
    [System.ComponentModel.TypeConverter(typeof(ConnectionMonitorQueryResultTypeConverter))]
    public partial class ConnectionMonitorQueryResult
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorQueryResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ConnectionMonitorQueryResult(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResultInternal)this).SourceStatus = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus?) content.GetValueForProperty("SourceStatus",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResultInternal)this).SourceStatus, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResultInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionStateSnapshot[]) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResultInternal)this).State, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionStateSnapshot>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionStateSnapshotTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorQueryResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ConnectionMonitorQueryResult(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResultInternal)this).SourceStatus = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus?) content.GetValueForProperty("SourceStatus",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResultInternal)this).SourceStatus, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResultInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionStateSnapshot[]) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResultInternal)this).State, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionStateSnapshot>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionStateSnapshotTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorQueryResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResult DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ConnectionMonitorQueryResult(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorQueryResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResult DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ConnectionMonitorQueryResult(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConnectionMonitorQueryResult" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResult FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// List of connection states snapshots.
    [System.ComponentModel.TypeConverter(typeof(ConnectionMonitorQueryResultTypeConverter))]
    public partial interface IConnectionMonitorQueryResult

    {

    }
}