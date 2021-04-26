namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Operations List response which contains list of available APIs.</summary>
    public partial class ClientDiscoveryResponse :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryResponse,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryResponseInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Link to the next chunk of Response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryValueForSingleApi[] _value;

        /// <summary>List of available operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryValueForSingleApi[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ClientDiscoveryResponse" /> instance.</summary>
        public ClientDiscoveryResponse()
        {

        }
    }
    /// Operations List response which contains list of available APIs.
    public partial interface IClientDiscoveryResponse :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Link to the next chunk of Response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link to the next chunk of Response.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>List of available operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of available operations.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryValueForSingleApi) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryValueForSingleApi[] Value { get; set; }

    }
    /// Operations List response which contains list of available APIs.
    internal partial interface IClientDiscoveryResponseInternal

    {
        /// <summary>Link to the next chunk of Response.</summary>
        string NextLink { get; set; }
        /// <summary>List of available operations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryValueForSingleApi[] Value { get; set; }

    }
}