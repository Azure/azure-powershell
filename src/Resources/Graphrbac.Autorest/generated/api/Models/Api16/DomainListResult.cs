namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Server response for Get tenant domains API call.</summary>
    public partial class DomainListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDomainListResult,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDomainListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDomain[] _value;

        /// <summary>the list of domains.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDomain[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DomainListResult" /> instance.</summary>
        public DomainListResult()
        {

        }
    }
    /// Server response for Get tenant domains API call.
    public partial interface IDomainListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>the list of domains.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the list of domains.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDomain) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDomain[] Value { get; set; }

    }
    /// Server response for Get tenant domains API call.
    internal partial interface IDomainListResultInternal

    {
        /// <summary>the list of domains.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDomain[] Value { get; set; }

    }
}