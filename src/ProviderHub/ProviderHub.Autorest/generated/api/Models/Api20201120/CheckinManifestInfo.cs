namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class CheckinManifestInfo :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckinManifestInfo,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckinManifestInfoInternal
    {

        /// <summary>Backing field for <see cref="CommitId" /> property.</summary>
        private string _commitId;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string CommitId { get => this._commitId; set => this._commitId = value; }

        /// <summary>Backing field for <see cref="IsCheckedIn" /> property.</summary>
        private bool _isCheckedIn;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public bool IsCheckedIn { get => this._isCheckedIn; set => this._isCheckedIn = value; }

        /// <summary>Backing field for <see cref="PullRequest" /> property.</summary>
        private string _pullRequest;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string PullRequest { get => this._pullRequest; set => this._pullRequest = value; }

        /// <summary>Backing field for <see cref="StatusMessage" /> property.</summary>
        private string _statusMessage;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string StatusMessage { get => this._statusMessage; set => this._statusMessage = value; }

        /// <summary>Creates an new <see cref="CheckinManifestInfo" /> instance.</summary>
        public CheckinManifestInfo()
        {

        }
    }
    public partial interface ICheckinManifestInfo :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"commitId",
        PossibleTypes = new [] { typeof(string) })]
        string CommitId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"isCheckedIn",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsCheckedIn { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"pullRequest",
        PossibleTypes = new [] { typeof(string) })]
        string PullRequest { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"statusMessage",
        PossibleTypes = new [] { typeof(string) })]
        string StatusMessage { get; set; }

    }
    internal partial interface ICheckinManifestInfoInternal

    {
        string CommitId { get; set; }

        bool IsCheckedIn { get; set; }

        string PullRequest { get; set; }

        string StatusMessage { get; set; }

    }
}