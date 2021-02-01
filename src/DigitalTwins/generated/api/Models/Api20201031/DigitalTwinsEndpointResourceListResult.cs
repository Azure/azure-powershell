namespace Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Extensions;

    /// <summary>A list of DigitalTwinsInstance Endpoints with a next link.</summary>
    public partial class DigitalTwinsEndpointResourceListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceListResult,
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link used to get the next page of DigitalTwinsInstance Endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResource[] _value;

        /// <summary>A list of DigitalTwinsInstance Endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResource[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DigitalTwinsEndpointResourceListResult" /> instance.</summary>
        public DigitalTwinsEndpointResourceListResult()
        {

        }
    }
    /// A list of DigitalTwinsInstance Endpoints with a next link.
    public partial interface IDigitalTwinsEndpointResourceListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.IJsonSerializable
    {
        /// <summary>The link used to get the next page of DigitalTwinsInstance Endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The link used to get the next page of DigitalTwinsInstance Endpoints.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>A list of DigitalTwinsInstance Endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of DigitalTwinsInstance Endpoints.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResource[] Value { get; set; }

    }
    /// A list of DigitalTwinsInstance Endpoints with a next link.
    internal partial interface IDigitalTwinsEndpointResourceListResultInternal

    {
        /// <summary>The link used to get the next page of DigitalTwinsInstance Endpoints.</summary>
        string NextLink { get; set; }
        /// <summary>A list of DigitalTwinsInstance Endpoints.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResource[] Value { get; set; }

    }
}