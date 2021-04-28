namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Feature Validation Response</summary>
    public partial class FeatureValidationResponse :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationResponse,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationResponseInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationResponseBase"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationResponseBase __featureValidationResponseBase = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.FeatureValidationResponseBase();

        /// <summary>Backing field for <see cref="Feature" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISupportedFeature[] _feature;

        /// <summary>Response features</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISupportedFeature[] Feature { get => this._feature; set => this._feature = value; }

        /// <summary>Backing field for <see cref="FeatureType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureType? _featureType;

        /// <summary>backup support feature type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureType? FeatureType { get => this._featureType; set => this._featureType = value; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationResponseBaseInternal)__featureValidationResponseBase).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationResponseBaseInternal)__featureValidationResponseBase).ObjectType = value ; }

        /// <summary>Creates an new <see cref="FeatureValidationResponse" /> instance.</summary>
        public FeatureValidationResponse()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__featureValidationResponseBase), __featureValidationResponseBase);
            await eventListener.AssertObjectIsValid(nameof(__featureValidationResponseBase), __featureValidationResponseBase);
        }
    }
    /// Feature Validation Response
    public partial interface IFeatureValidationResponse :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationResponseBase
    {
        /// <summary>Response features</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Response features",
        SerializedName = @"features",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISupportedFeature) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISupportedFeature[] Feature { get; set; }
        /// <summary>backup support feature type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"backup support feature type.",
        SerializedName = @"featureType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureType? FeatureType { get; set; }

    }
    /// Feature Validation Response
    internal partial interface IFeatureValidationResponseInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationResponseBaseInternal
    {
        /// <summary>Response features</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISupportedFeature[] Feature { get; set; }
        /// <summary>backup support feature type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureType? FeatureType { get; set; }

    }
}