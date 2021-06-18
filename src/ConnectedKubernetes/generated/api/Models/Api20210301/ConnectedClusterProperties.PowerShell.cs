namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.PowerShell;

    /// <summary>Properties of the connected cluster.</summary>
    [System.ComponentModel.TypeConverter(typeof(ConnectedClusterPropertiesTypeConverter))]
    public partial class ConnectedClusterProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedClusterProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ConnectedClusterProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).AgentPublicKeyCertificate = (string) content.GetValueForProperty("AgentPublicKeyCertificate",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).AgentPublicKeyCertificate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).ConnectivityStatus = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus?) content.GetValueForProperty("ConnectivityStatus",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).ConnectivityStatus, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).Distribution = (string) content.GetValueForProperty("Distribution",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).Distribution, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).Infrastructure = (string) content.GetValueForProperty("Infrastructure",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).Infrastructure, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).KubernetesVersion = (string) content.GetValueForProperty("KubernetesVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).KubernetesVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).LastConnectivityTime = (global::System.DateTime?) content.GetValueForProperty("LastConnectivityTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).LastConnectivityTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).ManagedIdentityCertificateExpirationTime = (global::System.DateTime?) content.GetValueForProperty("ManagedIdentityCertificateExpirationTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).ManagedIdentityCertificateExpirationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).Offering = (string) content.GetValueForProperty("Offering",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).Offering, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).TotalCoreCount = (int?) content.GetValueForProperty("TotalCoreCount",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).TotalCoreCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).TotalNodeCount = (int?) content.GetValueForProperty("TotalNodeCount",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).TotalNodeCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedClusterProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ConnectedClusterProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).AgentPublicKeyCertificate = (string) content.GetValueForProperty("AgentPublicKeyCertificate",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).AgentPublicKeyCertificate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).ConnectivityStatus = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus?) content.GetValueForProperty("ConnectivityStatus",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).ConnectivityStatus, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).Distribution = (string) content.GetValueForProperty("Distribution",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).Distribution, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).Infrastructure = (string) content.GetValueForProperty("Infrastructure",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).Infrastructure, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).KubernetesVersion = (string) content.GetValueForProperty("KubernetesVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).KubernetesVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).LastConnectivityTime = (global::System.DateTime?) content.GetValueForProperty("LastConnectivityTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).LastConnectivityTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).ManagedIdentityCertificateExpirationTime = (global::System.DateTime?) content.GetValueForProperty("ManagedIdentityCertificateExpirationTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).ManagedIdentityCertificateExpirationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).Offering = (string) content.GetValueForProperty("Offering",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).Offering, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).TotalCoreCount = (int?) content.GetValueForProperty("TotalCoreCount",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).TotalCoreCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).TotalNodeCount = (int?) content.GetValueForProperty("TotalNodeCount",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)this).TotalNodeCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedClusterProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ConnectedClusterProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedClusterProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ConnectedClusterProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConnectedClusterProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of the connected cluster.
    [System.ComponentModel.TypeConverter(typeof(ConnectedClusterPropertiesTypeConverter))]
    public partial interface IConnectedClusterProperties

    {

    }
}