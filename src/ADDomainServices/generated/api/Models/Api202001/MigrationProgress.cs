namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Migration Progress</summary>
    public partial class MigrationProgress :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgress,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgressInternal
    {

        /// <summary>Backing field for <see cref="CompletionPercentage" /> property.</summary>
        private double? _completionPercentage;

        /// <summary>Completion Percentage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public double? CompletionPercentage { get => this._completionPercentage; set => this._completionPercentage = value; }

        /// <summary>Backing field for <see cref="ProgressMessage" /> property.</summary>
        private string _progressMessage;

        /// <summary>Progress Message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string ProgressMessage { get => this._progressMessage; set => this._progressMessage = value; }

        /// <summary>Creates an new <see cref="MigrationProgress" /> instance.</summary>
        public MigrationProgress()
        {

        }
    }
    /// Migration Progress
    public partial interface IMigrationProgress :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IJsonSerializable
    {
        /// <summary>Completion Percentage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Completion Percentage",
        SerializedName = @"completionPercentage",
        PossibleTypes = new [] { typeof(double) })]
        double? CompletionPercentage { get; set; }
        /// <summary>Progress Message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Progress Message",
        SerializedName = @"progressMessage",
        PossibleTypes = new [] { typeof(string) })]
        string ProgressMessage { get; set; }

    }
    /// Migration Progress
    internal partial interface IMigrationProgressInternal

    {
        /// <summary>Completion Percentage</summary>
        double? CompletionPercentage { get; set; }
        /// <summary>Progress Message</summary>
        string ProgressMessage { get; set; }

    }
}