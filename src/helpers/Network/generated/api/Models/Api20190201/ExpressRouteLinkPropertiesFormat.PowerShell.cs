namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Properties specific to ExpressRouteLink resources.</summary>
    [System.ComponentModel.TypeConverter(typeof(ExpressRouteLinkPropertiesFormatTypeConverter))]
    public partial class ExpressRouteLinkPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteLinkPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ExpressRouteLinkPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteLinkPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ExpressRouteLinkPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteLinkPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ExpressRouteLinkPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).AdminState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkAdminState?) content.GetValueForProperty("AdminState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).AdminState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkAdminState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).ConnectorType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType?) content.GetValueForProperty("ConnectorType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).ConnectorType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).InterfaceName = (string) content.GetValueForProperty("InterfaceName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).InterfaceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).PatchPanelId = (string) content.GetValueForProperty("PatchPanelId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).PatchPanelId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).RackId = (string) content.GetValueForProperty("RackId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).RackId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).RouterName = (string) content.GetValueForProperty("RouterName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).RouterName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteLinkPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ExpressRouteLinkPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).AdminState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkAdminState?) content.GetValueForProperty("AdminState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).AdminState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkAdminState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).ConnectorType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType?) content.GetValueForProperty("ConnectorType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).ConnectorType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).InterfaceName = (string) content.GetValueForProperty("InterfaceName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).InterfaceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).PatchPanelId = (string) content.GetValueForProperty("PatchPanelId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).PatchPanelId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).RackId = (string) content.GetValueForProperty("RackId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).RackId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).RouterName = (string) content.GetValueForProperty("RouterName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)this).RouterName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExpressRouteLinkPropertiesFormat" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties specific to ExpressRouteLink resources.
    [System.ComponentModel.TypeConverter(typeof(ExpressRouteLinkPropertiesFormatTypeConverter))]
    public partial interface IExpressRouteLinkPropertiesFormat

    {

    }
}