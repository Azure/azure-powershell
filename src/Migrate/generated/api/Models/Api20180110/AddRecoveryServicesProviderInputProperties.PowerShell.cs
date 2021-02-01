namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>The properties of an add provider request.</summary>
    [System.ComponentModel.TypeConverter(typeof(AddRecoveryServicesProviderInputPropertiesTypeConverter))]
    public partial class AddRecoveryServicesProviderInputProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AddRecoveryServicesProviderInputProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AddRecoveryServicesProviderInputProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IIdentityProviderInput) content.GetValueForProperty("AuthenticationIdentityInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IIdentityProviderInput) content.GetValueForProperty("ResourceAccessIdentityInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).MachineName = (string) content.GetValueForProperty("MachineName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).MachineName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputTenantId = (string) content.GetValueForProperty("AuthenticationIdentityInputTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputApplicationId = (string) content.GetValueForProperty("AuthenticationIdentityInputApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputObjectId = (string) content.GetValueForProperty("AuthenticationIdentityInputObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputAudience = (string) content.GetValueForProperty("AuthenticationIdentityInputAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputAadAuthority = (string) content.GetValueForProperty("AuthenticationIdentityInputAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputTenantId = (string) content.GetValueForProperty("ResourceAccessIdentityInputTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputApplicationId = (string) content.GetValueForProperty("ResourceAccessIdentityInputApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputObjectId = (string) content.GetValueForProperty("ResourceAccessIdentityInputObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputAudience = (string) content.GetValueForProperty("ResourceAccessIdentityInputAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputAadAuthority = (string) content.GetValueForProperty("ResourceAccessIdentityInputAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputAadAuthority, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AddRecoveryServicesProviderInputProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AddRecoveryServicesProviderInputProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IIdentityProviderInput) content.GetValueForProperty("AuthenticationIdentityInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IIdentityProviderInput) content.GetValueForProperty("ResourceAccessIdentityInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).MachineName = (string) content.GetValueForProperty("MachineName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).MachineName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputTenantId = (string) content.GetValueForProperty("AuthenticationIdentityInputTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputApplicationId = (string) content.GetValueForProperty("AuthenticationIdentityInputApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputObjectId = (string) content.GetValueForProperty("AuthenticationIdentityInputObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputAudience = (string) content.GetValueForProperty("AuthenticationIdentityInputAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputAadAuthority = (string) content.GetValueForProperty("AuthenticationIdentityInputAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).AuthenticationIdentityInputAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputTenantId = (string) content.GetValueForProperty("ResourceAccessIdentityInputTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputApplicationId = (string) content.GetValueForProperty("ResourceAccessIdentityInputApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputObjectId = (string) content.GetValueForProperty("ResourceAccessIdentityInputObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputAudience = (string) content.GetValueForProperty("ResourceAccessIdentityInputAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputAadAuthority = (string) content.GetValueForProperty("ResourceAccessIdentityInputAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputPropertiesInternal)this).ResourceAccessIdentityInputAadAuthority, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AddRecoveryServicesProviderInputProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AddRecoveryServicesProviderInputProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AddRecoveryServicesProviderInputProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AddRecoveryServicesProviderInputProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AddRecoveryServicesProviderInputProperties" />, deserializing the content from a
        /// json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The properties of an add provider request.
    [System.ComponentModel.TypeConverter(typeof(AddRecoveryServicesProviderInputPropertiesTypeConverter))]
    public partial interface IAddRecoveryServicesProviderInputProperties

    {

    }
}