namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.PowerShell;

    /// <summary>A server security alert policy.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServerSecurityAlertPolicyTypeConverter))]
    public partial class ServerSecurityAlertPolicy
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ServerSecurityAlertPolicy"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicy"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicy DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServerSecurityAlertPolicy(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ServerSecurityAlertPolicy"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicy"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicy DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServerSecurityAlertPolicy(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServerSecurityAlertPolicy" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicy FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ServerSecurityAlertPolicy"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServerSecurityAlertPolicy(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.SecurityAlertPolicyPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerSecurityAlertPolicyState) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerSecurityAlertPolicyState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).DisabledAlert = (string[]) content.GetValueForProperty("DisabledAlert",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).DisabledAlert, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).EmailAddress = (string[]) content.GetValueForProperty("EmailAddress",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).EmailAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).EmailAccountAdmin = (bool?) content.GetValueForProperty("EmailAccountAdmin",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).EmailAccountAdmin, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).StorageEndpoint = (string) content.GetValueForProperty("StorageEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).StorageEndpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).StorageAccountAccessKey = (string) content.GetValueForProperty("StorageAccountAccessKey",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).StorageAccountAccessKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).RetentionDay = (int?) content.GetValueForProperty("RetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).RetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ServerSecurityAlertPolicy"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServerSecurityAlertPolicy(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.SecurityAlertPolicyPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerSecurityAlertPolicyState) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerSecurityAlertPolicyState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).DisabledAlert = (string[]) content.GetValueForProperty("DisabledAlert",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).DisabledAlert, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).EmailAddress = (string[]) content.GetValueForProperty("EmailAddress",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).EmailAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).EmailAccountAdmin = (bool?) content.GetValueForProperty("EmailAccountAdmin",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).EmailAccountAdmin, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).StorageEndpoint = (string) content.GetValueForProperty("StorageEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).StorageEndpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).StorageAccountAccessKey = (string) content.GetValueForProperty("StorageAccountAccessKey",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).StorageAccountAccessKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).RetentionDay = (int?) content.GetValueForProperty("RetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerSecurityAlertPolicyInternal)this).RetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A server security alert policy.
    [System.ComponentModel.TypeConverter(typeof(ServerSecurityAlertPolicyTypeConverter))]
    public partial interface IServerSecurityAlertPolicy

    {

    }
}