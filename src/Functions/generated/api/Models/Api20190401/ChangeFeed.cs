namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The blob service properties for change feed events.</summary>
    public partial class ChangeFeed :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IChangeFeed,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IChangeFeedInternal
    {

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>Indicates whether change feed event logging is enabled for the Blob service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Creates an new <see cref="ChangeFeed" /> instance.</summary>
        public ChangeFeed()
        {

        }
    }
    /// The blob service properties for change feed events.
    public partial interface IChangeFeed :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Indicates whether change feed event logging is enabled for the Blob service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether change feed event logging is enabled for the Blob service.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }

    }
    /// The blob service properties for change feed events.
    internal partial interface IChangeFeedInternal

    {
        /// <summary>Indicates whether change feed event logging is enabled for the Blob service.</summary>
        bool? Enabled { get; set; }

    }
}