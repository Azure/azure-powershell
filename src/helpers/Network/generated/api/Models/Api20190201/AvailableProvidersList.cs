namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>List of available countries with details.</summary>
    public partial class AvailableProvidersList :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersList,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListInternal
    {

        /// <summary>Backing field for <see cref="Country" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCountry[] _country;

        /// <summary>List of available countries.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCountry[] Country { get => this._country; set => this._country = value; }

        /// <summary>Creates an new <see cref="AvailableProvidersList" /> instance.</summary>
        public AvailableProvidersList()
        {

        }
    }
    /// List of available countries with details.
    public partial interface IAvailableProvidersList :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of available countries.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"List of available countries.",
        SerializedName = @"countries",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCountry) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCountry[] Country { get; set; }

    }
    /// List of available countries with details.
    internal partial interface IAvailableProvidersListInternal

    {
        /// <summary>List of available countries.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCountry[] Country { get; set; }

    }
}