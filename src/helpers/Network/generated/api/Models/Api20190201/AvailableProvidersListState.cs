namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>State details.</summary>
    public partial class AvailableProvidersListState :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListState,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListStateInternal
    {

        /// <summary>Backing field for <see cref="City" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCity[] _city;

        /// <summary>List of available cities or towns in the state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCity[] City { get => this._city; set => this._city = value; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string[] _provider;

        /// <summary>A list of Internet service providers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] Provider { get => this._provider; set => this._provider = value; }

        /// <summary>Backing field for <see cref="StateName" /> property.</summary>
        private string _stateName;

        /// <summary>The state name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string StateName { get => this._stateName; set => this._stateName = value; }

        /// <summary>Creates an new <see cref="AvailableProvidersListState" /> instance.</summary>
        public AvailableProvidersListState()
        {

        }
    }
    /// State details.
    public partial interface IAvailableProvidersListState :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of available cities or towns in the state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of available cities or towns in the state.",
        SerializedName = @"cities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCity[] City { get; set; }
        /// <summary>A list of Internet service providers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of Internet service providers.",
        SerializedName = @"providers",
        PossibleTypes = new [] { typeof(string) })]
        string[] Provider { get; set; }
        /// <summary>The state name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The state name.",
        SerializedName = @"stateName",
        PossibleTypes = new [] { typeof(string) })]
        string StateName { get; set; }

    }
    /// State details.
    internal partial interface IAvailableProvidersListStateInternal

    {
        /// <summary>List of available cities or towns in the state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableProvidersListCity[] City { get; set; }
        /// <summary>A list of Internet service providers.</summary>
        string[] Provider { get; set; }
        /// <summary>The state name.</summary>
        string StateName { get; set; }

    }
}