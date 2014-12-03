$pfxpwd='123'
$securepfxpwd=$pfxpwd | ConvertTo-SecureString -AsPlainText -Force
$expires= (Get-Date).AddYears(2).ToUniversalTime()
$nbf=(Get-Date).ToUniversalTime()
$newexpires= (Get-Date).AddYears(5).ToUniversalTime()
$newnbf=(Get-Date).AddYears(1).ToUniversalTime()
$ops =  "decrypt", "verify"   
$newOps = "encrypt", "decrypt", "sign"
$delta=[TimeSpan]::FromMinutes(2)

function Equal-DateTime($left, $right)
{   
    if ($left -eq $null -and $right -eq $null)
    {        
        return $true
    }
    if ($left -eq $null -or $right -eq $null)
    {
        return $false
    }
    
    return (($left - $right).Duration() -le $delta)
}

function Equal-OperationList($left, $right)
{   
    if ($left -eq $null -and $right -eq $null)
    {        
        return $true
    }
    if ($left -eq $null -or $right -eq $null)
    {
        return $false
    }

    $diff = Compare-Object -ReferenceObject $left -DifferenceObject $right -PassThru
    
    return (-not $diff)
}

function Assert-KeyAttributes($keyAttr, $keytype, $keyenable, $keyexp, $keynbf, $keyops)
{
    Assert-NotNull $keyAttr, "keyAttr is null."
    Assert-AreEqual $keytype $keyAttr.KeyType "Expect $keytype. Get $keyAttr.KeyType"
    Assert-AreEqual $keyenable $keyAttr.Enabled "Expect $keyenable. Get $keyAttr.Enabled"
    if ($keyexp -ne $null)
    {   
        Assert-True { Equal-DateTime  $keyexp $keyAttr.Expires } "Expect $keyexp. Get $keyAttr.Expires"
    }  
    if ($keynbf -ne $null)
    {
         Assert-True { Equal-DateTime  $keynbf $keyAttr.NotBefore} "Expect $keynbf. Get $keyAttr.NotBefore"
    }     
    if ($keyops -ne $null)
    {
         Assert-True { Equal-OperationList  $keyops $keyAttr.KeyOps} "Expect $keyops. Get $keyAttr.KeyOps"
    } 
}


<#
.SYNOPSIS
Tests create software key with default attributes
#>

function Test_CreateSoftwareKeyWithDefaultAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'soft'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' 
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $true $null $null $null
}

<#
.SYNOPSIS
Tests create software key with custom attributes
#>
function Test_CreateSoftwareKeyWithCustomAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'attr'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops
}

<#
.SYNOPSIS
Tests create Hsm key with custom attributes
#>
function Test_CreateHsmKeyWithDefaultAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'hsm'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'HSM'
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $true $null $null $null
}

<#
.SYNOPSIS
Tests create Hsm key with custom attributes
#>
function Test_CreateHsmKeyWithCustomAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'attrhsm'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'HSM' -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $false $expires $nbf $ops
}

<#
.SYNOPSIS
Tests import pfx with default attributes
#>
function Test_ImportPfxWithDefaultAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'pfx'
    $pfxpath = Get-ImportKeyFile 'pfx'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -KeyFilePath $pfxpath -KeyFilePassword $securepfxpwd
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $true $null $null $null
 }

<#
.SYNOPSIS
Tests import pfx with custom attributes
#>
function Test_ImportPfxWithCustomAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'attrpfx'   
    $pfxpath = Get-ImportKeyFile 'pfx'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -KeyFilePath $pfxpath -KeyFilePassword $securepfxpwd -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops
}

<#
.SYNOPSIS
Tests import pfx as Hsm with default attributes
#>
function Test_ImportPfxAsHsmWithDefaultAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'pfxashsm'   
    $pfxpath = Get-ImportKeyFile 'pfx'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'HSM' -KeyFilePath $pfxpath -KeyFilePassword $securepfxpwd
    Assert-NotNull $key           
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $true $null $null $null
}

<#
.SYNOPSIS
Tests import pfx as Hsm with custom attributes
#>
function Test_ImportPfxAsHsmWithCustomAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'attrpfxashsm'   
    $pfxpath = Get-ImportKeyFile 'pfx'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'HSM' -KeyFilePath $pfxpath -KeyFilePassword $securepfxpwd -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $false $expires $nbf $ops
}

<#
.SYNOPSIS
Tests import byok with default attributes
#>
function Test_ImportByokWithDefaultAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'byok'   
    $byokpath = Get-ImportKeyFile 'byok'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -KeyFilePath $byokpath
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $true $null $null $null
}

<#
.SYNOPSIS
Tests import byok with custom attributes
#>
function Test_ImportByokWithCustomAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'attrbyok'   
    $byokpath = Get-ImportKeyFile 'byok'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'HSM' -KeyFilePath $byokpath -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable
    Assert-NotNull $key                 
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $false $expires $nbf $ops
}

<#
.SYNOPSIS
Tests import byok with custom attributes
#>
function Test_ImportByokWithCustomAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'attrbyok'   
    $byokpath = Get-ImportKeyFile 'byok'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'HSM' -KeyFilePath $byokpath -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable
    Assert-NotNull $key                 
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $false $expires $nbf $ops
}

<#
.SYNOPSIS
Tests Add-AzureKeyVaultKey with positionalParameter
#>
function Test_AddKeyPositionalParameter
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'positional'   
    $key=Add-AzureKeyVaultKey $keyVault $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname    
}

<#
.SYNOPSIS
Tests Add-AzureKeyVaultKey with parameter alias
#>
function Test_AddKeyAliasParameter
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'alias'   
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname    
}


<#
.SYNOPSIS
Tests import non-exist pfx file
#>
function Test_ImportNonExistPfxFile
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'nonexistpfx'   
    $nonexistpfx = Get-ImportKeyFile 'pfx' $false
    Assert-Throws {Add-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname -KeyFilePath $nonexistpfx -KeyFilePassword $securepfxpwd}
}

<#
.SYNOPSIS
Tests import non-exist pfx file
#>
function Test_ImportPfxFileWithIncorrectPassword
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'wrongpwdpfx'   
    $pfxpath = Get-ImportKeyFile 'pfx'     
    $wrongpwd= 'foo' | ConvertTo-SecureString -AsPlainText -Force
    Assert-Throws {Add-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname -Name $keyname -KeyFilePath $pfxpath -KeyFilePassword $wrongpwd}
}

<#
.SYNOPSIS
Tests import non-exist pfx file
#>
function Test_ImportNonExistByokFile
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'nonexistbyok'   
    $nonexistbyok = Get-ImportKeyFile 'byok' $false
    Assert-Throws {Add-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname -KeyFilePath $nonexistbyok}
}

<#
.SYNOPSIS
Tests import non-exist pfx file
#>
function Test_CreateKeyInNonExistVault
{
    $keyVault = 'notexistvault'
    $keyname= 'notexitkey'
    Assert-Throws {Add-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname -Destination 'Software'}
}

<#
.SYNOPSIS
Tests import non-exist pfx file
#>
function Test_ImportByokAsSoftwareKey
{
    $keyVault = Get-KeyVault
    $keyname= Get-KeyName 'byokassoftware'
    Assert-Throws {Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -KeyFilePath $byokpath}
}

<#
.SYNOPSIS
Tests create key in a vault not have permission
#>
function Test_CreateKeyInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    $keyname= Get-KeyName 'nopermission'
        Assert-Throws {Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'}
}


<#
.SYNOPSIS
Tests update individual key attributes
#>
function Test_UpdateIndividualAttributes
{
    # Create a software key for updating
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'updatesoft'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops

    # Update Expires
    $key=Set-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Expires $newexpires
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $false $newexpires $nbf $null

    # Update NotBefore
    $key=Set-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -NotBefore $newnbf
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $false $newexpires $newnbf $null

    # Update KeyOps
    $key=Set-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -KeyOps $newOps
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $false $newexpires $newnbf -keyops $newOps

    # Update Enable
    $key=Set-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Enable $true
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $true $newexpires $newnbf $null
}

<#
.SYNOPSIS
Tests update with no change to key
#>
function Test_UpdateKeyWithNoChange
{
    # Create a software key for updating
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'updatesoft'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -Expires $expires -NotBefore $nbf -KeyOps $ops
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $true $expires $nbf $ops

    # Update Expires
    $key=Set-AzureKeyVaultKey -VaultName $keyVault -Name $keyname
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $true $expires $nbf $ops
}

<#
.SYNOPSIS
Tests update individual key attributes
#>
function Test_UpdateAllEditableAttributes
{
    # Create a software key for updating
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'usoft'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops

    # Update Expires
    $key=Set-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Expires $newexpires  -NotBefore $newnbf -Enable $true    
    Assert-KeyAttributes $key.Attributes 'RSA' $true $newexpires $newnbf $null

     # Create a hsm key for updating
    $keyname=Get-KeyName 'uhsm'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'HSM' -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $false $expires $nbf $ops

    # Update Expires
    $key=Set-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Expires $newexpires  -NotBefore $newnbf -Enable $true    
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $true $newexpires $newnbf $null
}


<#
.SYNOPSIS
Tests Set-AzureKeyVaultKey with positionalParameter
#>
function Test_SetKeyPositionalParameter
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'positional'   
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname    

    Set-AzureKeyVaultKey $keyVault $keyname -Expires $newexpires  -NotBefore $newnbf -Enable $true    
}

<#
.SYNOPSIS
Tests Set-AzureKeyVaultKey with parameter alias
#>
function Test_SetKeyAliasParameter
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'alias'   
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname    

    Set-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname -Expires $newexpires  -NotBefore $newnbf -Enable $true    
}

<#
.SYNOPSIS
Tests set a key in non-exist key vault
#>
function Test_SetKeyInNonExistVault
{
    $keyVault = 'notexistvault'
    $keyname=Get-KeyName 'nonexist'   
    Assert-Throws {Set-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname -Enable $true}
}

<#
.SYNOPSIS
Tests set an not exist key
#>
function Test_SetNonExistKey
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'nonexist'   
    Assert-Throws {Set-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname -Enable $true}
}

<#
.SYNOPSIS
Tests set invalid 
#>
function Test_SetInvalidAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'invalidattr'   
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname    

    Assert-Throws {Set-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname -Expires $nbf  -NotBefore $expires }    
    
}

<#
.SYNOPSIS
Tests set key in a vault not have permission
#>
function Test_SetKeyInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    $keyname= Get-KeyName 'nopermission'
    Assert-Throws {Set-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Enable $true}
}


<#
.SYNOPSIS
Tests get one key from key vault
#>

function Test_GetOneKey
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'getone'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $true $null $null $null

    $key=Get-AzureKeyVaultKey -VaultName $keyVault -Name $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $true $null $null $null
}

<#
.SYNOPSIS
Tests get all keys from key vault
#>

function Test_GetAllKeys
{
    $keyVault = Get-KeyVault
    $keypartialname=Get-KeyName 'get'
    $total=2
    for ($i=0;$i -lt $total; $i++) 
    { 
        $keyname = $keypartialname+$i; 
        $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
        Assert-NotNull $key
        $global:createdKeys += $keyname
    }
        
    $keys=Get-AzureKeyVaultKey -VaultName $keyVault
    Assert-True { $keys.Count -ge $total }
}

<#
.SYNOPSIS
Tests get previous version of a key from key vault
#>

function Test_GetPreviousVersionOfKey
{
    $keyOperation = 'encrypt'

    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'getversion'
    $key1=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -Disable -NotBefore $nbf -Expires $expires -KeyOps $ops 

    $global:createdKeys += $keyname 
    Assert-KeyAttributes -keyAttr $key1.Attributes -keytype 'RSA' -keyenable $false -keyexp $expires -keynbf $nbf -keyops $ops 

    $key2=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-KeyAttributes $key2.Attributes 'RSA' $true $null $null $null

    $key3=Get-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Version $key1.Version
    Assert-KeyAttributes -keyAttr $key3.Attributes -keytype 'RSA' -keyenable $false -keyexp $expires -keynbf $nbf -keyops $ops 
    
    $key4=Get-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Version $key2.Version
    Assert-KeyAttributes $key4.Attributes 'RSA' $true $null $null $null
}

<#
.SYNOPSIS
Tests Get-AzureKeyVaultKey with positional Parameter
#>
function Test_GetKeyPositionalParameter
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'positional'   
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname    

    $key=Get-AzureKeyVaultKey $keyVault $keyname
    Assert-NotNull $key                     
}

<#
.SYNOPSIS
Tests Get-AzureKeyVaultKey with parameter alias
#>
function Test_GetKeyAliasParameter
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'alias'   
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname    

    $key=Get-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname 
    Assert-NotNull $key     
}

<#
.SYNOPSIS
Tests get a key from non-exist key vault
#>
function Test_GetKeysInNonExistVault
{
    $keyVault = 'notexistvault'
    Assert-Throws {Get-AzureKeyVaultKey -VaultName $keyVault}
}

<#
.SYNOPSIS
Tests get a non-exist key
#>
function Test_GetNonExistKey
{
    $keyVault = Get-KeyVault
    $keyname = 'notexist'
    Assert-Throws {Get-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname}
}

<#
.SYNOPSIS
Tests get key in a vault not have permission
#>
function Test_GetKeyInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    Assert-Throws {Get-AzureKeyVaultKey -VaultName $keyVault}
}


<#
.SYNOPSIS
Tests remove a key
#>
function Test_RemoveKeyWithoutPrompt
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'remove'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key
    $global:createdKeys += $keyname
    
    $key=Remove-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Force -Confirm:$false -PassThru
    Assert-NotNull $key
    
    Assert-Throws { Get-AzureKeyVaultKey  -VaultName $keyVault -Name $keyname}    
}

<#
.SYNOPSIS
Tests Remove-AzureKeyVaultKey with whatif option
#>
function Test_RemoveKeyWhatIf
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'whatif'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key
    $global:createdKeys += $keyname
    
    Remove-AzureKeyVaultKey -VaultName $keyVault -Name $keyname  -WhatIf
    
    $key=Get-AzureKeyVaultKey -VaultName $keyVault -Name $keyname
    Assert-NotNull $key    
}

<#
.SYNOPSIS
Tests Remove-AzureKeyVaultKey with positional Parameter
#>
function Test_RemoveKeyPositionalParameter
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'positional'   
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname    

    Remove-AzureKeyVaultKey $keyVault $keyname -Force -Confirm:$false      
    
    Assert-Throws { Get-AzureKeyVaultKey  -VaultName $keyVault -Name $keyname}                    
}

<#
.SYNOPSIS
Tests Remove-AzureKeyVaultKey with parameter alias
#>
function Test_RemoveKeyAliasParameter
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'alias'   
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname    

    Remove-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname  -Force -Confirm:$false                

    Assert-Throws { Get-AzureKeyVaultKey  -VaultName $keyVault -Name $keyname} 
}

<#
.SYNOPSIS
Tests get a key from non-exist key vault
#>
function Test_RemoveKeyInNonExistVault
{
    $keyVault = 'notexistvault'
    $keyname = 'notexist'
    Assert-Throws {Remove-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests get a non-exist key
#>
function Test_RemoveNonExistKey
{
    $keyVault = Get-KeyVault
    $keyname = 'notexist'
    Assert-Throws {Remove-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests remove key in a vault not have permission
#>
function Test_RemoveKeyInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    $keyname= Get-KeyName 'nopermission'
    Assert-Throws {Remove-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Enable $true -Force -Confirm:$false}
}

<#
.SYNOPSIS
Tests pipeline commands to update attributes of multiple keys  
#>

function Test_PipelineUpdateKeys
{
    $keyVault = Get-KeyVault
    $keypartialname=Get-KeyName 'pipeupdate'
    $total=2
    for ($i=0;$i -lt $total; $i++) 
    { 
        $keyname = $keypartialname+$i; 
        $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
        Assert-NotNull $key
        $global:createdKeys += $keyname
    }

    Get-AzureKeyVaultKey $keyVault |  Where-Object {$_.KeyName -like $keypartialname+'*'}  | Set-AzureKeyVaultKey -Enable $false	

    Get-AzureKeyVaultKey $keyVault |  Where-Object {$_.KeyName -like $keypartialname+'*'}  |  ForEach-Object {  Assert-False { return $_.Attributes.Enable } }
 }

<#
.SYNOPSIS
Tests pipeline commands to remove multiple keys  
#>

function Test_PipelineRemoveKeys
{
    $keyVault = Get-KeyVault
    $keypartialname=Get-KeyName 'piperemove'
    $total=2
    for ($i=0;$i -lt $total; $i++) 
    { 
        $keyname = $keypartialname+$i; 
        $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
        Assert-NotNull $key
        $global:createdKeys += $keyname
    }

    Get-AzureKeyVaultKey $keyVault |  Where-Object {$_.KeyName -like $keypartialname+'*'}  | Remove-AzureKeyVaultKey -Force -Confirm:$false

    $keys = Get-AzureKeyVaultKey $keyVault |  Where-Object {$_.KeyName -like $keypartialname+'*'} 
    Assert-AreEqual $keys.Count 0     
}