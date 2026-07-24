// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Supercomputer properties</summary>
    public partial class SupercomputerProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject json ? new SupercomputerProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject into a new instance of <see cref="SupercomputerProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal SupercomputerProperties(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_identity = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject>("identities"), out var __jsonIdentities) ? Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentities.FromJson(__jsonIdentities) : _identity;}
            {_managedOnBehalfOfConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject>("managedOnBehalfOfConfiguration"), out var __jsonManagedOnBehalfOfConfiguration) ? Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResources.FromJson(__jsonManagedOnBehalfOfConfiguration) : _managedOnBehalfOfConfiguration;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)_provisioningState;}
            {_subnetId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("subnetId"), out var __jsonSubnetId) ? (string)__jsonSubnetId : (string)_subnetId;}
            {_managementSubnetId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("managementSubnetId"), out var __jsonManagementSubnetId) ? (string)__jsonManagementSubnetId : (string)_managementSubnetId;}
            {_outboundType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("outboundType"), out var __jsonOutboundType) ? (string)__jsonOutboundType : (string)_outboundType;}
            {_systemSku = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("systemSku"), out var __jsonSystemSku) ? (string)__jsonSystemSku : (string)_systemSku;}
            {_customerManagedKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("customerManagedKeys"), out var __jsonCustomerManagedKeys) ? (string)__jsonCustomerManagedKeys : (string)_customerManagedKey;}
            {_diskEncryptionSetId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("diskEncryptionSetId"), out var __jsonDiskEncryptionSetId) ? (string)__jsonDiskEncryptionSetId : (string)_diskEncryptionSetId;}
            {_logAnalyticsClusterId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("logAnalyticsClusterId"), out var __jsonLogAnalyticsClusterId) ? (string)__jsonLogAnalyticsClusterId : (string)_logAnalyticsClusterId;}
            {_managedResourceGroup = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("managedResourceGroup"), out var __jsonManagedResourceGroup) ? (string)__jsonManagedResourceGroup : (string)_managedResourceGroup;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="SupercomputerProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="SupercomputerProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._identity ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) this._identity.ToJson(null,serializationMode) : null, "identities" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._managedOnBehalfOfConfiguration ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) this._managedOnBehalfOfConfiguration.ToJson(null,serializationMode) : null, "managedOnBehalfOfConfiguration" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._subnetId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._subnetId.ToString()) : null, "subnetId" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._managementSubnetId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._managementSubnetId.ToString()) : null, "managementSubnetId" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._outboundType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._outboundType.ToString()) : null, "outboundType" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._systemSku)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._systemSku.ToString()) : null, "systemSku" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._customerManagedKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._customerManagedKey.ToString()) : null, "customerManagedKeys" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._diskEncryptionSetId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._diskEncryptionSetId.ToString()) : null, "diskEncryptionSetId" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._logAnalyticsClusterId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._logAnalyticsClusterId.ToString()) : null, "logAnalyticsClusterId" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._managedResourceGroup)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._managedResourceGroup.ToString()) : null, "managedResourceGroup" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}