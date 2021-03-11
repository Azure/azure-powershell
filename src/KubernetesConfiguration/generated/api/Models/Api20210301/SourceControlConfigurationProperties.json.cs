namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>Properties to create a Source Control Configuration resource</summary>
    public partial class SourceControlConfigurationProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject json ? new SourceControlConfigurationProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject into a new instance of <see cref="SourceControlConfigurationProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal SourceControlConfigurationProperties(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_complianceStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject>("complianceStatus"), out var __jsonComplianceStatus) ? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ComplianceStatus.FromJson(__jsonComplianceStatus) : ComplianceStatus;}
            {_helmOperatorProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject>("helmOperatorProperties"), out var __jsonHelmOperatorProperties) ? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.HelmOperatorProperties.FromJson(__jsonHelmOperatorProperties) : HelmOperatorProperty;}
            {_configurationProtectedSetting = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject>("configurationProtectedSettings"), out var __jsonConfigurationProtectedSettings) ? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ConfigurationProtectedSettings.FromJson(__jsonConfigurationProtectedSettings) : ConfigurationProtectedSetting;}
            {_enableHelmOperator = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonBoolean>("enableHelmOperator"), out var __jsonEnableHelmOperator) ? (bool?)__jsonEnableHelmOperator : EnableHelmOperator;}
            {_operatorInstanceName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString>("operatorInstanceName"), out var __jsonOperatorInstanceName) ? (string)__jsonOperatorInstanceName : (string)OperatorInstanceName;}
            {_operatorNamespace = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString>("operatorNamespace"), out var __jsonOperatorNamespace) ? (string)__jsonOperatorNamespace : (string)OperatorNamespace;}
            {_operatorParam = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString>("operatorParams"), out var __jsonOperatorParams) ? (string)__jsonOperatorParams : (string)OperatorParam;}
            {_operatorScope = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString>("operatorScope"), out var __jsonOperatorScope) ? (string)__jsonOperatorScope : (string)OperatorScope;}
            {_operatorType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString>("operatorType"), out var __jsonOperatorType) ? (string)__jsonOperatorType : (string)OperatorType;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_repositoryPublicKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString>("repositoryPublicKey"), out var __jsonRepositoryPublicKey) ? (string)__jsonRepositoryPublicKey : (string)RepositoryPublicKey;}
            {_repositoryUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString>("repositoryUrl"), out var __jsonRepositoryUrl) ? (string)__jsonRepositoryUrl : (string)RepositoryUrl;}
            {_sshKnownHostsContent = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString>("sshKnownHostsContents"), out var __jsonSshKnownHostsContents) ? (string)__jsonSshKnownHostsContents : (string)SshKnownHostsContent;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="SourceControlConfigurationProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="SourceControlConfigurationProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._complianceStatus ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode) this._complianceStatus.ToJson(null,serializationMode) : null, "complianceStatus" ,container.Add );
            }
            AddIf( null != this._helmOperatorProperty ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode) this._helmOperatorProperty.ToJson(null,serializationMode) : null, "helmOperatorProperties" ,container.Add );
            AddIf( null != this._configurationProtectedSetting ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode) this._configurationProtectedSetting.ToJson(null,serializationMode) : null, "configurationProtectedSettings" ,container.Add );
            AddIf( null != this._enableHelmOperator ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonBoolean((bool)this._enableHelmOperator) : null, "enableHelmOperator" ,container.Add );
            AddIf( null != (((object)this._operatorInstanceName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString(this._operatorInstanceName.ToString()) : null, "operatorInstanceName" ,container.Add );
            AddIf( null != (((object)this._operatorNamespace)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString(this._operatorNamespace.ToString()) : null, "operatorNamespace" ,container.Add );
            AddIf( null != (((object)this._operatorParam)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString(this._operatorParam.ToString()) : null, "operatorParams" ,container.Add );
            AddIf( null != (((object)this._operatorScope)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString(this._operatorScope.ToString()) : null, "operatorScope" ,container.Add );
            AddIf( null != (((object)this._operatorType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString(this._operatorType.ToString()) : null, "operatorType" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._repositoryPublicKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString(this._repositoryPublicKey.ToString()) : null, "repositoryPublicKey" ,container.Add );
            }
            AddIf( null != (((object)this._repositoryUrl)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString(this._repositoryUrl.ToString()) : null, "repositoryUrl" ,container.Add );
            AddIf( null != (((object)this._sshKnownHostsContent)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonString(this._sshKnownHostsContent.ToString()) : null, "sshKnownHostsContents" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}