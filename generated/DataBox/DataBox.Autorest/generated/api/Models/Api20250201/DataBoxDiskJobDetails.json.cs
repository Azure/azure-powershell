// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Extensions;

    /// <summary>DataBox Disk Job Details.</summary>
    public partial class DataBoxDiskJobDetails
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name= "returnNow" />
        /// output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject into a new instance of <see cref="DataBoxDiskJobDetails" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DataBoxDiskJobDetails(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __jobDetails = new Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.JobDetails(json);
            {_preferredDisk = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject>("preferredDisks"), out var __jsonPreferredDisks) ? Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.DataBoxDiskJobDetailsPreferredDisks.FromJson(__jsonPreferredDisks) : PreferredDisk;}
            {_copyProgress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonArray>("copyProgress"), out var __jsonCopyProgress) ? If( __jsonCopyProgress as Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.IDataBoxDiskCopyProgress[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.IDataBoxDiskCopyProgress) (Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.DataBoxDiskCopyProgress.FromJson(__u) )) ))() : null : CopyProgress;}
            {_granularCopyProgress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonArray>("granularCopyProgress"), out var __jsonGranularCopyProgress) ? If( __jsonGranularCopyProgress as Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.IDataBoxDiskGranularCopyProgress[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.IDataBoxDiskGranularCopyProgress) (Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.DataBoxDiskGranularCopyProgress.FromJson(__p) )) ))() : null : GranularCopyProgress;}
            {_granularCopyLogDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonArray>("granularCopyLogDetails"), out var __jsonGranularCopyLogDetails) ? If( __jsonGranularCopyLogDetails as Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.IDataBoxDiskGranularCopyLogDetails[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.IDataBoxDiskGranularCopyLogDetails) (Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.DataBoxDiskGranularCopyLogDetails.FromJson(__k) )) ))() : null : GranularCopyLogDetail;}
            {_disksAndSizeDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject>("disksAndSizeDetails"), out var __jsonDisksAndSizeDetails) ? Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.DataBoxDiskJobDetailsDisksAndSizeDetails.FromJson(__jsonDisksAndSizeDetails) : DisksAndSizeDetail;}
            {_passkey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonString>("passkey"), out var __jsonPasskey) ? (string)__jsonPasskey : (string)Passkey;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.IDataBoxDiskJobDetails.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.IDataBoxDiskJobDetails.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20250201.IDataBoxDiskJobDetails FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject json ? new DataBoxDiskJobDetails(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DataBoxDiskJobDetails" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DataBoxDiskJobDetails" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            __jobDetails?.ToJson(container, serializationMode);
            AddIf( null != this._preferredDisk ? (Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonNode) this._preferredDisk.ToJson(null,serializationMode) : null, "preferredDisks" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._copyProgress)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.XNodeArray();
                    foreach( var __x in this._copyProgress )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("copyProgress",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._granularCopyProgress)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.XNodeArray();
                    foreach( var __s in this._granularCopyProgress )
                    {
                        AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                    }
                    container.Add("granularCopyProgress",__r);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._granularCopyLogDetail)
                {
                    var __m = new Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.XNodeArray();
                    foreach( var __n in this._granularCopyLogDetail )
                    {
                        AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                    }
                    container.Add("granularCopyLogDetails",__m);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._disksAndSizeDetail ? (Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonNode) this._disksAndSizeDetail.ToJson(null,serializationMode) : null, "disksAndSizeDetails" ,container.Add );
            }
            AddIf( null != (((object)this._passkey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataBox.Runtime.Json.JsonString(this._passkey.ToString()) : null, "passkey" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}