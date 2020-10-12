namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.PowerShell;

    /// <summary>Defines NIC IP configuration properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(NicIPConfigurationResourceSettingsTypeConverter))]
    public partial class NicIPConfigurationResourceSettings
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.NicIPConfigurationResourceSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettings"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettings DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NicIPConfigurationResourceSettings(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.NicIPConfigurationResourceSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettings"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettings DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NicIPConfigurationResourceSettings(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NicIPConfigurationResourceSettings" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettings FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.NicIPConfigurationResourceSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NicIPConfigurationResourceSettings(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).Subnet = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetReference) content.GetValueForProperty("Subnet",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).Subnet, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.SubnetReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).LoadBalancerBackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILoadBalancerBackendAddressPoolReference[]) content.GetValueForProperty("LoadBalancerBackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).LoadBalancerBackendAddressPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILoadBalancerBackendAddressPoolReference>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.LoadBalancerBackendAddressPoolReferenceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).Primary = (bool?) content.GetValueForProperty("Primary",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).Primary, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).PrivateIPAddress = (string) content.GetValueForProperty("PrivateIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).PrivateIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).PrivateIPAllocationMethod = (string) content.GetValueForProperty("PrivateIPAllocationMethod",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).PrivateIPAllocationMethod, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).SubnetSourceArmResourceId = (string) content.GetValueForProperty("SubnetSourceArmResourceId",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).SubnetSourceArmResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).SubnetName = (string) content.GetValueForProperty("SubnetName",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).SubnetName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.NicIPConfigurationResourceSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NicIPConfigurationResourceSettings(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).Subnet = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetReference) content.GetValueForProperty("Subnet",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).Subnet, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.SubnetReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).LoadBalancerBackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILoadBalancerBackendAddressPoolReference[]) content.GetValueForProperty("LoadBalancerBackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).LoadBalancerBackendAddressPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILoadBalancerBackendAddressPoolReference>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.LoadBalancerBackendAddressPoolReferenceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).Primary = (bool?) content.GetValueForProperty("Primary",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).Primary, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).PrivateIPAddress = (string) content.GetValueForProperty("PrivateIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).PrivateIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).PrivateIPAllocationMethod = (string) content.GetValueForProperty("PrivateIPAllocationMethod",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).PrivateIPAllocationMethod, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).SubnetSourceArmResourceId = (string) content.GetValueForProperty("SubnetSourceArmResourceId",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).SubnetSourceArmResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).SubnetName = (string) content.GetValueForProperty("SubnetName",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal)this).SubnetName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Defines NIC IP configuration properties.
    [System.ComponentModel.TypeConverter(typeof(NicIPConfigurationResourceSettingsTypeConverter))]
    public partial interface INicIPConfigurationResourceSettings

    {

    }
}