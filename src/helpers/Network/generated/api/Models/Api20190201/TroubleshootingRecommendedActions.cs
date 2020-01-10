namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Recommended actions based on discovered issues.</summary>
    public partial class TroubleshootingRecommendedActions :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingRecommendedActions,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingRecommendedActionsInternal
    {

        /// <summary>Backing field for <see cref="ActionId" /> property.</summary>
        private string _actionId;

        /// <summary>ID of the recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ActionId { get => this._actionId; set => this._actionId = value; }

        /// <summary>Backing field for <see cref="ActionText" /> property.</summary>
        private string _actionText;

        /// <summary>Description of recommended actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ActionText { get => this._actionText; set => this._actionText = value; }

        /// <summary>Backing field for <see cref="ActionUri" /> property.</summary>
        private string _actionUri;

        /// <summary>The uri linking to a documentation for the recommended troubleshooting actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ActionUri { get => this._actionUri; set => this._actionUri = value; }

        /// <summary>Backing field for <see cref="ActionUriText" /> property.</summary>
        private string _actionUriText;

        /// <summary>The information from the URI for the recommended troubleshooting actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ActionUriText { get => this._actionUriText; set => this._actionUriText = value; }

        /// <summary>Creates an new <see cref="TroubleshootingRecommendedActions" /> instance.</summary>
        public TroubleshootingRecommendedActions()
        {

        }
    }
    /// Recommended actions based on discovered issues.
    public partial interface ITroubleshootingRecommendedActions :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>ID of the recommended action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ID of the recommended action.",
        SerializedName = @"actionId",
        PossibleTypes = new [] { typeof(string) })]
        string ActionId { get; set; }
        /// <summary>Description of recommended actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of recommended actions.",
        SerializedName = @"actionText",
        PossibleTypes = new [] { typeof(string) })]
        string ActionText { get; set; }
        /// <summary>The uri linking to a documentation for the recommended troubleshooting actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The uri linking to a documentation for the recommended troubleshooting actions.",
        SerializedName = @"actionUri",
        PossibleTypes = new [] { typeof(string) })]
        string ActionUri { get; set; }
        /// <summary>The information from the URI for the recommended troubleshooting actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The information from the URI for the recommended troubleshooting actions.",
        SerializedName = @"actionUriText",
        PossibleTypes = new [] { typeof(string) })]
        string ActionUriText { get; set; }

    }
    /// Recommended actions based on discovered issues.
    internal partial interface ITroubleshootingRecommendedActionsInternal

    {
        /// <summary>ID of the recommended action.</summary>
        string ActionId { get; set; }
        /// <summary>Description of recommended actions.</summary>
        string ActionText { get; set; }
        /// <summary>The uri linking to a documentation for the recommended troubleshooting actions.</summary>
        string ActionUri { get; set; }
        /// <summary>The information from the URI for the recommended troubleshooting actions.</summary>
        string ActionUriText { get; set; }

    }
}