$data=123
$securedata=$data | ConvertTo-SecureString -AsPlainText -Force	
$newdata=456
$newsecuredata=$newdata | ConvertTo-SecureString -AsPlainText -Force	

$expires= (Get-Date).AddYears(2).ToUniversalTime()
$nbf=(Get-Date).ToUniversalTime()
$newexpires= (Get-Date).AddYears(5).ToUniversalTime()
$newnbf=(Get-Date).AddYears(1).ToUniversalTime()
$delta=[TimeSpan]::FromMinutes(2)
$tags=@{"tag1"="value1"; "tag2"=""; "tag3"=$null}
$newtags= @{"tag1"="value1"; "tag2"="value2"; "tag3"="value3"; "tag4"="value4"}
$emptytags=@{}
$contenttype="contenttype"
$newcontenttype="newcontenttype"
$emptycontenttype=""

function Equal-String($left, $right)
{
    if (([string]::IsNullOrEmpty($left)) -and ([string]::IsNullOrEmpty($right)))
    {
        return $true
    }
    if (([string]::IsNullOrEmpty($left)) -or ([string]::IsNullOrEmpty($right)))
    {
        return $false
    }    
    
    return $left.Equals($right)
}

function Assert-SecretAttributes($secretAttr, $secenable, $secexp, $secnbf, $seccontenttype, $sectags)
{
    Assert-NotNull $secretAttr, "secretAttr is null."
    Assert-AreEqual $secenable $secretAttr.Enabled "Expect $secenable. Get $secretAttr.Enabled"  
    Assert-True { Equal-DateTime  $secexp $secretAttr.Expires } "Expect $secexp. Get $secretAttr.Expires"
    Assert-True { Equal-DateTime  $secnbf $secretAttr.NotBefore} "Expect $secnbf. Get $secretAttr.NotBefore"
    Assert-True { Equal-String  $seccontenttype $secretAttr.ContentType} "Expect $seccontenttype. Get $secretAttr.ContentType" 
    Assert-True { Equal-Hashtable $sectags $secretAttr.Tags} "Expected $sectags. Get $secretAttr.Tags"
}

function BulkCreateSecrets ($vault, $prefix, $total)
{
    for ($i=0;$i -lt $total; $i++) 
    { 
        $name = $prefix+$i; 
        $sec=Set-AzureRMKeyVaultSecret -VaultName $vault -Name $name  -SecretValue $securedata
        Assert-NotNull $sec
        $global:createdSecrets += $name   
    }
 }

function BulkCreateSecretVersions ($vault, $name, $total)
{
    for ($i=0;$i -lt $total; $i++) 
    { 
        $sec=Set-AzureRMKeyVaultSecret -VaultName $vault -Name $name  -SecretValue $securedata
        Assert-NotNull $sec      
    }
    $global:createdSecrets += $name
 }


<#
.SYNOPSIS
Create a secret with default attributes
#>

function Test_CreateSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'default'    
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    Assert-AreEqual $sec.SecretValueText $data
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
}

<#
.SYNOPSIS
Create a secret with custom attributes
#>

function Test_CreateSecretWithCustomAttributes
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'attr'    
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata -Expires $expires -NotBefore $nbf -ContentType $contenttype -Disable -Tags $tags
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    Assert-AreEqual $sec.SecretValueText $data
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags
}


<#
.SYNOPSIS
Update a secret
#>

function Test_UpdateSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'update'
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    Assert-AreEqual $sec.SecretValueText $data
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
    
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $newsecuredata
    Assert-NotNull $sec
    Assert-AreEqual $sec.SecretValueText $newdata
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
}

<#
.SYNOPSIS
Tests Set-AzureRMKeyVaultSecret with positional parameter
#>
function Test_SetSecretPositionalParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'positional'  
    $sec=Set-AzureRMKeyVaultSecret $keyVault $secretname $securedata -Expires $expires -NotBefore $nbf -ContentType $contenttype -Disable -Tags $tags
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data    
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags
}

<#
.SYNOPSIS
Tests Set-AzureRMKeyVaultSecret with parameter alias
#>
function Test_SetSecretAliasParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'alias'   
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -SecretName $secretname -SecretValue $securedata -Expires $expires -NotBefore $nbf -ContentType $contenttype -Disable -Tags $tags
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags            
}

<#
.SYNOPSIS
Tests set a secret in non-exist key vault
#>
function Test_SetSecretInNonExistVault
{
    $keyVault = 'notexistvault'
    $secretname= Get-SecretName 'nonexist'    
    Assert-Throws {Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata}
}

<#
.SYNOPSIS
Tests set secret in a vault the user does not have permission
#>
function Test_SetSecretInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    $secretname= Get-SecretName 'nopermission' 
    Assert-Throws {Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata}
}

<#
.SYNOPSIS
Tests update individual secret attributes
#>
function Test_UpdateIndividualSecretAttributes
{
    # Create a secret for updating
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'updateattr'
    $sec=Set-AzureRMKeyVaultSecret $keyVault $secretname $securedata -Expires $expires -NotBefore $nbf -ContentType $contenttype -Disable -Tags $tags
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    Assert-AreEqual $sec.SecretValueText $data
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags
    
    
    # Update Expires
    $sec=Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Expires $newexpires -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $false $newexpires $nbf $contenttype $tags
    
    # Update NotBefore
    $sec=Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -NotBefore $newnbf -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $false $newexpires $newnbf $contenttype $tags
   
    # Update Enable
    $sec=Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Enable $true -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $newexpires $newnbf $contenttype $tags
    
    # Update ContentType
    $sec=Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -ContentType $newcontenttype -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $newexpires $newnbf $newcontenttype $tags
    
    # Update Tags
    $sec=Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Tags $newtags -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $newexpires $newnbf $newcontenttype $newtags
    
    # Clean Tags
    $sec=Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Tags $emptytags -PassThru   
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $newexpires $newnbf $newcontenttype $emptytags
}

<#
.SYNOPSIS
Tests update with no change to secret
#>
function Test_UpdateSecretWithNoChange
{
    # Create a secret for updating
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'updatenochange'
    $sec=Set-AzureRMKeyVaultSecret $keyVault $secretname $securedata -Expires $expires -NotBefore $nbf -ContentType $contenttype -Disable -Tags $tags
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    Assert-AreEqual $sec.SecretValueText $data
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags

    # No change
    $sec=Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags
}

<#
.SYNOPSIS
Tests update individual secret attributes
#>
function Test_UpdateAllEditableSecretAttributes
{
    # Create a secret for updating
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'updateall'
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    Assert-AreEqual $sec.SecretValueText $data
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
  
    # Update all attributes  
    $sec=Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Expires $expires -NotBefore $nbf -ContentType $contenttype -Enable $false -Tags $tags -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags
}

<#
.SYNOPSIS
Tests Set-AzureRMKeyVaultSecretAttribute with positionalParameter
#>
function Test_SetSecretAttributePositionalParameter
{
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'attrpos'
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    Assert-AreEqual $sec.SecretValueText $data
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
  
    $sec=Set-AzureRMKeyVaultSecretAttribute $keyVault $secretname -Expires $expires -NotBefore $nbf -ContentType $contenttype -Enable $false -Tags $tags -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags    
}

<#
.SYNOPSIS
Tests Set-AzureRMKeyVaultSecretAttribute with parameter alias
#>
function Test_SetSecretAttributeAliasParameter
{
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'attralias'
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    Assert-AreEqual $sec.SecretValueText $data
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
  
    $sec=Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -SecretName $secretname -Expires $expires -NotBefore $nbf -ContentType $contenttype -Enable $false -Tags $tags -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags    
}


<#
.SYNOPSIS
Tests Set-AzureRMKeyVaultSecretAttribute with version
#>
function Test_SetSecretVersion
{
        # create a secret and record the version
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'mulupdate'
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $v1 = $sec.Version    
    $global:createdSecrets += $secretname
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
    
    # create a new version
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
    
    # Update old version
    Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -SecretName $secretname -Version $v1 -Enable $true -Expires $expires -NotBefore $nbf -ContentType $contenttype -Tags $tags -PassThru
    
    # Verify old Version changed
    $sec=Get-AzureRMKeyVaultSecret -VaultName $keyVault -SecretName $secretname -Version $v1
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $expires $nbf $contenttype $tags            
    
      # Verify new Version not changed
    $sec=Get-AzureRMKeyVaultSecret -VaultName $keyVault -SecretName $secretname -Version $v2
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
    
    # Verify current Version not changed
    $sec=Get-AzureRMKeyVaultSecret -VaultName $keyVault -SecretName $secretname 
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
    
    # Update old version using positional parameters
    # Set-AzureRMKeyVaultSecretAttribute $keyVault $secretname $v1 -Enable $true -Expires $newexpires -NotBefore $newnbf -ContentType $newcontenttype -Tags $newtags
    
    # Verify old Version changed
    #$sec=Get-AzureRMKeyVaultSecret -VaultName $keyVault -SecretName $secretname -Version $v1
    #Assert-NotNull $sec
    #Assert-SecretAttributes $sec.Attributes $true $newexpires $newnbf $newcontenttype $newtags      
 }                  
    

<#
.SYNOPSIS
Tests set a secret in non-exist key vault
#>
function Test_SetSecretInNonExistVault
{
    $keyVault = 'notexistvault'
    $secretname=Get-SecretName 'nonexist'   
    Assert-Throws {Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -ContentType $newcontenttype}
}

<#
.SYNOPSIS
Tests set an not exist secret
#>
function Test_SetNonExistSecret
{
    $keyVault = Get-KeyVault   
    $secretname=Get-SecretName 'nonexist'   
    Assert-Throws {Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -ContentType $newcontenttype}    
}

<#
.SYNOPSIS
Tests set invalid 
#>
function Test_SetInvalidSecretAttributes
{
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'invalidattr'
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null

    Assert-Throws {Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Expires $nbf  -NotBefore $expires }       
}

<#
.SYNOPSIS
Tests set secret attribute in a vault not have permission
#>
function Test_SetSecretAttrInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    $secretname= Get-SecretName 'nopermission'
    Assert-Throws {Set-AzureRMKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Enable $true}
}

<#
.SYNOPSIS
Tests get one secret from key vault
#>

function Test_GetOneSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'getone'
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data    
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null

    $sec=Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname
    Assert-NotNull $sec
    Assert-AreEqual $sec.SecretValueText $data    
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
}

<#
.SYNOPSIS
Tests get all secrets from key vault
#>

function Test_GetAllSecrets
{
    $keyVault = Get-KeyVault
    $secretpartialname=Get-SecretName 'get'
    $total=30
    BulkCreateSecrets $keyVault $secretpartialname $total
        
    $secs=Get-AzureRMKeyVaultSecret -VaultName $keyVault
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
    $sec1=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec1
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec1.SecretValueText $data    
    Assert-SecretAttributes $sec1.Attributes $true $null $null $null $null
    
    # set the same secret with new values and atrributes
    $sec2=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $newsecuredata -Expires $expires -NotBefore $nbf -ContentType $contenttype -Tags $tags
    Assert-NotNull $sec2  
    Assert-AreEqual $sec2.SecretValueText $newdata    
    Assert-SecretAttributes $sec2.Attributes $true $expires $nbf $contenttype $tags

    # Get the older version of the secret
    $sec3=Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -Version $sec1.Version
    Assert-NotNull $sec3
    Assert-AreEqual $sec3.SecretValueText $data
    Assert-SecretAttributes $sec3.Attributes $true $null $null $null $null

    # Get the newer version of the secret
    $sec4=Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -Version $sec2.Version
    Assert-NotNull $sec4
    Assert-AreEqual $sec4.SecretValueText $newdata  
    Assert-SecretAttributes $sec4.Attributes $true $expires $nbf $contenttype $tags
}

<#
.SYNOPSIS
Tests get all key versions from key vault
#>

function Test_GetSecretVersions
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'getversions'    
    $total=30
    
    BulkCreateSecretVersions $keyVault $secretname $total
        
    $secs=Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -IncludeVersions
    Assert-True { $secs.Count -ge $total }
}

<#
.SYNOPSIS
Tests Get-AzureRMKeyVaultSecret with positional parameter
#>
function Test_GetSecretPositionalParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'positional'  
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data    

    $sec=Get-AzureRMKeyVaultSecret $keyVault $secretname
    Assert-NotNull $sec
    Assert-AreEqual $sec.SecretValueText $data    
}

<#
.SYNOPSIS
Tests Get-AzureRMKeyVaultSecret with parameter alias
#>
function Test_GetSecretAliasParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'alias'  
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data    

    $sec=Get-AzureRMKeyVaultSecret -VaultName $keyVault -SecretName $secretname 
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
    Assert-Throws {Get-AzureRMKeyVaultSecret -VaultName $keyVault}
}

<#
.SYNOPSIS
Tests get a non-exist secret
#>
function Test_GetNonExistSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'notexistvault'
      
    Assert-Throws {Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname}
}

<#
.SYNOPSIS
Tests get secret in a vault the user does not have permission
#>
function Test_GetSecretInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    Assert-Throws {Get-AzureRMKeyVaultSecret -VaultName $keyVault}
}

<#
.SYNOPSIS
Tests remove a secret
#>
function Test_RemoveSecretWithoutPrompt
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'remove'  
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    $sec=Remove-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -Force -Confirm:$false -PassThru
    Assert-NotNull $sec
    
    Assert-Throws { Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname }    
}

<#
.SYNOPSIS
Tests Remove-AzureRMKeyVaultSecret with whatif option
#>
function Test_RemoveSecretWhatIf
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'whatif'
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    Remove-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -WhatIf -Force
    
    $sec=Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname
    Assert-NotNull $sec        
}

<#
.SYNOPSIS
Tests Remove-AzureRMKeyVaultSecret with positional parameter
#>
function Test_RemoveSecretPositionalParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'positional'  
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data    

    Remove-AzureRMKeyVaultSecret $keyVault $secretname  -Force -Confirm:$false 
    
    Assert-Throws {Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname}    
}

<#
.SYNOPSIS
Tests Remove-AzureRMKeyVaultSecret with parameter alias
#>
function Test_RemoveSecretAliasParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'alias'  
    $sec=Set-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    Assert-AreEqual $sec.SecretValueText $data    

    Remove-AzureRMKeyVaultSecret -VaultName $keyVault  -SecretName $secretname  -Force -Confirm:$false 
    
    Assert-Throws {Get-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname}               
}

<#
.SYNOPSIS
Tests remove a secret in non-exist key vault
#>
function Test_RemoveSecretInNonExistVault
{
    $keyVault = 'notexistvault'
    $secretname= Get-SecretName 'notexistvault'
    Assert-Throws {Remove-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests remove a non-exist secret
#>
function Test_RemoveNonExistSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'notexistvault'
      
    Assert-Throws {Remove-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests Remove a secret in a vault the user does not have permission
#>
function Test_RemoveSecretInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    $secretname= Get-SecretName 'nopermission'
    Assert-Throws {Remove-AzureRMKeyVaultSecret -VaultName $keyVault -Name $secretname -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests pipeline commands to update values of multiple secrets
#>
function Test_PipelineUpdateSecrets
{
    $keyVault = Get-KeyVault
    $secretpartialname=Get-SecretName 'pipeupdate'
    $total=2
    BulkCreateSecrets $keyVault $secretpartialname $total        
    Get-AzureRMKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | Set-AzureRMKeyVaultSecret -SecretValue $newsecuredata	
    Get-AzureRMKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | ForEach-Object { Assert-AreEqual $_.SecretValueText $newdata }
}

<#
.SYNOPSIS
Tests pipeline commands to update attributes of multiple secret
#>
function Test_PipelineUpdateSecretAttributes
{
    $keyVault = Get-KeyVault
    $secretpartialname=Get-SecretName 'pipeupdateattr'
    $total=2
    BulkCreateSecrets $keyVault $secretpartialname $total        
    
    Get-AzureRMKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | Set-AzureRMKeyVaultSecretAttribute -ContentType $newcontenttype
    Get-AzureRMKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | ForEach-Object { Assert-True { Equal-String $newcontenttype  $_.ContentType }}
    
    Get-AzureRMKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | Set-AzureRMKeyVaultSecretAttribute -Tags $newtags
    Get-AzureRMKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | ForEach-Object { Assert-True { Equal-Hashtable $newtags $_.Tags }}
}

 <#
.SYNOPSIS
Tests pipeline commands to update attributes of multiple secret versions  
#>

function Test_PipelineUpdateSecretVersions
{
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'pipeupdateversion'
    $total=2    
    BulkCreateSecretVersions $keyVault $secretname $total
    
    Get-AzureRMKeyVaultSecret $keyVault $secretname -IncludeVersions | Set-AzureRMKeyVaultSecretAttribute -Expires $newexpires
    Get-AzureRMKeyVaultSecret $keyVault $secretname -IncludeVersions |  ForEach-Object { Assert-True { Equal-DateTime $newexpires  $_.Expires }}
    
    Get-AzureRMKeyVaultSecret $keyVault $secretname -IncludeVersions | Set-AzureRMKeyVaultSecretAttribute -Tags $newtags
    Get-AzureRMKeyVaultSecret $keyVault $secretname -IncludeVersions | ForEach-Object { Assert-True { Equal-Hashtable $newtags $_.Tags }}
 }
 
<#
.SYNOPSIS
Tests pipeline commands to remove multiple secrets 
#>

function Test_PipelineRemoveSecrets
{
    $keyVault = Get-KeyVault
    $secretpartialname=Get-SecretName 'piperemove'
    $total=2
    BulkCreateSecrets $keyVault $secretpartialname $total 
    Get-AzureRMKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | Remove-AzureRMKeyVaultSecret -Force -Confirm:$false	

    $secs = Get-AzureRMKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  
    Assert-AreEqual $secs.Count 0     
}