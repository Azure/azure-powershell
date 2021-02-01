namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell;

    /// <summary>Request parameters for creating a new service principal.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServicePrincipalCreateParametersTypeConverter))]
    public partial class ServicePrincipalCreateParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ServicePrincipalCreateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalCreateParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalCreateParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServicePrincipalCreateParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ServicePrincipalCreateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalCreateParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalCreateParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServicePrincipalCreateParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServicePrincipalCreateParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalCreateParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ServicePrincipalCreateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServicePrincipalCreateParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalCreateParametersInternal)this).AppId = (string) content.GetValueForProperty("AppId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalCreateParametersInternal)this).AppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).AccountEnabled = (bool?) content.GetValueForProperty("AccountEnabled",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).AccountEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).AppRoleAssignmentRequired = (bool?) content.GetValueForProperty("AppRoleAssignmentRequired",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).AppRoleAssignmentRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).KeyCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]) content.GetValueForProperty("KeyCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).KeyCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.KeyCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).PasswordCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]) content.GetValueForProperty("PasswordCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).PasswordCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).ServicePrincipalType = (string) content.GetValueForProperty("ServicePrincipalType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).ServicePrincipalType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).Tag = (string[]) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).Tag, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ServicePrincipalCreateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServicePrincipalCreateParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalCreateParametersInternal)this).AppId = (string) content.GetValueForProperty("AppId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalCreateParametersInternal)this).AppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).AccountEnabled = (bool?) content.GetValueForProperty("AccountEnabled",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).AccountEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).AppRoleAssignmentRequired = (bool?) content.GetValueForProperty("AppRoleAssignmentRequired",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).AppRoleAssignmentRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).KeyCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]) content.GetValueForProperty("KeyCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).KeyCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.KeyCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).PasswordCredentials = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]) content.GetValueForProperty("PasswordCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).PasswordCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).ServicePrincipalType = (string) content.GetValueForProperty("ServicePrincipalType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).ServicePrincipalType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).Tag = (string[]) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)this).Tag, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Request parameters for creating a new service principal.
    [System.ComponentModel.TypeConverter(typeof(ServicePrincipalCreateParametersTypeConverter))]
    public partial interface IServicePrincipalCreateParameters

    {

    }
}