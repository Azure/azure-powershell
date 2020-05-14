namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ProcessModuleInfo resource specific properties</summary>
    public partial class ProcessModuleInfoProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json ? new ProcessModuleInfoProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject into a new instance of <see cref="ProcessModuleInfoProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ProcessModuleInfoProperties(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_baseAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("base_address"), out var __jsonBaseAddress) ? (string)__jsonBaseAddress : (string)BaseAddress;}
            {_fileDescription = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("file_description"), out var __jsonFileDescription) ? (string)__jsonFileDescription : (string)FileDescription;}
            {_fileName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("file_name"), out var __jsonFileName) ? (string)__jsonFileName : (string)FileName;}
            {_filePath = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("file_path"), out var __jsonFilePath) ? (string)__jsonFilePath : (string)FilePath;}
            {_fileVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("file_version"), out var __jsonFileVersion) ? (string)__jsonFileVersion : (string)FileVersion;}
            {_href = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("href"), out var __jsonHref) ? (string)__jsonHref : (string)Href;}
            {_isDebug = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("is_debug"), out var __jsonIsDebug) ? (bool?)__jsonIsDebug : IsDebug;}
            {_moduleMemorySize = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("module_memory_size"), out var __jsonModuleMemorySize) ? (int?)__jsonModuleMemorySize : ModuleMemorySize;}
            {_product = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("product"), out var __jsonProduct) ? (string)__jsonProduct : (string)Product;}
            {_productVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("product_version"), out var __jsonProductVersion) ? (string)__jsonProductVersion : (string)ProductVersion;}
            {_language = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("language"), out var __jsonLanguage) ? (string)__jsonLanguage : (string)Language;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ProcessModuleInfoProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ProcessModuleInfoProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._baseAddress)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._baseAddress.ToString()) : null, "base_address" ,container.Add );
            AddIf( null != (((object)this._fileDescription)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._fileDescription.ToString()) : null, "file_description" ,container.Add );
            AddIf( null != (((object)this._fileName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._fileName.ToString()) : null, "file_name" ,container.Add );
            AddIf( null != (((object)this._filePath)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._filePath.ToString()) : null, "file_path" ,container.Add );
            AddIf( null != (((object)this._fileVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._fileVersion.ToString()) : null, "file_version" ,container.Add );
            AddIf( null != (((object)this._href)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._href.ToString()) : null, "href" ,container.Add );
            AddIf( null != this._isDebug ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._isDebug) : null, "is_debug" ,container.Add );
            AddIf( null != this._moduleMemorySize ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._moduleMemorySize) : null, "module_memory_size" ,container.Add );
            AddIf( null != (((object)this._product)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._product.ToString()) : null, "product" ,container.Add );
            AddIf( null != (((object)this._productVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._productVersion.ToString()) : null, "product_version" ,container.Add );
            AddIf( null != (((object)this._language)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._language.ToString()) : null, "language" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}