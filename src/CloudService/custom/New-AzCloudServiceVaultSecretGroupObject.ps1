function New-AzCloudServiceVaultSecretGroupObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudServiceVaultSecretGroup')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(
        [Parameter(HelpMessage="Key Vault Resource Id.")]
        [string]
        $Id,

        [Parameter(HelpMessage="This is the URL of a certificate that has been uploaded to Key Vault as a secret..")]
        [string[]]
        $CertificateUrl
    )

    process {
              $certificateUrls = @()
              ForEach ($url in $CertificateUrl)
              {
                     $cloudServiceVaultCertificate = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudServiceVaultCertificate]::New()
                     $cloudServiceVaultCertificate.CertificateUrl = $url
                     $certificateUrls = $certificateUrls + $cloudServiceVaultCertificate
              }

              $cloudServiceVaultSecretGroup = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudServiceVaultSecretGroup]::New()
              $cloudServiceVaultSecretGroup.SourceVaultId = $Id
              $cloudServiceVaultSecretGroup.VaultCertificate = $certificateUrls

        return $cloudServiceVaultSecretGroup
    }
}
