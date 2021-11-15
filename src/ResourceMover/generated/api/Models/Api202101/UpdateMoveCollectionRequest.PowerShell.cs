namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.PowerShell;

    /// <summary>Defines the request body for updating move collection.</summary>
    [System.ComponentModel.TypeConverter(typeof(UpdateMoveCollectionRequestTypeConverter))]
    public partial class UpdateMoveCollectionRequest
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UpdateMoveCollectionRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequest"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequest DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new UpdateMoveCollectionRequest(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UpdateMoveCollectionRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequest"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequest DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new UpdateMoveCollectionRequest(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UpdateMoveCollectionRequest" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequest FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UpdateMoveCollectionRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal UpdateMoveCollectionRequest(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UpdateMoveCollectionRequestTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UpdateMoveCollectionRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal UpdateMoveCollectionRequest(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UpdateMoveCollectionRequestTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType.CreateFrom);
            AfterDeserializePSObject(content);
        }
    }
    /// Defines the request body for updating move collection.
    [System.ComponentModel.TypeConverter(typeof(UpdateMoveCollectionRequestTypeConverter))]
    public partial interface IUpdateMoveCollectionRequest

    {

    }
}