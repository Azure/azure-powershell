namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    public partial class PublicIPAddressSku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressSku,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressSkuInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSku"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSku __publicIPAddressSku = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddressSku();

        /// <summary>Name of a public IP address SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName? Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSkuInternal)__publicIPAddressSku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSkuInternal)__publicIPAddressSku).Name = value; }

        /// <summary>Creates an new <see cref="PublicIPAddressSku" /> instance.</summary>
        public PublicIPAddressSku()
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
            await eventListener.AssertNotNull(nameof(__publicIPAddressSku), __publicIPAddressSku);
            await eventListener.AssertObjectIsValid(nameof(__publicIPAddressSku), __publicIPAddressSku);
        }
    }
    public partial interface IPublicIPAddressSku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSku
    {

    }
    internal partial interface IPublicIPAddressSkuInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSkuInternal
    {

    }
}