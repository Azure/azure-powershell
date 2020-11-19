namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Model class for event details of a HyperVReplica E2E event.</summary>
    [System.ComponentModel.TypeConverter(typeof(HyperVReplica2012EventDetailsTypeConverter))]
    public partial class HyperVReplica2012EventDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplica2012EventDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HyperVReplica2012EventDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplica2012EventDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HyperVReplica2012EventDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HyperVReplica2012EventDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplica2012EventDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HyperVReplica2012EventDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).ContainerName = (string) content.GetValueForProperty("ContainerName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).ContainerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).FabricName = (string) content.GetValueForProperty("FabricName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).FabricName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).RemoteContainerName = (string) content.GetValueForProperty("RemoteContainerName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).RemoteContainerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).RemoteFabricName = (string) content.GetValueForProperty("RemoteFabricName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).RemoteFabricName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplica2012EventDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HyperVReplica2012EventDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).ContainerName = (string) content.GetValueForProperty("ContainerName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).ContainerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).FabricName = (string) content.GetValueForProperty("FabricName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).FabricName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).RemoteContainerName = (string) content.GetValueForProperty("RemoteContainerName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).RemoteContainerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).RemoteFabricName = (string) content.GetValueForProperty("RemoteFabricName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012EventDetailsInternal)this).RemoteFabricName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Model class for event details of a HyperVReplica E2E event.
    [System.ComponentModel.TypeConverter(typeof(HyperVReplica2012EventDetailsTypeConverter))]
    public partial interface IHyperVReplica2012EventDetails

    {

    }
}