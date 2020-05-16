namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Class representing certificate reissue request.</summary>
    public partial class ReissueCertificateOrderRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Csr to be used for re-key operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Csr { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestPropertiesInternal)Property).Csr; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestPropertiesInternal)Property).Csr = value; }

        /// <summary>
        /// Delay in hours to revoke existing certificate after the new certificate is issued.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? DelayExistingRevokeInHour { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestPropertiesInternal)Property).DelayExistingRevokeInHour; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestPropertiesInternal)Property).DelayExistingRevokeInHour = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>
        /// Should we change the ASC type (from managed private key to external private key and vice versa).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsPrivateKeyExternal { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestPropertiesInternal)Property).IsPrivateKeyExternal; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestPropertiesInternal)Property).IsPrivateKeyExternal = value; }

        /// <summary>Certificate Key Size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? KeySize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestPropertiesInternal)Property).KeySize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestPropertiesInternal)Property).KeySize = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ReissueCertificateOrderRequestProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestProperties _property;

        /// <summary>ReissueCertificateOrderRequest resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ReissueCertificateOrderRequestProperties()); set => this._property = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="ReissueCertificateOrderRequest" /> instance.</summary>
        public ReissueCertificateOrderRequest()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Class representing certificate reissue request.
    public partial interface IReissueCertificateOrderRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Csr to be used for re-key operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Csr to be used for re-key operation.",
        SerializedName = @"csr",
        PossibleTypes = new [] { typeof(string) })]
        string Csr { get; set; }
        /// <summary>
        /// Delay in hours to revoke existing certificate after the new certificate is issued.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Delay in hours to revoke existing certificate after the new certificate is issued.",
        SerializedName = @"delayExistingRevokeInHours",
        PossibleTypes = new [] { typeof(int) })]
        int? DelayExistingRevokeInHour { get; set; }
        /// <summary>
        /// Should we change the ASC type (from managed private key to external private key and vice versa).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Should we change the ASC type (from managed private key to external private key and vice versa).",
        SerializedName = @"isPrivateKeyExternal",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsPrivateKeyExternal { get; set; }
        /// <summary>Certificate Key Size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Certificate Key Size.",
        SerializedName = @"keySize",
        PossibleTypes = new [] { typeof(int) })]
        int? KeySize { get; set; }

    }
    /// Class representing certificate reissue request.
    internal partial interface IReissueCertificateOrderRequestInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Csr to be used for re-key operation.</summary>
        string Csr { get; set; }
        /// <summary>
        /// Delay in hours to revoke existing certificate after the new certificate is issued.
        /// </summary>
        int? DelayExistingRevokeInHour { get; set; }
        /// <summary>
        /// Should we change the ASC type (from managed private key to external private key and vice versa).
        /// </summary>
        bool? IsPrivateKeyExternal { get; set; }
        /// <summary>Certificate Key Size.</summary>
        int? KeySize { get; set; }
        /// <summary>ReissueCertificateOrderRequest resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestProperties Property { get; set; }

    }
}