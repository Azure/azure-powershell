namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Information gained from troubleshooting of specified resource.</summary>
    public partial class TroubleshootingDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingDetailsInternal
    {

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private string _detail;

        /// <summary>Details on troubleshooting results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The id of the get troubleshoot operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="ReasonType" /> property.</summary>
        private string _reasonType;

        /// <summary>Reason type of failure.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ReasonType { get => this._reasonType; set => this._reasonType = value; }

        /// <summary>Backing field for <see cref="RecommendedAction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingRecommendedActions[] _recommendedAction;

        /// <summary>List of recommended actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingRecommendedActions[] RecommendedAction { get => this._recommendedAction; set => this._recommendedAction = value; }

        /// <summary>Backing field for <see cref="Summary" /> property.</summary>
        private string _summary;

        /// <summary>A summary of troubleshooting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Summary { get => this._summary; set => this._summary = value; }

        /// <summary>Creates an new <see cref="TroubleshootingDetails" /> instance.</summary>
        public TroubleshootingDetails()
        {

        }
    }
    /// Information gained from troubleshooting of specified resource.
    public partial interface ITroubleshootingDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Details on troubleshooting results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Details on troubleshooting results.",
        SerializedName = @"detail",
        PossibleTypes = new [] { typeof(string) })]
        string Detail { get; set; }
        /// <summary>The id of the get troubleshoot operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The id of the get troubleshoot operation.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Reason type of failure.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Reason type of failure.",
        SerializedName = @"reasonType",
        PossibleTypes = new [] { typeof(string) })]
        string ReasonType { get; set; }
        /// <summary>List of recommended actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of recommended actions.",
        SerializedName = @"recommendedActions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingRecommendedActions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingRecommendedActions[] RecommendedAction { get; set; }
        /// <summary>A summary of troubleshooting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A summary of troubleshooting.",
        SerializedName = @"summary",
        PossibleTypes = new [] { typeof(string) })]
        string Summary { get; set; }

    }
    /// Information gained from troubleshooting of specified resource.
    internal partial interface ITroubleshootingDetailsInternal

    {
        /// <summary>Details on troubleshooting results.</summary>
        string Detail { get; set; }
        /// <summary>The id of the get troubleshoot operation.</summary>
        string Id { get; set; }
        /// <summary>Reason type of failure.</summary>
        string ReasonType { get; set; }
        /// <summary>List of recommended actions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingRecommendedActions[] RecommendedAction { get; set; }
        /// <summary>A summary of troubleshooting.</summary>
        string Summary { get; set; }

    }
}