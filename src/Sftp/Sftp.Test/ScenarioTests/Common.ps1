function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

function Get-StorageAccountName
{
    return 'sa' + (getAssetName)
}

function Get-ResourceGroupName 
{
    return 'rg-' + (getAssetName)
}

function Get-CertificatePath
{
    return Join-Path $env:TEMP "sftp-test-cert-$(Get-Random).cert"
}

function Get-PrivateKeyPath
{
    return Join-Path $env:TEMP "sftp-test-key-$(Get-Random)"
}

function IsPlayback
{
	return [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback
}

function Get-AzAccessToken {
    $Account = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Account
    $AzureEnv = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments[[Microsoft.Azure.Commands.Common.Authentication.Abstractions.EnvironmentName]::AzureCloud]
    $TenantId = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Tenant.Id
    $PromptBehavior = [Microsoft.Azure.Commands.Common.Authentication.ShowDialog]::Never
    $Token = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.AuthenticationFactory.Authenticate($account, $AzureEnv, $tenantId, $null, $promptBehavior, $null)
    return $Token.AccessToken
}

function New-TestStorageAccount {
    param(
        [string]$ResourceGroupName,
        [string]$StorageAccountName,
        [string]$Location = "eastus"
    )
    
    # Create resource group if it doesn't exist
    $rg = Get-AzResourceGroup -Name $ResourceGroupName -ErrorAction SilentlyContinue
    if (-not $rg) {
        New-AzResourceGroup -Name $ResourceGroupName -Location $Location | Out-Null
    }
    
    # Create storage account with hierarchical namespace and SFTP enabled
    $storageAccount = New-AzStorageAccount -ResourceGroupName $ResourceGroupName `
        -Name $StorageAccountName `
        -Location $Location `
        -SkuName "Standard_LRS" `
        -Kind "StorageV2" `
        -EnableHierarchicalNamespace $true
    
    # Enable SFTP
    $storageAccount | Set-AzStorageAccount -EnableSftp $true
    
    return $storageAccount
}

function Remove-TestStorageAccount {
    param(
        [string]$ResourceGroupName,
        [string]$StorageAccountName
    )
    
    Remove-AzStorageAccount -ResourceGroupName $ResourceGroupName -Name $StorageAccountName -Force -ErrorAction SilentlyContinue
}

function New-TestLocalUser {
    param(
        [string]$ResourceGroupName,
        [string]$StorageAccountName,
        [string]$Username,
        [string]$PublicKeyPath
    )
    
    $publicKey = Get-Content $PublicKeyPath -Raw
    
    # Create local user on the storage account
    $localUser = New-AzStorageLocalUser -ResourceGroupName $ResourceGroupName `
        -StorageAccountName $StorageAccountName `
        -UserName $Username `
        -HasSshKey $true `
        -SshAuthorizedKey @{
            Description = "Test key"
            Key = $publicKey
        }
    
    return $localUser
}

function Remove-TestLocalUser {
    param(
        [string]$ResourceGroupName,
        [string]$StorageAccountName,
        [string]$Username
    )
    
    Remove-AzStorageLocalUser -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName -UserName $Username -Force -ErrorAction SilentlyContinue
}
