namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.PowerShell;

    /// <summary>Specifies the return address information for the job.</summary>
    [System.ComponentModel.TypeConverter(typeof(ReturnAddressTypeConverter))]
    public partial class ReturnAddress
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddress"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ReturnAddress(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddress"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ReturnAddress(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ReturnAddress" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddress FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddress"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ReturnAddress(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).City = (string) content.GetValueForProperty("City",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).City, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).CountryOrRegion = (string) content.GetValueForProperty("CountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).CountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).Email = (string) content.GetValueForProperty("Email",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).Email, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).Phone = (string) content.GetValueForProperty("Phone",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).Phone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).PostalCode = (string) content.GetValueForProperty("PostalCode",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).PostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).RecipientName = (string) content.GetValueForProperty("RecipientName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).RecipientName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).StateOrProvince = (string) content.GetValueForProperty("StateOrProvince",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).StateOrProvince, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).StreetAddress1 = (string) content.GetValueForProperty("StreetAddress1",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).StreetAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).StreetAddress2 = (string) content.GetValueForProperty("StreetAddress2",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).StreetAddress2, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddress"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ReturnAddress(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).City = (string) content.GetValueForProperty("City",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).City, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).CountryOrRegion = (string) content.GetValueForProperty("CountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).CountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).Email = (string) content.GetValueForProperty("Email",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).Email, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).Phone = (string) content.GetValueForProperty("Phone",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).Phone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).PostalCode = (string) content.GetValueForProperty("PostalCode",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).PostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).RecipientName = (string) content.GetValueForProperty("RecipientName",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).RecipientName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).StateOrProvince = (string) content.GetValueForProperty("StateOrProvince",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).StateOrProvince, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).StreetAddress1 = (string) content.GetValueForProperty("StreetAddress1",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).StreetAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).StreetAddress2 = (string) content.GetValueForProperty("StreetAddress2",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnAddressInternal)this).StreetAddress2, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Specifies the return address information for the job.
    [System.ComponentModel.TypeConverter(typeof(ReturnAddressTypeConverter))]
    public partial interface IReturnAddress

    {

    }
}