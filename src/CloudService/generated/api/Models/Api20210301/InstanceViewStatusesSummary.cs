namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Instance view statuses.</summary>
    public partial class InstanceViewStatusesSummary :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceViewStatusesSummary,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceViewStatusesSummaryInternal
    {

        /// <summary>Internal Acessors for StatusesSummary</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IStatusCodeCount[] Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceViewStatusesSummaryInternal.StatusesSummary { get => this._statusesSummary; set { {_statusesSummary = value;} } }

        /// <summary>Backing field for <see cref="StatusesSummary" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IStatusCodeCount[] _statusesSummary;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IStatusCodeCount[] StatusesSummary { get => this._statusesSummary; }

        /// <summary>Creates an new <see cref="InstanceViewStatusesSummary" /> instance.</summary>
        public InstanceViewStatusesSummary()
        {

        }
    }
    /// Instance view statuses.
    public partial interface IInstanceViewStatusesSummary :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"statusesSummary",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IStatusCodeCount) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IStatusCodeCount[] StatusesSummary { get;  }

    }
    /// Instance view statuses.
    internal partial interface IInstanceViewStatusesSummaryInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IStatusCodeCount[] StatusesSummary { get; set; }

    }
}