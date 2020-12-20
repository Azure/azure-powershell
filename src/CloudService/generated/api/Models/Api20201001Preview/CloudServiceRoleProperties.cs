namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    public partial class CloudServiceRoleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceRoleProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceRolePropertiesInternal
    {

        /// <summary>Internal Acessors for UniqueId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceRolePropertiesInternal.UniqueId { get => this._uniqueId; set { {_uniqueId = value;} } }

        /// <summary>Backing field for <see cref="UniqueId" /> property.</summary>
        private string _uniqueId;

        /// <summary>Specifies the ID which uniquely identifies a cloud service role.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string UniqueId { get => this._uniqueId; }

        /// <summary>Creates an new <see cref="CloudServiceRoleProperties" /> instance.</summary>
        public CloudServiceRoleProperties()
        {

        }
    }
    public partial interface ICloudServiceRoleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>Specifies the ID which uniquely identifies a cloud service role.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the ID which uniquely identifies a cloud service role.",
        SerializedName = @"uniqueId",
        PossibleTypes = new [] { typeof(string) })]
        string UniqueId { get;  }

    }
    internal partial interface ICloudServiceRolePropertiesInternal

    {
        /// <summary>Specifies the ID which uniquely identifies a cloud service role.</summary>
        string UniqueId { get; set; }

    }
}