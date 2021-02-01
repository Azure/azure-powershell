namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Specifying the claims to be included in a token.</summary>
    public partial class OptionalClaim :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimInternal
    {

        /// <summary>Backing field for <see cref="AdditionalProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimAdditionalProperties _additionalProperty;

        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimAdditionalProperties AdditionalProperty { get => (this._additionalProperty = this._additionalProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaimAdditionalProperties()); set => this._additionalProperty = value; }

        /// <summary>Backing field for <see cref="Essential" /> property.</summary>
        private bool? _essential;

        /// <summary>Is this a required claim.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? Essential { get => this._essential; set => this._essential = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Claim name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private string _source;

        /// <summary>Claim source.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Source { get => this._source; set => this._source = value; }

        /// <summary>Creates an new <see cref="OptionalClaim" /> instance.</summary>
        public OptionalClaim()
        {

        }
    }
    /// Specifying the claims to be included in a token.
    public partial interface IOptionalClaim :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"additionalProperties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimAdditionalProperties) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimAdditionalProperties AdditionalProperty { get; set; }
        /// <summary>Is this a required claim.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Is this a required claim.",
        SerializedName = @"essential",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Essential { get; set; }
        /// <summary>Claim name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Claim name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Claim source.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Claim source.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        string Source { get; set; }

    }
    /// Specifying the claims to be included in a token.
    internal partial interface IOptionalClaimInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimAdditionalProperties AdditionalProperty { get; set; }
        /// <summary>Is this a required claim.</summary>
        bool? Essential { get; set; }
        /// <summary>Claim name.</summary>
        string Name { get; set; }
        /// <summary>Claim source.</summary>
        string Source { get; set; }

    }
}