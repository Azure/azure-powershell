namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>Specifies the job properties</summary>
    public partial class JobDetails
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetails.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetails.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobDetails FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject json ? new JobDetails(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject into a new instance of <see cref="JobDetails" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal JobDetails(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_deliveryPackage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject>("deliveryPackage"), out var __jsonDeliveryPackage) ? Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomation.FromJson(__jsonDeliveryPackage) : DeliveryPackage;}
            {_export = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject>("export"), out var __jsonExport) ? Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.Export.FromJson(__jsonExport) : Export;}
            {_returnAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject>("returnAddress"), out var __jsonReturnAddress) ? Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnAddress.FromJson(__jsonReturnAddress) : ReturnAddress;}
            {_returnPackage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject>("returnPackage"), out var __jsonReturnPackage) ? Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.PackageInfomation.FromJson(__jsonReturnPackage) : ReturnPackage;}
            {_returnShipping = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject>("returnShipping"), out var __jsonReturnShipping) ? Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ReturnShipping.FromJson(__jsonReturnShipping) : ReturnShipping;}
            {_shippingInformation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject>("shippingInformation"), out var __jsonShippingInformation) ? Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ShippingInformation.FromJson(__jsonShippingInformation) : ShippingInformation;}
            {_backupDriveManifest = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonBoolean>("backupDriveManifest"), out var __jsonBackupDriveManifest) ? (bool?)__jsonBackupDriveManifest : BackupDriveManifest;}
            {_cancelRequested = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonBoolean>("cancelRequested"), out var __jsonCancelRequested) ? (bool?)__jsonCancelRequested : CancelRequested;}
            {_diagnosticsPath = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("diagnosticsPath"), out var __jsonDiagnosticsPath) ? (string)__jsonDiagnosticsPath : (string)DiagnosticsPath;}
            {_driveList = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonArray>("driveList"), out var __jsonDriveList) ? If( __jsonDriveList as Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus) (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatus.FromJson(__u) )) ))() : null : DriveList;}
            {_incompleteBlobListUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("incompleteBlobListUri"), out var __jsonIncompleteBlobListUri) ? (string)__jsonIncompleteBlobListUri : (string)IncompleteBlobListUri;}
            {_jobType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("jobType"), out var __jsonJobType) ? (string)__jsonJobType : (string)JobType;}
            {_logLevel = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("logLevel"), out var __jsonLogLevel) ? (string)__jsonLogLevel : (string)LogLevel;}
            {_percentComplete = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNumber>("percentComplete"), out var __jsonPercentComplete) ? (int?)__jsonPercentComplete : PercentComplete;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_state = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("state"), out var __jsonState) ? (string)__jsonState : (string)State;}
            {_storageAccountId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("storageAccountId"), out var __jsonStorageAccountId) ? (string)__jsonStorageAccountId : (string)StorageAccountId;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="JobDetails" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="JobDetails" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._export ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) this._export.ToJson(null,serializationMode) : null, "export" ,container.Add );
            AddIf( null != this._returnAddress ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) this._returnAddress.ToJson(null,serializationMode) : null, "returnAddress" ,container.Add );
            AddIf( null != this._returnPackage ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) this._returnPackage.ToJson(null,serializationMode) : null, "returnPackage" ,container.Add );
            AddIf( null != this._returnShipping ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) this._returnShipping.ToJson(null,serializationMode) : null, "returnShipping" ,container.Add );
            AddIf( null != this._shippingInformation ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) this._shippingInformation.ToJson(null,serializationMode) : null, "shippingInformation" ,container.Add );
            AddIf( null != this._backupDriveManifest ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonBoolean((bool)this._backupDriveManifest) : null, "backupDriveManifest" ,container.Add );
            AddIf( null != this._cancelRequested ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonBoolean((bool)this._cancelRequested) : null, "cancelRequested" ,container.Add );
            AddIf( null != (((object)this._diagnosticsPath)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._diagnosticsPath.ToString()) : null, "diagnosticsPath" ,container.Add );
            if (null != this._driveList)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.XNodeArray();
                foreach( var __x in this._driveList )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("driveList",__w);
            }
            AddIf( null != (((object)this._incompleteBlobListUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._incompleteBlobListUri.ToString()) : null, "incompleteBlobListUri" ,container.Add );
            AddIf( null != (((object)this._jobType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._jobType.ToString()) : null, "jobType" ,container.Add );
            AddIf( null != (((object)this._logLevel)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._logLevel.ToString()) : null, "logLevel" ,container.Add );
            AddIf( null != this._percentComplete ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNumber((int)this._percentComplete) : null, "percentComplete" ,container.Add );
            AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            AddIf( null != (((object)this._state)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._state.ToString()) : null, "state" ,container.Add );
            AddIf( null != (((object)this._storageAccountId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._storageAccountId.ToString()) : null, "storageAccountId" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}