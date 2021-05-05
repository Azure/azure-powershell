namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    public partial class CloudServiceRoleListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleListResult,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRole[] _value;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRole[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="CloudServiceRoleListResult" /> instance.</summary>
        public CloudServiceRoleListResult()
        {

        }
    }
    public partial interface ICloudServiceRoleListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRole) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRole[] Value { get; set; }

    }
    internal partial interface ICloudServiceRoleListResultInternal

    {
        string NextLink { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRole[] Value { get; set; }

    }
}