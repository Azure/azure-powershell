namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Publishing options for requested profile.</summary>
    public partial class CsmPublishingProfileOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptions,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptionsInternal
    {

        /// <summary>Backing field for <see cref="Format" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublishingProfileFormat? _format;

        /// <summary>
        /// Name of the format. Valid values are:
        /// FileZilla3
        /// WebDeploy -- default
        /// Ftp
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublishingProfileFormat? Format { get => this._format; set => this._format = value; }

        /// <summary>Backing field for <see cref="IncludeDisasterRecoveryEndpoint" /> property.</summary>
        private bool? _includeDisasterRecoveryEndpoint;

        /// <summary>Include the DisasterRecover endpoint if true</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IncludeDisasterRecoveryEndpoint { get => this._includeDisasterRecoveryEndpoint; set => this._includeDisasterRecoveryEndpoint = value; }

        /// <summary>Creates an new <see cref="CsmPublishingProfileOptions" /> instance.</summary>
        public CsmPublishingProfileOptions()
        {

        }
    }
    /// Publishing options for requested profile.
    public partial interface ICsmPublishingProfileOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Name of the format. Valid values are:
        /// FileZilla3
        /// WebDeploy -- default
        /// Ftp
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the format. Valid values are:
        FileZilla3
        WebDeploy -- default
        Ftp",
        SerializedName = @"format",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublishingProfileFormat) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublishingProfileFormat? Format { get; set; }
        /// <summary>Include the DisasterRecover endpoint if true</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Include the DisasterRecover endpoint if true",
        SerializedName = @"includeDisasterRecoveryEndpoints",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IncludeDisasterRecoveryEndpoint { get; set; }

    }
    /// Publishing options for requested profile.
    internal partial interface ICsmPublishingProfileOptionsInternal

    {
        /// <summary>
        /// Name of the format. Valid values are:
        /// FileZilla3
        /// WebDeploy -- default
        /// Ftp
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublishingProfileFormat? Format { get; set; }
        /// <summary>Include the DisasterRecover endpoint if true</summary>
        bool? IncludeDisasterRecoveryEndpoint { get; set; }

    }
}