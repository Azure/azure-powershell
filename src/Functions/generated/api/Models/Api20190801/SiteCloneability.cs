namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Represents whether or not an app is cloneable.</summary>
    public partial class SiteCloneability :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneability,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityInternal
    {

        /// <summary>Backing field for <see cref="BlockingCharacteristic" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion[] _blockingCharacteristic;

        /// <summary>List of blocking application characteristics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion[] BlockingCharacteristic { get => this._blockingCharacteristic; set => this._blockingCharacteristic = value; }

        /// <summary>Backing field for <see cref="BlockingFeature" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion[] _blockingFeature;

        /// <summary>List of features enabled on app that prevent cloning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion[] BlockingFeature { get => this._blockingFeature; set => this._blockingFeature = value; }

        /// <summary>Backing field for <see cref="Result" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CloneAbilityResult? _result;

        /// <summary>Name of app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CloneAbilityResult? Result { get => this._result; set => this._result = value; }

        /// <summary>Backing field for <see cref="UnsupportedFeature" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion[] _unsupportedFeature;

        /// <summary>
        /// List of features enabled on app that are non-blocking but cannot be cloned. The app can still be cloned
        /// but the features in this list will not be set up on cloned app.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion[] UnsupportedFeature { get => this._unsupportedFeature; set => this._unsupportedFeature = value; }

        /// <summary>Creates an new <see cref="SiteCloneability" /> instance.</summary>
        public SiteCloneability()
        {

        }
    }
    /// Represents whether or not an app is cloneable.
    public partial interface ISiteCloneability :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>List of blocking application characteristics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of blocking application characteristics.",
        SerializedName = @"blockingCharacteristics",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion[] BlockingCharacteristic { get; set; }
        /// <summary>List of features enabled on app that prevent cloning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of features enabled on app that prevent cloning.",
        SerializedName = @"blockingFeatures",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion[] BlockingFeature { get; set; }
        /// <summary>Name of app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of app.",
        SerializedName = @"result",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CloneAbilityResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CloneAbilityResult? Result { get; set; }
        /// <summary>
        /// List of features enabled on app that are non-blocking but cannot be cloned. The app can still be cloned
        /// but the features in this list will not be set up on cloned app.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of features enabled on app that are non-blocking but cannot be cloned. The app can still be cloned
        but the features in this list will not be set up on cloned app.",
        SerializedName = @"unsupportedFeatures",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion[] UnsupportedFeature { get; set; }

    }
    /// Represents whether or not an app is cloneable.
    internal partial interface ISiteCloneabilityInternal

    {
        /// <summary>List of blocking application characteristics.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion[] BlockingCharacteristic { get; set; }
        /// <summary>List of features enabled on app that prevent cloning.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion[] BlockingFeature { get; set; }
        /// <summary>Name of app.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CloneAbilityResult? Result { get; set; }
        /// <summary>
        /// List of features enabled on app that are non-blocking but cannot be cloned. The app can still be cloned
        /// but the features in this list will not be set up on cloned app.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteCloneabilityCriterion[] UnsupportedFeature { get; set; }

    }
}