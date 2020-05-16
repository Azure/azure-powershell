namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>State of the Key Vault secret.</summary>
    public partial class AppServiceCertificateOrderPatchResourcePropertiesCertificates :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesCertificates,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesCertificatesInternal
    {

        /// <summary>
        /// Creates an new <see cref="AppServiceCertificateOrderPatchResourcePropertiesCertificates" /> instance.
        /// </summary>
        public AppServiceCertificateOrderPatchResourcePropertiesCertificates()
        {

        }
    }
    /// State of the Key Vault secret.
    public partial interface IAppServiceCertificateOrderPatchResourcePropertiesCertificates :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificate>
    {

    }
    /// State of the Key Vault secret.
    internal partial interface IAppServiceCertificateOrderPatchResourcePropertiesCertificatesInternal

    {

    }
}