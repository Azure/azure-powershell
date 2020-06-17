namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>
    /// The list of user identities associated with the image template. The user identity dictionary key references will be ARM
    /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    /// </summary>
    public partial class ImageTemplateIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentityUserAssignedIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentityUserAssignedIdentitiesInternal
    {

        /// <summary>
        /// Creates an new <see cref="ImageTemplateIdentityUserAssignedIdentities" /> instance.
        /// </summary>
        public ImageTemplateIdentityUserAssignedIdentities()
        {

        }
    }
    /// The list of user identities associated with the image template. The user identity dictionary key references will be ARM
    /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    public partial interface IImageTemplateIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IComponentsVrq145SchemasImagetemplateidentityPropertiesUserassignedidentitiesAdditionalproperties>
    {

    }
    /// The list of user identities associated with the image template. The user identity dictionary key references will be ARM
    /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    public partial interface IImageTemplateIdentityUserAssignedIdentitiesInternal

    {

    }
}