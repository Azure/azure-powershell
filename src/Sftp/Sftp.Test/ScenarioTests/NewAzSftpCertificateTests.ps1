<#
.SYNOPSIS
Test New-AzSftpCertificate with automatic key generation
#>
function Test-NewAzSftpCertificateAutoGenerate
{
    $certificatePath = Get-CertificatePath

    try {
        # Skip test in playback mode for now
        if (IsPlayback) {
            return
        }

        # Test automatic certificate generation
        $cert = New-AzSftpCertificate -CertificatePath $certificatePath

        Assert-NotNull $cert
        Assert-NotNull $cert.CertificatePath
        Assert-NotNull $cert.PrivateKeyPath
        Assert-NotNull $cert.PublicKeyPath
        Assert-NotNull $cert.ValidFrom
        Assert-NotNull $cert.ValidUntil
        Assert-NotNull $cert.Principal
        Assert-True (Test-Path $cert.CertificatePath)
        Assert-True (Test-Path $cert.PrivateKeyPath)
        Assert-True (Test-Path $cert.PublicKeyPath)
        
        # Verify certificate validity
        Assert-True $cert.IsValid
        Assert-True ($cert.ValidUntil -gt (Get-Date))
    }
    finally {
        # Cleanup
        if ($cert) {
            Remove-Item $cert.CertificatePath -ErrorAction SilentlyContinue
            Remove-Item $cert.PrivateKeyPath -ErrorAction SilentlyContinue
            Remove-Item $cert.PublicKeyPath -ErrorAction SilentlyContinue
        }
        Remove-Item $certificatePath -ErrorAction SilentlyContinue
    }
}

<#
.SYNOPSIS
Test New-AzSftpCertificate with existing private key
#>
function Test-NewAzSftpCertificateWithPrivateKey
{
    $certificatePath = Get-CertificatePath
    $privateKeyPath = Get-PrivateKeyPath

    try {
        # Skip test in playback mode for now
        if (IsPlayback) {
            return
        }

        # Generate SSH key pair first
        $keyGenResult = ssh-keygen -t rsa -b 2048 -f $privateKeyPath -N '""' -C "test@example.com"
        
        if (Test-Path $privateKeyPath) {
            # Test certificate generation from existing private key
            $cert = New-AzSftpCertificate -PrivateKeyFile $privateKeyPath -CertificatePath $certificatePath

            Assert-NotNull $cert
            Assert-NotNull $cert.CertificatePath
            Assert-AreEqual $cert.PrivateKeyPath $privateKeyPath
            Assert-True (Test-Path $cert.CertificatePath)
            Assert-True (Test-Path $cert.PrivateKeyPath)
            
            # Verify certificate validity
            Assert-True $cert.IsValid
            Assert-True ($cert.ValidUntil -gt (Get-Date))
        }
    }
    finally {
        # Cleanup
        if ($cert) {
            Remove-Item $cert.CertificatePath -ErrorAction SilentlyContinue
        }
        Remove-Item $privateKeyPath -ErrorAction SilentlyContinue
        Remove-Item "$privateKeyPath.pub" -ErrorAction SilentlyContinue
        Remove-Item $certificatePath -ErrorAction SilentlyContinue
    }
}

<#
.SYNOPSIS
Test New-AzSftpCertificate with existing public key
#>
function Test-NewAzSftpCertificateWithPublicKey
{
    $certificatePath = Get-CertificatePath
    $privateKeyPath = Get-PrivateKeyPath

    try {
        # Skip test in playback mode for now
        if (IsPlayback) {
            return
        }

        # Generate SSH key pair first
        $keyGenResult = ssh-keygen -t rsa -b 2048 -f $privateKeyPath -N '""' -C "test@example.com"
        
        if (Test-Path "$privateKeyPath.pub") {
            # Test certificate generation from existing public key
            $cert = New-AzSftpCertificate -PublicKeyFile "$privateKeyPath.pub" -CertificatePath $certificatePath

            Assert-NotNull $cert
            Assert-NotNull $cert.CertificatePath
            Assert-AreEqual $cert.PublicKeyPath "$privateKeyPath.pub"
            Assert-True (Test-Path $cert.CertificatePath)
            Assert-True (Test-Path $cert.PublicKeyPath)
            
            # Verify certificate validity
            Assert-True $cert.IsValid
            Assert-True ($cert.ValidUntil -gt (Get-Date))
        }
    }
    finally {
        # Cleanup
        if ($cert) {
            Remove-Item $cert.CertificatePath -ErrorAction SilentlyContinue
        }
        Remove-Item $privateKeyPath -ErrorAction SilentlyContinue
        Remove-Item "$privateKeyPath.pub" -ErrorAction SilentlyContinue
        Remove-Item $certificatePath -ErrorAction SilentlyContinue
    }
}

<#
.SYNOPSIS
Test New-AzSftpCertificate with local user
#>
function Test-NewAzSftpCertificateForLocalUser
{
    $certificatePath = Get-CertificatePath
    $username = "testuser"

    try {
        # Skip test in playback mode for now
        if (IsPlayback) {
            return
        }

        # Test certificate generation for local user
        $cert = New-AzSftpCertificate -LocalUser $username -CertificatePath $certificatePath

        Assert-NotNull $cert
        Assert-NotNull $cert.CertificatePath
        Assert-NotNull $cert.PrivateKeyPath
        Assert-NotNull $cert.PublicKeyPath
        Assert-AreEqual $cert.LocalUser $username
        Assert-True (Test-Path $cert.CertificatePath)
        Assert-True (Test-Path $cert.PrivateKeyPath)
        Assert-True (Test-Path $cert.PublicKeyPath)
        
        # Verify certificate validity
        Assert-True $cert.IsValid
        Assert-True ($cert.ValidUntil -gt (Get-Date))
    }
    finally {
        # Cleanup
        if ($cert) {
            Remove-Item $cert.CertificatePath -ErrorAction SilentlyContinue
            Remove-Item $cert.PrivateKeyPath -ErrorAction SilentlyContinue
            Remove-Item $cert.PublicKeyPath -ErrorAction SilentlyContinue
        }
        Remove-Item $certificatePath -ErrorAction SilentlyContinue
    }
}

<#
.SYNOPSIS
Test New-AzSftpCertificate parameter validation
#>
function Test-NewAzSftpCertificateParameterValidation
{
    # Test invalid file paths
    Assert-Throws { New-AzSftpCertificate -PrivateKeyFile "nonexistent.key" } "Private key file must exist"
    Assert-Throws { New-AzSftpCertificate -PublicKeyFile "nonexistent.pub" } "Public key file must exist"
    
    # Test that parameter sets are mutually exclusive
    $tempKey = [System.IO.Path]::GetTempFileName()
    try {
        "test" | Out-File $tempKey
        Assert-Throws { New-AzSftpCertificate -PrivateKeyFile $tempKey -PublicKeyFile $tempKey -LocalUser "test" } "Cannot specify multiple parameter sets"
    }
    finally {
        Remove-Item $tempKey -ErrorAction SilentlyContinue
    }
}

<#
.SYNOPSIS
Test New-AzSftpCertificate with StorageAccountEndpoint parameter
#>
function Test-NewAzSftpCertificateWithStorageAccountEndpoint
{
    $certificatePath = Get-CertificatePath
    $customEndpoint = "blob.core.custom.endpoint.net"

    try {
        # Skip test in playback mode for now
        if (IsPlayback) {
            return
        }

        # Test certificate generation with custom storage account endpoint
        $cert = New-AzSftpCertificate -CertificatePath $certificatePath -StorageAccountEndpoint $customEndpoint

        Assert-NotNull $cert
        Assert-NotNull $cert.CertificatePath
        Assert-NotNull $cert.PrivateKeyPath
        Assert-NotNull $cert.PublicKeyPath
        Assert-True (Test-Path $cert.CertificatePath)
        Assert-True (Test-Path $cert.PrivateKeyPath)
        Assert-True (Test-Path $cert.PublicKeyPath)
        
        # Verify certificate validity
        Assert-True $cert.IsValid
        Assert-True ($cert.ValidUntil -gt (Get-Date))
    }
    finally {
        # Cleanup
        if ($cert) {
            Remove-Item $cert.CertificatePath -ErrorAction SilentlyContinue
            Remove-Item $cert.PrivateKeyPath -ErrorAction SilentlyContinue
            Remove-Item $cert.PublicKeyPath -ErrorAction SilentlyContinue
        }
        Remove-Item $certificatePath -ErrorAction SilentlyContinue
    }
}
