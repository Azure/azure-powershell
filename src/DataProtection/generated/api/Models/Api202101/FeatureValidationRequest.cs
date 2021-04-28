namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Base class for feature object</summary>
    public partial class FeatureValidationRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationRequest,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationRequestInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationRequestBase"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationRequestBase __featureValidationRequestBase = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.FeatureValidationRequestBase();

        /// <summary>Backing field for <see cref="FeatureName" /> property.</summary>
        private string _featureName;

        /// <summary>backup support feature name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string FeatureName { get => this._featureName; set => this._featureName = value; }

        /// <summary>Backing field for <see cref="FeatureType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureType? _featureType;

        /// <summary>backup support feature type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureType? FeatureType { get => this._featureType; set => this._featureType = value; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationRequestBaseInternal)__featureValidationRequestBase).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationRequestBaseInternal)__featureValidationRequestBase).ObjectType = value ; }

        /// <summary>Creates an new <see cref="FeatureValidationRequest" /> instance.</summary>
        public FeatureValidationRequest()
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
            await eventListener.AssertNotNull(nameof(__featureValidationRequestBase), __featureValidationRequestBase);
            await eventListener.AssertObjectIsValid(nameof(__featureValidationRequestBase), __featureValidationRequestBase);
        }
    }
    /// Base class for feature object
    public partial interface IFeatureValidationRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationRequestBase
    {
        /// <summary>backup support feature name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"backup support feature name.",
        SerializedName = @"featureName",
        PossibleTypes = new [] { typeof(string) })]
        string FeatureName { get; set; }
        /// <summary>backup support feature type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"backup support feature type.",
        SerializedName = @"featureType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureType? FeatureType { get; set; }

    }
    /// Base class for feature object
    internal partial interface IFeatureValidationRequestInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IFeatureValidationRequestBaseInternal
    {
        /// <summary>backup support feature name.</summary>
        string FeatureName { get; set; }
        /// <summary>backup support feature type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureType? FeatureType { get; set; }

    }
}