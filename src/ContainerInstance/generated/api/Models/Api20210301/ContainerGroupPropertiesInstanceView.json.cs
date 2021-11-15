namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The instance view of the container group. Only valid in response.</summary>
    public partial class ContainerGroupPropertiesInstanceView
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject into a new instance of <see cref="ContainerGroupPropertiesInstanceView" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ContainerGroupPropertiesInstanceView(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_event = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray>("events"), out var __jsonEvents) ? If( __jsonEvents as Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent) (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Event.FromJson(__u) )) ))() : null : Event;}
            {_state = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString>("state"), out var __jsonState) ? (string)__jsonState : (string)State;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceView.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceView.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceView FromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json ? new ContainerGroupPropertiesInstanceView(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ContainerGroupPropertiesInstanceView" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ContainerGroupPropertiesInstanceView" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._event)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.XNodeArray();
                    foreach( var __x in this._event )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("events",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._state)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString(this._state.ToString()) : null, "state" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}