# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------
. "$PSScriptRoot/Common.ps1"

function New-CertificateFromKeyVault
{
    param (
        [Parameter(Mandatory=$true)]
        [string]
        $KeyVaultName,
        
        [Parameter(Mandatory=$true)]
        [string]
        $CertificateName,

        [Parameter(Mandatory=$true)]
        [string]
        $SubjectName
    )

    $certificate = Get-AzKeyVaultCertificate -VaultName $KeyVaultName -Name $CertificateName
    if ($null -eq $certificate)
    {
        $Policy = New-AzKeyVaultCertificatePolicy -SecretContentType "application/x-pkcs12" -SubjectName $SubjectName -IssuerName "Self" -ValidityInMonths 12 -ReuseKeyOnRenewal
        Add-AzKeyVaultCertificate -VaultName $KeyVaultName -Name $CertificateName -CertificatePolicy $Policy
        Start-Sleep -Seconds 5
        $certificate = Get-AzKeyVaultCertificate -VaultName $KeyVaultName -Name $CertificateName
    }
    $certificate
}

function Get-CertificateFromKeyVault
{
    param(
        [Parameter(Mandatory=$true)]
        [string]
        $KeyVaultName,
        
        [Parameter(Mandatory=$true)]
        [string]
        $CertificateName,

        [Parameter(Mandatory = $true)]
        [string]
        $CertPlainPassword,

        [Parameter(Mandatory = $true)]
        [string]
        $Path,

        [Parameter(Mandatory = $true)]
        [string]
        $PfxFileName
    )

    #$cert = Get-AzKeyVaultCertificate -VaultName $KeyVaultName -Name $CertificateName
    #$protectedCertificateBytes = $cert.Certificate.Export([System.Security.Cryptography.X509Certificates.X509ContentType]::Pfx, $CertPlainPassword)
    $pfxFile =  Join-Path -Path $Path -ChildPath $PfxFileName

    $secretValue = (Get-AzKeyVaultSecret -VaultName $KeyVaultName -Name $CertificateName).SecretValue
    $secretValueText = ConvertTo-PlainString -Secret $secretValue
    $kvSecretBytes = [System.Convert]::FromBase64String($secretValueText)
    $certCollection = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2Collection
    $certCollection.Import($kvSecretBytes,$null,[System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::Exportable)
    $protectedCertificateBytes = $certCollection.Export([System.Security.Cryptography.X509Certificates.X509ContentType]::Pkcs12, $CertPlainPassword)
    [System.IO.File]::WriteAllBytes($pfxFile, $protectedCertificateBytes)

    $pfxFile
}
