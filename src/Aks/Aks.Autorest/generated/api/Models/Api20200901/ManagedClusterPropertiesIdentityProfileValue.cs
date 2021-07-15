namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    public partial class ManagedClusterPropertiesIdentityProfileValue :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesIdentityProfileValue,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesIdentityProfileValueInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentity"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentity __userAssignedIdentity = new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.UserAssignedIdentity();

        /// <summary>The client id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string ClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal)__userAssignedIdentity).ClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal)__userAssignedIdentity).ClientId = value ?? null; }

        /// <summary>The object id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string ObjectId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal)__userAssignedIdentity).ObjectId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal)__userAssignedIdentity).ObjectId = value ?? null; }

        /// <summary>The resource id of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string ResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal)__userAssignedIdentity).ResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal)__userAssignedIdentity).ResourceId = value ?? null; }

        /// <summary>
        /// Creates an new <see cref="ManagedClusterPropertiesIdentityProfileValue" /> instance.
        /// </summary>
        public ManagedClusterPropertiesIdentityProfileValue()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__userAssignedIdentity), __userAssignedIdentity);
            await eventListener.AssertObjectIsValid(nameof(__userAssignedIdentity), __userAssignedIdentity);
        }
    }
    public partial interface IManagedClusterPropertiesIdentityProfileValue :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentity
    {

    }
    internal partial interface IManagedClusterPropertiesIdentityProfileValueInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentityInternal
    {

    }
}