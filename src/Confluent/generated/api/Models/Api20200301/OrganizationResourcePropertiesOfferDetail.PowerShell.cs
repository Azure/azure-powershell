namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.PowerShell;

    /// <summary>Confluent offer detail</summary>
    [System.ComponentModel.TypeConverter(typeof(OrganizationResourcePropertiesOfferDetailTypeConverter))]
    public partial class OrganizationResourcePropertiesOfferDetail
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OrganizationResourcePropertiesOfferDetail"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesOfferDetail"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesOfferDetail DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new OrganizationResourcePropertiesOfferDetail(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OrganizationResourcePropertiesOfferDetail"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesOfferDetail"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesOfferDetail DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new OrganizationResourcePropertiesOfferDetail(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="OrganizationResourcePropertiesOfferDetail" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesOfferDetail FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OrganizationResourcePropertiesOfferDetail"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal OrganizationResourcePropertiesOfferDetail(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).PublisherId = (string) content.GetValueForProperty("PublisherId",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).PublisherId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).PlanId = (string) content.GetValueForProperty("PlanId",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).PlanId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).PlanName = (string) content.GetValueForProperty("PlanName",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).PlanName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).TermUnit = (string) content.GetValueForProperty("TermUnit",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).TermUnit, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OrganizationResourcePropertiesOfferDetail"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal OrganizationResourcePropertiesOfferDetail(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).PublisherId = (string) content.GetValueForProperty("PublisherId",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).PublisherId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).PlanId = (string) content.GetValueForProperty("PlanId",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).PlanId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).PlanName = (string) content.GetValueForProperty("PlanName",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).PlanName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).TermUnit = (string) content.GetValueForProperty("TermUnit",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).TermUnit, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Confluent offer detail
    [System.ComponentModel.TypeConverter(typeof(OrganizationResourcePropertiesOfferDetailTypeConverter))]
    public partial interface IOrganizationResourcePropertiesOfferDetail

    {

    }
}