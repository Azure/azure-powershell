namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The secret volume.</summary>
    public partial class SecretVolume :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ISecretVolume,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ISecretVolumeInternal
    {

        /// <summary>Creates an new <see cref="SecretVolume" /> instance.</summary>
        public SecretVolume()
        {

        }
    }
    /// The secret volume.
    public partial interface ISecretVolume :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IAssociativeArray<string>
    {

    }
    /// The secret volume.
    internal partial interface ISecretVolumeInternal

    {

    }
}