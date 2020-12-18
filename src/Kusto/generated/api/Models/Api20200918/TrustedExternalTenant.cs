namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Represents a tenant ID that is trusted by the cluster.</summary>
    public partial class TrustedExternalTenant :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.ITrustedExternalTenant,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.ITrustedExternalTenantInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>GUID representing an external tenant.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="TrustedExternalTenant" /> instance.</summary>
        public TrustedExternalTenant()
        {

        }
    }
    /// Represents a tenant ID that is trusted by the cluster.
    public partial interface ITrustedExternalTenant :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>GUID representing an external tenant.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"GUID representing an external tenant.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Represents a tenant ID that is trusted by the cluster.
    internal partial interface ITrustedExternalTenantInternal

    {
        /// <summary>GUID representing an external tenant.</summary>
        string Value { get; set; }

    }
}