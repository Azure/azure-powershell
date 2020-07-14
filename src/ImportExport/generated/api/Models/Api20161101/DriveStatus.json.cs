namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>Provides information about the drive's status</summary>
    public partial class DriveStatus
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject into a new instance of <see cref="DriveStatus" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DriveStatus(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_bitLockerKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("bitLockerKey"), out var __jsonBitLockerKey) ? (string)__jsonBitLockerKey : (string)BitLockerKey;}
            {_bytesSucceeded = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNumber>("bytesSucceeded"), out var __jsonBytesSucceeded) ? (long?)__jsonBytesSucceeded : BytesSucceeded;}
            {_copyStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("copyStatus"), out var __jsonCopyStatus) ? (string)__jsonCopyStatus : (string)CopyStatus;}
            {_driveHeaderHash = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("driveHeaderHash"), out var __jsonDriveHeaderHash) ? (string)__jsonDriveHeaderHash : (string)DriveHeaderHash;}
            {_driveId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("driveId"), out var __jsonDriveId) ? (string)__jsonDriveId : (string)DriveId;}
            {_errorLogUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("errorLogUri"), out var __jsonErrorLogUri) ? (string)__jsonErrorLogUri : (string)ErrorLogUri;}
            {_manifestFile = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("manifestFile"), out var __jsonManifestFile) ? (string)__jsonManifestFile : (string)ManifestFile;}
            {_manifestHash = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("manifestHash"), out var __jsonManifestHash) ? (string)__jsonManifestHash : (string)ManifestHash;}
            {_manifestUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("manifestUri"), out var __jsonManifestUri) ? (string)__jsonManifestUri : (string)ManifestUri;}
            {_percentComplete = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNumber>("percentComplete"), out var __jsonPercentComplete) ? (int?)__jsonPercentComplete : PercentComplete;}
            {_state = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("state"), out var __jsonState) ? (string)__jsonState : (string)State;}
            {_verboseLogUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("verboseLogUri"), out var __jsonVerboseLogUri) ? (string)__jsonVerboseLogUri : (string)VerboseLogUri;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject json ? new DriveStatus(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DriveStatus" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DriveStatus" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._bitLockerKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._bitLockerKey.ToString()) : null, "bitLockerKey" ,container.Add );
            AddIf( null != this._bytesSucceeded ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNumber((long)this._bytesSucceeded) : null, "bytesSucceeded" ,container.Add );
            AddIf( null != (((object)this._copyStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._copyStatus.ToString()) : null, "copyStatus" ,container.Add );
            AddIf( null != (((object)this._driveHeaderHash)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._driveHeaderHash.ToString()) : null, "driveHeaderHash" ,container.Add );
            AddIf( null != (((object)this._driveId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._driveId.ToString()) : null, "driveId" ,container.Add );
            AddIf( null != (((object)this._errorLogUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._errorLogUri.ToString()) : null, "errorLogUri" ,container.Add );
            AddIf( null != (((object)this._manifestFile)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._manifestFile.ToString()) : null, "manifestFile" ,container.Add );
            AddIf( null != (((object)this._manifestHash)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._manifestHash.ToString()) : null, "manifestHash" ,container.Add );
            AddIf( null != (((object)this._manifestUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._manifestUri.ToString()) : null, "manifestUri" ,container.Add );
            AddIf( null != this._percentComplete ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNumber((int)this._percentComplete) : null, "percentComplete" ,container.Add );
            AddIf( null != (((object)this._state)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._state.ToString()) : null, "state" ,container.Add );
            AddIf( null != (((object)this._verboseLogUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._verboseLogUri.ToString()) : null, "verboseLogUri" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}