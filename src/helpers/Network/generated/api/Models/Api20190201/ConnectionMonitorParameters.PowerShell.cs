namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Parameters that define the operation to create a connection monitor.</summary>
    [System.ComponentModel.TypeConverter(typeof(ConnectionMonitorParametersTypeConverter))]
    public partial class ConnectionMonitorParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ConnectionMonitorParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).Destination = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestination) content.GetValueForProperty("Destination",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).Destination, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorDestinationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).Source = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSource) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).Source, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorSourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).AutoStart = (bool?) content.GetValueForProperty("AutoStart",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).AutoStart, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).MonitoringIntervalInSeconds = (int?) content.GetValueForProperty("MonitoringIntervalInSeconds",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).MonitoringIntervalInSeconds, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).DestinationAddress = (string) content.GetValueForProperty("DestinationAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).DestinationAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).DestinationPort = (int?) content.GetValueForProperty("DestinationPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).DestinationPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).DestinationResourceId = (string) content.GetValueForProperty("DestinationResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).DestinationResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).SourcePort = (int?) content.GetValueForProperty("SourcePort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).SourcePort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).SourceResourceId = (string) content.GetValueForProperty("SourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).SourceResourceId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ConnectionMonitorParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).Destination = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorDestination) content.GetValueForProperty("Destination",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).Destination, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorDestinationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).Source = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorSource) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).Source, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorSourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).AutoStart = (bool?) content.GetValueForProperty("AutoStart",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).AutoStart, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).MonitoringIntervalInSeconds = (int?) content.GetValueForProperty("MonitoringIntervalInSeconds",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).MonitoringIntervalInSeconds, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).DestinationAddress = (string) content.GetValueForProperty("DestinationAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).DestinationAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).DestinationPort = (int?) content.GetValueForProperty("DestinationPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).DestinationPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).DestinationResourceId = (string) content.GetValueForProperty("DestinationResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).DestinationResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).SourcePort = (int?) content.GetValueForProperty("SourcePort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).SourcePort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).SourceResourceId = (string) content.GetValueForProperty("SourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParametersInternal)this).SourceResourceId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ConnectionMonitorParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectionMonitorParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ConnectionMonitorParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConnectionMonitorParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Parameters that define the operation to create a connection monitor.
    [System.ComponentModel.TypeConverter(typeof(ConnectionMonitorParametersTypeConverter))]
    public partial interface IConnectionMonitorParameters

    {

    }
}