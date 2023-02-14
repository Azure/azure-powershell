﻿$data=123
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

function Assert-SecretAttributes($secretAttr, $secenable, $secexp, $secnbf, $seccontenttype, $sectags)
{
    Assert-NotNull $secretAttr, "secretAttr is null."
    Assert-AreEqual $secenable $secretAttr.Enabled "Expect $secenable. Get $secretAttr.Enabled"  
    Assert-True { Equal-DateTime  $secexp $secretAttr.Expires } "Expect $secexp. Get $secretAttr.Expires"
    Assert-True { Equal-DateTime  $secnbf $secretAttr.NotBefore} "Expect $secnbf. Get $secretAttr.NotBefore"
    Assert-True { Equal-String  $seccontenttype $secretAttr.ContentType} "Expect $seccontenttype. Get $secretAttr.ContentType" 
    Assert-True { Equal-Hashtable $sectags $secretAttr.Tags} "Expected $sectags. Get $secretAttr.Tags"
	Assert-NotNull $secretAttr.RecoveryLevel, "Deletion recovery level is null."
}

function BulkCreateSecrets ($vault, $prefix, $total)
{
    for ($i=0;$i -lt $total; $i++) 
    { 
        $name = $prefix+$i; 
        $sec=Set-AzKeyVaultSecret -VaultName $vault -Name $name  -SecretValue $securedata
        Assert-NotNull $sec
        $global:createdSecrets += $name   
    }
 }

function BulkCreateSecretVersions ($vault, $name, $total)
{
    for ($i=0;$i -lt $total; $i++) 
    { 
        $sec=Set-AzKeyVaultSecret -VaultName $vault -Name $name  -SecretValue $securedata
        Assert-NotNull $sec      
    }
    $global:createdSecrets += $name
 }


<#
.SYNOPSIS
Create a secret with default attributes
.DESCRIPTION
SmokeTest
#>

function Test_CreateSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'default'    
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $data
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
}

<#
.SYNOPSIS
Create a secret with custom attributes
.DESCRIPTION
SmokeTest
#>

function Test_CreateSecretWithCustomAttributes
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'attr'    
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata -Expires $expires -NotBefore $nbf -ContentType $contenttype -Disable -Tag $tags
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $data
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags
}


<#
.SYNOPSIS
Update a secret
.DESCRIPTION
SmokeTest
#>

function Test_UpdateSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'update'
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $data
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
    
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $newsecuredata
    Assert-NotNull $sec
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $newdata
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
}

<#
.SYNOPSIS
Tests Set-AzKeyVaultSecret with positional parameter
#>
function Test_SetSecretPositionalParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'positional'  
    $sec=Set-AzKeyVaultSecret $keyVault $secretname $securedata -Expires $expires -NotBefore $nbf -ContentType $contenttype -Disable -Tag $tags
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $data 
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags
}

<#
.SYNOPSIS
Tests Set-AzKeyVaultSecret with parameter alias
#>
function Test_SetSecretAliasParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'alias'   
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -SecretName $secretname -SecretValue $securedata -Expires $expires -NotBefore $nbf -ContentType $contenttype -Disable -Tag $tags
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $data
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
    Assert-Throws {Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata}
}

<#
.SYNOPSIS
Tests set secret in a vault the user does not have permission
#>
function Test_SetSecretInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    $secretname= Get-SecretName 'nopermission' 
    Assert-Throws {Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata}
}

<#
.SYNOPSIS
Tests update individual secret attributes
.DESCRIPTION
SmokeTest
#>
function Test_UpdateIndividualSecretAttributes
{
    # Create a secret for updating
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'updateattr'
    $sec=Set-AzKeyVaultSecret $keyVault $secretname $securedata -Expires $expires -NotBefore $nbf -ContentType $contenttype -Disable -Tag $tags
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $data
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags
    
    
    # Update Expires
    $sec=Set-AzKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Expires $newexpires -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $false $newexpires $nbf $contenttype $tags
    
    # Update NotBefore
    $sec=Set-AzKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -NotBefore $newnbf -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $false $newexpires $newnbf $contenttype $tags
   
    # Update Enable
    $sec=Set-AzKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Enable $true -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $newexpires $newnbf $contenttype $tags
    
    # Update ContentType
    $sec=Set-AzKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -ContentType $newcontenttype -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $newexpires $newnbf $newcontenttype $tags
    
    # Update Tags
    $sec=Set-AzKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Tag $newtags -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $newexpires $newnbf $newcontenttype $newtags
    
    # Clean Tags
    $sec=Set-AzKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Tag $emptytags -PassThru   
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
    $sec=Set-AzKeyVaultSecret $keyVault $secretname $securedata -Expires $expires -NotBefore $nbf -ContentType $contenttype -Disable -Tag $tags
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $data
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags

    # No change
    $sec=Set-AzKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -PassThru
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
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $data
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
  
    # Update all attributes  
    $sec=Set-AzKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Expires $expires -NotBefore $nbf -ContentType $contenttype -Enable $false -Tag $tags -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags
}

<#
.SYNOPSIS
Tests Set-AzKeyVaultSecretAttribute with positionalParameter
#>
function Test_SetSecretAttributePositionalParameter
{
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'attrpos'
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $data
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
  
    $sec=Set-AzKeyVaultSecretAttribute $keyVault $secretname -Expires $expires -NotBefore $nbf -ContentType $contenttype -Enable $false -Tag $tags -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags    
}

<#
.SYNOPSIS
Tests Set-AzKeyVaultSecretAttribute with parameter alias
#>
function Test_SetSecretAttributeAliasParameter
{
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'attralias'
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $data
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
  
    $sec=Set-AzKeyVaultSecretAttribute -VaultName $keyVault -SecretName $secretname -Expires $expires -NotBefore $nbf -ContentType $contenttype -Enable $false -Tag $tags -PassThru
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $false $expires $nbf $contenttype $tags    
}


<#
.SYNOPSIS
Tests Set-AzKeyVaultSecretAttribute with version
#>
function Test_SetSecretVersion
{
        # create a secret and record the version
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'mulupdate'
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $v1 = $sec.Version    
    $global:createdSecrets += $secretname
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
    
    # create a new version
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $v2 = $sec.Version
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
    
    # Update old version
    Set-AzKeyVaultSecretAttribute -VaultName $keyVault -SecretName $secretname -Version $v1 -Enable $true -Expires $expires -NotBefore $nbf -ContentType $contenttype -Tag $tags -PassThru
    
    # Verify old Version changed
    $sec=Get-AzKeyVaultSecret -VaultName $keyVault -SecretName $secretname -Version $v1
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $expires $nbf $contenttype $tags            
    
      # Verify new Version not changed
    $sec=Get-AzKeyVaultSecret -VaultName $keyVault -SecretName $secretname -Version $v2
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
    
    # Verify current Version not changed
    $sec=Get-AzKeyVaultSecret -VaultName $keyVault -SecretName $secretname 
    Assert-NotNull $sec
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
    
    # Update old version using positional parameters
    # Set-AzKeyVaultSecretAttribute $keyVault $secretname $v1 -Enable $true -Expires $newexpires -NotBefore $newnbf -ContentType $newcontenttype -Tag $newtags
    
    # Verify old Version changed
    #$sec=Get-AzKeyVaultSecret -VaultName $keyVault -SecretName $secretname -Version $v1
    #Assert-NotNull $sec
    #Assert-SecretAttributes $sec.Attributes $true $newexpires $newnbf $newcontenttype $newtags      
 }                  
    
<#
.SYNOPSIS
Get a secret in a syntactically bad vault name
#>

function Test_GetSecretInABadVault
{
    $secretname = Get-SecretName 'nonexist'   
    Assert-Throws { Get-AzKeyVaultSecret '$vaultName' $secretname }
}

<#
.SYNOPSIS
Tests set a secret in non-exist key vault
#>
function Test_SetSecretInNonExistVault
{
    $keyVault = 'notexistvault'
    $secretname=Get-SecretName 'nonexist'   
    Assert-Throws {Set-AzKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -ContentType $newcontenttype}
}

<#
.SYNOPSIS
Tests set an not exist secret
#>
function Test_SetNonExistSecret
{
    $keyVault = Get-KeyVault   
    $secretname=Get-SecretName 'nonexist'   
    Assert-Throws {Set-AzKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -ContentType $newcontenttype}    
}

<#
.SYNOPSIS
Tests set invalid 
#>
function Test_SetInvalidSecretAttributes
{
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'invalidattr'
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null

    Assert-Throws {Set-AzKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Expires $nbf  -NotBefore $expires }       
}

<#
.SYNOPSIS
Tests set secret attribute in a vault not have permission
#>
function Test_SetSecretAttrInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    $secretname= Get-SecretName 'nopermission'
    Assert-Throws {Set-AzKeyVaultSecretAttribute -VaultName $keyVault -Name $secretname -Enable $true}
}

<#
.SYNOPSIS
Tests get one secret from key vault
.DESCRIPTION
SmokeTest
#>
function Test_GetOneSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'getone'
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $data 
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null

    $sec=Get-AzKeyVaultSecret -VaultName $keyVault -Name $secretname
    Assert-NotNull $sec
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))
    Assert-AreEqual $secretValueText $data  
    Assert-SecretAttributes $sec.Attributes $true $null $null $null $null
}

<#
.SYNOPSIS
Tests get all secrets from key vault
.DESCRIPTION
SmokeTest
#>
function Test_GetAllSecrets
{
    $keyVault = Get-KeyVault
    $secretpartialname=Get-SecretName 'get'
    $total=30
    BulkCreateSecrets $keyVault $secretpartialname $total
        
    $secs=Get-AzKeyVaultSecret -VaultName $keyVault
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
    $sec1=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $securedata
    Assert-NotNull $sec1
    $global:createdSecrets += $secretname 
    $secretValueText1 = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec1.SecretValue))  
    Assert-AreEqual $secretValueText1 $data    
    Assert-SecretAttributes $sec1.Attributes $true $null $null $null $null
    
    # set the same secret with new values and atrributes
    $sec2=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -SecretValue $newsecuredata -Expires $expires -NotBefore $nbf -ContentType $contenttype -Tag $tags
    Assert-NotNull $sec2
    $secretValueText2 = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec2.SecretValue))  
    Assert-AreEqual $secretValueText2 $newdata    
    Assert-SecretAttributes $sec2.Attributes $true $expires $nbf $contenttype $tags

    # Get the older version of the secret
    $sec3=Get-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -Version $sec1.Version
    Assert-NotNull $sec3
    $secretValueText3 = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec3.SecretValue))  
    Assert-AreEqual $secretValueText3 $data
    Assert-SecretAttributes $sec3.Attributes $true $null $null $null $null

    # Get the newer version of the secret
    $sec4=Get-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -Version $sec2.Version
    Assert-NotNull $sec4
    $secretValueText4 = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec4.SecretValue))  
    Assert-AreEqual $secretValueText4 $newdata  
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
        
    $secs=Get-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -IncludeVersions
    Assert-True { $secs.Count -ge $total }
}

<#
.SYNOPSIS
Tests Get-AzKeyVaultSecret with positional parameter
#>
function Test_GetSecretPositionalParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'positional'  
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))  
    Assert-AreEqual $secretValueText $data    

    $sec=Get-AzKeyVaultSecret $keyVault $secretname
    Assert-NotNull $sec
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))  
    Assert-AreEqual $secretValueText $data   
}

<#
.SYNOPSIS
Tests Get-AzKeyVaultSecret with parameter alias
#>
function Test_GetSecretAliasParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'alias'  
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))  
    Assert-AreEqual $secretValueText $data   

    $sec=Get-AzKeyVaultSecret -VaultName $keyVault -SecretName $secretname 
    Assert-NotNull $sec
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))  
    Assert-AreEqual $secretValueText $data               
}

<#
.SYNOPSIS
Tests get a secret in non-exist key vault
#>
function Test_GetSecretInNonExistVault
{
    $keyVault = 'notexistvault'
    Assert-Throws {Get-AzKeyVaultSecret -VaultName $keyVault}
}

<#
.SYNOPSIS
Tests get a non-exist secret
#>
function Test_GetNonExistSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'notexistvault'
      
    $secret = Get-AzKeyVaultSecret -VaultName $keyVault -Name $secretname
    Assert-Null $secret
}

<#
.SYNOPSIS
Tests get secret in a vault the user does not have permission
#>
function Test_GetSecretInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    Assert-Throws {Get-AzKeyVaultSecret -VaultName $keyVault}
}

<#
.SYNOPSIS
Tests remove a secret
.DESCRIPTION
SmokeTest
#>
function Test_RemoveSecretWithoutPrompt
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'remove'  
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    $sec=Remove-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -Force -Confirm:$false -PassThru
    Assert-NotNull $sec
    
    $secret = Get-AzKeyVaultSecret -VaultName $keyVault -Name $secretname
    Assert-Null $secret
}

<#
.SYNOPSIS
Tests Remove-AzKeyVaultSecret with whatif option
#>
function Test_RemoveSecretWhatIf
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'whatif'
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
       
    Remove-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -WhatIf -Force
    
    $sec=Get-AzKeyVaultSecret -VaultName $keyVault -Name $secretname
    Assert-NotNull $sec        
}

<#
.SYNOPSIS
Tests Remove-AzKeyVaultSecret with positional parameter
#>
function Test_RemoveSecretPositionalParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'positional'  
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))  
    Assert-AreEqual $secretValueText $data  

    Remove-AzKeyVaultSecret $keyVault $secretname  -Force -Confirm:$false 
    
    $secret = Get-AzKeyVaultSecret -VaultName $keyVault -Name $secretname
    Assert-Null $secret
}

<#
.SYNOPSIS
Tests Remove-AzKeyVaultSecret with parameter alias
#>
function Test_RemoveSecretAliasParameter
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'alias'  
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($sec.SecretValue))  
    Assert-AreEqual $secretValueText $data  

    Remove-AzKeyVaultSecret -VaultName $keyVault  -SecretName $secretname  -Force -Confirm:$false 
    
    $secret = Get-AzKeyVaultSecret -VaultName $keyVault -Name $secretname
    Assert-Null $secret            
}

<#
.SYNOPSIS
Tests remove a secret in non-exist key vault
#>
function Test_RemoveSecretInNonExistVault
{
    $keyVault = 'notexistvault'
    $secretname= Get-SecretName 'notexistvault'
    Assert-Throws {Remove-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests remove a non-exist secret
#>
function Test_RemoveNonExistSecret
{
    $keyVault = Get-KeyVault
    $secretname= Get-SecretName 'notexistvault'
      
    Assert-Throws {Remove-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests Remove a secret in a vault the user does not have permission
#>
function Test_RemoveSecretInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    $secretname= Get-SecretName 'nopermission'
    Assert-Throws {Remove-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests backup and restoring of a secret by name
.DESCRIPTION
SmokeTest
#>
function Test_BackupRestoreSecretByName
{
    $keyVault = Get-KeyVault
    $name=Get-SecretName 'backuprestore'   
    $secret=Set-AzKeyVaultSecret -VaultName $keyVault -Name $name -SecretValue $securedata
    Assert-NotNull $secret                 
    $global:createdSecrets += $name

    $backupblob = Backup-AzKeyVaultSecret -VaultName $keyVault -SecretName $name       
    Remove-AzKeyVaultSecret -VaultName $keyVault -Name $name -Force -Confirm:$false
    $restoredSecret = Restore-AzKeyVaultSecret -VaultName $keyVault -InputFile $backupblob
    
    $retrievedSecret = Get-AzKeyVaultSecret -VaultName $keyVault -SecretName $name
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($retrievedSecret.SecretValue))  
    Assert-AreEqual $secretValueText $data
}

<#
.SYNOPSIS
Tests backup and restoring of a secret by object
#>
function Test_BackupRestoreSecretByRef
{
    $keyVault = Get-KeyVault
    $name=Get-SecretName 'backuprestore'   
    $secret=Set-AzKeyVaultSecret -VaultName $keyVault -Name $name -SecretValue $securedata
    Assert-NotNull $secret                 
    $global:createdSecrets += $name

    $backupblob = Backup-AzKeyVaultSecret -Secret $secret
    Remove-AzKeyVaultSecret -VaultName $keyVault -Name $name -Force -Confirm:$false
    $restoredSecret = Restore-AzKeyVaultSecret -VaultName $keyVault -InputFile $backupblob
    
    $retrievedSecret = Get-AzKeyVaultSecret -VaultName $keyVault -SecretName $name
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($retrievedSecret.SecretValue))  
    Assert-AreEqual $secretValueText $data
}

<#
.SYNOPSIS
Tests backup of a non-existing secret
#>
function Test_BackupNonExistingSecret
{
    $keyVault = Get-KeyVault
    $name=Get-SecretName 'backupnonexisting'

    Assert-Throws { Backup-AzKeyVaultSecret -VaultName $keyVault -SecretName $name }
}

<#
.SYNOPSIS
Tests backup of a secret to a specific file and ability to restore
#>
function Test_BackupSecretToANamedFile
{
    $keyVault = Get-KeyVault
    $name=Get-SecretName 'backupnamedfile'
    $secret=Set-AzKeyVaultSecret -VaultName $keyVault -Name $name -SecretValue $securedata
    Assert-NotNull $secret                 
    $global:createdSecrets += $name
  
    $backupfile='.\backup' + ([GUID]::NewGuid()).GUID.ToString() + '.blob'
 
    Backup-AzKeyVaultSecret -VaultName $keyVault -SecretName $name -OutputFile $backupfile    
    Remove-AzKeyVaultSecret -VaultName $keyVault -Name $name -Force -Confirm:$false
    $restoredSecret = Restore-AzKeyVaultSecret -VaultName $keyVault -InputFile $backupfile

    $retrievedSecret = Get-AzKeyVaultSecret -VaultName $keyVault -SecretName $name
    $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($retrievedSecret.SecretValue))  
    Assert-AreEqual $secretValueText $data
}

<#
.SYNOPSIS
Tests backup of a key to a specific, existing file 
#>
function Test_BackupSecretToExistingFile
{
    $keyVault = Get-KeyVault
    $name=Get-SecretName 'backupexistingfile'
    $secret=Set-AzKeyVaultSecret -VaultName $keyVault -Name $name -SecretValue $securedata
    Assert-NotNull $secret                 
    $global:createdSecrets += $name
  
    $backupfile='.\backup' + ([GUID]::NewGuid()).GUID.ToString() + '.blob'
    Backup-AzKeyVaultSecret -VaultName $keyVault -SecretName $name -OutputFile $backupfile 
    Backup-AzKeyVaultSecret -VaultName $keyVault -SecretName $name -OutputFile $backupfile -Force -Confirm:$false
}


<#
.SYNOPSIS
Tests restoring a secret from a non-existing file
#>
function Test_RestoreSecretFromNonExistingFile
{
    $keyVault = Get-KeyVault

    Assert-Throws { Restore-AzKeyVaultSecret -VaultName $keyVault -InputFile c:\nonexisting.blob }
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
    Get-AzKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | Set-AzKeyVaultSecret -SecretValue $newsecuredata	
    Get-AzKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | ForEach-Object { Assert-AreEqual ([System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($_.SecretValue))) $newdata }
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
    
    Get-AzKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | Set-AzKeyVaultSecretAttribute -ContentType $newcontenttype
    Get-AzKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | ForEach-Object { Assert-True { Equal-String $newcontenttype  $_.ContentType }}
    
    Get-AzKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | Set-AzKeyVaultSecretAttribute -Tag $newtags
    Get-AzKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | ForEach-Object { Assert-True { Equal-Hashtable $newtags $_.Tags }}
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
    
    Get-AzKeyVaultSecret $keyVault $secretname -IncludeVersions | Set-AzKeyVaultSecretAttribute -Expires $newexpires
    Get-AzKeyVaultSecret $keyVault $secretname -IncludeVersions |  ForEach-Object { Assert-True { Equal-DateTime $newexpires  $_.Expires }}
    
    Get-AzKeyVaultSecret $keyVault $secretname -IncludeVersions | Set-AzKeyVaultSecretAttribute -Tag $newtags
    Get-AzKeyVaultSecret $keyVault $secretname -IncludeVersions | ForEach-Object { Assert-True { Equal-Hashtable $newtags $_.Tags }}
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
    Get-AzKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | Remove-AzKeyVaultSecret -Force -Confirm:$false	

    $secs = Get-AzKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  
    Assert-AreEqual $secs.Count 0     
}

<#
.SYNOPSIS
Tests getting a previously deleted secret
.DESCRIPTION
SmokeTest
#>
function Test_GetDeletedSecret
{
	# Create a software secret for deleting
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'GetDeletedSecret'
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   

	$sec | Remove-AzKeyVaultSecret -Force -Confirm:$false

	Wait-ForDeletedSecret $keyVault $secretname

	$deletedSecret = Get-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -InRemovedState
	Assert-NotNull $deletedSecret
	Assert-NotNull $deletedSecret.DeletedDate
	Assert-NotNull $deletedSecret.ScheduledPurgeDate
}

<#
.SYNOPSIS
Tests listing all previously deleted secrets
.DESCRIPTION
SmokeTest
#>
function Test_GetDeletedSecrets
{
	$keyVault = Get-KeyVault
    $secretname=Get-SecretName 'GetDeletedSecrets'
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   

	$sec | Remove-AzKeyVaultSecret -Force -Confirm:$false

	Wait-ForDeletedSecret $keyVault $secretname

	$deletedSecrets = Get-AzKeyVaultSecret -VaultName $keyVault -InRemovedState
	Assert-True {$deletedSecrets.Count -ge 1}
    Assert-True {$deletedSecrets.Name -contains $key.Name}
}

<#
.SYNOPSIS
Tests recovering a previously deleted secret.
.DESCRIPTION
SmokeTest
#>
function Test_UndoRemoveSecret
{
	# Create a software secret for updating
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'UndoRemoveSecret'
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   

	$sec | Remove-AzKeyVaultSecret -Force -Confirm:$false

	Wait-ForDeletedSecret $keyVault $secretname

	$recoveredSecret = Undo-AzKeyVaultSecretRemoval -VaultName $keyVault -Name $secretname

	Assert-NotNull $recoveredSecret
	Assert-AreEqual $recoveredSecret.Name $sec.Name
	Assert-AreEqual $recoveredSecret.Version $sec.Version
}

<#
.SYNOPSIS
Tests purging a deleted secret for good.
.DESCRIPTION
SmokeTest
#>
function Test_RemoveDeletedSecret
{
	# Create a software key for updating
    $keyVault = Get-KeyVault
    $secretname=Get-SecretName 'RemoveDeletedSecret'
    $sec=Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
    Assert-NotNull $sec
    $global:createdSecrets += $secretname   

	$sec | Remove-AzKeyVaultSecret -Force -Confirm:$false

	Wait-ForDeletedSecret $keyVault $secretname
	
	Remove-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -InRemovedState -Force -Confirm:$false
}

<#
.SYNOPSIS
Tests purge a secret that has not been deleted yet
#>
function Test_RemoveNonExistDeletedSecret
{
	$keyVault = Get-KeyVault
    $secretname= Get-SecretName 'RemoveNonExistSecret'
	$sec= Set-AzKeyVaultSecret -VaultName $keyVault -Name $secretname  -SecretValue $securedata
	Assert-NotNull $sec
    $global:createdSecrets += $secretname   

    Assert-Throws {Remove-AzKeyVaultSecret -VaultName $keyVault -Name $secretname -InRemovedState -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests pipeline commands to remove multiple deleted secrets 
#>

function Test_PipelineRemoveDeletedSecrets
{
    $keyVault = Get-KeyVault
    $secretpartialname=Get-SecretName 'piperemove'
    $total=2
    BulkCreateSecrets $keyVault $secretpartialname $total 
    Get-AzKeyVaultSecret $keyVault |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | Remove-AzKeyVaultSecret -Force -Confirm:$false	
	Wait-Seconds 30 # wait for slm to delete keys
    Get-AzKeyVaultSecret $keyVault -InRemovedState |  Where-Object {$_.SecretName -like $secretpartialname+'*'}  | Remove-AzKeyVaultSecret -Force -Confirm:$false	-InRemovedState

	$secs = Get-AzKeyVaultSecret $keyVault -InRemovedState |  Where-Object {$_.SecretName -like $secretpartialname+'*'}
	Assert-AreEqual $secs.Count 0   
}