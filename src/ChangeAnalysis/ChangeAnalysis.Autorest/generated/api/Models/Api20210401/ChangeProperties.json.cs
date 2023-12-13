namespace Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Extensions;

    /// <summary>The properties of a change.</summary>
    public partial class ChangeProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonObject into a new instance of <see cref="ChangeProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ChangeProperties(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_resourceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonString>("resourceId"), out var __jsonResourceId) ? (string)__jsonResourceId : (string)ResourceId;}
            {_timeStamp = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonString>("timeStamp"), out var __jsonTimeStamp) ? global::System.DateTime.TryParse((string)__jsonTimeStamp, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonTimeStampValue) ? __jsonTimeStampValue : TimeStamp : TimeStamp;}
            {_initiatedByList = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonArray>("initiatedByList"), out var __jsonInitiatedByList) ? If( __jsonInitiatedByList as Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : InitiatedByList;}
            {_changeType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonString>("changeType"), out var __jsonChangeType) ? (string)__jsonChangeType : (string)ChangeType;}
            {_propertyChange = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonArray>("propertyChanges"), out var __jsonPropertyChanges) ? If( __jsonPropertyChanges as Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange) (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.PropertyChange.FromJson(__p) )) ))() : null : PropertyChange;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonObject json ? new ChangeProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ChangeProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ChangeProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._resourceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonString(this._resourceId.ToString()) : null, "resourceId" ,container.Add );
            AddIf( null != this._timeStamp ? (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonString(this._timeStamp?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "timeStamp" ,container.Add );
            if (null != this._initiatedByList)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.XNodeArray();
                foreach( var __x in this._initiatedByList )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("initiatedByList",__w);
            }
            AddIf( null != (((object)this._changeType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonString(this._changeType.ToString()) : null, "changeType" ,container.Add );
            if (null != this._propertyChange)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.XNodeArray();
                foreach( var __s in this._propertyChange )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("propertyChanges",__r);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}