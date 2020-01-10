namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Reference to an express route circuit.</summary>
    public partial class ExpressRouteCircuitReference :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitReference,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitReferenceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Corresponding Express Route Circuit Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitReference" /> instance.</summary>
        public ExpressRouteCircuitReference()
        {

        }
    }
    /// Reference to an express route circuit.
    public partial interface IExpressRouteCircuitReference :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Corresponding Express Route Circuit Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Corresponding Express Route Circuit Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// Reference to an express route circuit.
    internal partial interface IExpressRouteCircuitReferenceInternal

    {
        /// <summary>Corresponding Express Route Circuit Id.</summary>
        string Id { get; set; }

    }
}