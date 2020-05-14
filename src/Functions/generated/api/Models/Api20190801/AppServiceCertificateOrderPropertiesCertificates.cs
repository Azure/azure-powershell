namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>State of the Key Vault secret.</summary>
    public partial class AppServiceCertificateOrderPropertiesCertificates :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesCertificates,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesCertificatesInternal
    {

        /// <summary>
        /// Creates an new <see cref="AppServiceCertificateOrderPropertiesCertificates" /> instance.
        /// </summary>
        public AppServiceCertificateOrderPropertiesCertificates()
        {

        }
    }
    /// State of the Key Vault secret.
    public partial interface IAppServiceCertificateOrderPropertiesCertificates :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificate>
    {

    }
    /// State of the Key Vault secret.
    internal partial interface IAppServiceCertificateOrderPropertiesCertificatesInternal

    {

    }
}