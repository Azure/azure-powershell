namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>Specifies the properties of a UpdateJob.</summary>
    public partial class UpdateJobParametersProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject json ? new UpdateJobParametersProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="UpdateJobParametersProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="UpdateJobParametersProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._deliveryPackage ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) this._deliveryPackage.ToJson(null,serializationMode) : null, "deliveryPackage" ,container.Add );
            AddIf( null != this._returnAddress ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) this._returnAddress.ToJson(null,serializationMode) : null, "returnAddress" ,container.Add );
            AddIf( null != this._returnShipping ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) this._returnShipping.ToJson(null,serializationMode) : null, "returnShipping" ,container.Add );
            AddIf( null != this._backupDriveManifest ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonBoolean((bool)this._backupDriveManifest) : null, "backupDriveManifest" ,container.Add );
            AddIf( null != this._cancelRequested ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonBoolean((bool)this._cancelRequested) : null, "cancelRequested" ,container.Add );
            if (null != this._driveList)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.XNodeArray();
                foreach( var __x in this._driveList )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("driveList",__w);
            }
            AddIf( null != (((object)this._logLevel)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._logLevel.ToString()) : null, "logLevel" ,container.Add );
            AddIf( null != (((object)this._state)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._state.ToString()) : null, "state" ,container.Add );
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject into a new instance of <see cref="UpdateJobParametersProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal UpdateJobParametersProperties(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_deliveryPackage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject>("deliveryPackage"), out var __jsonDeliveryPackage) ? Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomation.FromJson(__jsonDeliveryPackage) : DeliveryPackage;}
            {_returnAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject>("returnAddress"), out var __jsonReturnAddress) ? Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddress.FromJson(__jsonReturnAddress) : ReturnAddress;}
            {_returnShipping = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject>("returnShipping"), out var __jsonReturnShipping) ? Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnShipping.FromJson(__jsonReturnShipping) : ReturnShipping;}
            {_backupDriveManifest = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonBoolean>("backupDriveManifest"), out var __jsonBackupDriveManifest) ? (bool?)__jsonBackupDriveManifest : BackupDriveManifest;}
            {_cancelRequested = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonBoolean>("cancelRequested"), out var __jsonCancelRequested) ? (bool?)__jsonCancelRequested : CancelRequested;}
            {_driveList = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonArray>("driveList"), out var __jsonDriveList) ? If( __jsonDriveList as Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus) (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatus.FromJson(__u) )) ))() : null : DriveList;}
            {_logLevel = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("logLevel"), out var __jsonLogLevel) ? (string)__jsonLogLevel : (string)LogLevel;}
            {_state = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("state"), out var __jsonState) ? (string)__jsonState : (string)State;}
            AfterFromJson(json);
        }
    }
}