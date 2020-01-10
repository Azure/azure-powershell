namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>BGP peer status details</summary>
    [System.ComponentModel.TypeConverter(typeof(BgpPeerStatusTypeConverter))]
    public partial class BgpPeerStatus
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpPeerStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal BgpPeerStatus(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).Asn = (int?) content.GetValueForProperty("Asn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).Asn, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).ConnectedDuration = (string) content.GetValueForProperty("ConnectedDuration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).ConnectedDuration, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).LocalAddress = (string) content.GetValueForProperty("LocalAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).LocalAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).MessagesReceived = (long?) content.GetValueForProperty("MessagesReceived",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).MessagesReceived, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).MessagesSent = (long?) content.GetValueForProperty("MessagesSent",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).MessagesSent, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).Neighbor = (string) content.GetValueForProperty("Neighbor",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).Neighbor, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).RoutesReceived = (long?) content.GetValueForProperty("RoutesReceived",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).RoutesReceived, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.BgpPeerState?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.BgpPeerState.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpPeerStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal BgpPeerStatus(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).Asn = (int?) content.GetValueForProperty("Asn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).Asn, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).ConnectedDuration = (string) content.GetValueForProperty("ConnectedDuration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).ConnectedDuration, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).LocalAddress = (string) content.GetValueForProperty("LocalAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).LocalAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).MessagesReceived = (long?) content.GetValueForProperty("MessagesReceived",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).MessagesReceived, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).MessagesSent = (long?) content.GetValueForProperty("MessagesSent",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).MessagesSent, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).Neighbor = (string) content.GetValueForProperty("Neighbor",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).Neighbor, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).RoutesReceived = (long?) content.GetValueForProperty("RoutesReceived",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).RoutesReceived, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.BgpPeerState?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.BgpPeerState.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpPeerStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatus DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new BgpPeerStatus(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpPeerStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatus DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new BgpPeerStatus(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BgpPeerStatus" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatus FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// BGP peer status details
    [System.ComponentModel.TypeConverter(typeof(BgpPeerStatusTypeConverter))]
    public partial interface IBgpPeerStatus

    {

    }
}