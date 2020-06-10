namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Legal agreement for a top level domain.</summary>
    public partial class TldLegalAgreement :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITldLegalAgreement,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITldLegalAgreementInternal
    {

        /// <summary>Backing field for <see cref="AgreementKey" /> property.</summary>
        private string _agreementKey;

        /// <summary>Unique identifier for the agreement.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AgreementKey { get => this._agreementKey; set => this._agreementKey = value; }

        /// <summary>Backing field for <see cref="Content" /> property.</summary>
        private string _content;

        /// <summary>Agreement details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Content { get => this._content; set => this._content = value; }

        /// <summary>Backing field for <see cref="Title" /> property.</summary>
        private string _title;

        /// <summary>Agreement title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Title { get => this._title; set => this._title = value; }

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>URL where a copy of the agreement details is hosted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Url { get => this._url; set => this._url = value; }

        /// <summary>Creates an new <see cref="TldLegalAgreement" /> instance.</summary>
        public TldLegalAgreement()
        {

        }
    }
    /// Legal agreement for a top level domain.
    public partial interface ITldLegalAgreement :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Unique identifier for the agreement.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Unique identifier for the agreement.",
        SerializedName = @"agreementKey",
        PossibleTypes = new [] { typeof(string) })]
        string AgreementKey { get; set; }
        /// <summary>Agreement details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Agreement details.",
        SerializedName = @"content",
        PossibleTypes = new [] { typeof(string) })]
        string Content { get; set; }
        /// <summary>Agreement title.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Agreement title.",
        SerializedName = @"title",
        PossibleTypes = new [] { typeof(string) })]
        string Title { get; set; }
        /// <summary>URL where a copy of the agreement details is hosted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL where a copy of the agreement details is hosted.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get; set; }

    }
    /// Legal agreement for a top level domain.
    internal partial interface ITldLegalAgreementInternal

    {
        /// <summary>Unique identifier for the agreement.</summary>
        string AgreementKey { get; set; }
        /// <summary>Agreement details.</summary>
        string Content { get; set; }
        /// <summary>Agreement title.</summary>
        string Title { get; set; }
        /// <summary>URL where a copy of the agreement details is hosted.</summary>
        string Url { get; set; }

    }
}