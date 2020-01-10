namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Constraints that determine the list of available Internet service providers.</summary>
    public partial class AvailableProvidersListParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListParametersInternal
    {

        /// <summary>Backing field for <see cref="AzureLocation" /> property.</summary>
        private string[] _azureLocation;

        /// <summary>A list of Azure regions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] AzureLocation { get => this._azureLocation; set => this._azureLocation = value; }

        /// <summary>Backing field for <see cref="City" /> property.</summary>
        private string _city;

        /// <summary>The city or town for available providers list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string City { get => this._city; set => this._city = value; }

        /// <summary>Backing field for <see cref="Country" /> property.</summary>
        private string _country;

        /// <summary>The country for available providers list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Country { get => this._country; set => this._country = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>The state for available providers list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="AvailableProvidersListParameters" /> instance.</summary>
        public AvailableProvidersListParameters()
        {

        }
    }
    /// Constraints that determine the list of available Internet service providers.
    public partial interface IAvailableProvidersListParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>A list of Azure regions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of Azure regions.",
        SerializedName = @"azureLocations",
        PossibleTypes = new [] { typeof(string) })]
        string[] AzureLocation { get; set; }
        /// <summary>The city or town for available providers list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The city or town for available providers list.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string City { get; set; }
        /// <summary>The country for available providers list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The country for available providers list.",
        SerializedName = @"country",
        PossibleTypes = new [] { typeof(string) })]
        string Country { get; set; }
        /// <summary>The state for available providers list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The state for available providers list.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get; set; }

    }
    /// Constraints that determine the list of available Internet service providers.
    internal partial interface IAvailableProvidersListParametersInternal

    {
        /// <summary>A list of Azure regions.</summary>
        string[] AzureLocation { get; set; }
        /// <summary>The city or town for available providers list.</summary>
        string City { get; set; }
        /// <summary>The country for available providers list.</summary>
        string Country { get; set; }
        /// <summary>The state for available providers list.</summary>
        string State { get; set; }

    }
}