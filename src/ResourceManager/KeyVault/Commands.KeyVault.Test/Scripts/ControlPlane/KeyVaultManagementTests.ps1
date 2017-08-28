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

#------------------------------New-AzureRmKeyVault--------------------------------------

function Get-AllSecretPermissions 
{
    return @(
        "get",
        "list",
        "set",
        "delete",
        "backup",
        "restore",
        "recover"
    )
}

function Get-AllKeyPermissions
{
    return @(
        "get",
        "create",
        "delete",
        "list",
        "update",
        "import",
        "backup",
        "restore",
        "recover",
        "sign", 
        "verify", 
        "wrapKey",
        "unwrapKey", 
        "encrypt", 
        "decrypt"
    )
}

function Get-AllCertPermissions
{
    return @(
        "get",
        "delete",
        "list",
        "create",
        "import",
        "update",
        "deleteissuers",
        "getissuers",
        "listissuers",
        "managecontacts", 
        "manageissuers", 
        "setissuers",
        "recover"
    )
}

function Get-AllStoragePermissions
{
    return @(
         "delete",
         "deletesas",
         "get",
         "getsas",
         "list",
         "listsas",
         "regeneratekey",
         "set",
         "setsas",
         "update"
    )
}

<#
.SYNOPSIS
Tests creating a new vault.
#>
function Test-CreateNewVault
{
Param($rgName, $location, $tagName, $tagValue)

    # Setup
    $vaultname = Get-VaultName

    # Test
    $actual = New-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Tag @{$tagName = $tagValue}

    # Assert
    Assert-AreEqual $vaultName $actual.VaultName
    Assert-AreEqual $rgname $actual.ResourceGroupName
    Assert-AreEqual $location $actual.Location
    Assert-AreEqual $actual.Tags.Count 1
    Assert-AreEqual $actual.Tags.ContainsKey($tagName) $true
    Assert-AreEqual $actual.Tags.ContainsValue($tagValue) $true
    Assert-AreEqual "Standard" $actual.Sku
    Assert-AreEqual $false $actual.EnabledForDeployment

    # Default Access Policy
    $objectId = $global:objectId
    $expectedPermsToKeys = @("get",
            "create",
            "delete",
            "list",
            "update",
            "import",
            "backup",
            "restore",
            "recover")
    $expectedPermsToSecrets = Get-AllSecretPermissions
    $expectedPermsToCertificates = Get-AllCertPermissions
    $expectedPermsToStorage = Get-AllStoragePermissions

    Assert-AreEqual 1 @($actual.AccessPolicies).Count
    Assert-AreEqual $objectId $actual.AccessPolicies[0].ObjectId
    $result = Compare-Object $expectedPermsToKeys $actual.AccessPolicies[0].PermissionsToKeys
    Assert-Null $result
    $result = Compare-Object $expectedPermsToSecrets $actual.AccessPolicies[0].PermissionsToSecrets
    Assert-Null $result
    $result = Compare-Object $expectedPermsToCertificates $actual.AccessPolicies[0].PermissionsToCertificates
    Assert-Null $result
    $result = Compare-Object $expectedPermsToStorage $actual.AccessPolicies[0].PermissionsToStorage
    Assert-Null $result
}

<#
.SYNOPSIS
Tests creating a new premium vault with enabledForDeployment set to true.
#>
function Test-CreateNewPremiumVaultEnabledForDeployment
{
    Param($rgName, $location)

    # Setup
    $vaultname = Get-VaultName

    # Test
    $actual = New-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Sku premium -EnabledForDeployment

    # Assert
    Assert-AreEqual $vaultName $actual.VaultName
    Assert-AreEqual $rgname $actual.ResourceGroupName
    Assert-AreEqual $location $actual.Location
    Assert-AreEqual "Premium" $actual.Sku
    Assert-AreEqual $true $actual.EnabledForDeployment

    if ($global:noADCmdLetMode) {return;}

    Assert-AreEqual 1 @($actual.AccessPolicies).Count
}

<#
.SYNOPSIS
Tests creating a new premium vault with enableSoftDelete set to true.
#>
function Test-CreateNewStandardVaultEnableSoftDelete
{
    Param($rgName, $location)

    # Setup
    $vaultname = Get-VaultName

    # Test
    $actual = New-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Sku standard -EnableSoftDelete

    # Assert
    Assert-AreEqual $vaultName $actual.VaultName
    Assert-AreEqual $rgname $actual.ResourceGroupName
    Assert-AreEqual $location $actual.Location
    Assert-AreEqual "Standard" $actual.Sku
    Assert-AreEqual $true $actual.EnableSoftDelete

    if ($global:noADCmdLetMode) {return;}

    Assert-AreEqual 1 @($actual.AccessPolicies).Count
}

<#
.SYNOPSIS
Recreate vault fails
#>
function Test-RecreateVaultFails
{
    Param($existingVaultName, $rgName, $location)

     Assert-Throws { New-AzureRmKeyVault -VaultName $existingVaultName -ResourceGroupName $rgname -Location $location }
}

function Test-CreateVaultInUnknownResGrpFails
{
    Param($location)

    $vaultname = Get-VaultName
    $rgName = Get-ResourceGroupName

    Assert-Throws { New-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $location }
}

function Test-CreateVaultPositionalParams
{
    Param($rgName, $location)

    # Setup
    $vaultname = Get-VaultName

    # Test
    $actual = New-AzureRmKeyVault $vaultName $rgname $location

    Assert-NotNull $actual
}

#-------------------------------------------------------------------------------------

#------------------------------Soft-delete--------------------------------------

<#
.SYNOPSIS
Tests creating a soft-delete enabled vault, delete, retrieve and recover it.
#>
function Test-RecoverDeletedVault
{
    Param($rgName, $location)

    # Setup
    $vaultname = Get-VaultName

    # Test
    $vault = New-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Sku standard -EnableSoftDelete -Tag @{"x"= "y"}

    # Assert
    Assert-AreEqual $vaultName $vault.VaultName
    Assert-AreEqual $rgname $vault.ResourceGroupName
    Assert-AreEqual $location $vault.Location
    Assert-AreEqual "Standard" $vault.Sku
    Assert-True { $vault.EnableSoftDelete }
    Assert-AreEqual $vault.Tags.Count 1
    Assert-True { $vault.Tags.ContainsKey("x") }
    Assert-True { $vault.Tags.ContainsValue("y") }

    if ($global:noADCmdLetMode) {return;}
    Assert-AreEqual 1 @($vault.AccessPolicies).Count

    # Test
    Remove-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Force -Confirm:$false

    $allDeletedVault = Get-AzureRmKeyVault -InRemovedState
    Assert-True { $allDeletedVault.Count -gt 0 }

    $deletedVault = Get-AzureRmKeyVault -VaultName  $vaultName -Location $location -InRemovedState
    Assert-AreEqual $vaultName $deletedVault.VaultName
    Assert-AreEqual $location $deletedVault.Location
    Assert-AreEqual "Standard" $vault.Sku
    Assert-NotNull $deletedVault.DeletionDate
    Assert-NotNull $deletedVault.ScheduledPurgeDate
    Assert-AreEqual $deletedVault.Tags.Count 1
    Assert-True { $deletedVault.Tags.ContainsKey("x") }
    Assert-True { $deletedVault.Tags.ContainsValue("y") }

    $recoveredVault = Undo-AzureRmKeyVaultRemoval -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Tag @{"m"= "n"}
    Compare-Vaults $vault $recoveredVault
    
    Assert-AreEqual $recoveredVault.Tags.Count 1
    Assert-True { $recoveredVault.Tags.ContainsKey("m") }
    Assert-True { $recoveredVault.Tags.ContainsValue("n") }
}

<#
.SYNOPSIS
Get not existing deleted vault
#>
function Test-GetNoneexistingDeletedVault
{
    $deletedVault = Get-AzureRmKeyVault -VaultName  'non-existing' -Location 'eastus2' -InRemovedState
    Assert-Null $deletedVault
}

<#
.SYNOPSIS
Tests creating a soft-delete enabled vault, delete and purge it.
#>
function Test-PurgeDeletedVault
{
    Param($rgName, $location)

    # Setup
    $vaultname = Get-VaultName

    # Test
    New-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Sku standard -EnableSoftDelete -Tag @{"x"= "y"}
    Remove-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Force -Confirm:$false
    Remove-AzureRmKeyVault -VaultName $vaultName -Location $location -Force -Confirm:$false -InRemovedState

    $deletedVault = Get-AzureRmKeyVault -VaultName  $vaultName -Location $location -InRemovedState
    Assert-Null $deletedVault
}
#-------------------------------------------------------------------------------------

#------------------------------Get-AzureRmKeyVault--------------------------------------

function Test-GetVaultByNameAndResourceGroup
{
    Param($existingVaultName, $rgName)

    $got = Get-AzureRmKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName

    Assert-NotNull $got
}

function Test-GetVaultByNameAndResourceGroupPositionalParams
{
    Param($existingVaultName, $rgName)

    $got = Get-AzureRmKeyVault $existingVaultName $rgName

    Assert-NotNull $got
}

function Test-GetVaultByName
{
    Param($existingVaultName)

    $got = Get-AzureRmKeyVault -VaultName $existingVaultName

    Assert-NotNull $got
}

function Test-GetUnknownVaultFails
{
    Param($rgName)
    $vaultname = Get-VaultName

    $unknown = Get-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgName
    Assert-Null $unknown
}

function Test-GetVaultFromUnknownResourceGroupFails
{
    Param($existingVaultName)
    $rgName = Get-ResourceGroupName

    $unknown = Get-AzureRmKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName
    Assert-Null $unknown
}

function Test-ListVaultsByResourceGroup
{
    Param($rgName)
    $list = Get-AzureRmKeyVault -ResourceGroupName $rgName

    Assert-NotNull $list
    Assert-True { $list.Count -gt 0 }
    foreach($v in $list) {
        Assert-NotNull($v.VaultName)
        Assert-NotNull($v.ResourceGroupName)
        Assert-AreEqual $rgName $v.ResourceGroupName
    }
}

function Test-ListAllVaultsInSubscription
{
    $list = Get-AzureRmKeyVault

    Assert-NotNull $list
    Assert-True { $list.Count -gt 0 }
    foreach($v in $list) {
        Assert-NotNull $v.VaultName
        Assert-NotNull $v.ResourceGroupName
    }
}

function Test-ListVaultsByTag
{
    Param($tagName, $tagValue)
    $list = Get-AzureRmKeyVault -Tag  @{ $tagName = $tagValue }

    Assert-NotNull $list
    Assert-True { $list.Count -gt 0 }
}

function Test-ListVaultsByUnknownResourceGroupFails
{
    $rgName = Get-ResourceGroupName

    Assert-Throws { Get-AzureRmKeyVault -ResourceGroupName $rgName }
}

#-------------------------------------------------------------------------------------

#------------------------------Remove-AzureRmKeyVault-----------------------------------
function Test-DeleteVaultByName
{
    Param($rgName, $location)
    $vaultName = Get-VaultName

    New-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location

    Remove-AzureRmKeyVault -VaultName $vaultName -Force -Confirm:$false

    $deletedVault = Get-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgName
    Assert-Null $deletedVault
}

function Test-DeleteUnknownVaultFails
{
    $vaultName = Get-VaultName

    Assert-Throws { Remove-AzureRmKeyVault -VaultName $vaultName }
}

#-------------------------------------------------------------------------------------

#------------------------------Set-AzureRmKeyVaultAccessPolicy--------------------------

function Test-SetRemoveAccessPolicyByUPN
{
    Param($existingVaultName, $rgName, $upn)

    $PermToKeys = @("encrypt", "decrypt", "unwrapKey", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")
    $PermToSecrets = @("get", "list", "set", "delete", "backup", "restore")
    $PermToCertificates = @("get", "list", "create", "delete")
    $PermToStorage = @("get", "list", "delete")
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru
    
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
    if (-not $global:noADCmdLetMode) {
        Assert-AreEqual $upn (Get-AzureRmADUser -ObjectId $vault.AccessPolicies[0].ObjectId)[0].UserPrincipalName
    }

    $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

function Test-SetRemoveAccessPolicyByEmailAddress
{
    Param($existingVaultName, $rgName, $email, $upn)

    $PermToKeys = @("encrypt", "decrypt", "unwrapKey", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")
    $PermToSecrets = @("get", "list", "set", "delete")
    $PermToCertificates = @("get", "list", "create", "delete")
    $PermToStorage = @("get", "list", "delete")

    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EmailAddress $email -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru

    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
    if (-not $global:noADCmdLetMode) {
        Assert-AreEqual  $vault.AccessPolicies[0].ObjectId (Get-AzureRmADUser -Mail $upn).Id
    }

    $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EmailAddress $email -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

function Test-SetRemoveAccessPolicyBySPN
{
    Param($existingVaultName, $rgName, $spn)

    $PermToKeys = @()
    $PermToSecrets = @("get", "set", "list")
    $PermToCertificates = @("get", "import")
    $PermToStorage = @("get", "list")
    
    $setAccessPolicyFunc = { Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ServicePrincipalName $spn -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru }
    
    if ($global:noADCmdLetMode) {
        Assert-Throws { &$setAccessPolicyFunc }
    }
    else{
        $vault = &$setAccessPolicyFunc

        CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage

        Assert-AreEqual $spn (Get-AzureRmADServicePrincipal -ObjectId $vault.AccessPolicies[0].ObjectId)[0].ServicePrincipalNames[0]

        $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -SPN $spn -PassThru
        Assert-AreEqual 0 $vault.AccessPolicies.Count
    }
}

function Test-SetRemoveAccessPolicyByObjectId
{
    Param($existingVaultName, $rgName, $objId, [switch]$bypassObjectIdValidation)

    $PermToKeys = @("encrypt", "decrypt")
    $PermToSecrets = @()
    $PermToCertificates = @()
    $PermToStorage = @()

    $vault;
    if ($bypassObjectIdValidation.IsPresent)
    {
        $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -BypassObjectIdValidation -PassThru
    }
    else
    {
        $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru
    }

    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
    
    Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId

    $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

function Test-SetRemoveAccessPolicyByCompoundId
{
    Param($existingVaultName, $rgName, $appId, $objId)

    Assert-NotNull $appId

    $PermToKeys = @("encrypt", "decrypt")
    $PermToSecrets = @()
    $PermToCertificates = @("list", "delete")
    $PermToStorage = @("list", "delete")
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PermissionsToKeys $PermToKeys -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru

    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
    
    Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId
    Assert-AreEqual $appId $vault.AccessPolicies[0].ApplicationId

    $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

function Test-RemoveAccessPolicyWithCompoundIdPolicies
{
    Param($existingVaultName, $rgName, $appId1, $appId2, $objId)

    Assert-NotNull $appId1
    Assert-NotNull $appId2

    # Add three access policies: ObjectId, (ObjectId, App1), (ObjectId, App2)
    $PermToKeys = @("encrypt", "decrypt")
    $PermToSecrets = @()
    $PermToCertificates = @("all")
    $PermToStorage = @("all")
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PassThru
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId1 -PermissionsToKeys $PermToKeys -PassThru
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId2 -PermissionsToKeys $PermToKeys -PermissionsToCertificates $PermToCertificates -PassThru
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId2 -PermissionsToKeys $PermToKeys -PermissionsToStorage $PermToStorage -PassThru
    Assert-AreEqual 3 $vault.AccessPolicies.Count

    # Remove one policy if specify compound id
    $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId1 -PassThru
    Assert-AreEqual 2 $vault.AccessPolicies.Count

    # Remove remaining two policies if specify object id
    $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

function Test-SetCompoundIdAccessPolicy
{
    Param($existingVaultName, $rgName, $appId, $objId)

    Assert-NotNull $appId

    # Add one compound id policy
    $PermToKeys = @("encrypt", "decrypt")
    $PermToSecrets = @()
    $PermToCertificates = @()
    $PermToStorage = @()
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PermissionsToKeys $PermToKeys -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru

    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
    
    Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId
    Assert-AreEqual $appId $vault.AccessPolicies[0].ApplicationId

    # Add one object id policy
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PassThru
    Assert-AreEqual 2 $vault.AccessPolicies.Count

    # Change compound id policy shall not affect object id policy
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PermissionsToKeys @("encrypt") -PassThru
    Assert-AreEqual 2 $vault.AccessPolicies.Count
    $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PassThru
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
    Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId
    Assert-AreEqual $vault.AccessPolicies[0].ApplicationId $null

    $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}



function Test-ModifyAccessPolicy
{
    Param($existingVaultName, $rgName, $objId)

    # Adding nothing should not change the vault
    $PermToKeys = @()
    $PermToSecrets = @()
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count

    # Add some perms now
    $PermToKeys = @("encrypt", "decrypt", "unwrapKey", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")
    $PermToSecrets = @("get", "list", "set", "delete", "backup", "restore")
    $PermToCertificates = @("list", "delete")
    $PermToStorage = @("list", "delete")
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru

    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
    Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId

    # Remove one perm from keys list, use piping to set
    $vault.AccessPolicies[0].PermissionsToKeys.Remove("unwrapKey")
    $vault = $vault.AccessPolicies[0] | Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -PassThru

    $PermToKeys = @("encrypt", "decrypt", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")    
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage 

    # Change just the secrets perms
    $PermToSecrets = Get-AllSecretPermissions
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToSecrets $PermToSecrets -PassThru
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage 

    # Remove just the keys perms
    $PermToKeys = @()
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PassThru
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage 
    
    # Remove secret perms too
    $PermToSecrets = @()
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PassThru
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage 

    # Remove certificates perms
    $PermToCertificates = @()
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToCertificates $PermToCertificates -PassThru
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage 

    # Finally remove certificates perms
    $PermToStorage = @()
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToStorage $PermToStorage -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

function Test-ModifyAccessPolicyEnabledForDeployment
{
    Param($existingVaultName, $rgName)
    $vault = Get-AzureRmKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $false $vault.EnabledForDeployment

    # Set and Remove EnabledForDeployment
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForDeployment -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $true $vault.EnabledForDeployment

    $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForDeployment -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $false $vault.EnabledForDeployment
}

function Test-ModifyAccessPolicyEnabledForTemplateDeployment
{
    Param($existingVaultName, $rgName)
    $vault = Get-AzureRmKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    if ($vault.EnabledForTemplateDeployment -ne $null)
    {
        Assert-AreEqual $false $vault.EnabledForTemplateDeployment
    }

    # Set and Remove EnabledForTemplateDeployment
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForTemplateDeployment -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $true $vault.EnabledForTemplateDeployment

    $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForTemplateDeployment -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $false $vault.EnabledForTemplateDeployment
}

function Test-ModifyAccessPolicyEnabledForDiskEncryption
{
    Param($existingVaultName, $rgName)
    $vault = Get-AzureRmKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    if ($vault.EnabledForDiskEncryption -ne $null)
    {
        Assert-AreEqual $false $vault.EnabledForDiskEncryption
    }

    # Set and Remove EnabledForDiskEncryption
    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForDiskEncryption -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $true $vault.EnabledForDiskEncryption

    $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForDiskEncryption -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $false $vault.EnabledForDiskEncryption
}

function Test-ModifyAccessPolicyNegativeCases
{
    Param($existingVaultName, $rgName, $objId)

    # random string in perms
    Assert-Throws { Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToSecrets blah, get }
    Assert-Throws { Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToCertificates blah, get }

    # invalid set of params
    Assert-Throws { Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName }
    Assert-Throws { Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName }
    Assert-Throws { Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName }
    Assert-Throws { Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName }
    Assert-Throws { Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $objId }
    Assert-Throws { Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -SPN $objId }
    Assert-Throws { Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId }
}

function Test-RemoveNonExistentAccessPolicyDoesNotThrow
{
    Param($existingVaultName, $rgName, $objId)
    $vault = Remove-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

#-------------------------------------------------------------------------------------


#------------------------------Piping--------------------------

function Test-CreateDeleteVaultWithPiping
{
    Param($rgName, $location)
    $vaultName = Get-VaultName

    New-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location | Get-AzureRmKeyVault | Remove-AzureRmKeyVault -Force -Confirm:$false

    $deletedVault = Get-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgName
    Assert-Null $deletedVault
}

#-------------------------------------------------------------------------------------

function Test-AllPermissionExpansion
{
    Param($existingVaultName, $rgName, $upn)
    $vault = Get-AzureRmKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count

    $vault = Set-AzureRmKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PermissionsToKeys all -PermissionsToSecrets all -PermissionsToCertificates all -PermissionsToStorage all -PassThru
    CheckVaultAccessPolicy $vault (Get-AllKeyPermissions) (Get-AllSecretPermissions) (Get-AllCertPermissions) (Get-AllStoragePermissions)
}

function CheckVaultAccessPolicy
{
    Param($vault, $expectedPermsToKeys, $expectedPermsToSecrets, $expectedPermsToCertificates, $expectedPermsToStorage)
    Assert-NotNull $vault
    Assert-AreEqual 1 $vault.AccessPolicies.Count

    $compare = Compare-Object $vault.AccessPolicies[0].PermissionsToKeys $expectedPermsToKeys
    Assert-Null $compare
    $compare = Compare-Object $vault.AccessPolicies[0].PermissionsToSecrets $expectedPermsToSecrets
    Assert-Null $compare
    $compare = Compare-Object $vault.AccessPolicies[0].PermissionsToCertificates $expectedPermsToCertificates
    Assert-Null $compare
    $compare = Compare-Object $vault.AccessPolicies[0].PermissionsToStorage $expectedPermsToStorage
    Assert-Null $compare
}

function Compare-Vaults
{
    Param($vault1, $vault2)
    Assert-AreEqual $vault1.VaultName $vault2.VaultName
    Assert-AreEqual $vault1.ResourceGroupName $vault2.ResourceGroupName
    Assert-AreEqual $vault1.Location $vault2.Location
    Assert-AreEqual $vault1.Sku $vault2.Sku
    Assert-AreEqual $vault1.EnabledForDeployment $vault2.EnabledForDeployment
    Assert-AreEqual $vault1.EnableSoftDelete $vault2.EnableSoftDelete
    Assert-AreEqual $vault1.EnabledForTemplateDeployment $vault2.EnabledForTemplateDeployment
    Assert-AreEqual $vault1.EnabledForDiskEncryption $vault2.EnabledForDiskEncryption

    If($vault2.AccessPolicies.Count -eq 1)
    {
        CheckVaultAccessPolicy $vault1 $vault2.AccessPolicies[0].PermissionsToKeys $vault2.AccessPolicies[0].PermissionsToSecrets $vault2.AccessPolicies[0].PermissionsToCertificates $vault2.AccessPolicies[0].PermissionsToStorage
        Assert-AreEqual $vault1.AccessPolicies[0].ObjectId $vault2.AccessPolicies[0].ObjectId
    }
}