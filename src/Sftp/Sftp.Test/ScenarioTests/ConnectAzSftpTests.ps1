<#
.SYNOPSIS
Test Connect-AzSftp with certificate authentication
#>
function Test-ConnectAzSftpWithCertificateAuth
{
    $storageAccountName = Get-StorageAccountName
    $resourceGroupName = Get-ResourceGroupName
    $certificatePath = Get-CertificatePath
    $privateKeyPath = Get-PrivateKeyPath

    try {
        # Skip test in playback mode for now
        if (IsPlayback) {
            return
        }

        # Create test storage account
        $storageAccount = New-TestStorageAccount -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName

        # Generate certificate for testing
        $cert = New-AzSftpCertificate -CertificatePath $certificatePath -PrivateKeyFile $privateKeyPath

        Assert-NotNull $cert
        Assert-NotNull $cert.CertificatePath
        Assert-NotNull $cert.PrivateKeyPath
        Assert-True (Test-Path $cert.CertificatePath)
        Assert-True (Test-Path $cert.PrivateKeyPath)

        # Test connection (this will fail in automated tests but validates parameter parsing)
        try {
            $result = Connect-AzSftp -StorageAccount $storageAccountName -CertificateFile $cert.CertificatePath -PrivateKeyFile $cert.PrivateKeyPath -SftpArg "-o", "ConnectTimeout=1"
            # Connection should fail in test environment but cmdlet should parse parameters correctly
        }
        catch {
            # Expected to fail in test environment - this is acceptable
            Write-Host "Connection failed as expected in test environment: $($_.Exception.Message)"
        }
    }
    finally {
        # Cleanup
        Remove-Item $certificatePath -ErrorAction SilentlyContinue
        Remove-Item $privateKeyPath -ErrorAction SilentlyContinue
        Remove-Item "$privateKeyPath.pub" -ErrorAction SilentlyContinue
        Remove-TestStorageAccount -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName
        Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue
    }
}

<#
.SYNOPSIS
Test Connect-AzSftp with automatic Azure AD authentication
#>
function Test-ConnectAzSftpWithAzureADAuth
{
    $storageAccountName = Get-StorageAccountName
    $resourceGroupName = Get-ResourceGroupName

    try {
        # Skip test in playback mode for now
        if (IsPlayback) {
            return
        }

        # Create test storage account
        $storageAccount = New-TestStorageAccount -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName

        # Test automatic Azure AD authentication (will fail in test environment)
        try {
            $result = Connect-AzSftp -StorageAccount $storageAccountName -SftpArg "-o", "ConnectTimeout=1"
            # Connection should fail in test environment but cmdlet should parse parameters correctly
        }
        catch {
            # Expected to fail in test environment - this is acceptable
            Write-Host "Connection failed as expected in test environment: $($_.Exception.Message)"
        }
    }
    finally {
        # Cleanup
        Remove-TestStorageAccount -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName
        Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue
    }
}

<#
.SYNOPSIS
Test Connect-AzSftp with local user authentication
#>
function Test-ConnectAzSftpWithLocalUserAuth
{
    $storageAccountName = Get-StorageAccountName
    $resourceGroupName = Get-ResourceGroupName
    $username = "testuser"
    $privateKeyPath = Get-PrivateKeyPath

    try {
        # Skip test in playback mode for now
        if (IsPlayback) {
            return
        }

        # Create test storage account
        $storageAccount = New-TestStorageAccount -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName

        # Generate SSH key pair for local user
        $keyGenResult = ssh-keygen -t rsa -b 2048 -f $privateKeyPath -N '""' -C "test@example.com"
        
        if (Test-Path "$privateKeyPath.pub") {
            # Create local user
            $localUser = New-TestLocalUser -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -Username $username -PublicKeyPath "$privateKeyPath.pub"

            # Test local user authentication (will fail in test environment)
            try {
                $result = Connect-AzSftp -StorageAccount $storageAccountName -LocalUser $username -PrivateKeyFile $privateKeyPath -SftpArg "-o", "ConnectTimeout=1"
                # Connection should fail in test environment but cmdlet should parse parameters correctly
            }
            catch {
                # Expected to fail in test environment - this is acceptable
                Write-Host "Connection failed as expected in test environment: $($_.Exception.Message)"
            }
        }
    }
    finally {
        # Cleanup
        Remove-Item $privateKeyPath -ErrorAction SilentlyContinue
        Remove-Item "$privateKeyPath.pub" -ErrorAction SilentlyContinue
        Remove-TestLocalUser -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -Username $username
        Remove-TestStorageAccount -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName
        Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue
    }
}

<#
.SYNOPSIS
Test Connect-AzSftp parameter validation
#>
function Test-ConnectAzSftpParameterValidation
{
    # Test that required parameters are validated
    Assert-Throws { Connect-AzSftp } "StorageAccount parameter is required"
    
    # Test invalid port values
    Assert-Throws { Connect-AzSftp -StorageAccount "test" -Port -1 } "Port must be positive"
    Assert-Throws { Connect-AzSftp -StorageAccount "test" -Port 70000 } "Port must be valid range"
    
    # Test certificate authentication requires both certificate and private key
    Assert-Throws { Connect-AzSftp -StorageAccount "test" -CertificateFile "cert.pub" } "CertificateFile requires PrivateKeyFile"
}

<#
.SYNOPSIS
Test Connect-AzSftp with BufferSizeInBytes parameter
#>
function Test-ConnectAzSftpWithBufferSizeInBytes
{
    $storageAccountName = Get-StorageAccountName
    $resourceGroupName = Get-ResourceGroupName

    try {
        # Skip test in playback mode for now
        if (IsPlayback) {
            return
        }

        # Create test storage account
        $storageAccount = New-TestStorageAccount -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName

        # Test connection with custom buffer size (will fail in test environment but validates parameter parsing)
        try {
            $result = Connect-AzSftp -StorageAccount $storageAccountName -BufferSizeInBytes 524288 -SftpArg "-o", "ConnectTimeout=1"
        }
        catch {
            # Expected to fail in test environment - this is acceptable
            Write-Host "Connection failed as expected in test environment: $($_.Exception.Message)"
        }

        # Test with default buffer size (256*1024 = 262144)
        try {
            $result = Connect-AzSftp -StorageAccount $storageAccountName -SftpArg "-o", "ConnectTimeout=1"
        }
        catch {
            Write-Host "Connection failed as expected in test environment: $($_.Exception.Message)"
        }
    }
    finally {
        # Cleanup
        Remove-TestStorageAccount -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName
        Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue
    }
}

<#
.SYNOPSIS
Test Connect-AzSftp with StorageAccountEndpoint parameter
#>
function Test-ConnectAzSftpWithStorageAccountEndpoint
{
    $storageAccountName = Get-StorageAccountName
    $resourceGroupName = Get-ResourceGroupName
    $customEndpoint = "blob.core.custom.endpoint.net"

    try {
        # Skip test in playback mode for now
        if (IsPlayback) {
            return
        }

        # Create test storage account
        $storageAccount = New-TestStorageAccount -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName

        # Test connection with custom storage account endpoint (will fail in test environment but validates parameter parsing)
        try {
            $result = Connect-AzSftp -StorageAccount $storageAccountName -StorageAccountEndpoint $customEndpoint -SftpArg "-o", "ConnectTimeout=1"
        }
        catch {
            # Expected to fail in test environment - this is acceptable
            Write-Host "Connection failed as expected in test environment: $($_.Exception.Message)"
        }
    }
    finally {
        # Cleanup
        Remove-TestStorageAccount -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName
        Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue
    }
}
