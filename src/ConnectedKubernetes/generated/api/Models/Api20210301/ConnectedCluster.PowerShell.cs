namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.PowerShell;

    /// <summary>Represents a connected cluster.</summary>
    [System.ComponentModel.TypeConverter(typeof(ConnectedClusterTypeConverter))]
    public partial class ConnectedCluster
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedCluster"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ConnectedCluster(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedClusterIdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedClusterPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.SystemDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.TrackedResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).ConnectivityStatus = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus?) content.GetValueForProperty("ConnectivityStatus",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).ConnectivityStatus, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).ManagedIdentityCertificateExpirationTime = (global::System.DateTime?) content.GetValueForProperty("ManagedIdentityCertificateExpirationTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).ManagedIdentityCertificateExpirationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ResourceIdentityType) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ResourceIdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Distribution = (string) content.GetValueForProperty("Distribution",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Distribution, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Infrastructure = (string) content.GetValueForProperty("Infrastructure",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Infrastructure, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).KubernetesVersion = (string) content.GetValueForProperty("KubernetesVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).KubernetesVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).LastConnectivityTime = (global::System.DateTime?) content.GetValueForProperty("LastConnectivityTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).LastConnectivityTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Offering = (string) content.GetValueForProperty("Offering",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Offering, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).TotalCoreCount = (int?) content.GetValueForProperty("TotalCoreCount",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).TotalCoreCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).TotalNodeCount = (int?) content.GetValueForProperty("TotalNodeCount",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).TotalNodeCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).AgentPublicKeyCertificate = (string) content.GetValueForProperty("AgentPublicKeyCertificate",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).AgentPublicKeyCertificate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataCreatedByType = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.CreatedByType?) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataCreatedByType, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataLastModifiedByType = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.LastModifiedByType?) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataLastModifiedByType, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.LastModifiedByType.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedCluster"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ConnectedCluster(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedClusterIdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedClusterPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.SystemDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.TrackedResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).ConnectivityStatus = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus?) content.GetValueForProperty("ConnectivityStatus",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).ConnectivityStatus, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).ManagedIdentityCertificateExpirationTime = (global::System.DateTime?) content.GetValueForProperty("ManagedIdentityCertificateExpirationTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).ManagedIdentityCertificateExpirationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ResourceIdentityType) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ResourceIdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Distribution = (string) content.GetValueForProperty("Distribution",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Distribution, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Infrastructure = (string) content.GetValueForProperty("Infrastructure",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Infrastructure, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).KubernetesVersion = (string) content.GetValueForProperty("KubernetesVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).KubernetesVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).LastConnectivityTime = (global::System.DateTime?) content.GetValueForProperty("LastConnectivityTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).LastConnectivityTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Offering = (string) content.GetValueForProperty("Offering",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).Offering, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).TotalCoreCount = (int?) content.GetValueForProperty("TotalCoreCount",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).TotalCoreCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).TotalNodeCount = (int?) content.GetValueForProperty("TotalNodeCount",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).TotalNodeCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).AgentPublicKeyCertificate = (string) content.GetValueForProperty("AgentPublicKeyCertificate",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).AgentPublicKeyCertificate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataCreatedByType = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.CreatedByType?) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataCreatedByType, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataLastModifiedByType = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.LastModifiedByType?) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal)this).SystemDataLastModifiedByType, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.LastModifiedByType.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedCluster"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedCluster"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedCluster DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ConnectedCluster(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedCluster"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedCluster"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedCluster DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ConnectedCluster(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConnectedCluster" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedCluster FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Represents a connected cluster.
    [System.ComponentModel.TypeConverter(typeof(ConnectedClusterTypeConverter))]
    public partial interface IConnectedCluster

    {

    }
}