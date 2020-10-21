namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The solution summary class.</summary>
    public partial class SolutionSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal.InstanceType { get => this._instanceType; set { {_instanceType = value;} } }

        /// <summary>Creates an new <see cref="SolutionSummary" /> instance.</summary>
        public SolutionSummary()
        {

        }
    }
    /// The solution summary class.
    public partial interface ISolutionSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the Instance type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get;  }

    }
    /// The solution summary class.
    internal partial interface ISolutionSummaryInternal

    {
        /// <summary>Gets the Instance type.</summary>
        string InstanceType { get; set; }

    }
}