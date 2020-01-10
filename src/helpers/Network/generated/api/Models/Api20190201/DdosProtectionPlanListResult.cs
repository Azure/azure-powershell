namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>A list of DDoS protection plans.</summary>
    public partial class DdosProtectionPlanListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlanListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlanListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlanListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlan[] _value;

        /// <summary>A list of DDoS protection plans.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlan[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DdosProtectionPlanListResult" /> instance.</summary>
        public DdosProtectionPlanListResult()
        {

        }
    }
    /// A list of DDoS protection plans.
    public partial interface IDdosProtectionPlanListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>A list of DDoS protection plans.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of DDoS protection plans.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlan) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlan[] Value { get; set; }

    }
    /// A list of DDoS protection plans.
    internal partial interface IDdosProtectionPlanListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of DDoS protection plans.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlan[] Value { get; set; }

    }
}