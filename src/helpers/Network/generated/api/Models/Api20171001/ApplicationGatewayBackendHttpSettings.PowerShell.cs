namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Backend address pool settings of an application gateway.</summary>
    [System.ComponentModel.TypeConverter(typeof(ApplicationGatewayBackendHttpSettingsTypeConverter))]
    public partial class ApplicationGatewayBackendHttpSettings
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayBackendHttpSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ApplicationGatewayBackendHttpSettings(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayBackendHttpSettingsPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Port = (int?) content.GetValueForProperty("Port",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Port, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ConnectionDraining = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDraining) content.GetValueForProperty("ConnectionDraining",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ConnectionDraining, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayConnectionDrainingTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Path = (string) content.GetValueForProperty("Path",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Path, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).AffinityCookieName = (string) content.GetValueForProperty("AffinityCookieName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).AffinityCookieName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).AuthenticationCertificate = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[]) content.GetValueForProperty("AuthenticationCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).AuthenticationCertificate, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).CookieBasedAffinity = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity?) content.GetValueForProperty("CookieBasedAffinity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).CookieBasedAffinity, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).HostName = (string) content.GetValueForProperty("HostName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).HostName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).PickHostNameFromBackendAddress = (bool?) content.GetValueForProperty("PickHostNameFromBackendAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).PickHostNameFromBackendAddress, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Probe = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) content.GetValueForProperty("Probe",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Probe, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ProbeEnabled = (bool?) content.GetValueForProperty("ProbeEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ProbeEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).RequestTimeout = (int?) content.GetValueForProperty("RequestTimeout",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).RequestTimeout, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol?) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ConnectionDrainingDrainTimeoutInSec = (int) content.GetValueForProperty("ConnectionDrainingDrainTimeoutInSec",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ConnectionDrainingDrainTimeoutInSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ConnectionDrainingEnabled = (bool) content.GetValueForProperty("ConnectionDrainingEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ConnectionDrainingEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ProbeId = (string) content.GetValueForProperty("ProbeId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ProbeId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayBackendHttpSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ApplicationGatewayBackendHttpSettings(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayBackendHttpSettingsPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Port = (int?) content.GetValueForProperty("Port",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Port, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ConnectionDraining = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDraining) content.GetValueForProperty("ConnectionDraining",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ConnectionDraining, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayConnectionDrainingTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Path = (string) content.GetValueForProperty("Path",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Path, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).AffinityCookieName = (string) content.GetValueForProperty("AffinityCookieName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).AffinityCookieName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).AuthenticationCertificate = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[]) content.GetValueForProperty("AuthenticationCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).AuthenticationCertificate, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).CookieBasedAffinity = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity?) content.GetValueForProperty("CookieBasedAffinity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).CookieBasedAffinity, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).HostName = (string) content.GetValueForProperty("HostName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).HostName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).PickHostNameFromBackendAddress = (bool?) content.GetValueForProperty("PickHostNameFromBackendAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).PickHostNameFromBackendAddress, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Probe = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) content.GetValueForProperty("Probe",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Probe, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ProbeEnabled = (bool?) content.GetValueForProperty("ProbeEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ProbeEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).RequestTimeout = (int?) content.GetValueForProperty("RequestTimeout",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).RequestTimeout, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol?) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ConnectionDrainingDrainTimeoutInSec = (int) content.GetValueForProperty("ConnectionDrainingDrainTimeoutInSec",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ConnectionDrainingDrainTimeoutInSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ConnectionDrainingEnabled = (bool) content.GetValueForProperty("ConnectionDrainingEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ConnectionDrainingEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ProbeId = (string) content.GetValueForProperty("ProbeId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal)this).ProbeId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayBackendHttpSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettings"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettings DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ApplicationGatewayBackendHttpSettings(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayBackendHttpSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettings"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettings DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ApplicationGatewayBackendHttpSettings(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApplicationGatewayBackendHttpSettings" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettings FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Backend address pool settings of an application gateway.
    [System.ComponentModel.TypeConverter(typeof(ApplicationGatewayBackendHttpSettingsTypeConverter))]
    public partial interface IApplicationGatewayBackendHttpSettings

    {

    }
}