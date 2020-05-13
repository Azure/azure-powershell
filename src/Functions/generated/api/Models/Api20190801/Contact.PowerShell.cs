namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>
    /// Contact information for domain registration. If 'Domain Privacy' option is not selected then the contact information is
    /// made publicly available through the Whois
    /// directories as per ICANN requirements.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(ContactTypeConverter))]
    public partial class Contact
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Contact(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailing = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress) content.GetValueForProperty("AddressMailing",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailing, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AddressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Email = (string) content.GetValueForProperty("Email",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Email, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Fax = (string) content.GetValueForProperty("Fax",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Fax, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).JobTitle = (string) content.GetValueForProperty("JobTitle",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).JobTitle, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).NameFirst = (string) content.GetValueForProperty("NameFirst",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).NameFirst, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).NameLast = (string) content.GetValueForProperty("NameLast",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).NameLast, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).NameMiddle = (string) content.GetValueForProperty("NameMiddle",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).NameMiddle, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Organization = (string) content.GetValueForProperty("Organization",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Organization, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Phone = (string) content.GetValueForProperty("Phone",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Phone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingAddress1 = (string) content.GetValueForProperty("AddressMailingAddress1",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingAddress2 = (string) content.GetValueForProperty("AddressMailingAddress2",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingAddress2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingCity = (string) content.GetValueForProperty("AddressMailingCity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingCountry = (string) content.GetValueForProperty("AddressMailingCountry",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingCountry, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingPostalCode = (string) content.GetValueForProperty("AddressMailingPostalCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingPostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingState = (string) content.GetValueForProperty("AddressMailingState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingState, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Contact(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailing = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddress) content.GetValueForProperty("AddressMailing",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailing, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AddressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Email = (string) content.GetValueForProperty("Email",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Email, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Fax = (string) content.GetValueForProperty("Fax",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Fax, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).JobTitle = (string) content.GetValueForProperty("JobTitle",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).JobTitle, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).NameFirst = (string) content.GetValueForProperty("NameFirst",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).NameFirst, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).NameLast = (string) content.GetValueForProperty("NameLast",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).NameLast, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).NameMiddle = (string) content.GetValueForProperty("NameMiddle",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).NameMiddle, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Organization = (string) content.GetValueForProperty("Organization",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Organization, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Phone = (string) content.GetValueForProperty("Phone",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).Phone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingAddress1 = (string) content.GetValueForProperty("AddressMailingAddress1",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingAddress1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingAddress2 = (string) content.GetValueForProperty("AddressMailingAddress2",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingAddress2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingCity = (string) content.GetValueForProperty("AddressMailingCity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingCountry = (string) content.GetValueForProperty("AddressMailingCountry",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingCountry, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingPostalCode = (string) content.GetValueForProperty("AddressMailingPostalCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingPostalCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingState = (string) content.GetValueForProperty("AddressMailingState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContactInternal)this).AddressMailingState, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Contact(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Contact(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Contact" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContact FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Contact information for domain registration. If 'Domain Privacy' option is not selected then the contact information is
    /// made publicly available through the Whois
    /// directories as per ICANN requirements.
    [System.ComponentModel.TypeConverter(typeof(ContactTypeConverter))]
    public partial interface IContact

    {

    }
}