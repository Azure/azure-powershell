$pfxpwd='123'
$securepfxpwd=$pfxpwd | ConvertTo-SecureString -AsPlainText -Force
$expires= (Get-Date).AddYears(2).ToUniversalTime()
$nbf=(Get-Date).ToUniversalTime()
$newexpires= (Get-Date).AddYears(5).ToUniversalTime()
$newnbf=(Get-Date).AddYears(1).ToUniversalTime()
$ops =  "decrypt", "verify"   
$newops = "encrypt", "decrypt", "sign"
$delta=[TimeSpan]::FromMinutes(2)
$tags=@{"tag1"="value1"; "tag2"=""; "tag3"=$null}
$newtags= @{"tag1"="value1"; "tag2"="value2"; "tag3"="value3"; "tag4"="value4"}
$emptytags=@{}
$defaultKeySizeInBytes = 256



function Assert-KeyAttributes($keyAttr, $keytype, $keyenable, $keyexp, $keynbf, $keyops, $tags)
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
    Assert-True { Equal-Hashtable $tags $keyAttr.Tags} "Expected $tags. Get $keyAttr.Tags"
}

function BulkCreateSoftKeys ($vault, $prefix, $total)
{
    for ($i=0;$i -lt $total; $i++) 
    { 
        $name = $prefix+$i; 
        $k=Add-AzureKeyVaultKey -VaultName $Vault -Name $name -Destination 'Software'
        Assert-NotNull $k
        $global:createdKeys += $name
    }
 }

function BulkCreateSoftKeyVersions ($vault, $name, $total)
{
    for ($i=0;$i -lt $total; $i++) 
    { 
        $k=Add-AzureKeyVaultKey -VaultName $Vault -Name $name -Destination 'Software'
        Assert-NotNull $k       
    }
    $global:createdKeys += $name
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
    Assert-KeyAttributes $key.Attributes 'RSA' $true $null $null $null $null
	Assert-AreEqual $key.Key.N.Length $defaultKeySizeInBytes
}

<#
.SYNOPSIS
Tests create software key with custom attributes
#>
function Test_CreateSoftwareKeyWithCustomAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'attr'    
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable -Tag $tags
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops $tags
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
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $true $null $null $null $null
	Assert-AreEqual $key.Key.N.Length $defaultKeySizeInBytes
}

<#
.SYNOPSIS
Tests create Hsm key with custom attributes
#>
function Test_CreateHsmKeyWithCustomAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'attrhsm'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'HSM' -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable -Tag $tags
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $false $expires $nbf $ops $tags
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
    Assert-KeyAttributes $key.Attributes 'RSA' $true $null $null $null $null
	Assert-AreEqual $key.Key.N.Length $defaultKeySizeInBytes
 }

 <#
.SYNOPSIS
Tests import pfx with default attributes
#>
function Test_ImportPfxWith1024BitKey
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'pfx1024'
    $pfxpath = Get-ImportKeyFile1024 'pfx'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -KeyFilePath $pfxpath -KeyFilePassword $securepfxpwd
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $true $null $null $null $null
	Assert-AreEqual $key.Key.N.Length 128
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
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -KeyFilePath $pfxpath -KeyFilePassword $securepfxpwd -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable -Tag $tags
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops $tags
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
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $true $null $null $null $null
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
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'HSM' -KeyFilePath $pfxpath -KeyFilePassword $securepfxpwd -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable -Tag $tags
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $false $expires $nbf $ops $tags
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
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $true $null $null $null $null
	Assert-AreEqual $key.Key.N.Length $defaultKeySizeInBytes
}

<#
.SYNOPSIS
Tests import byok with default attributes
#>
function Test_ImportByokWith1024BitKey
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'byok1024'   
    $byokpath = Get-ImportKeyFile1024 'byok'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -KeyFilePath $byokpath
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $true $null $null $null $null
	Assert-AreEqual $key.Key.N.Length 128
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
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'HSM' -KeyFilePath $byokpath -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable -Tag $tags
    Assert-NotNull $key                 
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA-HSM' $false $expires $nbf $ops $tags
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
Tests import byok as software key
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
function Test_UpdateIndividualKeyAttributes
{
    # Create a software key for updating
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'updatesoft'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable -Tag $tags
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops $tags

    # Update Expires
    $key=Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -Name $keyname -Expires $newexpires -PassThru
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $false $newexpires $nbf $ops $tags

    # Update NotBefore
    $key=Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -Name $keyname -NotBefore $newnbf -PassThru
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $false $newexpires $newnbf $ops $tags

    # Update KeyOps
    $key=Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -Name $keyname -KeyOps $newops -PassThru
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $false $newexpires $newnbf $newops $tags

    # Update Enable
    $key=Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -Name $keyname -Enable $true -PassThru
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $true $newexpires $newnbf $newops $tags
    
    # Update Tags
    $key=Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -Name $keyname -Tag $newtags -PassThru
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $true $newexpires $newnbf $newops $newtags
    
    # Clean Tags
    $key=Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -Name $keyname -Tag $emptytags -PassThru
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $true $newexpires $newnbf $newops $emptytags    
}

<#
.SYNOPSIS
Tests update with no change to key
#>
function Test_UpdateKeyWithNoChange
{
    # Create a software key for updating
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'updatesoftnochange'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -Expires $expires -NotBefore $nbf -KeyOps $ops -Tag $tags
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $true $expires $nbf $ops $tags

    # No change
    $key=Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -Name $keyname -PassThru
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $true $expires $nbf $ops $tags
}

<#
.SYNOPSIS
Tests update individual key attributes
#>
function Test_UpdateAllEditableKeyAttributes
{
    # Create a software key for updating
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'usoft'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable -Tag $tags
    Assert-NotNull $key
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops $tags

    # Update all attributes
    $key=Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -Name $keyname -Expires $newexpires  -NotBefore $newnbf -KeyOps $newops -Enable $true -Tag $newtags -PassThru   
    Assert-KeyAttributes $key.Attributes 'RSA' $true $newexpires $newnbf $newops $newtags
    if($global:standardVaultOnly -eq $false)
    {
       # Create a hsm key for updating
      $keyname=Get-KeyName 'uhsm'
      $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'HSM' -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable -Tag $tags
      Assert-NotNull $key
      $global:createdKeys += $keyname
      Assert-KeyAttributes $key.Attributes 'RSA-HSM' $false $expires $nbf $ops $tags

      # Update all attributes
      $key=Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -Name $keyname -Expires $newexpires  -NotBefore $newnbf -KeyOps $newops -Enable $true -Tag $newtags -PassThru
      Assert-KeyAttributes $key.Attributes 'RSA-HSM' $true $newexpires $newnbf $newops $newtags
    }
}


<#
.SYNOPSIS
Tests Set-AzureKeyVaultKeyAttribute with positionalParameter
#>
function Test_SetKeyPositionalParameter
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'positional'   
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' 
    Assert-NotNull $key                 
    $global:createdKeys += $keyname    

    Set-AzureKeyVaultKeyAttribute $keyVault $keyname -Expires $newexpires  -NotBefore $newnbf -Enable $true -PassThru   
}

<#
.SYNOPSIS
Tests Set-AzureKeyVaultKeyAttribute with parameter alias
#>
function Test_SetKeyAliasParameter
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'alias'   
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname    

    Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -KeyName $keyname -Expires $newexpires  -NotBefore $newnbf -Enable $true  -PassThru  
}

<#
.SYNOPSIS
Tests Set-AzureKeyVaultKeyAttribute with version
#>
function Test_SetKeyVersion
{
    # create a key and record the version
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'version'   
    
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable -Tag $tags
    Assert-NotNull $key        
    $v1=$key.Version
    $global:createdKeys += $keyname
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops $tags
    
    # create a new version
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software' -Expires $expires -NotBefore $nbf -KeyOps $ops -Disable -Tag $tags
    Assert-NotNull $key   
    $v2=$key.Version    
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops $tags
         
    # Update old version
    Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -Name $keyname -Version $v1 -Expires $newexpires  -NotBefore $newnbf -KeyOps $newops -Enable $true -Tag $newtags  -PassThru
    
    # Verify old Version changed
    $key=Get-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Version $v1
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $true $newexpires $newnbf $newops $newtags
            
    # Verify new Version not changed
    $key=Get-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Version $v2
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops $tags
    
    # Verify current Version not changed
    $key=Get-AzureKeyVaultKey -VaultName $keyVault -Name $keyname
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops $tags  
    
    # Update old version using positional parameter
    Set-AzureKeyVaultKeyAttribute $keyVault $keyname $v1 -Expires $expires -NotBefore $nbf -KeyOps $ops -Enable $false -Tag $tags -PassThru
    $key=Get-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Version $v1
    Assert-NotNull $key
    Assert-KeyAttributes $key.Attributes 'RSA' $false $expires $nbf $ops $tags    
}


<#
.SYNOPSIS
Tests set a key in non-exist key vault
#>
function Test_SetKeyInNonExistVault
{
    $keyVault = 'notexistvault'
    $keyname=Get-KeyName 'nonexist'   
    Assert-Throws {Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -KeyName $keyname -Enable $true}
}

<#
.SYNOPSIS
Get a key in a syntactically bad vault name
#>

function Test_GetKeyInABadVault
{
    $keyName = Get-CertificateName 'nonexist'
    Assert-Throws { Get-AzureKeyVaultKey '$vaultName' $keyName }
}

<#
.SYNOPSIS
Tests set an not exist key
#>
function Test_SetNonExistKey
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'nonexist'   
    Assert-Throws {Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -KeyName $keyname -Enable $true}
}

<#
.SYNOPSIS
Tests set invalid 
#>
function Test_SetInvalidKeyAttributes
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'invalidattr'   
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname    

    Assert-Throws {Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -KeyName $keyname -Expires $nbf  -NotBefore $expires }
}

<#
.SYNOPSIS
Tests set key in a vault not have permission
#>
function Test_SetKeyInNoPermissionVault
{
    $keyVault = Get-KeyVault $false
    $keyname= Get-KeyName 'nopermission'
    Assert-Throws {Set-AzureKeyVaultKeyAttribute -VaultName $keyVault -Name $keyname -Enable $true}
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
        
    $total=10
    $run = 5
    $i = 1
    do {
      Write-Host "Sleep 5 seconds before creating another $total keys"
      Wait-Seconds 5
      BulkCreateSoftKeys $keyVault $keypartialname $total
      $i++
    } while ($i -le $run)
        
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
Tests get all key versions from key vault
#>

function Test_GetKeyVersions
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'getversions'
    
    $total=10
    $run = 5
    $i = 1
    do {
      Write-Host "Sleep 5 seconds before creating another $total keys"
      Wait-Seconds 5
      BulkCreateSoftKeyVersions $keyVault $keyname $total          
      $i++
    } while ($i -le $run)
           
    $keys=Get-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -IncludeVersions
    Assert-True { $keys.Count -ge $total*$run }
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
    
    Remove-AzureKeyVaultKey -VaultName $keyVault -Name $keyname  -WhatIf -Force
    
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
Tests remove a non-exist key
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
Tests backup and restore a key
#>
function Test_BackupRestoreKey
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'backuprestore'   
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname

    $backupblob = Backup-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname       
    Remove-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Force -Confirm:$false
    $restoredKey = Restore-AzureKeyVaultKey -VaultName $keyVault -InputFile $backupblob
    Assert-KeyAttributes $restoredKey.Attributes 'RSA' $true $null $null $null
}

<#
.SYNOPSIS
Tests backup a none existing key
#>
function Test_BackupNonExisitingKey
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'backupnonexisting'

    Assert-Throws { Backup-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname }
}

<#
.SYNOPSIS
Tests backup a key to a specific file and be able to restore
#>
function Test_BackupToANamedFile
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'backupnamedfile'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname
  
    $backupfile='.\backup' + ([GUID]::NewGuid()).GUID.ToString() + '.blob'
 
    Backup-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname -OutputFile $backupfile    
    Remove-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Force -Confirm:$false
    $restoredKey = Restore-AzureKeyVaultKey -VaultName $keyVault -InputFile $backupfile
    Assert-KeyAttributes $restoredKey.Attributes 'RSA' $true $null $null $null
}

<#
.SYNOPSIS
Tests backup a key to a specific file which exists 
#>
function Test_BackupToExistingFile
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'backupexistingfile'
    $key=Add-AzureKeyVaultKey -VaultName $keyVault -Name $keyname -Destination 'Software'
    Assert-NotNull $key                 
    $global:createdKeys += $keyname
  
    $backupfile='.\backup' + ([GUID]::NewGuid()).GUID.ToString() + '.blob'
 
    Backup-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname -OutputFile $backupfile        
    Assert-Throws { Backup-AzureKeyVaultKey -VaultName $keyVault -KeyName $keyname -OutputFile $backupfile }
}


<#
.SYNOPSIS
Tests restore a key from a none existing file
#>
function Test_RestoreFromNonExistingFile
{
    $keyVault = Get-KeyVault

    Assert-Throws { Restore-AzureKeyVaultKey -VaultName $keyVault -InputFile c:\nonexisting.blob }
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
    BulkCreateSoftKeys $keyVault $keypartialname $total  
    
    Get-AzureKeyVaultKey $keyVault |  Where-Object {$_.KeyName -like $keypartialname+'*'}  | Set-AzureKeyVaultKeyAttribute -Enable $false	

    Get-AzureKeyVaultKey $keyVault |  Where-Object {$_.KeyName -like $keypartialname+'*'}  |  ForEach-Object {  Assert-False { return $_.Enabled } }
 }
 
 <#
.SYNOPSIS
Tests pipeline commands to update attributes of multiple key versions  
#>

function Test_PipelineUpdateKeyVersions
{
    $keyVault = Get-KeyVault
    $keyname=Get-KeyName 'pipeupdateversion'
    $total=2    
    BulkCreateSoftKeyVersions $keyVault $keyname $total
    
    Get-AzureKeyVaultKey $keyVault $keyname -IncludeVersions | Set-AzureKeyVaultKeyAttribute -Enable $false
    Get-AzureKeyVaultKey $keyVault $keyname -IncludeVersions |  ForEach-Object {  Assert-False { return $_.Enabled } }
    
    Get-AzureKeyVaultKey $keyVault $keyname -IncludeVersions | Set-AzureKeyVaultKeyAttribute -Tag $newtags
    Get-AzureKeyVaultKey $keyVault $keyname -IncludeVersions |  ForEach-Object {  Assert-True { return $_.Tags.Count -eq $newtags.Count } }
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
    BulkCreateSoftKeys $keyVault $keypartialname $total   

    Get-AzureKeyVaultKey $keyVault |  Where-Object {$_.KeyName -like $keypartialname+'*'}  | Remove-AzureKeyVaultKey -Force -Confirm:$false

    $keys = Get-AzureKeyVaultKey $keyVault |  Where-Object {$_.KeyName -like $keypartialname+'*'} 
    Assert-AreEqual $keys.Count 0     
}