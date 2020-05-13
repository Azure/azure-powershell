namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>VnetValidationFailureDetails resource specific properties</summary>
    public partial class VnetValidationFailureDetailsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetValidationFailureDetailsProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetValidationFailureDetailsPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Failed" /> property.</summary>
        private bool? _failed;

        /// <summary>A flag describing whether or not validation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Failed { get => this._failed; set => this._failed = value; }

        /// <summary>Backing field for <see cref="FailedTest" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetValidationTestFailure[] _failedTest;

        /// <summary>A list of tests that failed in the validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetValidationTestFailure[] FailedTest { get => this._failedTest; set => this._failedTest = value; }

        /// <summary>Creates an new <see cref="VnetValidationFailureDetailsProperties" /> instance.</summary>
        public VnetValidationFailureDetailsProperties()
        {

        }
    }
    /// VnetValidationFailureDetails resource specific properties
    public partial interface IVnetValidationFailureDetailsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>A flag describing whether or not validation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag describing whether or not validation failed.",
        SerializedName = @"failed",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Failed { get; set; }
        /// <summary>A list of tests that failed in the validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of tests that failed in the validation.",
        SerializedName = @"failedTests",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetValidationTestFailure) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetValidationTestFailure[] FailedTest { get; set; }

    }
    /// VnetValidationFailureDetails resource specific properties
    internal partial interface IVnetValidationFailureDetailsPropertiesInternal

    {
        /// <summary>A flag describing whether or not validation failed.</summary>
        bool? Failed { get; set; }
        /// <summary>A list of tests that failed in the validation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetValidationTestFailure[] FailedTest { get; set; }

    }
}