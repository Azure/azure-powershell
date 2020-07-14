namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.PowerShell;

    /// <summary>Provides information about an Azure data center location.</summary>
    [System.ComponentModel.TypeConverter(typeof(LocationTypeConverter))]
    public partial class Location
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.Location"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocation" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocation DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Location(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.Location"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocation" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocation DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Location(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Location" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocation FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.Location"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Location(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.LocationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).AlternateLocation = (string[]) content.GetValueForProperty("AlternateLocation",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).AlternateLocation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).City = (string) content.GetValueForProperty("City",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).City, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).CountryOrRegion = (string) content.GetValueForProperty("CountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).CountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Phone = (string) content.GetValueForProperty("Phone",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Phone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).PostalCode = (string) content.GetValueForProperty("PostalCode",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).PostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).RecipientName = (string) content.GetValueForProperty("RecipientName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).RecipientName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).StateOrProvince = (string) content.GetValueForProperty("StateOrProvince",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).StateOrProvince, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).StreetAddress1 = (string) content.GetValueForProperty("StreetAddress1",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).StreetAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).StreetAddress2 = (string) content.GetValueForProperty("StreetAddress2",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).StreetAddress2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).SupportedCarrier = (string[]) content.GetValueForProperty("SupportedCarrier",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).SupportedCarrier, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.Location"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Location(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.LocationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).AlternateLocation = (string[]) content.GetValueForProperty("AlternateLocation",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).AlternateLocation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).City = (string) content.GetValueForProperty("City",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).City, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).CountryOrRegion = (string) content.GetValueForProperty("CountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).CountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Phone = (string) content.GetValueForProperty("Phone",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).Phone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).PostalCode = (string) content.GetValueForProperty("PostalCode",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).PostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).RecipientName = (string) content.GetValueForProperty("RecipientName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).RecipientName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).StateOrProvince = (string) content.GetValueForProperty("StateOrProvince",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).StateOrProvince, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).StreetAddress1 = (string) content.GetValueForProperty("StreetAddress1",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).StreetAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).StreetAddress2 = (string) content.GetValueForProperty("StreetAddress2",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).StreetAddress2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).SupportedCarrier = (string[]) content.GetValueForProperty("SupportedCarrier",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationInternal)this).SupportedCarrier, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Provides information about an Azure data center location.
    [System.ComponentModel.TypeConverter(typeof(LocationTypeConverter))]
    public partial interface ILocation

    {

    }
}