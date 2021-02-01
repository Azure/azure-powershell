namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>
    /// Represents a group of URIs that provide terms of service, marketing, support and privacy policy information about an application.
    /// The default value for each string is null.
    /// </summary>
    public partial class InformationalUrl :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrl,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrlInternal
    {

        /// <summary>Backing field for <see cref="Marketing" /> property.</summary>
        private string _marketing;

        /// <summary>The marketing URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Marketing { get => this._marketing; set => this._marketing = value; }

        /// <summary>Backing field for <see cref="Privacy" /> property.</summary>
        private string _privacy;

        /// <summary>The privacy policy URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Privacy { get => this._privacy; set => this._privacy = value; }

        /// <summary>Backing field for <see cref="Support" /> property.</summary>
        private string _support;

        /// <summary>The support URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Support { get => this._support; set => this._support = value; }

        /// <summary>Backing field for <see cref="TermsOfService" /> property.</summary>
        private string _termsOfService;

        /// <summary>The terms of service URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string TermsOfService { get => this._termsOfService; set => this._termsOfService = value; }

        /// <summary>Creates an new <see cref="InformationalUrl" /> instance.</summary>
        public InformationalUrl()
        {

        }
    }
    /// Represents a group of URIs that provide terms of service, marketing, support and privacy policy information about an application.
    /// The default value for each string is null.
    public partial interface IInformationalUrl :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>The marketing URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The marketing URI",
        SerializedName = @"marketing",
        PossibleTypes = new [] { typeof(string) })]
        string Marketing { get; set; }
        /// <summary>The privacy policy URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The privacy policy URI",
        SerializedName = @"privacy",
        PossibleTypes = new [] { typeof(string) })]
        string Privacy { get; set; }
        /// <summary>The support URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The support URI",
        SerializedName = @"support",
        PossibleTypes = new [] { typeof(string) })]
        string Support { get; set; }
        /// <summary>The terms of service URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The terms of service URI",
        SerializedName = @"termsOfService",
        PossibleTypes = new [] { typeof(string) })]
        string TermsOfService { get; set; }

    }
    /// Represents a group of URIs that provide terms of service, marketing, support and privacy policy information about an application.
    /// The default value for each string is null.
    internal partial interface IInformationalUrlInternal

    {
        /// <summary>The marketing URI</summary>
        string Marketing { get; set; }
        /// <summary>The privacy policy URI</summary>
        string Privacy { get; set; }
        /// <summary>The support URI</summary>
        string Support { get; set; }
        /// <summary>The terms of service URI</summary>
        string TermsOfService { get; set; }

    }
}