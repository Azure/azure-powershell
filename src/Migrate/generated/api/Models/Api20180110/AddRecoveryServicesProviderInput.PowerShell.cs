namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Input required to add a provider.</summary>
    [System.ComponentModel.TypeConverter(typeof(AddRecoveryServicesProviderInputTypeConverter))]
    public partial class AddRecoveryServicesProviderInput
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AddRecoveryServicesProviderInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AddRecoveryServicesProviderInput(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AddRecoveryServicesProviderInputPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IIdentityProviderInput) content.GetValueForProperty("AuthenticationIdentityInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).MachineName = (string) content.GetValueForProperty("MachineName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).MachineName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IIdentityProviderInput) content.GetValueForProperty("ResourceAccessIdentityInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputTenantId = (string) content.GetValueForProperty("AuthenticationIdentityInputTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputApplicationId = (string) content.GetValueForProperty("AuthenticationIdentityInputApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputObjectId = (string) content.GetValueForProperty("AuthenticationIdentityInputObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputAadAuthority = (string) content.GetValueForProperty("ResourceAccessIdentityInputAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputAadAuthority = (string) content.GetValueForProperty("AuthenticationIdentityInputAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputTenantId = (string) content.GetValueForProperty("ResourceAccessIdentityInputTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputApplicationId = (string) content.GetValueForProperty("ResourceAccessIdentityInputApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputObjectId = (string) content.GetValueForProperty("ResourceAccessIdentityInputObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputAudience = (string) content.GetValueForProperty("ResourceAccessIdentityInputAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputAudience = (string) content.GetValueForProperty("AuthenticationIdentityInputAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputAudience, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AddRecoveryServicesProviderInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AddRecoveryServicesProviderInput(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AddRecoveryServicesProviderInputPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IIdentityProviderInput) content.GetValueForProperty("AuthenticationIdentityInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).MachineName = (string) content.GetValueForProperty("MachineName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).MachineName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IIdentityProviderInput) content.GetValueForProperty("ResourceAccessIdentityInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputTenantId = (string) content.GetValueForProperty("AuthenticationIdentityInputTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputApplicationId = (string) content.GetValueForProperty("AuthenticationIdentityInputApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputObjectId = (string) content.GetValueForProperty("AuthenticationIdentityInputObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputAadAuthority = (string) content.GetValueForProperty("ResourceAccessIdentityInputAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputAadAuthority = (string) content.GetValueForProperty("AuthenticationIdentityInputAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputTenantId = (string) content.GetValueForProperty("ResourceAccessIdentityInputTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputApplicationId = (string) content.GetValueForProperty("ResourceAccessIdentityInputApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputObjectId = (string) content.GetValueForProperty("ResourceAccessIdentityInputObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputAudience = (string) content.GetValueForProperty("ResourceAccessIdentityInputAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).ResourceAccessIdentityInputAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputAudience = (string) content.GetValueForProperty("AuthenticationIdentityInputAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInputInternal)this).AuthenticationIdentityInputAudience, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AddRecoveryServicesProviderInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInput"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInput DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AddRecoveryServicesProviderInput(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AddRecoveryServicesProviderInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInput"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInput DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AddRecoveryServicesProviderInput(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AddRecoveryServicesProviderInput" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAddRecoveryServicesProviderInput FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Input required to add a provider.
    [System.ComponentModel.TypeConverter(typeof(AddRecoveryServicesProviderInputTypeConverter))]
    public partial interface IAddRecoveryServicesProviderInput

    {

    }
}