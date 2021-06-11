namespace Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataDog.Runtime.Extensions;

    /// <summary>
    /// The set of properties that can be update in a PATCH request to a monitor resource.
    /// </summary>
    public partial class MonitorUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301.IMonitorUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301.IMonitorUpdatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="MonitoringStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataDog.Support.MonitoringStatus? _monitoringStatus;

        /// <summary>Flag specifying if the resource monitoring is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataDog.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataDog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataDog.Support.MonitoringStatus? MonitoringStatus { get => this._monitoringStatus; set => this._monitoringStatus = value; }

        /// <summary>Creates an new <see cref="MonitorUpdateProperties" /> instance.</summary>
        public MonitorUpdateProperties()
        {

        }
    }
    /// The set of properties that can be update in a PATCH request to a monitor resource.
    public partial interface IMonitorUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Runtime.IJsonSerializable
    {
        /// <summary>Flag specifying if the resource monitoring is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataDog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag specifying if the resource monitoring is enabled or disabled.",
        SerializedName = @"monitoringStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataDog.Support.MonitoringStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Support.MonitoringStatus? MonitoringStatus { get; set; }

    }
    /// The set of properties that can be update in a PATCH request to a monitor resource.
    internal partial interface IMonitorUpdatePropertiesInternal

    {
        /// <summary>Flag specifying if the resource monitoring is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Support.MonitoringStatus? MonitoringStatus { get; set; }

    }
}