namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Domain recommendation search parameters.</summary>
    public partial class DomainRecommendationSearchParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainRecommendationSearchParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainRecommendationSearchParametersInternal
    {

        /// <summary>Backing field for <see cref="Keyword" /> property.</summary>
        private string _keyword;

        /// <summary>Keywords to be used for generating domain recommendations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Keyword { get => this._keyword; set => this._keyword = value; }

        /// <summary>Backing field for <see cref="MaxDomainRecommendation" /> property.</summary>
        private int? _maxDomainRecommendation;

        /// <summary>Maximum number of recommendations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? MaxDomainRecommendation { get => this._maxDomainRecommendation; set => this._maxDomainRecommendation = value; }

        /// <summary>Creates an new <see cref="DomainRecommendationSearchParameters" /> instance.</summary>
        public DomainRecommendationSearchParameters()
        {

        }
    }
    /// Domain recommendation search parameters.
    public partial interface IDomainRecommendationSearchParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Keywords to be used for generating domain recommendations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Keywords to be used for generating domain recommendations.",
        SerializedName = @"keywords",
        PossibleTypes = new [] { typeof(string) })]
        string Keyword { get; set; }
        /// <summary>Maximum number of recommendations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of recommendations.",
        SerializedName = @"maxDomainRecommendations",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxDomainRecommendation { get; set; }

    }
    /// Domain recommendation search parameters.
    internal partial interface IDomainRecommendationSearchParametersInternal

    {
        /// <summary>Keywords to be used for generating domain recommendations.</summary>
        string Keyword { get; set; }
        /// <summary>Maximum number of recommendations.</summary>
        int? MaxDomainRecommendation { get; set; }

    }
}