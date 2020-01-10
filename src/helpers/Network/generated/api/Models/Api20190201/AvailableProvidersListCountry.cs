namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Country details.</summary>
    public partial class AvailableProvidersListCountry :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCountry,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCountryInternal
    {

        /// <summary>Backing field for <see cref="CountryName" /> property.</summary>
        private string _countryName;

        /// <summary>The country name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string CountryName { get => this._countryName; set => this._countryName = value; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string[] _provider;

        /// <summary>A list of Internet service providers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] Provider { get => this._provider; set => this._provider = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListState[] _state;

        /// <summary>List of available states in the country.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListState[] State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="AvailableProvidersListCountry" /> instance.</summary>
        public AvailableProvidersListCountry()
        {

        }
    }
    /// Country details.
    public partial interface IAvailableProvidersListCountry :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The country name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The country name.",
        SerializedName = @"countryName",
        PossibleTypes = new [] { typeof(string) })]
        string CountryName { get; set; }
        /// <summary>A list of Internet service providers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of Internet service providers.",
        SerializedName = @"providers",
        PossibleTypes = new [] { typeof(string) })]
        string[] Provider { get; set; }
        /// <summary>List of available states in the country.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of available states in the country.",
        SerializedName = @"states",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListState[] State { get; set; }

    }
    /// Country details.
    internal partial interface IAvailableProvidersListCountryInternal

    {
        /// <summary>The country name.</summary>
        string CountryName { get; set; }
        /// <summary>A list of Internet service providers.</summary>
        string[] Provider { get; set; }
        /// <summary>List of available states in the country.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListState[] State { get; set; }

    }
}