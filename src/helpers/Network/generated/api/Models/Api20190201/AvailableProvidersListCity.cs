namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>City or town details.</summary>
    public partial class AvailableProvidersListCity :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCity,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCityInternal
    {

        /// <summary>Backing field for <see cref="CityName" /> property.</summary>
        private string _cityName;

        /// <summary>The city or town name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string CityName { get => this._cityName; set => this._cityName = value; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string[] _provider;

        /// <summary>A list of Internet service providers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] Provider { get => this._provider; set => this._provider = value; }

        /// <summary>Creates an new <see cref="AvailableProvidersListCity" /> instance.</summary>
        public AvailableProvidersListCity()
        {

        }
    }
    /// City or town details.
    public partial interface IAvailableProvidersListCity :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The city or town name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The city or town name.",
        SerializedName = @"cityName",
        PossibleTypes = new [] { typeof(string) })]
        string CityName { get; set; }
        /// <summary>A list of Internet service providers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of Internet service providers.",
        SerializedName = @"providers",
        PossibleTypes = new [] { typeof(string) })]
        string[] Provider { get; set; }

    }
    /// City or town details.
    internal partial interface IAvailableProvidersListCityInternal

    {
        /// <summary>The city or town name.</summary>
        string CityName { get; set; }
        /// <summary>A list of Internet service providers.</summary>
        string[] Provider { get; set; }

    }
}