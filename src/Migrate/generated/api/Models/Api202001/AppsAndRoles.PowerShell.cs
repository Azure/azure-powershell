namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>AppsAndRoles in the guest virtual machine.</summary>
    [System.ComponentModel.TypeConverter(typeof(AppsAndRolesTypeConverter))]
    public partial class AppsAndRoles
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.AppsAndRoles"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AppsAndRoles(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).Application = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[]) content.GetValueForProperty("Application",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).Application, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ApplicationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).WebApplication = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[]) content.GetValueForProperty("WebApplication",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).WebApplication, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.WebApplicationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).Feature = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[]) content.GetValueForProperty("Feature",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).Feature, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.FeatureTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).SqlServer = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[]) content.GetValueForProperty("SqlServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).SqlServer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SqlServerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).SharePointServer = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[]) content.GetValueForProperty("SharePointServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).SharePointServer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SharePointServerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).SystemCenter = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[]) content.GetValueForProperty("SystemCenter",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).SystemCenter, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SystemCenterTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).BizTalkServer = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[]) content.GetValueForProperty("BizTalkServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).BizTalkServer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.BizTalkServerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).ExchangeServer = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[]) content.GetValueForProperty("ExchangeServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).ExchangeServer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ExchangeServerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).OtherDatabase = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[]) content.GetValueForProperty("OtherDatabase",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).OtherDatabase, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.OtherDatabaseTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.AppsAndRoles"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AppsAndRoles(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).Application = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[]) content.GetValueForProperty("Application",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).Application, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ApplicationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).WebApplication = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[]) content.GetValueForProperty("WebApplication",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).WebApplication, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.WebApplicationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).Feature = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[]) content.GetValueForProperty("Feature",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).Feature, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.FeatureTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).SqlServer = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[]) content.GetValueForProperty("SqlServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).SqlServer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SqlServerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).SharePointServer = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[]) content.GetValueForProperty("SharePointServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).SharePointServer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SharePointServerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).SystemCenter = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[]) content.GetValueForProperty("SystemCenter",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).SystemCenter, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SystemCenterTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).BizTalkServer = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[]) content.GetValueForProperty("BizTalkServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).BizTalkServer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.BizTalkServerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).ExchangeServer = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[]) content.GetValueForProperty("ExchangeServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).ExchangeServer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ExchangeServerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).OtherDatabase = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[]) content.GetValueForProperty("OtherDatabase",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)this).OtherDatabase, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.OtherDatabaseTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.AppsAndRoles"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AppsAndRoles(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.AppsAndRoles"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AppsAndRoles(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AppsAndRoles" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// AppsAndRoles in the guest virtual machine.
    [System.ComponentModel.TypeConverter(typeof(AppsAndRolesTypeConverter))]
    public partial interface IAppsAndRoles

    {

    }
}