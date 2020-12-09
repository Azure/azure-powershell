namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.PowerShell;

    /// <summary>Custom Parameters used for Cluster Creation.</summary>
    [System.ComponentModel.TypeConverter(typeof(WorkspaceCustomParametersTypeConverter))]
    public partial class WorkspaceCustomParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new WorkspaceCustomParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new WorkspaceCustomParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="WorkspaceCustomParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal WorkspaceCustomParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).AmlWorkspaceId = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter) content.GetValueForProperty("AmlWorkspaceId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).AmlWorkspaceId, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomVirtualNetworkId = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter) content.GetValueForProperty("CustomVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomVirtualNetworkId, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPublicSubnetName = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter) content.GetValueForProperty("CustomPublicSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPublicSubnetName, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPrivateSubnetName = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter) content.GetValueForProperty("CustomPrivateSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPrivateSubnetName, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EnableNoPublicIP = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter) content.GetValueForProperty("EnableNoPublicIP",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EnableNoPublicIP, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).PrepareEncryption = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter) content.GetValueForProperty("PrepareEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).PrepareEncryption, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).Encryption = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameter) content.GetValueForProperty("Encryption",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).Encryption, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceEncryptionParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).RequireInfrastructureEncryption = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter) content.GetValueForProperty("RequireInfrastructureEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).RequireInfrastructureEncryption, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EncryptionValue = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryption) content.GetValueForProperty("EncryptionValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EncryptionValue, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.EncryptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).PrepareEncryptionType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("PrepareEncryptionType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).PrepareEncryptionType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomVirtualNetworkIdType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("CustomVirtualNetworkIdType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomVirtualNetworkIdType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomVirtualNetworkIdValue = (string) content.GetValueForProperty("CustomVirtualNetworkIdValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomVirtualNetworkIdValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPublicSubnetNameType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("CustomPublicSubnetNameType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPublicSubnetNameType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPublicSubnetNameValue = (string) content.GetValueForProperty("CustomPublicSubnetNameValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPublicSubnetNameValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPrivateSubnetNameType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("CustomPrivateSubnetNameType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPrivateSubnetNameType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPrivateSubnetNameValue = (string) content.GetValueForProperty("CustomPrivateSubnetNameValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPrivateSubnetNameValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EnableNoPublicIPType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("EnableNoPublicIPType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EnableNoPublicIPType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EnableNoPublicIPValue = (bool) content.GetValueForProperty("EnableNoPublicIPValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EnableNoPublicIPValue, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).AmlWorkspaceIdValue = (string) content.GetValueForProperty("AmlWorkspaceIdValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).AmlWorkspaceIdValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).PrepareEncryptionValue = (bool) content.GetValueForProperty("PrepareEncryptionValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).PrepareEncryptionValue, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).AmlWorkspaceIdType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("AmlWorkspaceIdType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).AmlWorkspaceIdType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EncryptionType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("EncryptionType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EncryptionType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeySource = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource?) content.GetValueForProperty("ValueKeySource",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeySource, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeyVersion = (string) content.GetValueForProperty("ValueKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).RequireInfrastructureEncryptionType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("RequireInfrastructureEncryptionType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).RequireInfrastructureEncryptionType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).RequireInfrastructureEncryptionValue = (bool) content.GetValueForProperty("RequireInfrastructureEncryptionValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).RequireInfrastructureEncryptionValue, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeyVaultUri = (string) content.GetValueForProperty("ValueKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeyName = (string) content.GetValueForProperty("ValueKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeyName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal WorkspaceCustomParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).AmlWorkspaceId = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter) content.GetValueForProperty("AmlWorkspaceId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).AmlWorkspaceId, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomVirtualNetworkId = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter) content.GetValueForProperty("CustomVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomVirtualNetworkId, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPublicSubnetName = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter) content.GetValueForProperty("CustomPublicSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPublicSubnetName, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPrivateSubnetName = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter) content.GetValueForProperty("CustomPrivateSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPrivateSubnetName, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EnableNoPublicIP = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter) content.GetValueForProperty("EnableNoPublicIP",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EnableNoPublicIP, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).PrepareEncryption = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter) content.GetValueForProperty("PrepareEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).PrepareEncryption, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).Encryption = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameter) content.GetValueForProperty("Encryption",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).Encryption, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceEncryptionParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).RequireInfrastructureEncryption = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter) content.GetValueForProperty("RequireInfrastructureEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).RequireInfrastructureEncryption, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EncryptionValue = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryption) content.GetValueForProperty("EncryptionValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EncryptionValue, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.EncryptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).PrepareEncryptionType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("PrepareEncryptionType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).PrepareEncryptionType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomVirtualNetworkIdType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("CustomVirtualNetworkIdType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomVirtualNetworkIdType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomVirtualNetworkIdValue = (string) content.GetValueForProperty("CustomVirtualNetworkIdValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomVirtualNetworkIdValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPublicSubnetNameType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("CustomPublicSubnetNameType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPublicSubnetNameType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPublicSubnetNameValue = (string) content.GetValueForProperty("CustomPublicSubnetNameValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPublicSubnetNameValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPrivateSubnetNameType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("CustomPrivateSubnetNameType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPrivateSubnetNameType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPrivateSubnetNameValue = (string) content.GetValueForProperty("CustomPrivateSubnetNameValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).CustomPrivateSubnetNameValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EnableNoPublicIPType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("EnableNoPublicIPType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EnableNoPublicIPType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EnableNoPublicIPValue = (bool) content.GetValueForProperty("EnableNoPublicIPValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EnableNoPublicIPValue, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).AmlWorkspaceIdValue = (string) content.GetValueForProperty("AmlWorkspaceIdValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).AmlWorkspaceIdValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).PrepareEncryptionValue = (bool) content.GetValueForProperty("PrepareEncryptionValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).PrepareEncryptionValue, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).AmlWorkspaceIdType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("AmlWorkspaceIdType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).AmlWorkspaceIdType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EncryptionType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("EncryptionType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).EncryptionType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeySource = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource?) content.GetValueForProperty("ValueKeySource",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeySource, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeyVersion = (string) content.GetValueForProperty("ValueKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).RequireInfrastructureEncryptionType = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType?) content.GetValueForProperty("RequireInfrastructureEncryptionType",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).RequireInfrastructureEncryptionType, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).RequireInfrastructureEncryptionValue = (bool) content.GetValueForProperty("RequireInfrastructureEncryptionValue",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).RequireInfrastructureEncryptionValue, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeyVaultUri = (string) content.GetValueForProperty("ValueKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeyName = (string) content.GetValueForProperty("ValueKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)this).ValueKeyName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Custom Parameters used for Cluster Creation.
    [System.ComponentModel.TypeConverter(typeof(WorkspaceCustomParametersTypeConverter))]
    public partial interface IWorkspaceCustomParameters

    {

    }
}