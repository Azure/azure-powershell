// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.PowerShell;

    /// <summary>The offer content</summary>
    [System.ComponentModel.TypeConverter(typeof(OfferContentTypeConverter))]
    public partial class OfferContent
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.OfferContent"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new OfferContent(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.OfferContent"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new OfferContent(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="OfferContent" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="OfferContent" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.OfferContent"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal OfferContent(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("OfferPublisher"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferPublisher = (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPublisher) content.GetValueForProperty("OfferPublisher",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferPublisher, Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.OfferPublisherTypeConverter.ConvertFrom);
            }
            if (content.Contains("IconFileUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUri = (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUris) content.GetValueForProperty("IconFileUri",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUri, Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IconFileUrisTypeConverter.ConvertFrom);
            }
            if (content.Contains("TermsAndCondition"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermsAndCondition = (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditions) content.GetValueForProperty("TermsAndCondition",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermsAndCondition, Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.TermsAndConditionsTypeConverter.ConvertFrom);
            }
            if (content.Contains("DisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).DisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("Summary"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Summary = (string) content.GetValueForProperty("Summary",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Summary, global::System.Convert.ToString);
            }
            if (content.Contains("LongSummary"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).LongSummary = (string) content.GetValueForProperty("LongSummary",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).LongSummary, global::System.Convert.ToString);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Description, global::System.Convert.ToString);
            }
            if (content.Contains("OfferId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferId = (string) content.GetValueForProperty("OfferId",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferId, global::System.Convert.ToString);
            }
            if (content.Contains("OfferType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferType = (string) content.GetValueForProperty("OfferType",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferType, global::System.Convert.ToString);
            }
            if (content.Contains("SupportUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).SupportUri = (string) content.GetValueForProperty("SupportUri",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).SupportUri, global::System.Convert.ToString);
            }
            if (content.Contains("Popularity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Popularity = (int?) content.GetValueForProperty("Popularity",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Popularity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("Availability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Availability = (string) content.GetValueForProperty("Availability",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Availability, global::System.Convert.ToString);
            }
            if (content.Contains("ReleaseType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).ReleaseType = (string) content.GetValueForProperty("ReleaseType",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).ReleaseType, global::System.Convert.ToString);
            }
            if (content.Contains("CategoryId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).CategoryId = (System.Collections.Generic.List<string>) content.GetValueForProperty("CategoryId",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).CategoryId, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("OperatingSystem"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OperatingSystem = (System.Collections.Generic.List<string>) content.GetValueForProperty("OperatingSystem",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OperatingSystem, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("OfferPublisherId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferPublisherId = (string) content.GetValueForProperty("OfferPublisherId",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferPublisherId, global::System.Convert.ToString);
            }
            if (content.Contains("OfferPublisherDisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferPublisherDisplayName = (string) content.GetValueForProperty("OfferPublisherDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferPublisherDisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("IconFileUriSmall"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriSmall = (string) content.GetValueForProperty("IconFileUriSmall",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriSmall, global::System.Convert.ToString);
            }
            if (content.Contains("IconFileUriMedium"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriMedium = (string) content.GetValueForProperty("IconFileUriMedium",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriMedium, global::System.Convert.ToString);
            }
            if (content.Contains("IconFileUriWide"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriWide = (string) content.GetValueForProperty("IconFileUriWide",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriWide, global::System.Convert.ToString);
            }
            if (content.Contains("IconFileUriLarge"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriLarge = (string) content.GetValueForProperty("IconFileUriLarge",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriLarge, global::System.Convert.ToString);
            }
            if (content.Contains("TermAndConditionLegalTermsUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermAndConditionLegalTermsUri = (string) content.GetValueForProperty("TermAndConditionLegalTermsUri",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermAndConditionLegalTermsUri, global::System.Convert.ToString);
            }
            if (content.Contains("TermAndConditionLegalTermsType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermAndConditionLegalTermsType = (string) content.GetValueForProperty("TermAndConditionLegalTermsType",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermAndConditionLegalTermsType, global::System.Convert.ToString);
            }
            if (content.Contains("TermAndConditionPrivacyPolicyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermAndConditionPrivacyPolicyUri = (string) content.GetValueForProperty("TermAndConditionPrivacyPolicyUri",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermAndConditionPrivacyPolicyUri, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.OfferContent"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal OfferContent(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("OfferPublisher"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferPublisher = (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPublisher) content.GetValueForProperty("OfferPublisher",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferPublisher, Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.OfferPublisherTypeConverter.ConvertFrom);
            }
            if (content.Contains("IconFileUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUri = (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUris) content.GetValueForProperty("IconFileUri",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUri, Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IconFileUrisTypeConverter.ConvertFrom);
            }
            if (content.Contains("TermsAndCondition"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermsAndCondition = (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditions) content.GetValueForProperty("TermsAndCondition",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermsAndCondition, Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.TermsAndConditionsTypeConverter.ConvertFrom);
            }
            if (content.Contains("DisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).DisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("Summary"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Summary = (string) content.GetValueForProperty("Summary",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Summary, global::System.Convert.ToString);
            }
            if (content.Contains("LongSummary"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).LongSummary = (string) content.GetValueForProperty("LongSummary",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).LongSummary, global::System.Convert.ToString);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Description, global::System.Convert.ToString);
            }
            if (content.Contains("OfferId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferId = (string) content.GetValueForProperty("OfferId",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferId, global::System.Convert.ToString);
            }
            if (content.Contains("OfferType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferType = (string) content.GetValueForProperty("OfferType",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferType, global::System.Convert.ToString);
            }
            if (content.Contains("SupportUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).SupportUri = (string) content.GetValueForProperty("SupportUri",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).SupportUri, global::System.Convert.ToString);
            }
            if (content.Contains("Popularity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Popularity = (int?) content.GetValueForProperty("Popularity",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Popularity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("Availability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Availability = (string) content.GetValueForProperty("Availability",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).Availability, global::System.Convert.ToString);
            }
            if (content.Contains("ReleaseType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).ReleaseType = (string) content.GetValueForProperty("ReleaseType",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).ReleaseType, global::System.Convert.ToString);
            }
            if (content.Contains("CategoryId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).CategoryId = (System.Collections.Generic.List<string>) content.GetValueForProperty("CategoryId",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).CategoryId, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("OperatingSystem"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OperatingSystem = (System.Collections.Generic.List<string>) content.GetValueForProperty("OperatingSystem",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OperatingSystem, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("OfferPublisherId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferPublisherId = (string) content.GetValueForProperty("OfferPublisherId",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferPublisherId, global::System.Convert.ToString);
            }
            if (content.Contains("OfferPublisherDisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferPublisherDisplayName = (string) content.GetValueForProperty("OfferPublisherDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).OfferPublisherDisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("IconFileUriSmall"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriSmall = (string) content.GetValueForProperty("IconFileUriSmall",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriSmall, global::System.Convert.ToString);
            }
            if (content.Contains("IconFileUriMedium"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriMedium = (string) content.GetValueForProperty("IconFileUriMedium",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriMedium, global::System.Convert.ToString);
            }
            if (content.Contains("IconFileUriWide"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriWide = (string) content.GetValueForProperty("IconFileUriWide",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriWide, global::System.Convert.ToString);
            }
            if (content.Contains("IconFileUriLarge"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriLarge = (string) content.GetValueForProperty("IconFileUriLarge",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).IconFileUriLarge, global::System.Convert.ToString);
            }
            if (content.Contains("TermAndConditionLegalTermsUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermAndConditionLegalTermsUri = (string) content.GetValueForProperty("TermAndConditionLegalTermsUri",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermAndConditionLegalTermsUri, global::System.Convert.ToString);
            }
            if (content.Contains("TermAndConditionLegalTermsType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermAndConditionLegalTermsType = (string) content.GetValueForProperty("TermAndConditionLegalTermsType",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermAndConditionLegalTermsType, global::System.Convert.ToString);
            }
            if (content.Contains("TermAndConditionPrivacyPolicyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermAndConditionPrivacyPolicyUri = (string) content.GetValueForProperty("TermAndConditionPrivacyPolicyUri",((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal)this).TermAndConditionPrivacyPolicyUri, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// The offer content
    [System.ComponentModel.TypeConverter(typeof(OfferContentTypeConverter))]
    public partial interface IOfferContent

    {

    }
}