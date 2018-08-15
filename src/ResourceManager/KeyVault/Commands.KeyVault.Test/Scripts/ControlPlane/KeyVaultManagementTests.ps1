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
	$rgName = getAssetName
	$unknownRGName = getAssetName
	$vault1Name = getAssetName
	$vault2Name = getAssetName
	$vault3Name = getAssetName
	$vault4Name = getAssetName
	$vault5Name = getAssetName
	$rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
	$vaultLocation = Get-Location "Microsoft.KeyVault" "vault" "West US"
	$tagKey = "asdf"
	$tagValue = "qwerty"
	New-AzureRmResourceGroup -Name $rgName -Location $rgLocation

	try
	{
		$actual = New-AzureRmKeyVault -VaultName $vault1Name -ResourceGroupName $rgName -Location $vaultLocation -Tag @{$tagKey = $tagValue}
		Assert-AreEqual $vault1Name $actual.VaultName
		Assert-AreEqual $rgName $actual.ResourceGroupName
		Assert-AreEqual $vaultLocation $actual.Location
		Assert-AreEqual $actual.Tags.Count 1
		Assert-AreEqual $actual.Tags.ContainsKey($tagKey) $true
		Assert-AreEqual $actual.Tags.ContainsValue($tagValue) $true
		Assert-AreEqual "Standard" $actual.Sku
		Assert-AreEqual $false $actual.EnabledForDeployment
		# Default Access Policy is not set by Service Principal
		Assert-AreEqual 0 @($actual.AccessPolicies).Count

		# Test premium vault
		$actual = New-AzureRmKeyVault -VaultName $vault2Name -ResourceGroupName $rgName -Location $vaultLocation -Sku premium -EnabledForDeployment
		Assert-AreEqual $vault2Name $actual.VaultName
		Assert-AreEqual $rgName $actual.ResourceGroupName
		Assert-AreEqual $vaultLocation $actual.Location
		Assert-AreEqual "Premium" $actual.Sku
		Assert-AreEqual $true $actual.EnabledForDeployment
		Assert-AreEqual 0 @($actual.AccessPolicies).Count

		# Test soft delete
		$actual = New-AzureRmKeyVault -VaultName $vault3Name -ResourceGroupName $rgName -Location $vaultLocation -Sku standard -EnableSoftDelete
		Assert-AreEqual $vault3Name $actual.VaultName
		Assert-AreEqual $rgName $actual.ResourceGroupName
		Assert-AreEqual $vaultLocation $actual.Location
		Assert-AreEqual "Standard" $actual.Sku
		Assert-AreEqual $true $actual.EnableSoftDelete
		Assert-AreEqual 0 @($actual.AccessPolicies).Count

		# Test positional parameters
		$actual = New-AzureRmKeyVault $vault4Name $rgName $vaultLocation
		Assert-NotNull $actual

		# Test throws for existing vault
		Assert-Throws { New-AzureRmKeyVault -VaultName $vault1Name -ResourceGroupName $rgname -Location $vaultLocation }

		# Test throws for resourcegroup nonexistent
		Assert-Throws { New-AzureRmKeyVault -VaultName $vault5Name -ResourceGroupName $unknownRGName -Location $vaultLocation }
	}

	finally
	{
		Remove-AzureRmResourceGroup -Name $rgName -Force
	}
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

function Test-GetVault
{
	$rgName = getAssetName
	$vaultName = getAssetName
	$rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
	$vaultLocation = Get-Location "Microsoft.KeyVault" "vault" "West US"
	New-AzureRmResourceGroup -Name $rgName -Location $rgLocation

	try
	{
		New-AzureRmKeyVault -Name $vaultName -ResourceGroupName $rgName -Location $vaultLocation
		$got = Get-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgName

		Assert-NotNull $got
		Assert-AreEqual $got.Location $vaultLocation
		Assert-AreEqual $got.ResourceGroupName $rgName
		Assert-AreEqual $got.VaultName $vaultName

		$got = Get-AzureRmKeyVault -VaultName $vaultName

		Assert-NotNull $got
		Assert-AreEqual $got.Location $vaultLocation
		Assert-AreEqual $got.ResourceGroupName $rgName
		Assert-AreEqual $got.VaultName $vaultName

		$got = Get-AzureRmKeyVault -VaultName $vaultName.toUpper()

		Assert-NotNull $got
		Assert-AreEqual $got.Location $vaultLocation
		Assert-AreEqual $got.ResourceGroupName $rgName
		Assert-AreEqual $got.VaultName $vaultName

		$unknownVault = getAssetName
		$unknownRG = getAssetName

		$unknown = Get-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $unknownRG
		Assert-Null $unknown

		$unknown = Get-AzureRmKeyVault -VaultName $unknownVault -ResourceGroupName $rgName
		Assert-Null $unknown
	}

	finally
	{
		Remove-AzureRmResourceGroup -Name $rgName -Force
	}
}

function Test-ListVaults
{
	$rgName = getAssetName
	$vault1Name = getAssetName
	$vault2Name = getAssetName
	$rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
	$vaultLocation = Get-Location "Microsoft.KeyVault" "vault" "West US"
	$tag = @{"abcdefg"="bcdefgh"}

	New-AzureRmResourceGroup -Name $rgName -Location $rgLocation
	
	try
	{
		New-AzureRmKeyVault -Name $vault1Name -ResourceGroupName $rgName -Location $vaultLocation
		New-AzureRmKeyVault -Name $vault2Name -ResourceGroupName $rgName -Location $vaultLocation -Tag $tag

		$list = Get-AzureRmKeyVault
		Assert-NotNull $list
		Assert-True { $list.Count -gt 1 }
		foreach($v in $list)
		{
			Assert-NotNull $v.VaultName
			Assert-NotNull $v.ResourceGroupName
		}

		$list = Get-AzureRmKeyVault -ResourceGroupName $rgName
		Assert-NotNull $list
		Assert-True { $list.Count -eq 2 }
		foreach($v in $list)
		{
			Assert-NotNull $v.VaultName
			Assert-AreEqual $rgName $v.ResourceGroupName
			Assert-AreEqual (Normalize-Location $vaultLocation) (Normalize-Location $v.Location)
		}

		$list = Get-AzureRmKeyVault -Tag $tag
		Assert-NotNull $list
		Assert-True { $list.Count -eq 1 }
		Assert-AreEqual $list[0].Tags.Keys[0] $tag.Keys[0]
		Assert-AreEqual $list.Tags[$list[0].Tags.Keys[0]] $tag[$tag.Keys[0]]

		$unknownRg = getAssetName
		Assert-Throws { Get-AzureRmKeyVault -ResourceGroupName $unknownRg }
	}
    
	finally
	{
		Remove-AzureRmResourceGroup -Name $rgName -Force
	}
}

#-------------------------------------------------------------------------------------

#------------------------------Remove-AzureRmKeyVault-----------------------------------
function Test-DeleteVaultByName
{
	$rgName = getAssetName
	$vaultName = getAssetName
	$rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
	$vaultLocation = Get-Location "Microsoft.KeyVault" "vault" "West US"
	$tag = @{"abcdefg"="bcdefgh"}

	New-AzureRmResourceGroup -Name $rgName -Location $rgLocation

	try
	{
		New-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $vaultLocation

		Remove-AzureRmKeyVault -VaultName $vaultName -Force

		$deletedVault = Get-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgName
		Assert-Null $deletedVault

		# Test piping
		New-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $vaultLocation
		
		Get-AzureRmKeyVault -VaultName $vaultName | Remove-AzureRmKeyVault -Force

		$deletedVault = Get-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgName
		Assert-Null $deletedVault

		# Test negative case
		$job = Remove-AzureRmKeyVault -VaultName $vaultName -AsJob
		$job | Wait-Job

		Assert-Throws { $job | Receive-Job }
	}
	
	finally
	{
		Remove-AzureRmResourceGroup -Name $rgName -Force
	}
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