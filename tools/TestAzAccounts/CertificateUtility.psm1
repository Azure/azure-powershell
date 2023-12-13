. "$PSScriptRoot/Common.ps1"
#Use securestring or plain string
function Convert-CertFileToObject {
    
    Param (
        [Parameter(Mandatory = $true)]
        [String]
        $CertPath,
        
        [Parameter(Mandatory = $true)]
        [String]
        $CertPlainPassword
    )
        
    #$CertPassword = ConvertTo-SecureString $CertPlainPassword -AsPlainText -Force
    $PFXCert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($CertPath, $CertPlainPassword)
    $PFXCert
}

#Fixme: split and fix
function New-SelfSignedCertificateCrossPlatform {
    Param (
        [Parameter(Mandatory = $true)]
        [String]
        $Subject,

        [Parameter(Mandatory = $true)]
        [String]
        $Path,

        [Parameter(Mandatory = $true)]
        [String]
        $PfxFile,
        
        [Parameter(Mandatory = $true)]
        [string]
        $CertPasswordPlainText
    )

    $certFile = Join-Path -Path $Path -ChildPath $pfxFile

    if ($PSVersionTable.PSEdition -eq 'Desktop'-or $IsWindows)
    {
        $params = @{
            Subject = 'C=CN,ST=Shanghai,L=Shanghai,O=Microsoft,OU=AzurePowerShell,CN=leijinps'
            KeySpec = 'Signature'
            KeyAlgorithm = 'RSA'
            HashAlgorithm = 'SHA256'
            KeyLength = 4096
            KeyExportPolicy = 'Exportable'
            CertStoreLocation = 'Cert:\CurrentUser\My'
            NotAfter = (Get-Date).AddMonths(6)
        }
        
        $cert = New-SelfSignedCertificate @params
        Export-PfxCertificate -Cert $cert -FilePath $certFile -Password $CertPassword
    }
    elseif($IsLinux -or $IsMacOS)
    {
        openssl req -x509 -newkey rsa:4096 `
        -keyout leijinps.key `
        -out leijinps.crt `
        -sha256 -days 365 `
        -subj "/C=CN/ST=Shanghai/L=Shanghai/O=Microsoft/OU=AzurePowerShell/CN=leijinps" `
        -nodes

        openssl pkcs12 -inkey leijinps.key -in leijinps.crt -export -out $certFile -password "pass:`"$certPasswordPlainText`""
    }
    $certFile
}

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
