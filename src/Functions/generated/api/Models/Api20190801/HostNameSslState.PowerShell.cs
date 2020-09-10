namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>SSL-enabled hostname.</summary>
    [System.ComponentModel.TypeConverter(typeof(HostNameSslStateTypeConverter))]
    public partial class HostNameSslState
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostNameSslState"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HostNameSslState(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostNameSslState"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HostNameSslState(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HostNameSslState" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostNameSslState"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HostNameSslState(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).HostType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostType?) content.GetValueForProperty("HostType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).HostType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).SslState = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState?) content.GetValueForProperty("SslState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).SslState, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).Thumbprint = (string) content.GetValueForProperty("Thumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).Thumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).ToUpdate = (bool?) content.GetValueForProperty("ToUpdate",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).ToUpdate, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).VirtualIP = (string) content.GetValueForProperty("VirtualIP",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).VirtualIP, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostNameSslState"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HostNameSslState(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).HostType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostType?) content.GetValueForProperty("HostType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).HostType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).SslState = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState?) content.GetValueForProperty("SslState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).SslState, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).Thumbprint = (string) content.GetValueForProperty("Thumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).Thumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).ToUpdate = (bool?) content.GetValueForProperty("ToUpdate",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).ToUpdate, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).VirtualIP = (string) content.GetValueForProperty("VirtualIP",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslStateInternal)this).VirtualIP, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// SSL-enabled hostname.
    [System.ComponentModel.TypeConverter(typeof(HostNameSslStateTypeConverter))]
    public partial interface IHostNameSslState

    {

    }
}