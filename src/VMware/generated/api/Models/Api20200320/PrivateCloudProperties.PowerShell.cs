namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.PowerShell;

    /// <summary>The properties of a private cloud resource</summary>
    [System.ComponentModel.TypeConverter(typeof(PrivateCloudPropertiesTypeConverter))]
    public partial class PrivateCloudProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.PrivateCloudProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PrivateCloudProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.PrivateCloudProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PrivateCloudProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PrivateCloudProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.PrivateCloudProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PrivateCloudProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).Circuit = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuit) content.GetValueForProperty("Circuit",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).Circuit, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.CircuitTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).Endpoint = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpoints) content.GetValueForProperty("Endpoint",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).Endpoint, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.EndpointsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.PrivateCloudProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.PrivateCloudProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).NetworkBlock = (string) content.GetValueForProperty("NetworkBlock",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).NetworkBlock, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).ManagementNetwork = (string) content.GetValueForProperty("ManagementNetwork",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).ManagementNetwork, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).ProvisioningNetwork = (string) content.GetValueForProperty("ProvisioningNetwork",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).ProvisioningNetwork, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).VmotionNetwork = (string) content.GetValueForProperty("VmotionNetwork",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).VmotionNetwork, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).VcenterPassword = (string) content.GetValueForProperty("VcenterPassword",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).VcenterPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).NsxtPassword = (string) content.GetValueForProperty("NsxtPassword",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).NsxtPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).VcenterCertificateThumbprint = (string) content.GetValueForProperty("VcenterCertificateThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).VcenterCertificateThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).NsxtCertificateThumbprint = (string) content.GetValueForProperty("NsxtCertificateThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).NsxtCertificateThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterHost = (string[]) content.GetValueForProperty("ManagementClusterHost",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterHost, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterSize = (int?) content.GetValueForProperty("ManagementClusterSize",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterSize, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState?) content.GetValueForProperty("ManagementClusterProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterId = (int?) content.GetValueForProperty("ManagementClusterId",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementCluster = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementCluster) content.GetValueForProperty("ManagementCluster",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementCluster, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ManagementClusterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).Internet = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum?) content.GetValueForProperty("Internet",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).Internet, Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).IdentitySource = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource[]) content.GetValueForProperty("IdentitySource",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).IdentitySource, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource>(__y, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IdentitySourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitPrimarySubnet = (string) content.GetValueForProperty("CircuitPrimarySubnet",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitPrimarySubnet, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitSecondarySubnet = (string) content.GetValueForProperty("CircuitSecondarySubnet",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitSecondarySubnet, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).EndpointNsxtManager = (string) content.GetValueForProperty("EndpointNsxtManager",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).EndpointNsxtManager, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).EndpointVcsa = (string) content.GetValueForProperty("EndpointVcsa",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).EndpointVcsa, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitExpressRouteId = (string) content.GetValueForProperty("CircuitExpressRouteId",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitExpressRouteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitExpressRoutePrivatePeeringId = (string) content.GetValueForProperty("CircuitExpressRoutePrivatePeeringId",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitExpressRoutePrivatePeeringId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).EndpointHcxCloudManager = (string) content.GetValueForProperty("EndpointHcxCloudManager",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).EndpointHcxCloudManager, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.PrivateCloudProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PrivateCloudProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).Circuit = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuit) content.GetValueForProperty("Circuit",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).Circuit, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.CircuitTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).Endpoint = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpoints) content.GetValueForProperty("Endpoint",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).Endpoint, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.EndpointsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.PrivateCloudProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.PrivateCloudProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).NetworkBlock = (string) content.GetValueForProperty("NetworkBlock",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).NetworkBlock, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).ManagementNetwork = (string) content.GetValueForProperty("ManagementNetwork",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).ManagementNetwork, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).ProvisioningNetwork = (string) content.GetValueForProperty("ProvisioningNetwork",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).ProvisioningNetwork, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).VmotionNetwork = (string) content.GetValueForProperty("VmotionNetwork",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).VmotionNetwork, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).VcenterPassword = (string) content.GetValueForProperty("VcenterPassword",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).VcenterPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).NsxtPassword = (string) content.GetValueForProperty("NsxtPassword",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).NsxtPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).VcenterCertificateThumbprint = (string) content.GetValueForProperty("VcenterCertificateThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).VcenterCertificateThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).NsxtCertificateThumbprint = (string) content.GetValueForProperty("NsxtCertificateThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).NsxtCertificateThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterHost = (string[]) content.GetValueForProperty("ManagementClusterHost",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterHost, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterSize = (int?) content.GetValueForProperty("ManagementClusterSize",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterSize, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState?) content.GetValueForProperty("ManagementClusterProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterId = (int?) content.GetValueForProperty("ManagementClusterId",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementClusterId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementCluster = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementCluster) content.GetValueForProperty("ManagementCluster",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).ManagementCluster, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ManagementClusterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).Internet = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum?) content.GetValueForProperty("Internet",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).Internet, Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).IdentitySource = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource[]) content.GetValueForProperty("IdentitySource",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)this).IdentitySource, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource>(__y, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IdentitySourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitPrimarySubnet = (string) content.GetValueForProperty("CircuitPrimarySubnet",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitPrimarySubnet, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitSecondarySubnet = (string) content.GetValueForProperty("CircuitSecondarySubnet",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitSecondarySubnet, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).EndpointNsxtManager = (string) content.GetValueForProperty("EndpointNsxtManager",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).EndpointNsxtManager, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).EndpointVcsa = (string) content.GetValueForProperty("EndpointVcsa",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).EndpointVcsa, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitExpressRouteId = (string) content.GetValueForProperty("CircuitExpressRouteId",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitExpressRouteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitExpressRoutePrivatePeeringId = (string) content.GetValueForProperty("CircuitExpressRoutePrivatePeeringId",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).CircuitExpressRoutePrivatePeeringId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).EndpointHcxCloudManager = (string) content.GetValueForProperty("EndpointHcxCloudManager",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal)this).EndpointHcxCloudManager, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The properties of a private cloud resource
    [System.ComponentModel.TypeConverter(typeof(PrivateCloudPropertiesTypeConverter))]
    public partial interface IPrivateCloudProperties

    {

    }
}