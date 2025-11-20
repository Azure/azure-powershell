// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.PowerShell;

    /// <summary>The image download properties</summary>
    [System.ComponentModel.TypeConverter(typeof(ImageDownloadResultTypeConverter))]
    public partial class ImageDownloadResult
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ImageDownloadResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ImageDownloadResult(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ImageDownloadResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ImageDownloadResult(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ImageDownloadResult" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="ImageDownloadResult" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ImageDownloadResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ImageDownloadResult(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("ReleaseVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseVersion = (string) content.GetValueForProperty("ReleaseVersion",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ReleaseDisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseDisplayName = (string) content.GetValueForProperty("ReleaseDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseDisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("ReleaseNote"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseNote = (string) content.GetValueForProperty("ReleaseNote",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseNote, global::System.Convert.ToString);
            }
            if (content.Contains("ReleaseDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseDate = (global::System.DateTime?) content.GetValueForProperty("ReleaseDate",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ReleaseType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseType = (string) content.GetValueForProperty("ReleaseType",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseType, global::System.Convert.ToString);
            }
            if (content.Contains("CompatibleVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).CompatibleVersion = (System.Collections.Generic.List<string>) content.GetValueForProperty("CompatibleVersion",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).CompatibleVersion, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("TransactionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).TransactionId = (string) content.GetValueForProperty("TransactionId",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).TransactionId, global::System.Convert.ToString);
            }
            if (content.Contains("DownloadLink"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).DownloadLink = (string) content.GetValueForProperty("DownloadLink",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).DownloadLink, global::System.Convert.ToString);
            }
            if (content.Contains("LinkExpiry"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).LinkExpiry = (global::System.DateTime?) content.GetValueForProperty("LinkExpiry",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).LinkExpiry, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ImageDownloadResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ImageDownloadResult(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("ReleaseVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseVersion = (string) content.GetValueForProperty("ReleaseVersion",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ReleaseDisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseDisplayName = (string) content.GetValueForProperty("ReleaseDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseDisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("ReleaseNote"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseNote = (string) content.GetValueForProperty("ReleaseNote",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseNote, global::System.Convert.ToString);
            }
            if (content.Contains("ReleaseDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseDate = (global::System.DateTime?) content.GetValueForProperty("ReleaseDate",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ReleaseType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseType = (string) content.GetValueForProperty("ReleaseType",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).ReleaseType, global::System.Convert.ToString);
            }
            if (content.Contains("CompatibleVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).CompatibleVersion = (System.Collections.Generic.List<string>) content.GetValueForProperty("CompatibleVersion",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).CompatibleVersion, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("TransactionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).TransactionId = (string) content.GetValueForProperty("TransactionId",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).TransactionId, global::System.Convert.ToString);
            }
            if (content.Contains("DownloadLink"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).DownloadLink = (string) content.GetValueForProperty("DownloadLink",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).DownloadLink, global::System.Convert.ToString);
            }
            if (content.Contains("LinkExpiry"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).LinkExpiry = (global::System.DateTime?) content.GetValueForProperty("LinkExpiry",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal)this).LinkExpiry, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// The image download properties
    [System.ComponentModel.TypeConverter(typeof(ImageDownloadResultTypeConverter))]
    public partial interface IImageDownloadResult

    {

    }
}