$pfxpwd='123'
$securepfxpwd=$pfxpwd | ConvertTo-SecureString -AsPlainText -Force
$data=123
$securedata=$data | ConvertTo-SecureString -AsPlainText -Force	
  
<#
.SYNOPSIS
Tests remove a key with two confirmations
#>
function Test_RemoveKeyWithTwoConfirmations
{
    Write-Host "Type 'Yes' twice"
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'remove'
    $key=Add-AzureRMKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key
    $global:createdKeys += $keyname
    
    $cr=$global:ConfirmPreference
    $global:ConfirmPreference="High"    
    Remove-AzureRMKeyVaultKey -VaultName $keyVault -Name $keyname
    $global:ConfirmPreference=$cr
    
    Assert-Throws { Get-AzureRMKeyVaultKey  -VaultName $keyVault -Name $keyname}    
}

<#
.SYNOPSIS
Tests remove a key with one confirmation
#>
function Test_RemoveKeyWithOneConfirmations
{
    Write-Host "Type 'Yes' once"
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'remove'
    $key=Add-AzureRMKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key
    $global:createdKeys += $keyname
    
    $cr=$global:ConfirmPreference   
    $global:ConfirmPreference="High"     
    Remove-AzureRMKeyVaultKey -VaultName $keyVault -Name $keyname -Force
    $global:ConfirmPreference=$cr

    Assert-Throws { Get-AzureRMKeyVaultKey  -VaultName $keyVault -Name $keyname}    
}

<#
.SYNOPSIS
Tests cancel removing a key with once
#>
function Test_CancelKeyRemovalOnce
{
    Write-Host "Type 'No' once"
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'remove'
    $key=Add-AzureRMKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key
    $global:createdKeys += $keyname
    
    $cr=$global:ConfirmPreference    
    $global:ConfirmPreference="High"    
    Remove-AzureRMKeyVaultKey -VaultName $keyVault -Name $keyname       
    $global:ConfirmPreference=$cr

    $key=Get-AzureRMKeyVaultKey  -VaultName $keyVault -Name $keyname
    Assert-NotNull $key
}

<#
.SYNOPSIS
Tests cancel removing a key with two prompts
#>
function Test_ConfirmThenCancelKeyRemoval
{
    Write-Host "Type 'Yes' first. Then type 'No'"
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'remove'
    $key=Add-AzureRMKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key
    $global:createdKeys += $keyname
    
    $cr=$global:ConfirmPreference   
    $global:ConfirmPreference="High"     
    Remove-AzureRMKeyVaultKey -VaultName $keyVault -Name $keyname
    $global:ConfirmPreference=$cr

    $key=Get-AzureRMKeyVaultKey  -VaultName $keyVault -Name $keyname
    Assert-NotNull $key
}



<#
.SYNOPSIS
Tests remove a secret with two confirmations
#>
function Test_RemoveSecretWithTwoConfirmations
{
    Write-Host "Type 'Yes' twice"
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'remove'  
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    $cr=$global:ConfirmPreference    
    $global:ConfirmPreference="High"    
    Remove-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname 
    $global:ConfirmPreference=$cr

    Assert-Throws { Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname }    
}

<#
.SYNOPSIS
Tests remove a secret with one confirmations
#>
function Test_RemoveSecretWithOneConfirmations
{
    Write-Host "Type 'Yes' once"
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'remove'  
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    $cr=$global:ConfirmPreference   
    $global:ConfirmPreference="High"    
    Remove-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname  -Force
    $global:ConfirmPreference=$cr

    Assert-Throws { Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname }    
}

<#
.SYNOPSIS
Tests cancel removing a secret with once
#>
function Test_CancelSecretRemovalOnce
{
    Write-Host "Type 'No' once"
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'remove'  
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    $cr=$global:ConfirmPreference    
    $global:ConfirmPreference="High"    
    Remove-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname
    $global:ConfirmPreference=$cr

    $sec=Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname 
    Assert-NotNull $sec
}

<#
.SYNOPSIS
Tests cancel removing a secret with two prompts
#>
function Test_ConfirmThenCancelSecretRemoval
{
    Write-Host "Type 'Yes' first. Then type 'No'"
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'remove'  
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    $cr=$global:ConfirmPreference    
    $global:ConfirmPreference="High"
    Remove-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname  
    $global:ConfirmPreference=$cr

    $sec=Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname 
    Assert-NotNull $sec
}



