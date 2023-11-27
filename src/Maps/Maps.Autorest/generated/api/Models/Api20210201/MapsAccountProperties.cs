namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>Additional Map account properties</summary>
    public partial class MapsAccountProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DisableLocalAuth" /> property.</summary>
        private bool? _disableLocalAuth;

        /// <summary>
        /// Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support. This will disable Shared
        /// Keys authentication from any usage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public bool? DisableLocalAuth { get => this._disableLocalAuth; set => this._disableLocalAuth = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for UniqueId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal.UniqueId { get => this._uniqueId; set { {_uniqueId = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>the state of the provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="UniqueId" /> property.</summary>
        private string _uniqueId;

        /// <summary>A unique identifier for the maps account</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string UniqueId { get => this._uniqueId; }

        /// <summary>Creates an new <see cref="MapsAccountProperties" /> instance.</summary>
        public MapsAccountProperties()
        {

        }
    }
    /// Additional Map account properties
    public partial interface IMapsAccountProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support. This will disable Shared
        /// Keys authentication from any usage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support. This will disable Shared Keys authentication from any usage.",
        SerializedName = @"disableLocalAuth",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DisableLocalAuth { get; set; }
        /// <summary>the state of the provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"the state of the provisioning.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>A unique identifier for the maps account</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A unique identifier for the maps account",
        SerializedName = @"uniqueId",
        PossibleTypes = new [] { typeof(string) })]
        string UniqueId { get;  }

    }
    /// Additional Map account properties
    internal partial interface IMapsAccountPropertiesInternal

    {
        /// <summary>
        /// Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support. This will disable Shared
        /// Keys authentication from any usage.
        /// </summary>
        bool? DisableLocalAuth { get; set; }
        /// <summary>the state of the provisioning.</summary>
        string ProvisioningState { get; set; }
        /// <summary>A unique identifier for the maps account</summary>
        string UniqueId { get; set; }

    }
}