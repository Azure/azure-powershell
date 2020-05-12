namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Site seal request.</summary>
    public partial class SiteSealRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteSealRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteSealRequestInternal
    {

        /// <summary>Backing field for <see cref="LightTheme" /> property.</summary>
        private bool? _lightTheme;

        /// <summary>
        /// If <code>true</code> use the light color theme for site seal; otherwise, use the default color theme.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? LightTheme { get => this._lightTheme; set => this._lightTheme = value; }

        /// <summary>Backing field for <see cref="Locale" /> property.</summary>
        private string _locale;

        /// <summary>Locale of site seal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Locale { get => this._locale; set => this._locale = value; }

        /// <summary>Creates an new <see cref="SiteSealRequest" /> instance.</summary>
        public SiteSealRequest()
        {

        }
    }
    /// Site seal request.
    public partial interface ISiteSealRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// If <code>true</code> use the light color theme for site seal; otherwise, use the default color theme.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If <code>true</code> use the light color theme for site seal; otherwise, use the default color theme.",
        SerializedName = @"lightTheme",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LightTheme { get; set; }
        /// <summary>Locale of site seal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Locale of site seal.",
        SerializedName = @"locale",
        PossibleTypes = new [] { typeof(string) })]
        string Locale { get; set; }

    }
    /// Site seal request.
    internal partial interface ISiteSealRequestInternal

    {
        /// <summary>
        /// If <code>true</code> use the light color theme for site seal; otherwise, use the default color theme.
        /// </summary>
        bool? LightTheme { get; set; }
        /// <summary>Locale of site seal.</summary>
        string Locale { get; set; }

    }
}