$data=123
$securedata=$data | ConvertTo-SecureString -AsPlainText -Force	
$newdata=456
$newsecuredata=$newdata | ConvertTo-SecureString -AsPlainText -Force	

<#
.SYNOPSIS
Create a secret
#>

function Test_CreateSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'default'    
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    Assert-AreEqual $sec.SecretValueText $data
}


<#
.SYNOPSIS
Update a secret
#>

function Test_UpdateSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'update'
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    Assert-AreEqual $sec.SecretValueText $data
    
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $newsecuredata
    Assert-NotNull $sec
    Assert-AreEqual $sec.SecretValueText $newdata
}

<#
.SYNOPSIS
Tests Set-AzureKeyVaultSecret with positional parameter
#>
function Test_SetSecretPositionalParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'positional'  
    $sec=Set-AzureKeyVaultSecret $keyVault $secretname $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data    
}

<#
.SYNOPSIS
Tests Set-AzureKeyVaultSecret with parameter alias
#>
function Test_SetSecretAliasParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'alias'   
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -SecretName $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data            
}

<#
.SYNOPSIS
Tests set a secret in non-exist key vault
#>
function Test_SetSecretInNonExistVault
{
    $keyVault = 'notexistvault'
    $secretname= Get-SecretName 'nonexist'    
    Assert-Throws {Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata}
}

<#
.SYNOPSIS
Tests set secret in a vault the user does not have permission
#>
function Test_SetSecretInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    $secretname= Get-SecretName 'nopermission' 
    Assert-Throws {Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata}
}

<#
.SYNOPSIS
Tests get one secret from key vault
#>

function Test_GetOneSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'getone'
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data    

    $sec=Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname
    Assert-NotNull $sec
    Assert-AreEqual $sec.SecretValueText $data    
}

<#
.SYNOPSIS
Tests get all secrets from key vault
#>

function Test_GetAllSecrets
{
    $keyVault = Get-KeyVault
    $secretpartialname=Get-SecretName 'get'
    $total=2
    for ($i=0;$i -lt $total; $i++) 
    { 
        $secretname = $secretpartialname+$i; 
        $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
        Assert-NotNull $sec
        $global:createdSecrets += $secretname
    }
        
    $secs=Get-AzureKeyVaultSecret -VaultName $keyVault
    Assert-True { $secs.Count -ge $total }
}

<#
.SYNOPSIS
Tests get previous version of a secret from key vault
#>

function Test_GetPreviousVersionOfSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'getversion'

    # set secret for the first time
    $sec1=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec1
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec1.SecretValueText $data    

    # set the same secret with new values but with new version
    $sec2=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $newsecuredata
    Assert-NotNull $sec2  
    Assert-AreEqual $sec2.SecretValueText $newdata    

    # Get the older version of the secret
    $sec3=Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -Version $sec1.Version
    Assert-NotNull $sec3
    Assert-AreEqual $sec3.SecretValueText $data

    # Get the newer version of the secret
    $sec4=Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -Version $sec2.Version
    Assert-NotNull $sec4
    Assert-AreEqual $sec4.SecretValueText $newdata  
}

<#
.SYNOPSIS
Tests Get-AzureKeyVaultSecret with positional parameter
#>
function Test_GetSecretPositionalParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'positional'  
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data    

    $sec=Get-AzureKeyVaultSecret $keyVault $secretname
    Assert-NotNull $sec
    Assert-AreEqual $sec.SecretValueText $data    
}

<#
.SYNOPSIS
Tests Get-AzureKeyVaultSecret with parameter alias
#>
function Test_GetSecretAliasParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'alias'  
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data    

    $sec=Get-AzureKeyVaultSecret -VaultName $keyVault -SecretName $secretname 
    Assert-NotNull $sec
    Assert-AreEqual $sec.SecretValueText $data                    
}

<#
.SYNOPSIS
Tests get a secret in non-exist key vault
#>
function Test_GetSecretInNonExistVault
{
    $keyVault = 'notexistvault'
    Assert-Throws {Get-AzureKeyVaultSecret -VaultName $keyVault}
}

<#
.SYNOPSIS
Tests get a non-exist secret
#>
function Test_GetNonExistSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'notexistvault'
      
    Assert-Throws {Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname}
}

<#
.SYNOPSIS
Tests get secret in a vault the user does not have permission
#>
function Test_GetSecretInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    Assert-Throws {Get-AzureKeyVaultSecret -VaultName $keyVault}
}

<#
.SYNOPSIS
Tests remove a secret
#>
function Test_RemoveSecretWithoutPrompt
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'remove'  
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    $sec=Remove-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -Force -Confirm:$false -PassThru
    Assert-NotNull $sec
    
    Assert-Throws { Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname }    
}

<#
.SYNOPSIS
Tests Remove-AzureKeyVaultSecret with whatif option
#>
function Test_RemoveSecretWhatIf
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'whatif'
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    Remove-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -WhatIf -Force
    
    $sec=Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname
    Assert-NotNull $sec        
}

<#
.SYNOPSIS
Tests Remove-AzureKeyVaultSecret with positional parameter
#>
function Test_RemoveSecretPositionalParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'positional'  
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data    

    Remove-AzureKeyVaultSecret $keyVault $secretname  -Force -Confirm:$false 
    
    Assert-Throws {Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname}    
}

<#
.SYNOPSIS
Tests Remove-AzureKeyVaultSecret with parameter alias
#>
function Test_RemoveSecretAliasParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'alias'  
    $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data    

    Remove-AzureKeyVaultSecret -VaultName $keyVault  -SecretName $secretname  -Force -Confirm:$false 
    
    Assert-Throws {Get-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname}               
}

<#
.SYNOPSIS
Tests remove a secret in non-exist key vault
#>
function Test_RemoveSecretInNonExistVault
{
    $keyVault = 'notexistvault'
    $secretname= Get-SecretName 'notexistvault'
    Assert-Throws {Remove-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests remove a non-exist secret
#>
function Test_RemoveNonExistSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'notexistvault'
      
    Assert-Throws {Remove-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests Remove a secret in a vault the user does not have permission
#>
function Test_RemoveSecretInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    $secretname= Get-SecretName 'nopermission'
    Assert-Throws {Remove-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests pipeline commands to update attributes of multiple secret
#>

function Test_PipelineUpdateSecrets
{
    $keyVault = Get-KeyVault
    $secretpartialname=Get-KeyName 'pipeupdate'
    $total=2
    for ($i=0;$i -lt $total; $i++) 
    { 
        $secretname = $secretpartialname+$i; 
        $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
        Assert-NotNull $sec
        $global:createdSecrets += $secretname   
        Assert-AreEqual $sec.SecretValueText $data
    }
        
    Get-AzureKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | Set-AzureKeyVaultSecret -SecretValue $newsecuredata	
    Get-AzureKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | ForEach-Object { Assert-AreEqual $_.SecretValueText $newdata }
}

<#
.SYNOPSIS
Tests pipeline commands to remove multiple secrets 
#>

function Test_PipelineRemoveSecrets
{
    $keyVault = Get-KeyVault
    $secretpartialname=Get-KeyName 'piperemove'
    $total=2
    for ($i=0;$i -lt $total; $i++) 
    { 
        $secretname = $secretpartialname+$i; 
        $sec=Set-AzureKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
        Assert-NotNull $sec
        $global:createdSecrets += $secretname   
        Assert-AreEqual $sec.SecretValueText $data
    }


    Get-AzureKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | Remove-AzureKeyVaultSecret -Force -Confirm:$false	

    $secs = Get-AzureKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  
    Assert-AreEqual $secs.Count 0     
}