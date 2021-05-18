namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The response containing list of capabilities.</summary>
    public partial class CapabilitiesListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICapabilitiesListResult,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICapabilitiesListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URI to fetch the next page of capabilities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICapabilities[] _value;

        /// <summary>The list of capabilities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICapabilities[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="CapabilitiesListResult" /> instance.</summary>
        public CapabilitiesListResult()
        {

        }
    }
    /// The response containing list of capabilities.
    public partial interface ICapabilitiesListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The URI to fetch the next page of capabilities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI to fetch the next page of capabilities.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The list of capabilities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of capabilities.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICapabilities) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICapabilities[] Value { get; set; }

    }
    /// The response containing list of capabilities.
    internal partial interface ICapabilitiesListResultInternal

    {
        /// <summary>The URI to fetch the next page of capabilities.</summary>
        string NextLink { get; set; }
        /// <summary>The list of capabilities.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICapabilities[] Value { get; set; }

    }
}