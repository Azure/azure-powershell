namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Describes the properties of a hybrid machine.</summary>
    public partial class MachineProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject json ? new MachineProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject into a new instance of <see cref="MachineProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal MachineProperties(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_locationData = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject>("locationData"), out var __jsonLocationData) ? Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.LocationData.FromJson(__jsonLocationData) : LocationData;}
            {_oSProfile = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject>("osProfile"), out var __jsonOSProfile) ? Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.MachinePropertiesOSProfile.FromJson(__jsonOSProfile) : OSProfile;}
            {_adFqdn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("adFqdn"), out var __jsonAdFqdn) ? (string)__jsonAdFqdn : (string)AdFqdn;}
            {_agentVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("agentVersion"), out var __jsonAgentVersion) ? (string)__jsonAgentVersion : (string)AgentVersion;}
            {_clientPublicKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("clientPublicKey"), out var __jsonClientPublicKey) ? (string)__jsonClientPublicKey : (string)ClientPublicKey;}
            {_displayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("displayName"), out var __jsonDisplayName) ? (string)__jsonDisplayName : (string)DisplayName;}
            {_dnsFqdn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("dnsFqdn"), out var __jsonDnsFqdn) ? (string)__jsonDnsFqdn : (string)DnsFqdn;}
            {_domainName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("domainName"), out var __jsonDomainName) ? (string)__jsonDomainName : (string)DomainName;}
            {_errorDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonArray>("errorDetails"), out var __jsonErrorDetails) ? If( __jsonErrorDetails as Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IErrorDetail[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IErrorDetail) (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.ErrorDetail.FromJson(__u) )) ))() : null : ErrorDetail;}
            {_lastStatusChange = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("lastStatusChange"), out var __jsonLastStatusChange) ? global::System.DateTime.TryParse((string)__jsonLastStatusChange, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastStatusChangeValue) ? __jsonLastStatusChangeValue : LastStatusChange : LastStatusChange;}
            {_machineFqdn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("machineFqdn"), out var __jsonMachineFqdn) ? (string)__jsonMachineFqdn : (string)MachineFqdn;}
            {_oSName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("osName"), out var __jsonOSName) ? (string)__jsonOSName : (string)OSName;}
            {_oSSku = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("osSku"), out var __jsonOSSku) ? (string)__jsonOSSku : (string)OSSku;}
            {_oSVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("osVersion"), out var __jsonOSVersion) ? (string)__jsonOSVersion : (string)OSVersion;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_status = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("status"), out var __jsonStatus) ? (string)__jsonStatus : (string)Status;}
            {_vMId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("vmId"), out var __jsonVMId) ? (string)__jsonVMId : (string)VMId;}
            {_vMUuid = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString>("vmUuid"), out var __jsonVMUuid) ? (string)__jsonVMUuid : (string)VMUuid;}
            {_extension = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonArray>("extensions"), out var __jsonExtensions) ? If( __jsonExtensions as Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceView[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceView) (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.MachineExtensionInstanceView.FromJson(__p) )) ))() : null : Extension;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="MachineProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="MachineProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._locationData ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) this._locationData.ToJson(null,serializationMode) : null, "locationData" ,container.Add );
            AddIf( null != this._oSProfile ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) this._oSProfile.ToJson(null,serializationMode) : null, "osProfile" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._adFqdn)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._adFqdn.ToString()) : null, "adFqdn" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._agentVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._agentVersion.ToString()) : null, "agentVersion" ,container.Add );
            }
            AddIf( null != (((object)this._clientPublicKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._clientPublicKey.ToString()) : null, "clientPublicKey" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._displayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._displayName.ToString()) : null, "displayName" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._dnsFqdn)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._dnsFqdn.ToString()) : null, "dnsFqdn" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._domainName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._domainName.ToString()) : null, "domainName" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._errorDetail)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.XNodeArray();
                    foreach( var __x in this._errorDetail )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("errorDetails",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._lastStatusChange ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._lastStatusChange?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastStatusChange" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._machineFqdn)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._machineFqdn.ToString()) : null, "machineFqdn" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._oSName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._oSName.ToString()) : null, "osName" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._oSSku)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._oSSku.ToString()) : null, "osSku" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._oSVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._oSVersion.ToString()) : null, "osVersion" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._status)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._status.ToString()) : null, "status" ,container.Add );
            }
            AddIf( null != (((object)this._vMId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._vMId.ToString()) : null, "vmId" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._vMUuid)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonString(this._vMUuid.ToString()) : null, "vmUuid" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._extension)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.XNodeArray();
                    foreach( var __s in this._extension )
                    {
                        AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                    }
                    container.Add("extensions",__r);
                }
            }
            AfterToJson(ref container);
            return container;
        }
    }
}