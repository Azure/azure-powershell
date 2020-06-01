namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Application stack major version.</summary>
    public partial class StackMajorVersion :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal
    {

        /// <summary>Backing field for <see cref="ApplicationInsight" /> property.</summary>
        private bool? _applicationInsight;

        /// <summary>
        /// <code>true</code> if this supports Application Insights; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ApplicationInsight { get => this._applicationInsight; set => this._applicationInsight = value; }

        /// <summary>Backing field for <see cref="DisplayVersion" /> property.</summary>
        private string _displayVersion;

        /// <summary>Application stack major version (display only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayVersion { get => this._displayVersion; set => this._displayVersion = value; }

        /// <summary>Backing field for <see cref="IsDefault" /> property.</summary>
        private bool? _isDefault;

        /// <summary>
        /// <code>true</code> if this is the default major version; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsDefault { get => this._isDefault; set => this._isDefault = value; }

        /// <summary>Backing field for <see cref="IsDeprecated" /> property.</summary>
        private bool? _isDeprecated;

        /// <summary>
        /// <code>true</code> if this stack has been deprecated, otherwise <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsDeprecated { get => this._isDeprecated; set => this._isDeprecated = value; }

        /// <summary>Backing field for <see cref="IsHidden" /> property.</summary>
        private bool? _isHidden;

        /// <summary>
        /// <code>true</code> if this stack should be hidden for new customers on portal, otherwise <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsHidden { get => this._isHidden; set => this._isHidden = value; }

        /// <summary>Backing field for <see cref="IsPreview" /> property.</summary>
        private bool? _isPreview;

        /// <summary><code>true</code> if this stack is in Preview, otherwise <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsPreview { get => this._isPreview; set => this._isPreview = value; }

        /// <summary>Backing field for <see cref="MinorVersion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMinorVersion[] _minorVersion;

        /// <summary>Minor versions associated with the major version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMinorVersion[] MinorVersion { get => this._minorVersion; set => this._minorVersion = value; }

        /// <summary>Backing field for <see cref="RuntimeVersion" /> property.</summary>
        private string _runtimeVersion;

        /// <summary>Application stack major version (runtime only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RuntimeVersion { get => this._runtimeVersion; set => this._runtimeVersion = value; }

        /// <summary>Creates an new <see cref="StackMajorVersion" /> instance.</summary>
        public StackMajorVersion()
        {

        }
    }
    /// Application stack major version.
    public partial interface IStackMajorVersion :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// <code>true</code> if this supports Application Insights; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if this supports Application Insights; otherwise, <code>false</code>.",
        SerializedName = @"applicationInsights",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ApplicationInsight { get; set; }
        /// <summary>Application stack major version (display only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application stack major version (display only).",
        SerializedName = @"displayVersion",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayVersion { get; set; }
        /// <summary>
        /// <code>true</code> if this is the default major version; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if this is the default major version; otherwise, <code>false</code>.",
        SerializedName = @"isDefault",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDefault { get; set; }
        /// <summary>
        /// <code>true</code> if this stack has been deprecated, otherwise <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if this stack has been deprecated, otherwise <code>false</code>.",
        SerializedName = @"isDeprecated",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDeprecated { get; set; }
        /// <summary>
        /// <code>true</code> if this stack should be hidden for new customers on portal, otherwise <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if this stack should be hidden for new customers on portal, otherwise <code>false</code>.",
        SerializedName = @"isHidden",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsHidden { get; set; }
        /// <summary><code>true</code> if this stack is in Preview, otherwise <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if this stack is in Preview, otherwise <code>false</code>.",
        SerializedName = @"isPreview",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsPreview { get; set; }
        /// <summary>Minor versions associated with the major version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minor versions associated with the major version.",
        SerializedName = @"minorVersions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMinorVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMinorVersion[] MinorVersion { get; set; }
        /// <summary>Application stack major version (runtime only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application stack major version (runtime only).",
        SerializedName = @"runtimeVersion",
        PossibleTypes = new [] { typeof(string) })]
        string RuntimeVersion { get; set; }

    }
    /// Application stack major version.
    internal partial interface IStackMajorVersionInternal

    {
        /// <summary>
        /// <code>true</code> if this supports Application Insights; otherwise, <code>false</code>.
        /// </summary>
        bool? ApplicationInsight { get; set; }
        /// <summary>Application stack major version (display only).</summary>
        string DisplayVersion { get; set; }
        /// <summary>
        /// <code>true</code> if this is the default major version; otherwise, <code>false</code>.
        /// </summary>
        bool? IsDefault { get; set; }
        /// <summary>
        /// <code>true</code> if this stack has been deprecated, otherwise <code>false</code>.
        /// </summary>
        bool? IsDeprecated { get; set; }
        /// <summary>
        /// <code>true</code> if this stack should be hidden for new customers on portal, otherwise <code>false</code>.
        /// </summary>
        bool? IsHidden { get; set; }
        /// <summary><code>true</code> if this stack is in Preview, otherwise <code>false</code>.</summary>
        bool? IsPreview { get; set; }
        /// <summary>Minor versions associated with the major version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMinorVersion[] MinorVersion { get; set; }
        /// <summary>Application stack major version (runtime only).</summary>
        string RuntimeVersion { get; set; }

    }
}