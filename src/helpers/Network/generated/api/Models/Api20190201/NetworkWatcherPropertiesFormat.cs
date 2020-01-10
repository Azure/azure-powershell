namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    public partial class NetworkWatcherPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkWatcherPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkWatcherPropertiesFormatInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkWatcherPropertiesFormat"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkWatcherPropertiesFormat __networkWatcherPropertiesFormat = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkWatcherPropertiesFormat();

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkWatcherPropertiesFormatInternal)__networkWatcherPropertiesFormat).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkWatcherPropertiesFormatInternal)__networkWatcherPropertiesFormat).ProvisioningState = value; }

        /// <summary>Creates an new <see cref="NetworkWatcherPropertiesFormat" /> instance.</summary>
        public NetworkWatcherPropertiesFormat()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__networkWatcherPropertiesFormat), __networkWatcherPropertiesFormat);
            await eventListener.AssertObjectIsValid(nameof(__networkWatcherPropertiesFormat), __networkWatcherPropertiesFormat);
        }
    }
    public partial interface INetworkWatcherPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkWatcherPropertiesFormat
    {

    }
    internal partial interface INetworkWatcherPropertiesFormatInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkWatcherPropertiesFormatInternal
    {

    }
}