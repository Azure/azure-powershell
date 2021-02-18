namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.PowerShell;

    /// <summary>Property of git.</summary>
    [System.ComponentModel.TypeConverter(typeof(ConfigServerGitPropertyTypeConverter))]
    public partial class ConfigServerGitProperty
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ConfigServerGitProperty"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ConfigServerGitProperty(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Repository = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IGitPatternRepository[]) content.GetValueForProperty("Repository",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Repository, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IGitPatternRepository>(__y, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.GitPatternRepositoryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Uri = (string) content.GetValueForProperty("Uri",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Uri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Label = (string) content.GetValueForProperty("Label",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Label, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).SearchPath = (string[]) content.GetValueForProperty("SearchPath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).SearchPath, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Username = (string) content.GetValueForProperty("Username",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Username, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Password = (string) content.GetValueForProperty("Password",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Password, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).HostKey = (string) content.GetValueForProperty("HostKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).HostKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).HostKeyAlgorithm = (string) content.GetValueForProperty("HostKeyAlgorithm",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).HostKeyAlgorithm, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).PrivateKey = (string) content.GetValueForProperty("PrivateKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).PrivateKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).StrictHostKeyChecking = (bool?) content.GetValueForProperty("StrictHostKeyChecking",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).StrictHostKeyChecking, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ConfigServerGitProperty"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ConfigServerGitProperty(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Repository = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IGitPatternRepository[]) content.GetValueForProperty("Repository",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Repository, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IGitPatternRepository>(__y, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.GitPatternRepositoryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Uri = (string) content.GetValueForProperty("Uri",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Uri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Label = (string) content.GetValueForProperty("Label",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Label, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).SearchPath = (string[]) content.GetValueForProperty("SearchPath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).SearchPath, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Username = (string) content.GetValueForProperty("Username",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Username, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Password = (string) content.GetValueForProperty("Password",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).Password, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).HostKey = (string) content.GetValueForProperty("HostKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).HostKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).HostKeyAlgorithm = (string) content.GetValueForProperty("HostKeyAlgorithm",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).HostKeyAlgorithm, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).PrivateKey = (string) content.GetValueForProperty("PrivateKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).PrivateKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).StrictHostKeyChecking = (bool?) content.GetValueForProperty("StrictHostKeyChecking",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitPropertyInternal)this).StrictHostKeyChecking, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ConfigServerGitProperty"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitProperty"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitProperty DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ConfigServerGitProperty(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ConfigServerGitProperty"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitProperty"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitProperty DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ConfigServerGitProperty(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConfigServerGitProperty" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitProperty FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Property of git.
    [System.ComponentModel.TypeConverter(typeof(ConfigServerGitPropertyTypeConverter))]
    public partial interface IConfigServerGitProperty

    {

    }
}