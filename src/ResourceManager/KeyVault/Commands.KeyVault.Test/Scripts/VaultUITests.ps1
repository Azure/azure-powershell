$pfxpwd='123'
$securepfxpwd=$pfxpwd | ConvertTo-SecureString -AsPlainText -Force
$data=123
$securedata=$data | ConvertTo-SecureString -AsPlainText -Force	
$pfxPassword = "123"
  
function CreateAKVCertificate(
    [string] $keyVault,
    [string] $certificateName)
{
    $pfxPath = Get-FilePathFromCommonData 'importpfx01.pfx'
    $securePfxPassword = ConvertTo-SecureString $pfxPassword -AsPlainText -Force
    $createdCert = Import-AzureKeyVaultCertificate $keyVault $certificateName -FilePath $pfxPath -Password $securePfxPassword
    $global:createdCertificates += $certificateName

    return $createdCert
}

function CreateAKVManagedStorageAccount(
    [string] $keyVault,
    [string] $managedStorageAccountName)
{
    $storageAccountResourceId = Get-KeyVaultManagedStorageResourceId
    $createdManagedStorageAccount = Set-AzureKeyVaultManagedStorageAccount $keyVault $managedStorageAccountName $storageAccountResourceId 'key1' -DisableAutoRegenerateKey
    return $createdManagedStorageAccount
}

function CreateAKVManagedStorageSasDefinition(
    [string] $keyVault,
    [string] $managedStorageAccountName,
    [string] $managedStorageSasDefinitionName)
{
    $storageAccountResourceId = Get-KeyVaultManagedStorageResourceId
    Set-AzureKeyVaultManagedStorageAccount $keyVault $managedStorageAccountName $storageAccountResourceId 'key1' -DisableAutoRegenerateKey
    $createdManagedStorageSasDefinition = Set-AzureKeyVaultManagedStorageSasDefinition $keyVault $managedStorageAccountName $managedStorageSasDefinitionName -Parameter @{"sasType"="service";"serviceSasType"="blob";"signedResourceTypes"="b";"signedVersion"="2016-05-31";"signedProtocols"="https";"signedIp"="168.1.5.60-168.1.5.70";"validityPeriod"="P30D";"signedPermissions"="ra";"blobName"="blob1";"containerName"="container1";"rscd"="";"rscc"=""}
    return $createdManagedStorageSasDefinition
}

<#
.SYNOPSIS
Tests remove a key with two confirmations
#>
function Test_RemoveKeyWithTwoConfirmations
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' twice"
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'remove'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key
    $global:createdKeys += $keyname
    
    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"    
    Remove-AzureKeyVaultKey -VaultName $keyVault -Name $keyname
    $global:ConfirmPreference=$cr
    
    $key = Get-AzureKeyVaultKey  -VaultName $keyVault -Name $keyname
    Assert-Null $key
}

<#
.SYNOPSIS
Tests remove a key with one confirmation
#>
function Test_RemoveKeyWithOneConfirmations
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' once"
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'remove'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key
    $global:createdKeys += $keyname
    
    $cr=$global:ConfirmPreference   
    $global:ConfirmPreference="High"     
    Remove-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Force
    $global:ConfirmPreference=$cr

    $key = Get-AzureKeyVaultKey  -VaultName $keyVault -Name $keyname
    Assert-Null $key
}

<#
.SYNOPSIS
Tests cancel removing a key with once
#>
function Test_CancelKeyRemovalOnce
{
    Write-Host -ForegroundColor Yellow "Type 'No' once"
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'remove'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key
    $global:createdKeys += $keyname
    
    $cr=$global:ConfirmPreference    
    $global:ConfirmPreference="High"    
    Remove-AzureKeyVaultKey -VaultName $keyVault -Name $keyname       
    $global:ConfirmPreference=$cr

    $key=Get-AzureKeyVaultKey  -VaultName $keyVault -Name $keyname
    Assert-NotNull $key
}

<#
.SYNOPSIS
Tests cancel removing a key with two prompts
#>
function Test_ConfirmThenCancelKeyRemoval
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' first. Then type 'No'"
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'remove'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key
    $global:createdKeys += $keyname
    
    $cr=$global:ConfirmPreference   
    $global:ConfirmPreference="High"     
    Remove-AzureKeyVaultKey -VaultName $keyVault -Name $keyname
    $global:ConfirmPreference=$cr

    $key=Get-AzureKeyVaultKey  -VaultName $keyVault -Name $keyname
    Assert-NotNull $key
}



<#
.SYNOPSIS
Tests remove a secret with two confirmations
#>
function Test_RemoveSecretWithTwoConfirmations
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' twice"
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'remove'  
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    $cr=$global:ConfirmPreference    
    $global:ConfirmPreference="High"    
    Remove-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname 
    $global:ConfirmPreference=$cr
	
    $secret = Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname
    Assert-Null $secret
}

<#
.SYNOPSIS
Tests remove a secret with one confirmations
#>
function Test_RemoveSecretWithOneConfirmations
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' once"
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'remove'  
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    $cr=$global:ConfirmPreference   
    $global:ConfirmPreference="High"    
    Remove-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -Force
    $global:ConfirmPreference=$cr

    $secret = Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname
    Assert-Null $secret
}

<#
.SYNOPSIS
Tests cancel removing a secret with once
#>
function Test_CancelSecretRemovalOnce
{
    Write-Host -ForegroundColor Yellow "Type 'No' once"
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'remove'  
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    $cr=$global:ConfirmPreference    
    $global:ConfirmPreference="High"    
    Remove-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname
    $global:ConfirmPreference=$cr

    $sec=Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname 
    Assert-NotNull $sec
}

<#
.SYNOPSIS
Tests cancel removing a secret with two prompts
#>
function Test_ConfirmThenCancelSecretRemoval
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' first. Then type 'No'"
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'remove'  
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    $cr=$global:ConfirmPreference    
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  
    $global:ConfirmPreference=$cr

    $sec=Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname 
    Assert-NotNull $sec
}

<#
.SYNOPSIS
Tests remove a certificate with two confirmations
#>
function Test_RemoveCertificateWithTwoConfirmations
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' twice"
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'removeWithTwo'
    $cert = CreateAKVCertificate $keyVault $certificateName
    Assert-NotNull $cert
    $global:createdCertificates += $certificateName

    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultCertificate -VaultName $keyVault -Name $certificateName
    $global:ConfirmPreference=$cr
	
    $cert = Get-AzureKeyVaultCertificate -VaultName $keyVault -Name $certificateName
    Assert-Null $cert
}

<#
.SYNOPSIS
Tests remove a certificate with one confirmations
#>
function Test_RemoveCertificateWithOneConfirmations
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' once"
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'removeWithOne'
    $cert = CreateAKVCertificate $keyVault $certificateName
    Assert-NotNull $cert
    $global:createdCertificates += $certificateName

    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultCertificate -VaultName $keyVault -Name $certificateName -Force
    $global:ConfirmPreference=$cr

    $cert = Get-AzureKeyVaultCertificate -VaultName $keyVault -Name $certificateName
    Assert-Null $cert
}

<#
.SYNOPSIS
Tests cancel removing a certificate with once
#>
function Test_CancelCertificateRemovalOnce
{
    Write-Host -ForegroundColor Yellow "Type 'No' once"
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'removeAgainstOne'
    $cert = CreateAKVCertificate $keyVault $certificateName
    Assert-NotNull $cert
    $global:createdCertificates += $certificateName

    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultCertificate -VaultName $keyVault -Name $certificateName
    $global:ConfirmPreference=$cr

    $sec=Get-AzureKeyVaultCertificate -VaultName $keyVault -Name $certificateName
    Assert-NotNull $sec
}

<#
.SYNOPSIS
Tests cancel removing a certificate with two prompts
#>
function Test_ConfirmThenCancelCertificateRemoval
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' first. Then type 'No'"
    $keyVault = Get-KeyVault
    $certificateName = Get-CertificateName 'removeAgainstTwo'
    $cert = CreateAKVCertificate $keyVault $certificateName
    Assert-NotNull $cert
    $global:createdCertificates += $certificateName

    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultCertificate -VaultName $keyVault -Name $certificateName
    $global:ConfirmPreference=$cr

    $sec=Get-AzureKeyVaultCertificate -VaultName $keyVault -Name $certificateName
    Assert-NotNull $sec
}

<#
.SYNOPSIS
Tests remove a managedStorageAccount with two confirmations
#>
function Test_RemoveManagedStorageAccountWithTwoConfirmations
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' twice"
    $keyVault = Get-KeyVault
    $managedStorageAccountName = Get-ManagedStorageAccountName 'remW2'
    $managedStorageAccount = CreateAKVManagedStorageAccount $keyVault $managedStorageAccountName
    Assert-NotNull $managedStorageAccount
    $global:createdManagedStorageAccounts += $managedStorageAccountName

    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName
    $global:ConfirmPreference=$cr

    Assert-Throws { Get-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName }
}

<#
.SYNOPSIS
Tests remove a managedStorageAccount with one confirmations
#>
function Test_RemoveManagedStorageAccountWithOneConfirmations
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' once"
    $keyVault = Get-KeyVault
    $managedStorageAccountName = Get-ManagedStorageAccountName 'remW1'
    $managedStorageAccount = CreateAKVManagedStorageAccount $keyVault $managedStorageAccountName
    Assert-NotNull $managedStorageAccount
    $global:createdManagedStorageAccounts += $managedStorageAccountName

    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName -Force
    $global:ConfirmPreference=$cr

    Assert-Throws { Get-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName }
}

<#
.SYNOPSIS
Tests cancel removing a managedStorageAccount with once
#>
function Test_CancelManagedStorageAccountRemovalOnce
{
    Write-Host -ForegroundColor Yellow "Type 'No' once"
    $keyVault = Get-KeyVault
    $managedStorageAccountName = Get-ManagedStorageAccountName 'remA1'
    $managedStorageAccount = CreateAKVManagedStorageAccount $keyVault $managedStorageAccountName
    Assert-NotNull $managedStorageAccount
    $global:createdManagedStorageAccounts += $managedStorageAccountName

    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName
    $global:ConfirmPreference=$cr

    $sec=Get-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName
    Assert-NotNull $sec
}

<#
.SYNOPSIS
Tests cancel removing a managedStorageAccount with two prompts
#>
function Test_ConfirmThenCancelManagedStorageAccountRemoval
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' first. Then type 'No'"
    $keyVault = Get-KeyVault
    $managedStorageAccountName = Get-ManagedStorageAccountName 'remA2'
    $managedStorageAccount = CreateAKVManagedStorageAccount $keyVault $managedStorageAccountName
    Assert-NotNull $managedStorageAccount
    $global:createdManagedStorageAccounts += $managedStorageAccountName

    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName
    $global:ConfirmPreference=$cr

    $sec=Get-AzureKeyVaultManagedStorageAccount -VaultName $keyVault -AccountName $managedStorageAccountName
    Assert-NotNull $sec
}

<#
.SYNOPSIS
Tests remove a managedStorageSasDefinition with two confirmations
#>
function Test_RemoveManagedStorageSasDefinitionWithTwoConfirmations
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' twice"
    $keyVault = Get-KeyVault
    $managedStorageAccountName = Get-ManagedStorageSasDefinitionName 'remW2'
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'remW2'
    $managedStorageSasDefinition = CreateAKVManagedStorageSasDefinition $keyVault $managedStorageAccountName $managedStorageSasDefinitionName
    Assert-NotNull $managedStorageSasDefinition
    $global:createdManagedStorageSasDefinitions += $managedStorageSasDefinitionName

    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultManagedStorageSasDefinition -VaultName $keyVault -AccountName $managedStorageAccountName -Name $managedStorageSasDefinitionName
    $global:ConfirmPreference=$cr

    Assert-Throws { Get-AzureKeyVaultManagedStorageSasDefinition -VaultName $keyVault -AccountName $managedStorageAccountName -Name $managedStorageSasDefinitionName }
}

<#
.SYNOPSIS
Tests remove a managedStorageSasDefinition with one confirmations
#>
function Test_RemoveManagedStorageSasDefinitionWithOneConfirmations
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' once"
    $keyVault = Get-KeyVault
    $managedStorageAccountName = Get-ManagedStorageAccountName 'remW1'
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'remW1'
    $managedStorageSasDefinition = CreateAKVManagedStorageSasDefinition $keyVault $managedStorageAccountName $managedStorageSasDefinitionName
    Assert-NotNull $managedStorageSasDefinition
    $global:createdManagedStorageSasDefinitions += $managedStorageSasDefinitionName

    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultManagedStorageSasDefinition -VaultName $keyVault -AccountName $managedStorageAccountName -Name $managedStorageSasDefinitionName -Force
    $global:ConfirmPreference=$cr

    Assert-Throws { Get-AzureKeyVaultManagedStorageSasDefinition -VaultName $keyVault -AccountName $managedStorageAccountName -Name $managedStorageSasDefinitionName }
}

<#
.SYNOPSIS
Tests cancel removing a managedStorageSasDefinition with once
#>
function Test_CancelManagedStorageSasDefinitionRemovalOnce
{
    Write-Host -ForegroundColor Yellow "Type 'No' once"
    $keyVault = Get-KeyVault
    $managedStorageAccountName = Get-ManagedStorageAccountName 'remA1'
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'remA1'
    $managedStorageSasDefinition = CreateAKVManagedStorageSasDefinition $keyVault $managedStorageAccountName $managedStorageSasDefinitionName
    Assert-NotNull $managedStorageSasDefinition
    $global:createdManagedStorageSasDefinitions += $managedStorageSasDefinitionName

    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultManagedStorageSasDefinition -VaultName $keyVault -AccountName $managedStorageAccountName -Name $managedStorageSasDefinitionName
    $global:ConfirmPreference=$cr

    $sec=Get-AzureKeyVaultManagedStorageSasDefinition -VaultName $keyVault -AccountName $managedStorageAccountName -Name $managedStorageSasDefinitionName
    Assert-NotNull $sec
}

<#
.SYNOPSIS
Tests cancel removing a managedStorageSasDefinition with two prompts
#>
function Test_ConfirmThenCancelManagedStorageSasDefinitionRemoval
{
    Write-Host -ForegroundColor Yellow "Type 'Yes' first. Then type 'No'"
    $keyVault = Get-KeyVault
    $managedStorageAccountName = Get-ManagedStorageAccountName 'remA2'
    $managedStorageSasDefinitionName = Get-ManagedStorageSasDefinitionName 'remA2'
    $managedStorageSasDefinition = CreateAKVManagedStorageSasDefinition $keyVault $managedStorageAccountName $managedStorageSasDefinitionName
    Assert-NotNull $managedStorageSasDefinition
    $global:createdManagedStorageSasDefinitions += $managedStorageSasDefinitionName

    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"
    Remove-AzureKeyVaultManagedStorageSasDefinition -VaultName $keyVault -AccountName $managedStorageAccountName -Name $managedStorageSasDefinitionName
    $global:ConfirmPreference=$cr

    $sec=Get-AzureKeyVaultManagedStorageSasDefinition -VaultName $keyVault -AccountName $managedStorageAccountName -Name $managedStorageSasDefinitionName
    Assert-NotNull $sec
}