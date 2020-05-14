namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>TriggeredJobHistory resource specific properties</summary>
    public partial class TriggeredJobHistoryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobHistoryProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobHistoryPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Run" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRun[] _run;

        /// <summary>List of triggered web job runs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRun[] Run { get => this._run; set => this._run = value; }

        /// <summary>Creates an new <see cref="TriggeredJobHistoryProperties" /> instance.</summary>
        public TriggeredJobHistoryProperties()
        {

        }
    }
    /// TriggeredJobHistory resource specific properties
    public partial interface ITriggeredJobHistoryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>List of triggered web job runs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of triggered web job runs.",
        SerializedName = @"runs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRun) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRun[] Run { get; set; }

    }
    /// TriggeredJobHistory resource specific properties
    internal partial interface ITriggeredJobHistoryPropertiesInternal

    {
        /// <summary>List of triggered web job runs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRun[] Run { get; set; }

    }
}