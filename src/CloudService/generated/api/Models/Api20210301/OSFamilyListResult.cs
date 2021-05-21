namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    public partial class OSFamilyListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyListResult,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamily[] _value;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamily[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OSFamilyListResult" /> instance.</summary>
        public OSFamilyListResult()
        {

        }
    }
    public partial interface IOSFamilyListResult :
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamily) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamily[] Value { get; set; }

    }
    internal partial interface IOSFamilyListResultInternal

    {
        string NextLink { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamily[] Value { get; set; }

    }
}