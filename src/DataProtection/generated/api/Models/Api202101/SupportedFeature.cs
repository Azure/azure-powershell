namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Elements class for feature request</summary>
    public partial class SupportedFeature :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISupportedFeature,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISupportedFeatureInternal
    {

        /// <summary>Backing field for <see cref="ExposureControlledFeature" /> property.</summary>
        private string[] _exposureControlledFeature;

        /// <summary>support feature type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string[] ExposureControlledFeature { get => this._exposureControlledFeature; set => this._exposureControlledFeature = value; }

        /// <summary>Backing field for <see cref="FeatureName" /> property.</summary>
        private string _featureName;

        /// <summary>support feature type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string FeatureName { get => this._featureName; set => this._featureName = value; }

        /// <summary>Backing field for <see cref="SupportStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureSupportStatus? _supportStatus;

        /// <summary>feature support status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureSupportStatus? SupportStatus { get => this._supportStatus; set => this._supportStatus = value; }

        /// <summary>Creates an new <see cref="SupportedFeature" /> instance.</summary>
        public SupportedFeature()
        {

        }
    }
    /// Elements class for feature request
    public partial interface ISupportedFeature :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>support feature type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"support feature type.",
        SerializedName = @"exposureControlledFeatures",
        PossibleTypes = new [] { typeof(string) })]
        string[] ExposureControlledFeature { get; set; }
        /// <summary>support feature type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"support feature type.",
        SerializedName = @"featureName",
        PossibleTypes = new [] { typeof(string) })]
        string FeatureName { get; set; }
        /// <summary>feature support status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"feature support status",
        SerializedName = @"supportStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureSupportStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureSupportStatus? SupportStatus { get; set; }

    }
    /// Elements class for feature request
    internal partial interface ISupportedFeatureInternal

    {
        /// <summary>support feature type.</summary>
        string[] ExposureControlledFeature { get; set; }
        /// <summary>support feature type.</summary>
        string FeatureName { get; set; }
        /// <summary>feature support status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureSupportStatus? SupportStatus { get; set; }

    }
}