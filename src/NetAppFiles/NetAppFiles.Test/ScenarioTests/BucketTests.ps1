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

<#
.SYNOPSIS
Generates a self-signed certificate + private key pair, returns the combined PEM
content as a base64-encoded string suitable for the bucket server's
'CertificateObject' property. Works cross-platform (no Windows-only cmdlets).
#>
function New-SelfSignedBucketCertificateObject
{
    param(
        [string] $SubjectName = "CN=anf-bucket.local"
    )

    $rsa = [System.Security.Cryptography.RSA]::Create(2048)
    try
    {
        $req = [System.Security.Cryptography.X509Certificates.CertificateRequest]::new(
            $SubjectName,
            $rsa,
            [System.Security.Cryptography.HashAlgorithmName]::SHA256,
            [System.Security.Cryptography.RSASignaturePadding]::Pkcs1)
        $notBefore = [System.DateTimeOffset]::UtcNow.AddMinutes(-5)
        $notAfter  = [System.DateTimeOffset]::UtcNow.AddYears(1)
        $cert = $req.CreateSelfSigned($notBefore, $notAfter)

        $certB64 = [System.Convert]::ToBase64String($cert.RawData, [System.Base64FormattingOptions]::InsertLineBreaks)
        $keyB64  = [System.Convert]::ToBase64String($rsa.ExportPkcs8PrivateKey(), [System.Base64FormattingOptions]::InsertLineBreaks)

        $pem = "-----BEGIN CERTIFICATE-----`n$certB64`n-----END CERTIFICATE-----`n" +
               "-----BEGIN PRIVATE KEY-----`n$keyB64`n-----END PRIVATE KEY-----`n"

        return [System.Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes($pem))
    }
    finally
    {
        $rsa.Dispose()
    }
}

<#
.SYNOPSIS
Test Bucket CRUD operations using an inline self-signed certificate object.
Uses OnCertificateConflictAction = 'Update' so repeat runs / multiple buckets on
the same server do not fail when certificates overlap.
#>
function Test-BucketCrud
{
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId

    $resourceGroup   = Get-ResourceGroupName
    $accName         = Get-ResourceName
    $poolName        = Get-ResourceName
    $volName         = Get-ResourceName
    $bucketName1     = Get-ResourceName
    $bucketName2     = Get-ResourceName

    $resourceLocation = "eastus"
    $gibibyte         = 1024 * 1024 * 1024
    $usageThreshold   = 100 * $gibibyte
    $poolSize         = 4398046511104
    $serviceLevel     = "Premium"

    $subnetName = "default"
    $vnetName   = $resourceGroup + "-vnet"
    $subnetId   = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    $protocolTypes    = @("NFSv3")
    $bucketServerFqdn = "anf-bucket.local"
    $bucketPath       = "/"
    $bucketPathUpdate = "/data"

    try
    {
        # Resource group + VNet/subnet
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation     = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        # Account / Pool / Volume
        $retrievedAcc    = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName
        $retrievedPool   = New-AzNetAppFilesPool    -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel
        $retrievedVolume = New-AzNetAppFilesVolume  -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -CreationToken $volName -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -ProtocolType $protocolTypes
        Assert-AreEqual "$accName/$poolName/$volName" $retrievedVolume.Name

        # Generate a self-signed cert/key PEM (base64) for the bucket server
        $certObject = New-SelfSignedBucketCertificateObject

        # Create first bucket (NFS user) -----------------------------------------
        $bucket1 = New-AzNetAppFilesBucket `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName1 `
            -Path $bucketPath -Permissions "ReadOnly" `
            -NfsUserId 1000 -NfsGroupId 1000 `
            -ServerFqdn $bucketServerFqdn `
            -ServerCertificateObject $certObject `
            -OnCertificateConflictAction "Update"

        Assert-AreEqual "$accName/$poolName/$volName/$bucketName1" $bucket1.Name
        Assert-AreEqual $bucketPath $bucket1.Path
        Assert-AreEqual "ReadOnly"  $bucket1.Permissions
        Assert-NotNull  $bucket1.Server
        Assert-AreEqual $bucketServerFqdn $bucket1.Server.Fqdn
        Assert-NotNull  $bucket1.FileSystemUser
        Assert-NotNull  $bucket1.FileSystemUser.NfsUser
        Assert-AreEqual 1000 $bucket1.FileSystemUser.NfsUser.UserId
        Assert-AreEqual 1000 $bucket1.FileSystemUser.NfsUser.GroupId

        # Get by name
        $getBucket1 = Get-AzNetAppFilesBucket -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName1
        Assert-AreEqual "$accName/$poolName/$volName/$bucketName1" $getBucket1.Name

        # Get by ResourceId
        $getByIdBucket = Get-AzNetAppFilesBucket -ResourceId $getBucket1.Id
        Assert-AreEqual $getBucket1.Id $getByIdBucket.Id

        # Create second bucket (CIFS user) on the same server - OnCertificateConflictAction=Update
        # allows the server certificate to be re-applied without failure.
        $bucket2 = New-AzNetAppFilesBucket `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName2 `
            -Path $bucketPath -Permissions "ReadWrite" `
            -CifsUserName "anfuser" `
            -ServerFqdn $bucketServerFqdn `
            -ServerCertificateObject $certObject `
            -OnCertificateConflictAction "Update"

        Assert-AreEqual "$accName/$poolName/$volName/$bucketName2" $bucket2.Name
        Assert-AreEqual "ReadWrite" $bucket2.Permissions
        Assert-NotNull  $bucket2.FileSystemUser
        Assert-NotNull  $bucket2.FileSystemUser.CifsUser
        Assert-AreEqual "anfuser" $bucket2.FileSystemUser.CifsUser.Username

        # List
        $listBuckets = Get-AzNetAppFilesBucket -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName
        Assert-AreEqual 2 $listBuckets.Length

        # Update: change path + permissions; refresh the cert (new cert but same OnCertificateConflictAction=Update)
        $newCertObject = New-SelfSignedBucketCertificateObject
        $updatedBucket = Update-AzNetAppFilesBucket `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName1 `
            -Permissions "ReadWrite" `
            -ServerCertificateObject $newCertObject `
            -OnCertificateConflictAction "Update"
        Assert-AreEqual "ReadWrite" $updatedBucket.Permissions

        # Generate credentials (returns Access/Secret key pair in cleartext)
        $cred = New-AzNetAppFilesBucketCredential `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName1 `
            -KeyPairExpiryDay 7
        Assert-NotNull $cred
        Assert-NotNull $cred.AccessKey
        Assert-NotNull $cred.SecretKey

        # Pipeline variant: get | generate credentials
        $credViaPipeline = Get-AzNetAppFilesBucket -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName1 `
            | New-AzNetAppFilesBucketCredential -KeyPairExpiryDay 3
        Assert-NotNull $credViaPipeline.AccessKey

        # WhatIf should not remove
        Remove-AzNetAppFilesBucket -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName1 -WhatIf
        $listAfterWhatIf = Get-AzNetAppFilesBucket -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName
        Assert-AreEqual 2 $listAfterWhatIf.Length

        # Remove bucket 1 by name
        Remove-AzNetAppFilesBucket -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName1
        $listAfterRemove1 = Get-AzNetAppFilesBucket -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName
        Assert-AreEqual 1 $listAfterRemove1.Length

        # Remove bucket 2 by ResourceId
        Remove-AzNetAppFilesBucket -ResourceId $bucket2.Id
        $retrievedDeleted = $null
        try
        {
            $retrievedDeleted = Get-AzNetAppFilesBucket -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName2
        }
        catch
        {
            $retrievedDeleted = $null
        }
        Assert-Null $retrievedDeleted
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Exercises pipeline binding: volume -> new bucket, bucket -> update/remove.
#>
function Test-BucketPipeline
{
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName      = Get-ResourceName
    $volName       = Get-ResourceName
    $bucketName    = Get-ResourceName

    $resourceLocation = "eastus"
    $gibibyte         = 1024 * 1024 * 1024
    $usageThreshold   = 100 * $gibibyte
    $poolSize         = 4398046511104
    $serviceLevel     = "Premium"

    $subnetName = "default"
    $vnetName   = $resourceGroup + "-vnet"
    $subnetId   = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    try
    {
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation     = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        $retrievedAcc    = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName
        $retrievedPool   = New-AzNetAppFilesPool    -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel
        $volume          = New-AzNetAppFilesVolume  -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -CreationToken $volName -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -ProtocolType @("NFSv3")

        $certObject = New-SelfSignedBucketCertificateObject

        # Pipe the volume to New-AzNetAppFilesBucket
        $bucket = $volume | New-AzNetAppFilesBucket `
            -Name $bucketName `
            -Path "/" `
            -Permissions "ReadOnly" `
            -NfsUserId 1000 -NfsGroupId 1000 `
            -ServerFqdn "anf-bucket.local" `
            -ServerCertificateObject $certObject `
            -OnCertificateConflictAction "Update"
        Assert-AreEqual "$accName/$poolName/$volName/$bucketName" $bucket.Name

        # Pipe the bucket to Update and Remove
        $bucket | Update-AzNetAppFilesBucket -Permissions "ReadWrite" -OnCertificateConflictAction "Update"
        $updated = Get-AzNetAppFilesBucket -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName
        Assert-AreEqual "ReadWrite" $updated.Permissions

        $updated | Remove-AzNetAppFilesBucket -PassThru | Out-Null
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}

# ---------------------------------------------------------------------------
# AKV-backed scenarios
#
# These tests require pre-provisioned Azure Key Vault resources:
#   * AKV instance reachable from the cache/volume VNet
#   * A PEM certificate stored under the specified name containing cert+key
#   * An access policy / RBAC role assignment granting the ANF resource
#     provider identity 'get' on the certificate secret, and for the
#     credentials scenarios 'set' on secrets in the credentials vault
#
# Until those prerequisites are automated in the test fixture, the xUnit
# wrappers for these tests are marked [Fact(Skip=...)] in BucketTests.cs.
# Re-enable them once the environment is available.
# ---------------------------------------------------------------------------

<#
.SYNOPSIS
Create a bucket that sources its server certificate from Azure Key Vault and
stores the generated bucket credentials back in Azure Key Vault. SKIPPED - see
note above.
#>
function Test-BucketCreateWithAkv
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName      = Get-ResourceName
    $volName       = Get-ResourceName
    $bucketName    = Get-ResourceName

    $resourceLocation = "eastus"
    $certKeyVaultUri        = "https://anf-bucket-certs.vault.azure.net/"
    $certName               = "anf-bucket-cert"
    $credentialsKeyVaultUri = "https://anf-bucket-creds.vault.azure.net/"
    $credentialsSecretName  = "anf-bucket-creds"

    try
    {
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        $subnetName = "default"
        $vnetName   = $resourceGroup + "-vnet"
        $subsid     = (Get-AzureRmContext).Subscription.SubscriptionId
        $subnetId   = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation     = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        $retrievedAcc  = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName
        $retrievedPool = New-AzNetAppFilesPool    -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize 4398046511104 -ServiceLevel "Premium"
        $volume        = New-AzNetAppFilesVolume  -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -CreationToken $volName -UsageThreshold (100 * 1024 * 1024 * 1024) -ServiceLevel "Premium" -SubnetId $subnetId -ProtocolType @("NFSv3")

        $bucket = New-AzNetAppFilesBucket `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName `
            -Path "/" -Permissions "ReadOnly" `
            -NfsUserId 1000 -NfsGroupId 1000 `
            -ServerFqdn "anf-bucket.local" `
            -OnCertificateConflictAction "Update" `
            -CertificateKeyVaultUri $certKeyVaultUri -CertificateName $certName `
            -CredentialsKeyVaultUri $credentialsKeyVaultUri -CredentialsSecretName $credentialsSecretName

        Assert-NotNull $bucket.AkvDetails
        Assert-NotNull $bucket.AkvDetails.CertificateAkvDetails
        Assert-AreEqual $certName $bucket.AkvDetails.CertificateAkvDetails.CertificateName
        Assert-NotNull $bucket.AkvDetails.CredentialsAkvDetails
        Assert-AreEqual $credentialsSecretName $bucket.AkvDetails.CredentialsAkvDetails.SecretName
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Create a bucket using an inline certificate and later migrate its certificate
management to Azure Key Vault via Update-AzNetAppFilesBucket. SKIPPED - see
note above.
#>
function Test-BucketUpdateWithAkv
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName      = Get-ResourceName
    $volName       = Get-ResourceName
    $bucketName    = Get-ResourceName

    $resourceLocation       = "eastus"
    $certKeyVaultUri        = "https://anf-bucket-certs.vault.azure.net/"
    $certName               = "anf-bucket-cert"

    try
    {
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        $subnetName = "default"
        $vnetName   = $resourceGroup + "-vnet"
        $subsid     = (Get-AzureRmContext).Subscription.SubscriptionId
        $subnetId   = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation     = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        $retrievedAcc  = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName
        $retrievedPool = New-AzNetAppFilesPool    -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize 4398046511104 -ServiceLevel "Premium"
        $volume        = New-AzNetAppFilesVolume  -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -CreationToken $volName -UsageThreshold (100 * 1024 * 1024 * 1024) -ServiceLevel "Premium" -SubnetId $subnetId -ProtocolType @("NFSv3")

        $certObject = New-SelfSignedBucketCertificateObject
        $bucket = New-AzNetAppFilesBucket `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName `
            -Path "/" -Permissions "ReadOnly" `
            -NfsUserId 1000 -NfsGroupId 1000 `
            -ServerFqdn "anf-bucket.local" `
            -ServerCertificateObject $certObject `
            -OnCertificateConflictAction "Update"

        # Migrate certificate management to AKV
        $updated = Update-AzNetAppFilesBucket `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName `
            -CertificateKeyVaultUri $certKeyVaultUri -CertificateName $certName `
            -OnCertificateConflictAction "Update"

        Assert-NotNull $updated.AkvDetails
        Assert-AreEqual $certName $updated.AkvDetails.CertificateAkvDetails.CertificateName
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Verifies Set-AzNetAppFilesBucketAkvCredential (stores the generated Access/Secret
key pair in Azure Key Vault rather than returning them). SKIPPED - see note above.
#>
function Test-BucketAkvCredential
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName      = Get-ResourceName
    $volName       = Get-ResourceName
    $bucketName    = Get-ResourceName

    $resourceLocation       = "eastus"
    $certKeyVaultUri        = "https://anf-bucket-certs.vault.azure.net/"
    $certName               = "anf-bucket-cert"
    $credentialsKeyVaultUri = "https://anf-bucket-creds.vault.azure.net/"
    $credentialsSecretName  = "anf-bucket-creds"

    try
    {
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        $subnetName = "default"
        $vnetName   = $resourceGroup + "-vnet"
        $subsid     = (Get-AzureRmContext).Subscription.SubscriptionId
        $subnetId   = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation     = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        $retrievedAcc  = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName
        $retrievedPool = New-AzNetAppFilesPool    -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize 4398046511104 -ServiceLevel "Premium"
        $volume        = New-AzNetAppFilesVolume  -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -CreationToken $volName -UsageThreshold (100 * 1024 * 1024 * 1024) -ServiceLevel "Premium" -SubnetId $subnetId -ProtocolType @("NFSv3")

        $bucket = New-AzNetAppFilesBucket `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName `
            -Path "/" -Permissions "ReadOnly" `
            -NfsUserId 1000 -NfsGroupId 1000 `
            -ServerFqdn "anf-bucket.local" `
            -OnCertificateConflictAction "Update" `
            -CertificateKeyVaultUri $certKeyVaultUri -CertificateName $certName `
            -CredentialsKeyVaultUri $credentialsKeyVaultUri -CredentialsSecretName $credentialsSecretName

        # Stores the key pair in AKV (no return value beyond success)
        $result = Set-AzNetAppFilesBucketAkvCredential `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName `
            -KeyPairExpiryDay 7 -PassThru
        Assert-True { $result -eq $true }
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Verifies Update-AzNetAppFilesBucketCertificate refreshes the bucket server
certificate from Azure Key Vault. SKIPPED - see note above.
#>
function Test-BucketRefreshCertificate
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName      = Get-ResourceName
    $volName       = Get-ResourceName
    $bucketName    = Get-ResourceName

    $resourceLocation       = "eastus"
    $certKeyVaultUri        = "https://anf-bucket-certs.vault.azure.net/"
    $certName               = "anf-bucket-cert"

    try
    {
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        $subnetName = "default"
        $vnetName   = $resourceGroup + "-vnet"
        $subsid     = (Get-AzureRmContext).Subscription.SubscriptionId
        $subnetId   = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation     = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        $retrievedAcc  = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName
        $retrievedPool = New-AzNetAppFilesPool    -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize 4398046511104 -ServiceLevel "Premium"
        $volume        = New-AzNetAppFilesVolume  -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -CreationToken $volName -UsageThreshold (100 * 1024 * 1024 * 1024) -ServiceLevel "Premium" -SubnetId $subnetId -ProtocolType @("NFSv3")

        $bucket = New-AzNetAppFilesBucket `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName `
            -Path "/" -Permissions "ReadOnly" `
            -NfsUserId 1000 -NfsGroupId 1000 `
            -ServerFqdn "anf-bucket.local" `
            -OnCertificateConflictAction "Update" `
            -CertificateKeyVaultUri $certKeyVaultUri -CertificateName $certName

        $result = Update-AzNetAppFilesBucketCertificate `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName -Name $bucketName `
            -PassThru
        Assert-True { $result -eq $true }
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}
