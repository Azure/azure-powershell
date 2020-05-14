namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Specifies the web app that snapshot contents will be retrieved from.</summary>
    public partial class SnapshotRecoverySource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySourceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>
        /// ARM resource ID of the source app.
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Geographical location of the source web app, e.g. SouthEastAsia, SouthCentralUS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Creates an new <see cref="SnapshotRecoverySource" /> instance.</summary>
        public SnapshotRecoverySource()
        {

        }
    }
    /// Specifies the web app that snapshot contents will be retrieved from.
    public partial interface ISnapshotRecoverySource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// ARM resource ID of the source app.
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ARM resource ID of the source app.
        /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and
        /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Geographical location of the source web app, e.g. SouthEastAsia, SouthCentralUS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Geographical location of the source web app, e.g. SouthEastAsia, SouthCentralUS",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }

    }
    /// Specifies the web app that snapshot contents will be retrieved from.
    internal partial interface ISnapshotRecoverySourceInternal

    {
        /// <summary>
        /// ARM resource ID of the source app.
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        string Id { get; set; }
        /// <summary>Geographical location of the source web app, e.g. SouthEastAsia, SouthCentralUS</summary>
        string Location { get; set; }

    }
}