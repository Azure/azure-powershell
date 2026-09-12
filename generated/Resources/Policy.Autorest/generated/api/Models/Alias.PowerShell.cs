// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.PowerShell;

    /// <summary>The alias type.</summary>
    [System.ComponentModel.TypeConverter(typeof(AliasTypeConverter))]
    public partial class Alias
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Alias"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Alias(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("DefaultPattern"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPattern = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPattern) content.GetValueForProperty("DefaultPattern",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPattern, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPatternTypeConverter.ConvertFrom);
            }
            if (content.Contains("DefaultMetadata"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultMetadata = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadata) content.GetValueForProperty("DefaultMetadata",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultMetadata, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPathMetadataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Path"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).Path = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath>) content.GetValueForProperty("Path",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).Path, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPathTypeConverter.ConvertFrom));
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultPath"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPath = (string) content.GetValueForProperty("DefaultPath",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPath, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultPatternPhrase"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPatternPhrase = (string) content.GetValueForProperty("DefaultPatternPhrase",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPatternPhrase, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultPatternVariable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPatternVariable = (string) content.GetValueForProperty("DefaultPatternVariable",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPatternVariable, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultPatternType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPatternType = (string) content.GetValueForProperty("DefaultPatternType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPatternType, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultMetadataType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultMetadataType = (string) content.GetValueForProperty("DefaultMetadataType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultMetadataType, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultMetadataAttribute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultMetadataAttribute = (string) content.GetValueForProperty("DefaultMetadataAttribute",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultMetadataAttribute, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Alias"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Alias(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("DefaultPattern"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPattern = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPattern) content.GetValueForProperty("DefaultPattern",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPattern, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPatternTypeConverter.ConvertFrom);
            }
            if (content.Contains("DefaultMetadata"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultMetadata = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadata) content.GetValueForProperty("DefaultMetadata",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultMetadata, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPathMetadataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Path"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).Path = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath>) content.GetValueForProperty("Path",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).Path, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPathTypeConverter.ConvertFrom));
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultPath"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPath = (string) content.GetValueForProperty("DefaultPath",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPath, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultPatternPhrase"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPatternPhrase = (string) content.GetValueForProperty("DefaultPatternPhrase",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPatternPhrase, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultPatternVariable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPatternVariable = (string) content.GetValueForProperty("DefaultPatternVariable",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPatternVariable, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultPatternType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPatternType = (string) content.GetValueForProperty("DefaultPatternType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultPatternType, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultMetadataType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultMetadataType = (string) content.GetValueForProperty("DefaultMetadataType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultMetadataType, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultMetadataAttribute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultMetadataAttribute = (string) content.GetValueForProperty("DefaultMetadataAttribute",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal)this).DefaultMetadataAttribute, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Alias"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAlias" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAlias DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Alias(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Alias"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAlias" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAlias DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Alias(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Alias" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="Alias" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAlias FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The alias type.
    [System.ComponentModel.TypeConverter(typeof(AliasTypeConverter))]
    public partial interface IAlias

    {

    }
}