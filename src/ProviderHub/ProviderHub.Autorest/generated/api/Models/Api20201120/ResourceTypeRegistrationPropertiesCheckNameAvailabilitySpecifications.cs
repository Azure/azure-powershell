namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeRegistrationPropertiesCheckNameAvailabilitySpecifications :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesCheckNameAvailabilitySpecifications,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationPropertiesCheckNameAvailabilitySpecificationsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecifications"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecifications __checkNameAvailabilitySpecifications = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.CheckNameAvailabilitySpecifications();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public bool? EnableDefaultValidation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecificationsInternal)__checkNameAvailabilitySpecifications).EnableDefaultValidation; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecificationsInternal)__checkNameAvailabilitySpecifications).EnableDefaultValidation = value ?? default(bool); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string[] ResourceTypesWithCustomValidation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecificationsInternal)__checkNameAvailabilitySpecifications).ResourceTypesWithCustomValidation; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecificationsInternal)__checkNameAvailabilitySpecifications).ResourceTypesWithCustomValidation = value ?? null /* arrayOf */; }

        /// <summary>
        /// Creates an new <see cref="ResourceTypeRegistrationPropertiesCheckNameAvailabilitySpecifications" /> instance.
        /// </summary>
        public ResourceTypeRegistrationPropertiesCheckNameAvailabilitySpecifications()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__checkNameAvailabilitySpecifications), __checkNameAvailabilitySpecifications);
            await eventListener.AssertObjectIsValid(nameof(__checkNameAvailabilitySpecifications), __checkNameAvailabilitySpecifications);
        }
    }
    public partial interface IResourceTypeRegistrationPropertiesCheckNameAvailabilitySpecifications :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecifications
    {

    }
    internal partial interface IResourceTypeRegistrationPropertiesCheckNameAvailabilitySpecificationsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckNameAvailabilitySpecificationsInternal
    {

    }
}