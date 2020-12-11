namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Properties of HostPool.</summary>
    public partial class HostPoolPatchProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IHostPoolPatchProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject json ? new HostPoolPatchProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject into a new instance of <see cref="HostPoolPatchProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal HostPoolPatchProperties(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_registrationInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject>("registrationInfo"), out var __jsonRegistrationInfo) ? Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.RegistrationInfoPatch.FromJson(__jsonRegistrationInfo) : RegistrationInfo;}
            {_friendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("friendlyName"), out var __jsonFriendlyName) ? (string)__jsonFriendlyName : (string)FriendlyName;}
            {_description = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("description"), out var __jsonDescription) ? (string)__jsonDescription : (string)Description;}
            {_customRdpProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("customRdpProperty"), out var __jsonCustomRdpProperty) ? (string)__jsonCustomRdpProperty : (string)CustomRdpProperty;}
            {_maxSessionLimit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber>("maxSessionLimit"), out var __jsonMaxSessionLimit) ? (int?)__jsonMaxSessionLimit : MaxSessionLimit;}
            {_personalDesktopAssignmentType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("personalDesktopAssignmentType"), out var __jsonPersonalDesktopAssignmentType) ? (string)__jsonPersonalDesktopAssignmentType : (string)PersonalDesktopAssignmentType;}
            {_loadBalancerType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("loadBalancerType"), out var __jsonLoadBalancerType) ? (string)__jsonLoadBalancerType : (string)LoadBalancerType;}
            {_ring = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber>("ring"), out var __jsonRing) ? (int?)__jsonRing : Ring;}
            {_validationEnvironment = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonBoolean>("validationEnvironment"), out var __jsonValidationEnvironment) ? (bool?)__jsonValidationEnvironment : ValidationEnvironment;}
            {_vMTemplate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("vmTemplate"), out var __jsonVMTemplate) ? (string)__jsonVMTemplate : (string)VMTemplate;}
            {_ssoContext = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("ssoContext"), out var __jsonSsoContext) ? (string)__jsonSsoContext : (string)SsoContext;}
            {_ssoadfsAuthority = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("ssoadfsAuthority"), out var __jsonSsoadfsAuthority) ? (string)__jsonSsoadfsAuthority : (string)SsoadfsAuthority;}
            {_ssoClientId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("ssoClientId"), out var __jsonSsoClientId) ? (string)__jsonSsoClientId : (string)SsoClientId;}
            {_ssoClientSecretKeyVaultPath = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("ssoClientSecretKeyVaultPath"), out var __jsonSsoClientSecretKeyVaultPath) ? (string)__jsonSsoClientSecretKeyVaultPath : (string)SsoClientSecretKeyVaultPath;}
            {_ssoSecretType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("ssoSecretType"), out var __jsonSsoSecretType) ? (string)__jsonSsoSecretType : (string)SsoSecretType;}
            {_preferredAppGroupType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString>("preferredAppGroupType"), out var __jsonPreferredAppGroupType) ? (string)__jsonPreferredAppGroupType : (string)PreferredAppGroupType;}
            {_startVMOnConnect = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonBoolean>("startVMOnConnect"), out var __jsonStartVMOnConnect) ? (bool?)__jsonStartVMOnConnect : StartVMOnConnect;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="HostPoolPatchProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="HostPoolPatchProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._registrationInfo ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) this._registrationInfo.ToJson(null,serializationMode) : null, "registrationInfo" ,container.Add );
            AddIf( null != (((object)this._friendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._friendlyName.ToString()) : null, "friendlyName" ,container.Add );
            AddIf( null != (((object)this._description)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._description.ToString()) : null, "description" ,container.Add );
            AddIf( null != (((object)this._customRdpProperty)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._customRdpProperty.ToString()) : null, "customRdpProperty" ,container.Add );
            AddIf( null != this._maxSessionLimit ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber((int)this._maxSessionLimit) : null, "maxSessionLimit" ,container.Add );
            AddIf( null != (((object)this._personalDesktopAssignmentType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._personalDesktopAssignmentType.ToString()) : null, "personalDesktopAssignmentType" ,container.Add );
            AddIf( null != (((object)this._loadBalancerType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._loadBalancerType.ToString()) : null, "loadBalancerType" ,container.Add );
            AddIf( null != this._ring ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNumber((int)this._ring) : null, "ring" ,container.Add );
            AddIf( null != this._validationEnvironment ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonBoolean((bool)this._validationEnvironment) : null, "validationEnvironment" ,container.Add );
            AddIf( null != (((object)this._vMTemplate)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._vMTemplate.ToString()) : null, "vmTemplate" ,container.Add );
            AddIf( null != (((object)this._ssoContext)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._ssoContext.ToString()) : null, "ssoContext" ,container.Add );
            AddIf( null != (((object)this._ssoadfsAuthority)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._ssoadfsAuthority.ToString()) : null, "ssoadfsAuthority" ,container.Add );
            AddIf( null != (((object)this._ssoClientId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._ssoClientId.ToString()) : null, "ssoClientId" ,container.Add );
            AddIf( null != (((object)this._ssoClientSecretKeyVaultPath)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._ssoClientSecretKeyVaultPath.ToString()) : null, "ssoClientSecretKeyVaultPath" ,container.Add );
            AddIf( null != (((object)this._ssoSecretType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._ssoSecretType.ToString()) : null, "ssoSecretType" ,container.Add );
            AddIf( null != (((object)this._preferredAppGroupType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonString(this._preferredAppGroupType.ToString()) : null, "preferredAppGroupType" ,container.Add );
            AddIf( null != this._startVMOnConnect ? (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonBoolean((bool)this._startVMOnConnect) : null, "startVMOnConnect" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}