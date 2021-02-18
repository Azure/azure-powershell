namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>ARM resource for a static site when patching</summary>
    [System.ComponentModel.TypeConverter(typeof(StaticSitePatchResourceTypeConverter))]
    public partial class StaticSitePatchResource
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSitePatchResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResource DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new StaticSitePatchResource(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSitePatchResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResource DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new StaticSitePatchResource(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="StaticSitePatchResource" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResource FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSitePatchResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal StaticSitePatchResource(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSite) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteBuildProperties) content.GetValueForProperty("BuildProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteBuildPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).DefaultHostname = (string) content.GetValueForProperty("DefaultHostname",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).DefaultHostname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).Branch = (string) content.GetValueForProperty("Branch",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).Branch, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).CustomDomain = (string[]) content.GetValueForProperty("CustomDomain",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).CustomDomain, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).RepositoryToken = (string) content.GetValueForProperty("RepositoryToken",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).RepositoryToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildPropertyAppLocation = (string) content.GetValueForProperty("BuildPropertyAppLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildPropertyAppLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildPropertyApiLocation = (string) content.GetValueForProperty("BuildPropertyApiLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildPropertyApiLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildPropertyAppArtifactLocation = (string) content.GetValueForProperty("BuildPropertyAppArtifactLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildPropertyAppArtifactLocation, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSitePatchResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal StaticSitePatchResource(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSite) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteBuildProperties) content.GetValueForProperty("BuildProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteBuildPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).DefaultHostname = (string) content.GetValueForProperty("DefaultHostname",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).DefaultHostname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).Branch = (string) content.GetValueForProperty("Branch",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).Branch, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).CustomDomain = (string[]) content.GetValueForProperty("CustomDomain",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).CustomDomain, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).RepositoryToken = (string) content.GetValueForProperty("RepositoryToken",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).RepositoryToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildPropertyAppLocation = (string) content.GetValueForProperty("BuildPropertyAppLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildPropertyAppLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildPropertyApiLocation = (string) content.GetValueForProperty("BuildPropertyApiLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildPropertyApiLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildPropertyAppArtifactLocation = (string) content.GetValueForProperty("BuildPropertyAppArtifactLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSitePatchResourceInternal)this).BuildPropertyAppArtifactLocation, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// ARM resource for a static site when patching
    [System.ComponentModel.TypeConverter(typeof(StaticSitePatchResourceTypeConverter))]
    public partial interface IStaticSitePatchResource

    {

    }
}