namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The response containing the usage data</summary>
    public partial class UsageListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageListResult,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageListResultInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsage[] Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsageListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsage[] _value;

        /// <summary>The usage data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsage[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="UsageListResult" /> instance.</summary>
        public UsageListResult()
        {

        }
    }
    /// The response containing the usage data
    public partial interface IUsageListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The usage data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The usage data.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsage) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsage[] Value { get;  }

    }
    /// The response containing the usage data
    internal partial interface IUsageListResultInternal

    {
        /// <summary>The usage data.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IUsage[] Value { get; set; }

    }
}