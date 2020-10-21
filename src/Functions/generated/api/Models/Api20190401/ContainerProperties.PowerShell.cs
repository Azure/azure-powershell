namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>The properties of a container.</summary>
    [System.ComponentModel.TypeConverter(typeof(ContainerPropertiesTypeConverter))]
    public partial class ContainerProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ContainerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ContainerProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperties) content.GetValueForProperty("ImmutabilityPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicy, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ImmutabilityPolicyPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LegalHold = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldProperties) content.GetValueForProperty("LegalHold",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LegalHold, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.LegalHoldPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).PublicAccess = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess?) content.GetValueForProperty("PublicAccess",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).PublicAccess, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LastModifiedTime = (global::System.DateTime?) content.GetValueForProperty("LastModifiedTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LastModifiedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LeaseStatus = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus?) content.GetValueForProperty("LeaseStatus",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LeaseStatus, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LeaseState = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState?) content.GetValueForProperty("LeaseState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LeaseState, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LeaseDuration = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration?) content.GetValueForProperty("LeaseDuration",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LeaseDuration, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesMetadata) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).Metadata, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ContainerPropertiesMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).HasLegalHold = (bool?) content.GetValueForProperty("HasLegalHold",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).HasLegalHold, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).HasImmutabilityPolicy = (bool?) content.GetValueForProperty("HasImmutabilityPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).HasImmutabilityPolicy, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicyProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperty) content.GetValueForProperty("ImmutabilityPolicyProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicyProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ImmutabilityPolicyPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicyEtag = (string) content.GetValueForProperty("ImmutabilityPolicyEtag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicyEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicyUpdateHistory = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty[]) content.GetValueForProperty("ImmutabilityPolicyUpdateHistory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicyUpdateHistory, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.UpdateHistoryPropertyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LegalHoldHasLegalHold = (bool?) content.GetValueForProperty("LegalHoldHasLegalHold",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LegalHoldHasLegalHold, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LegalHoldTag = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty[]) content.GetValueForProperty("LegalHoldTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LegalHoldTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.TagPropertyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPeriodSinceCreationInDay = (int) content.GetValueForProperty("ImmutabilityPeriodSinceCreationInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPeriodSinceCreationInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ContainerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ContainerProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperties) content.GetValueForProperty("ImmutabilityPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicy, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ImmutabilityPolicyPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LegalHold = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldProperties) content.GetValueForProperty("LegalHold",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LegalHold, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.LegalHoldPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).PublicAccess = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess?) content.GetValueForProperty("PublicAccess",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).PublicAccess, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LastModifiedTime = (global::System.DateTime?) content.GetValueForProperty("LastModifiedTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LastModifiedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LeaseStatus = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus?) content.GetValueForProperty("LeaseStatus",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LeaseStatus, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LeaseState = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState?) content.GetValueForProperty("LeaseState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LeaseState, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LeaseDuration = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration?) content.GetValueForProperty("LeaseDuration",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LeaseDuration, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesMetadata) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).Metadata, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ContainerPropertiesMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).HasLegalHold = (bool?) content.GetValueForProperty("HasLegalHold",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).HasLegalHold, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).HasImmutabilityPolicy = (bool?) content.GetValueForProperty("HasImmutabilityPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).HasImmutabilityPolicy, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicyProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperty) content.GetValueForProperty("ImmutabilityPolicyProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicyProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ImmutabilityPolicyPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicyEtag = (string) content.GetValueForProperty("ImmutabilityPolicyEtag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicyEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicyUpdateHistory = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty[]) content.GetValueForProperty("ImmutabilityPolicyUpdateHistory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPolicyUpdateHistory, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.UpdateHistoryPropertyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LegalHoldHasLegalHold = (bool?) content.GetValueForProperty("LegalHoldHasLegalHold",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LegalHoldHasLegalHold, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LegalHoldTag = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty[]) content.GetValueForProperty("LegalHoldTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).LegalHoldTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.TagPropertyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPeriodSinceCreationInDay = (int) content.GetValueForProperty("ImmutabilityPeriodSinceCreationInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).ImmutabilityPeriodSinceCreationInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ContainerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ContainerProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ContainerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ContainerProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContainerProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The properties of a container.
    [System.ComponentModel.TypeConverter(typeof(ContainerPropertiesTypeConverter))]
    public partial interface IContainerProperties

    {

    }
}