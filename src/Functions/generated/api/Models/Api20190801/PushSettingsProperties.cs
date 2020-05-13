namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>PushSettings resource specific properties</summary>
    public partial class PushSettingsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DynamicTagsJson" /> property.</summary>
        private string _dynamicTagsJson;

        /// <summary>
        /// Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration
        /// endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DynamicTagsJson { get => this._dynamicTagsJson; set => this._dynamicTagsJson = value; }

        /// <summary>Backing field for <see cref="IsPushEnabled" /> property.</summary>
        private bool _isPushEnabled;

        /// <summary>Gets or sets a flag indicating whether the Push endpoint is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool IsPushEnabled { get => this._isPushEnabled; set => this._isPushEnabled = value; }

        /// <summary>Backing field for <see cref="TagWhitelistJson" /> property.</summary>
        private string _tagWhitelistJson;

        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TagWhitelistJson { get => this._tagWhitelistJson; set => this._tagWhitelistJson = value; }

        /// <summary>Backing field for <see cref="TagsRequiringAuth" /> property.</summary>
        private string _tagsRequiringAuth;

        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration
        /// endpoint.
        /// Tags can consist of alphanumeric characters and the following:
        /// '_', '@', '#', '.', ':', '-'.
        /// Validation should be performed at the PushRequestHandler.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TagsRequiringAuth { get => this._tagsRequiringAuth; set => this._tagsRequiringAuth = value; }

        /// <summary>Creates an new <see cref="PushSettingsProperties" /> instance.</summary>
        public PushSettingsProperties()
        {

        }
    }
    /// PushSettings resource specific properties
    public partial interface IPushSettingsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration
        /// endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.",
        SerializedName = @"dynamicTagsJson",
        PossibleTypes = new [] { typeof(string) })]
        string DynamicTagsJson { get; set; }
        /// <summary>Gets or sets a flag indicating whether the Push endpoint is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets a flag indicating whether the Push endpoint is enabled.",
        SerializedName = @"isPushEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsPushEnabled { get; set; }
        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.",
        SerializedName = @"tagWhitelistJson",
        PossibleTypes = new [] { typeof(string) })]
        string TagWhitelistJson { get; set; }
        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration
        /// endpoint.
        /// Tags can consist of alphanumeric characters and the following:
        /// '_', '@', '#', '.', ':', '-'.
        /// Validation should be performed at the PushRequestHandler.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.
        Tags can consist of alphanumeric characters and the following:
        '_', '@', '#', '.', ':', '-'.
        Validation should be performed at the PushRequestHandler.",
        SerializedName = @"tagsRequiringAuth",
        PossibleTypes = new [] { typeof(string) })]
        string TagsRequiringAuth { get; set; }

    }
    /// PushSettings resource specific properties
    internal partial interface IPushSettingsPropertiesInternal

    {
        /// <summary>
        /// Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration
        /// endpoint.
        /// </summary>
        string DynamicTagsJson { get; set; }
        /// <summary>Gets or sets a flag indicating whether the Push endpoint is enabled.</summary>
        bool IsPushEnabled { get; set; }
        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
        /// </summary>
        string TagWhitelistJson { get; set; }
        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration
        /// endpoint.
        /// Tags can consist of alphanumeric characters and the following:
        /// '_', '@', '#', '.', ':', '-'.
        /// Validation should be performed at the PushRequestHandler.
        /// </summary>
        string TagsRequiringAuth { get; set; }

    }
}