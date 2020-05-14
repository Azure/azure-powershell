namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>VnetValidationTestFailure resource specific properties</summary>
    public partial class VnetValidationTestFailureProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetValidationTestFailureProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetValidationTestFailurePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private string _detail;

        /// <summary>The details of what caused the failure, e.g. the blocking rule name, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="TestName" /> property.</summary>
        private string _testName;

        /// <summary>The name of the test that failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TestName { get => this._testName; set => this._testName = value; }

        /// <summary>Creates an new <see cref="VnetValidationTestFailureProperties" /> instance.</summary>
        public VnetValidationTestFailureProperties()
        {

        }
    }
    /// VnetValidationTestFailure resource specific properties
    public partial interface IVnetValidationTestFailureProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The details of what caused the failure, e.g. the blocking rule name, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The details of what caused the failure, e.g. the blocking rule name, etc.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(string) })]
        string Detail { get; set; }
        /// <summary>The name of the test that failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the test that failed.",
        SerializedName = @"testName",
        PossibleTypes = new [] { typeof(string) })]
        string TestName { get; set; }

    }
    /// VnetValidationTestFailure resource specific properties
    internal partial interface IVnetValidationTestFailurePropertiesInternal

    {
        /// <summary>The details of what caused the failure, e.g. the blocking rule name, etc.</summary>
        string Detail { get; set; }
        /// <summary>The name of the test that failed.</summary>
        string TestName { get; set; }

    }
}