namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>A list of private endpoint connections</summary>
    public partial class PrivateEndpointConnectionListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointConnectionListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointConnectionListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointConnection[] _value;

        /// <summary>The collection value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointConnection[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PrivateEndpointConnectionListResult" /> instance.</summary>
        public PrivateEndpointConnectionListResult()
        {

        }
    }
    /// A list of private endpoint connections
    public partial interface IPrivateEndpointConnectionListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>The collection value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection value.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointConnection[] Value { get; set; }

    }
    /// A list of private endpoint connections
    internal partial interface IPrivateEndpointConnectionListResultInternal

    {
        /// <summary>The collection value.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateEndpointConnection[] Value { get; set; }

    }
}