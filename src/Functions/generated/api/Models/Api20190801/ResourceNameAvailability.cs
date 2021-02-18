namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Information regarding availability of a resource name.</summary>
    public partial class ResourceNameAvailability :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceNameAvailability,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceNameAvailabilityInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>
        /// If reason == invalid, provide the user with the reason why the given name is invalid, and provide the resource naming
        /// requirements so that the user can select a valid name. If reason == AlreadyExists, explain that resource name is already
        /// in use, and direct them to select a different name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="NameAvailable" /> property.</summary>
        private bool? _nameAvailable;

        /// <summary>
        /// <code>true</code> indicates name is valid and available. <code>false</code> indicates the name is invalid, unavailable,
        /// or both.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? NameAvailable { get => this._nameAvailable; set => this._nameAvailable = value; }

        /// <summary>Backing field for <see cref="Reason" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InAvailabilityReasonType? _reason;

        /// <summary>
        /// <code>Invalid</code> indicates the name provided does not match Azure App Service naming requirements. <code>AlreadyExists</code>
        /// indicates that the name is already in use and is therefore unavailable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InAvailabilityReasonType? Reason { get => this._reason; set => this._reason = value; }

        /// <summary>Creates an new <see cref="ResourceNameAvailability" /> instance.</summary>
        public ResourceNameAvailability()
        {

        }
    }
    /// Information regarding availability of a resource name.
    public partial interface IResourceNameAvailability :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// If reason == invalid, provide the user with the reason why the given name is invalid, and provide the resource naming
        /// requirements so that the user can select a valid name. If reason == AlreadyExists, explain that resource name is already
        /// in use, and direct them to select a different name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If reason == invalid, provide the user with the reason why the given name is invalid, and provide the resource naming requirements so that the user can select a valid name. If reason == AlreadyExists, explain that resource name is already in use, and direct them to select a different name.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>
        /// <code>true</code> indicates name is valid and available. <code>false</code> indicates the name is invalid, unavailable,
        /// or both.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> indicates name is valid and available. <code>false</code> indicates the name is invalid, unavailable, or both.",
        SerializedName = @"nameAvailable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? NameAvailable { get; set; }
        /// <summary>
        /// <code>Invalid</code> indicates the name provided does not match Azure App Service naming requirements. <code>AlreadyExists</code>
        /// indicates that the name is already in use and is therefore unavailable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>Invalid</code> indicates the name provided does not match Azure App Service naming requirements. <code>AlreadyExists</code> indicates that the name is already in use and is therefore unavailable.",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InAvailabilityReasonType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InAvailabilityReasonType? Reason { get; set; }

    }
    /// Information regarding availability of a resource name.
    internal partial interface IResourceNameAvailabilityInternal

    {
        /// <summary>
        /// If reason == invalid, provide the user with the reason why the given name is invalid, and provide the resource naming
        /// requirements so that the user can select a valid name. If reason == AlreadyExists, explain that resource name is already
        /// in use, and direct them to select a different name.
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// <code>true</code> indicates name is valid and available. <code>false</code> indicates the name is invalid, unavailable,
        /// or both.
        /// </summary>
        bool? NameAvailable { get; set; }
        /// <summary>
        /// <code>Invalid</code> indicates the name provided does not match Azure App Service naming requirements. <code>AlreadyExists</code>
        /// indicates that the name is already in use and is therefore unavailable.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InAvailabilityReasonType? Reason { get; set; }

    }
}