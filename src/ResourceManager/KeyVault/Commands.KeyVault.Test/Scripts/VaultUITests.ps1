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
    
    Assert-Throws { Get-AzureKeyVaultKey  -VaultName $keyVault -Name $keyname}    
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

    Assert-Throws { Get-AzureKeyVaultKey  -VaultName $keyVault -Name $keyname}    
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

    Assert-Throws { Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname }    
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

    Assert-Throws { Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname }    
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



