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

#------------------------------New-AzKeyVault--------------------------------------

<<<<<<< HEAD
function Get-AllSecretPermissions 
{
=======
function Get-AllSecretPermissions {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
function Get-AllKeyPermissions
{
=======
function Get-AllKeyPermissions {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
        "sign", 
        "verify", 
        "wrapKey",
        "unwrapKey", 
        "encrypt", 
=======
        "sign",
        "verify",
        "wrapKey",
        "unwrapKey",
        "encrypt",
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        "decrypt"
    )
}

<<<<<<< HEAD
function Get-AllCertPermissions
{
=======
function Get-AllCertPermissions {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
        "managecontacts", 
        "manageissuers", 
=======
        "managecontacts",
        "manageissuers",
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        "setissuers",
        "recover"
    )
}

<<<<<<< HEAD
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
=======
function Get-AllStoragePermissions {
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    )
}

<#
.SYNOPSIS
Tests creating a new vault.
#>
<<<<<<< HEAD
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
	New-AzResourceGroup -Name $rgName -Location $rgLocation

	try
	{
		$actual = New-AzKeyVault -VaultName $vault1Name -ResourceGroupName $rgName -Location $vaultLocation -Tag @{$tagKey = $tagValue}
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
		$actual = New-AzKeyVault -VaultName $vault2Name -ResourceGroupName $rgName -Location $vaultLocation -Sku premium -EnabledForDeployment
		Assert-AreEqual $vault2Name $actual.VaultName
		Assert-AreEqual $rgName $actual.ResourceGroupName
		Assert-AreEqual $vaultLocation $actual.Location
		Assert-AreEqual "Premium" $actual.Sku
		Assert-AreEqual $true $actual.EnabledForDeployment
		Assert-AreEqual 0 @($actual.AccessPolicies).Count

		# Test soft delete
		$actual = New-AzKeyVault -VaultName $vault3Name -ResourceGroupName $rgName -Location $vaultLocation -Sku standard -EnableSoftDelete
		Assert-AreEqual $vault3Name $actual.VaultName
		Assert-AreEqual $rgName $actual.ResourceGroupName
		Assert-AreEqual $vaultLocation $actual.Location
		Assert-AreEqual "Standard" $actual.Sku
		Assert-AreEqual $true $actual.EnableSoftDelete
		Assert-AreEqual 0 @($actual.AccessPolicies).Count

		# Test positional parameters
		$actual = New-AzKeyVault $vault4Name $rgName $vaultLocation
		Assert-NotNull $actual

		# Test throws for existing vault
		Assert-Throws { New-AzKeyVault -VaultName $vault1Name -ResourceGroupName $rgname -Location $vaultLocation }

		# Test throws for resourcegroup nonexistent
		Assert-Throws { New-AzKeyVault -VaultName $vault5Name -ResourceGroupName $unknownRGName -Location $vaultLocation }
	}

	finally
	{
		Remove-AzResourceGroup -Name $rgName -Force
	}
=======
function Test-CreateNewVault {
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
    New-AzResourceGroup -Name $rgName -Location $rgLocation

    try {
        # Test default vault
        $actual = New-AzKeyVault -VaultName $vault1Name -ResourceGroupName $rgName -Location $vaultLocation -Tag @{$tagKey = $tagValue }
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
        # Soft delete and purge protection defaults to true
        Assert-True { $actual.EnableSoftDelete } "By default EnableSoftDelete should be true"
        Assert-Null $actual.EnablePurgeProtection "By default EnablePurgeProtection should be null"
        # RbacAuthorization defaults to false
        Assert-False { $actual.EnableRbacAuthorization } "By default EnableRbacAuthorization should be false"
        # Default retention days
        Assert-AreEqual 90 $actual.SoftDeleteRetentionInDays "By default SoftDeleteRetentionInDays should be 90"

        # Test premium vault
        $actual = New-AzKeyVault -VaultName $vault2Name -ResourceGroupName $rgName -Location $vaultLocation -Sku premium -EnabledForDeployment
        Assert-AreEqual $vault2Name $actual.VaultName
        Assert-AreEqual $rgName $actual.ResourceGroupName
        Assert-AreEqual $vaultLocation $actual.Location
        Assert-AreEqual "Premium" $actual.Sku
        Assert-AreEqual $true $actual.EnabledForDeployment
        Assert-AreEqual 0 @($actual.AccessPolicies).Count

        # Test enable purge protection & customize retention days
        $actual = New-AzKeyVault -VaultName (getAssetName) -ResourceGroupName $rgName -Location $vaultLocation -Sku standard -EnablePurgeProtection -SoftDeleteRetentionInDays 10
        Assert-True { $actual.EnableSoftDelete } "By default EnableSoftDelete should be true"
        Assert-True { $actual.EnablePurgeProtection } "If -EnablePurgeProtection, EnablePurgeProtection should be null"
        Assert-AreEqual 10 $actual.SoftDeleteRetentionInDays "SoftDeleteRetentionInDays should be the same value as set"

        # Test enable RbacAuthorization
        $actual = New-AzKeyVault -VaultName (getAssetName) -ResourceGroupName $rgName -Location $vaultLocation -EnableRbacAuthorization
        Assert-True { $actual.EnableRbacAuthorization } "If specified, EnableRbacAuthorization should be true"

        # Test positional parameters
        $actual = New-AzKeyVault $vault4Name $rgName $vaultLocation
        Assert-NotNull $actual

        # Test throws for existing vault
        Assert-Throws { New-AzKeyVault -VaultName $vault1Name -ResourceGroupName $rgname -Location $vaultLocation }

        # Test throws for resourcegroup nonexistent
        Assert-Throws { New-AzKeyVault -VaultName $vault5Name -ResourceGroupName $unknownRGName -Location $vaultLocation }
    }

    finally {
        Remove-AzResourceGroup -Name $rgName -Force
    }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}

#-------------------------------------------------------------------------------------

#------------------------------Soft-delete--------------------------------------

<#
.SYNOPSIS
Tests creating a soft-delete enabled vault, delete, retrieve and recover it.
#>
<<<<<<< HEAD
function Test-RecoverDeletedVault
{
=======
function Test-RecoverDeletedVault {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($rgName, $location)

    # Setup
    $vaultname = Get-VaultName

    # Test
<<<<<<< HEAD
    $vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Sku standard -EnableSoftDelete -Tag @{"x"= "y"}
=======
    $vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Sku standard -Tag @{"x" = "y" }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

    # Assert
    Assert-AreEqual $vaultName $vault.VaultName
    Assert-AreEqual $rgname $vault.ResourceGroupName
    Assert-AreEqual $location $vault.Location
    Assert-AreEqual "Standard" $vault.Sku
    Assert-True { $vault.EnableSoftDelete }
    Assert-AreEqual $vault.Tags.Count 1
    Assert-True { $vault.Tags.ContainsKey("x") }
    Assert-True { $vault.Tags.ContainsValue("y") }

<<<<<<< HEAD
    if ($global:noADCmdLetMode) {return;}
=======
    if ($global:noADCmdLetMode) { return; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Assert-AreEqual 1 @($vault.AccessPolicies).Count

    # Test
    Remove-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Force -Confirm:$false

    $allDeletedVault = Get-AzKeyVault -InRemovedState
    Assert-True { $allDeletedVault.Count -gt 0 }

    $deletedVault = Get-AzKeyVault -VaultName  $vaultName -Location $location -InRemovedState
    Assert-AreEqual $vaultName $deletedVault.VaultName
    Assert-AreEqual $location $deletedVault.Location
    Assert-AreEqual "Standard" $vault.Sku
    Assert-NotNull $deletedVault.DeletionDate
    Assert-NotNull $deletedVault.ScheduledPurgeDate
    Assert-AreEqual $deletedVault.Tags.Count 1
    Assert-True { $deletedVault.Tags.ContainsKey("x") }
    Assert-True { $deletedVault.Tags.ContainsValue("y") }

<<<<<<< HEAD
    $recoveredVault = Undo-AzKeyVaultRemoval -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Tag @{"m"= "n"}
    Compare-Vaults $vault $recoveredVault
    
=======
    $recoveredVault = Undo-AzKeyVaultRemoval -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Tag @{"m" = "n" }
    Compare-Vaults $vault $recoveredVault

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Assert-AreEqual $recoveredVault.Tags.Count 1
    Assert-True { $recoveredVault.Tags.ContainsKey("m") }
    Assert-True { $recoveredVault.Tags.ContainsValue("n") }
}

<#
.SYNOPSIS
Get not existing deleted vault
#>
<<<<<<< HEAD
function Test-GetNoneexistingDeletedVault
{
=======
function Test-GetNoneexistingDeletedVault {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    $deletedVault = Get-AzKeyVault -VaultName  'non-existing' -Location 'eastus2' -InRemovedState
    Assert-Null $deletedVault
}

<#
.SYNOPSIS
Tests creating a soft-delete enabled vault, delete and purge it.
#>
<<<<<<< HEAD
function Test-PurgeDeletedVault
{
=======
function Test-PurgeDeletedVault {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($rgName, $location)

    # Setup
    $vaultname = Get-VaultName

    # Test
<<<<<<< HEAD
    New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Sku standard -EnableSoftDelete -Tag @{"x"= "y"}
=======
    New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Sku standard -Tag @{"x" = "y" }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Remove-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Force -Confirm:$false
    Remove-AzKeyVault -VaultName $vaultName -Location $location -Force -Confirm:$false -InRemovedState

    $deletedVault = Get-AzKeyVault -VaultName  $vaultName -Location $location -InRemovedState
    Assert-Null $deletedVault
}
#-------------------------------------------------------------------------------------

#------------------------------Get-AzKeyVault--------------------------------------

<<<<<<< HEAD
function Test-GetVault
{
	$rgName = getAssetName
	$vaultName = getAssetName
	$rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
	$vaultLocation = Get-Location "Microsoft.KeyVault" "vault" "West US"
	New-AzResourceGroup -Name $rgName -Location $rgLocation

	try
	{
		New-AzKeyVault -Name $vaultName -ResourceGroupName $rgName -Location $vaultLocation
		$got = Get-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName

		Assert-NotNull $got
		Assert-AreEqual $got.Location $vaultLocation
		Assert-AreEqual $got.ResourceGroupName $rgName
		Assert-AreEqual $got.VaultName $vaultName

		$got = Get-AzKeyVault -VaultName $vaultName

		Assert-NotNull $got
		Assert-AreEqual $got.Location $vaultLocation
		Assert-AreEqual $got.ResourceGroupName $rgName
		Assert-AreEqual $got.VaultName $vaultName

		$got = Get-AzKeyVault -VaultName $vaultName.toUpper()

		Assert-NotNull $got
		Assert-AreEqual $got.Location $vaultLocation
		Assert-AreEqual $got.ResourceGroupName $rgName
		Assert-AreEqual $got.VaultName $vaultName

		$unknownVault = getAssetName
		$unknownRG = getAssetName

		$unknown = Get-AzKeyVault -VaultName $vaultName -ResourceGroupName $unknownRG
		Assert-Null $unknown

		$unknown = Get-AzKeyVault -VaultName $unknownVault -ResourceGroupName $rgName
		Assert-Null $unknown
	}

	finally
	{
		Remove-AzResourceGroup -Name $rgName -Force
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

	New-AzResourceGroup -Name $rgName -Location $rgLocation
	
	try
	{
		New-AzKeyVault -Name $vault1Name -ResourceGroupName $rgName -Location $vaultLocation
		New-AzKeyVault -Name $vault2Name -ResourceGroupName $rgName -Location $vaultLocation -Tag $tag

		$list = Get-AzKeyVault
		Assert-NotNull $list
		Assert-True { $list.Count -gt 1 }
		foreach($v in $list)
		{
			Assert-NotNull $v.VaultName
			Assert-NotNull $v.ResourceGroupName
		}

		$list = Get-AzKeyVault -ResourceGroupName $rgName
		Assert-NotNull $list
		Assert-True { $list.Count -eq 2 }
		foreach($v in $list)
		{
			Assert-NotNull $v.VaultName
			Assert-AreEqual $rgName $v.ResourceGroupName
			Assert-AreEqual (Normalize-Location $vaultLocation) (Normalize-Location $v.Location)
		}

		$list = Get-AzKeyVault -ResourceGroupName $rgName -VaultName *
		Assert-NotNull $list
		Assert-True { $list.Count -eq 2 }
		foreach($v in $list)
		{
			Assert-NotNull $v.VaultName
			Assert-AreEqual $rgName $v.ResourceGroupName
			Assert-AreEqual (Normalize-Location $vaultLocation) (Normalize-Location $v.Location)
		}

		$list = Get-AzKeyVault -ResourceGroupName * -VaultName *
		Assert-NotNull $list
		Assert-True { $list.Count -gt 1 }
		foreach($v in $list)
		{
			Assert-NotNull $v.VaultName
			Assert-NotNull $v.ResourceGroupName
		}

		$list = Get-AzKeyVault -ResourceGroupName * -VaultName $vault1Name
		Assert-NotNull $list
		Assert-True { $list.Count -eq 1 }
		foreach($v in $list)
		{
			Assert-NotNull $v.VaultName
			Assert-AreEqual $rgName $v.ResourceGroupName
			Assert-AreEqual (Normalize-Location $vaultLocation) (Normalize-Location $v.Location)
		}

		$list = Get-AzKeyVault -VaultName *
		Assert-NotNull $list
		Assert-True { $list.Count -gt 1 }
		foreach($v in $list)
		{
			Assert-NotNull $v.VaultName
			Assert-NotNull $v.ResourceGroupName
		}

		$list = Get-AzKeyVault -Tag $tag
		Assert-NotNull $list
		Assert-True { $list.Count -eq 1 }
		Assert-AreEqual $list[0].Tags.Keys[0] $tag.Keys[0]
		Assert-AreEqual $list.Tags[$list[0].Tags.Keys[0]] $tag[$tag.Keys[0]]

		$unknownRg = getAssetName
		Assert-Throws { Get-AzKeyVault -ResourceGroupName $unknownRg }
	}
    
	finally
	{
		Remove-AzResourceGroup -Name $rgName -Force
	}
=======
function Test-GetVault {
    $rgName = getAssetName
    $vaultName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $vaultLocation = Get-Location "Microsoft.KeyVault" "vault" "West US"
    New-AzResourceGroup -Name $rgName -Location $rgLocation

    try {
        New-AzKeyVault -Name $vaultName -ResourceGroupName $rgName -Location $vaultLocation
        $got = Get-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName

        Assert-NotNull $got
        Assert-AreEqual $got.Location $vaultLocation
        Assert-AreEqual $got.ResourceGroupName $rgName
        Assert-AreEqual $got.VaultName $vaultName

        $got = Get-AzKeyVault -VaultName $vaultName

        Assert-NotNull $got
        Assert-AreEqual $got.Location $vaultLocation
        Assert-AreEqual $got.ResourceGroupName $rgName
        Assert-AreEqual $got.VaultName $vaultName

        $got = Get-AzKeyVault -VaultName $vaultName.toUpper()

        Assert-NotNull $got
        Assert-AreEqual $got.Location $vaultLocation
        Assert-AreEqual $got.ResourceGroupName $rgName
        Assert-AreEqual $got.VaultName $vaultName

        $unknownVault = getAssetName
        $unknownRG = getAssetName

        $unknown = Get-AzKeyVault -VaultName $vaultName -ResourceGroupName $unknownRG
        Assert-Null $unknown

        $unknown = Get-AzKeyVault -VaultName $unknownVault -ResourceGroupName $rgName
        Assert-Null $unknown
    }

    finally {
        Remove-AzResourceGroup -Name $rgName -Force
    }
}

function Test-ListVaults {
    $rgName = getAssetName
    $vault1Name = getAssetName
    $vault2Name = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $vaultLocation = Get-Location "Microsoft.KeyVault" "vault" "West US"
    $tag = @{"abcdefg" = "bcdefgh" }

    New-AzResourceGroup -Name $rgName -Location $rgLocation

    try {
        New-AzKeyVault -Name $vault1Name -ResourceGroupName $rgName -Location $vaultLocation
        New-AzKeyVault -Name $vault2Name -ResourceGroupName $rgName -Location $vaultLocation -Tag $tag

        $list = Get-AzKeyVault
        Assert-NotNull $list
        Assert-True { $list.Count -gt 1 }
        foreach ($v in $list) {
            Assert-NotNull $v.VaultName
            Assert-NotNull $v.ResourceGroupName
        }

        $list = Get-AzKeyVault -ResourceGroupName $rgName
        Assert-NotNull $list
        Assert-True { $list.Count -eq 2 }
        foreach ($v in $list) {
            Assert-NotNull $v.VaultName
            Assert-AreEqual $rgName $v.ResourceGroupName
            Assert-AreEqual (Normalize-Location $vaultLocation) (Normalize-Location $v.Location)
        }

        $list = Get-AzKeyVault -ResourceGroupName $rgName -VaultName *
        Assert-NotNull $list
        Assert-True { $list.Count -eq 2 }
        foreach ($v in $list) {
            Assert-NotNull $v.VaultName
            Assert-AreEqual $rgName $v.ResourceGroupName
            Assert-AreEqual (Normalize-Location $vaultLocation) (Normalize-Location $v.Location)
        }

        $list = Get-AzKeyVault -ResourceGroupName * -VaultName *
        Assert-NotNull $list
        Assert-True { $list.Count -gt 1 }
        foreach ($v in $list) {
            Assert-NotNull $v.VaultName
            Assert-NotNull $v.ResourceGroupName
        }

        $list = Get-AzKeyVault -ResourceGroupName * -VaultName $vault1Name
        Assert-NotNull $list
        Assert-True { $list.Count -eq 1 }
        foreach ($v in $list) {
            Assert-NotNull $v.VaultName
            Assert-AreEqual $rgName $v.ResourceGroupName
            Assert-AreEqual (Normalize-Location $vaultLocation) (Normalize-Location $v.Location)
        }

        $list = Get-AzKeyVault -VaultName *
        Assert-NotNull $list
        Assert-True { $list.Count -gt 1 }
        foreach ($v in $list) {
            Assert-NotNull $v.VaultName
            Assert-NotNull $v.ResourceGroupName
        }

        $list = Get-AzKeyVault -Tag $tag
        Assert-NotNull $list
        Assert-True { $list.Count -eq 1 }
        Assert-AreEqual $list[0].Tags.Keys[0] $tag.Keys[0]
        Assert-AreEqual $list.Tags[$list[0].Tags.Keys[0]] $tag[$tag.Keys[0]]

        $unknownRg = getAssetName
        Assert-Throws { Get-AzKeyVault -ResourceGroupName $unknownRg }
    }

    finally {
        Remove-AzResourceGroup -Name $rgName -Force
    }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}

#-------------------------------------------------------------------------------------

#------------------------------Remove-AzKeyVault-----------------------------------
<<<<<<< HEAD
function Test-DeleteVaultByName
{
	$rgName = getAssetName
	$vaultName = getAssetName
	$rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
	$vaultLocation = Get-Location "Microsoft.KeyVault" "vault" "West US"
	$tag = @{"abcdefg"="bcdefgh"}

	New-AzResourceGroup -Name $rgName -Location $rgLocation

	try
	{
		New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $vaultLocation

		Remove-AzKeyVault -VaultName $vaultName -Force

		$deletedVault = Get-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName
		Assert-Null $deletedVault

		# Test piping
		New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $vaultLocation
		
		Get-AzKeyVault -VaultName $vaultName | Remove-AzKeyVault -Force

		$deletedVault = Get-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName
		Assert-Null $deletedVault

		# Test negative case
		$job = Remove-AzKeyVault -VaultName $vaultName -AsJob
		$job | Wait-Job

		Assert-Throws { $job | Receive-Job }
	}
	
	finally
	{
		Remove-AzResourceGroup -Name $rgName -Force
	}
=======
function Test-DeleteVaultByName {
    $rgName = getAssetName
    $vaultName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $vaultLocation = Get-Location "Microsoft.KeyVault" "vault" "West US"
    $tag = @{"abcdefg" = "bcdefgh" }

    New-AzResourceGroup -Name $rgName -Location $rgLocation

    try {
        New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $vaultLocation

        Remove-AzKeyVault -VaultName $vaultName -Force

        $deletedVault = Get-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName
        Assert-Null $deletedVault

        # Test piping
        New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $vaultLocation

        Get-AzKeyVault -VaultName $vaultName | Remove-AzKeyVault -Force

        $deletedVault = Get-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName
        Assert-Null $deletedVault

        # Test negative case
        $job = Remove-AzKeyVault -VaultName $vaultName -AsJob
        $job | Wait-Job

        Assert-Throws { $job | Receive-Job }
    }

    finally {
        Remove-AzResourceGroup -Name $rgName -Force
    }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}

#-------------------------------------------------------------------------------------

#------------------------------Set-AzKeyVaultAccessPolicy--------------------------

<<<<<<< HEAD
function Test-SetRemoveAccessPolicyByUPN
{
=======
function Test-SetRemoveAccessPolicyByUPN {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName, $upn)

    $PermToKeys = @("encrypt", "decrypt", "unwrapKey", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")
    $PermToSecrets = @("get", "list", "set", "delete", "backup", "restore")
    $PermToCertificates = @("get", "list", "create", "delete")
    $PermToStorage = @("get", "list", "delete")
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru
<<<<<<< HEAD
    
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
    if (-not $global:noADCmdLetMode) {
        Assert-AreEqual $upn (Get-AzADUser -ObjectId $vault.AccessPolicies[0].ObjectId)[0].UserPrincipalName
    }

    $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

<<<<<<< HEAD
function Test-SetRemoveAccessPolicyByEmailAddress
{
=======
function Test-SetRemoveAccessPolicyByEmailAddress {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName, $email, $upn)

    $PermToKeys = @("encrypt", "decrypt", "unwrapKey", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")
    $PermToSecrets = @("get", "list", "set", "delete")
    $PermToCertificates = @("get", "list", "create", "delete")
    $PermToStorage = @("get", "list", "delete")

    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EmailAddress $email -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru

    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
    if (-not $global:noADCmdLetMode) {
        Assert-AreEqual  $vault.AccessPolicies[0].ObjectId (Get-AzADUser -Mail $upn).Id
    }

    $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EmailAddress $email -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

<<<<<<< HEAD
function Test-SetRemoveAccessPolicyBySPN
{
=======
function Test-SetRemoveAccessPolicyBySPN {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName, $spn)

    $PermToKeys = @()
    $PermToSecrets = @("get", "set", "list")
    $PermToCertificates = @("get", "import")
    $PermToStorage = @("get", "list")
<<<<<<< HEAD
    
    $setAccessPolicyFunc = { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ServicePrincipalName $spn -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru }
    
    if ($global:noADCmdLetMode) {
        Assert-Throws { &$setAccessPolicyFunc }
    }
    else{
=======

    $setAccessPolicyFunc = { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ServicePrincipalName $spn -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru }

    if ($global:noADCmdLetMode) {
        Assert-Throws { &$setAccessPolicyFunc }
    }
    else {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        $vault = &$setAccessPolicyFunc

        CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage

        Assert-AreEqual $spn (Get-AzADServicePrincipal -ObjectId $vault.AccessPolicies[0].ObjectId)[0].ServicePrincipalNames[0]

        $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -SPN $spn -PassThru
        Assert-AreEqual 0 $vault.AccessPolicies.Count
    }
}

<<<<<<< HEAD
function Test-SetRemoveAccessPolicyByObjectId
{
=======
function Test-SetRemoveAccessPolicyByObjectId {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName, $objId, [switch]$bypassObjectIdValidation)

    $PermToKeys = @("encrypt", "decrypt")
    $PermToSecrets = @()
    $PermToCertificates = @()
    $PermToStorage = @()

    $vault;
<<<<<<< HEAD
    if ($bypassObjectIdValidation.IsPresent)
    {
        $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -BypassObjectIdValidation -PassThru
    }
    else
    {
=======
    if ($bypassObjectIdValidation.IsPresent) {
        $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -BypassObjectIdValidation -PassThru
    }
    else {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru
    }

    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
<<<<<<< HEAD
    
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId

    $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

<<<<<<< HEAD
function Test-SetRemoveAccessPolicyByCompoundId
{
=======
function Test-SetRemoveAccessPolicyByCompoundId {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName, $appId, $objId)

    Assert-NotNull $appId

    $PermToKeys = @("encrypt", "decrypt")
    $PermToSecrets = @()
    $PermToCertificates = @("list", "delete")
    $PermToStorage = @("list", "delete")
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PermissionsToKeys $PermToKeys -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru

    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
<<<<<<< HEAD
    
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId
    Assert-AreEqual $appId $vault.AccessPolicies[0].ApplicationId

    $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

<<<<<<< HEAD
function Test-RemoveAccessPolicyWithCompoundIdPolicies
{
=======
function Test-RemoveAccessPolicyWithCompoundIdPolicies {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName, $appId1, $appId2, $objId)

    Assert-NotNull $appId1
    Assert-NotNull $appId2

    # Add three access policies: ObjectId, (ObjectId, App1), (ObjectId, App2)
    $PermToKeys = @("encrypt", "decrypt")
    $PermToSecrets = @()
    $PermToCertificates = @("all")
    $PermToStorage = @("all")
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PassThru
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId1 -PermissionsToKeys $PermToKeys -PassThru
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId2 -PermissionsToKeys $PermToKeys -PermissionsToCertificates $PermToCertificates -PassThru
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId2 -PermissionsToKeys $PermToKeys -PermissionsToStorage $PermToStorage -PassThru
    Assert-AreEqual 3 $vault.AccessPolicies.Count

    # Remove one policy if specify compound id
    $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId1 -PassThru
    Assert-AreEqual 2 $vault.AccessPolicies.Count

    # Remove remaining two policies if specify object id
    $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

<<<<<<< HEAD
function Test-SetCompoundIdAccessPolicy
{
=======
function Test-SetCompoundIdAccessPolicy {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName, $appId, $objId)

    Assert-NotNull $appId

    # Add one compound id policy
    $PermToKeys = @("encrypt", "decrypt")
    $PermToSecrets = @()
    $PermToCertificates = @()
    $PermToStorage = @()
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PermissionsToKeys $PermToKeys -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru

    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
<<<<<<< HEAD
    
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId
    Assert-AreEqual $appId $vault.AccessPolicies[0].ApplicationId

    # Add one object id policy
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PassThru
    Assert-AreEqual 2 $vault.AccessPolicies.Count

    # Change compound id policy shall not affect object id policy
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PermissionsToKeys @("encrypt") -PassThru
    Assert-AreEqual 2 $vault.AccessPolicies.Count
    $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PassThru
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
    Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId
    Assert-AreEqual $vault.AccessPolicies[0].ApplicationId $null

    $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}



<<<<<<< HEAD
function Test-ModifyAccessPolicy
{
=======
function Test-ModifyAccessPolicy {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName, $objId)

    # Adding nothing should not change the vault
    $PermToKeys = @()
    $PermToSecrets = @()
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count

    # Add some perms now
    $PermToKeys = @("encrypt", "decrypt", "unwrapKey", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")
    $PermToSecrets = @("get", "list", "set", "delete", "backup", "restore")
    $PermToCertificates = @("list", "delete")
    $PermToStorage = @("list", "delete")
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PermissionsToCertificates $PermToCertificates -PermissionsToStorage $PermToStorage -PassThru

    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
    Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId

    # Remove one perm from keys list, use piping to set
    $vault.AccessPolicies[0].PermissionsToKeys.Remove("unwrapKey")
    $vault = $vault.AccessPolicies[0] | Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -PassThru

<<<<<<< HEAD
    $PermToKeys = @("encrypt", "decrypt", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")    
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage 
=======
    $PermToKeys = @("encrypt", "decrypt", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

    # Change just the secrets perms
    $PermToSecrets = Get-AllSecretPermissions
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToSecrets $PermToSecrets -PassThru
<<<<<<< HEAD
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage 
=======
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

    # Remove just the keys perms
    $PermToKeys = @()
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PassThru
<<<<<<< HEAD
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage 
    
    # Remove secret perms too
    $PermToSecrets = @()
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PassThru
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage 
=======
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage

    # Remove secret perms too
    $PermToSecrets = @()
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PassThru
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

    # Remove certificates perms
    $PermToCertificates = @()
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToCertificates $PermToCertificates -PassThru
<<<<<<< HEAD
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage 
=======
    CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets $PermToCertificates $PermToStorage
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

    # Finally remove certificates perms
    $PermToStorage = @()
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToStorage $PermToStorage -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

<<<<<<< HEAD
function Test-ModifyAccessPolicyEnabledForDeployment
{
=======
function Test-ModifyAccessPolicyEnabledForDeployment {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName)
    $vault = Get-AzKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $false $vault.EnabledForDeployment

    # Set and Remove EnabledForDeployment
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForDeployment -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $true $vault.EnabledForDeployment

    $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForDeployment -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $false $vault.EnabledForDeployment
}

<<<<<<< HEAD
function Test-ModifyAccessPolicyEnabledForTemplateDeployment
{
=======
function Test-ModifyAccessPolicyEnabledForTemplateDeployment {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName)
    $vault = Get-AzKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
<<<<<<< HEAD
    if ($vault.EnabledForTemplateDeployment -ne $null)
    {
=======
    if ($vault.EnabledForTemplateDeployment -ne $null) {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        Assert-AreEqual $false $vault.EnabledForTemplateDeployment
    }

    # Set and Remove EnabledForTemplateDeployment
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForTemplateDeployment -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $true $vault.EnabledForTemplateDeployment

    $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForTemplateDeployment -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $false $vault.EnabledForTemplateDeployment
}

<<<<<<< HEAD
function Test-ModifyAccessPolicyEnabledForDiskEncryption
{
=======
function Test-ModifyAccessPolicyEnabledForDiskEncryption {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName)
    $vault = Get-AzKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
<<<<<<< HEAD
    if ($vault.EnabledForDiskEncryption -ne $null)
    {
=======
    if ($vault.EnabledForDiskEncryption -ne $null) {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        Assert-AreEqual $false $vault.EnabledForDiskEncryption
    }

    # Set and Remove EnabledForDiskEncryption
    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForDiskEncryption -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $true $vault.EnabledForDiskEncryption

    $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForDiskEncryption -PassThru
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count
    Assert-AreEqual $false $vault.EnabledForDiskEncryption
}

<<<<<<< HEAD
function Test-ModifyAccessPolicyNegativeCases
{
    Param($existingVaultName, $rgName, $objId)

    # random string in perms
    Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToSecrets blah, get }
    Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToCertificates blah, get }

    # invalid set of params
    Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName }
    Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName }
    Assert-Throws { Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName }
    Assert-Throws { Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName }
    Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $objId }
    Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -SPN $objId }
    Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId }
}

function Test-RemoveNonExistentAccessPolicyDoesNotThrow
{
=======
function Test-ModifyAccessPolicyNegativeCases {
    $objId = "" # INTENTIONAL
    $rgName = getAssetName
    $vaultName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $vaultLocation = Get-Location "Microsoft.KeyVault" "vault" "West US"
    New-AzResourceGroup -Name $rgName -Location $rgLocation

    try {
        New-AzKeyVault -Name $vaultName -ResourceGroupName $rgName -Location $vaultLocation

        # random string in perms
        Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToSecrets blah, get }
        Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToCertificates blah, get }

        # invalid set of params
        Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName }
        Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName }
        Assert-Throws { Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName }
        Assert-Throws { Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName }
        Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $objId }
        Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -SPN $objId }
        Assert-Throws { Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId }
    }
    finally {
        Remove-AzResourceGroup -Name $rgName -Force
    }
}

function Test-RemoveNonExistentAccessPolicyDoesNotThrow {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName, $objId)
    $vault = Remove-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PassThru
    Assert-AreEqual 0 $vault.AccessPolicies.Count
}

#-------------------------------------------------------------------------------------

<<<<<<< HEAD
function Test-AllPermissionExpansion
{
=======
function Test-AllPermissionExpansion {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($existingVaultName, $rgName, $upn)
    $vault = Get-AzKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName
    Assert-NotNull $vault
    Assert-AreEqual 0 $vault.AccessPolicies.Count

    $vault = Set-AzKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PermissionsToKeys all -PermissionsToSecrets all -PermissionsToCertificates all -PermissionsToStorage all -PassThru
    CheckVaultAccessPolicy $vault (Get-AllKeyPermissions) (Get-AllSecretPermissions) (Get-AllCertPermissions) (Get-AllStoragePermissions)
}

<<<<<<< HEAD
function CheckVaultAccessPolicy
{
=======
function CheckVaultAccessPolicy {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
function Compare-Vaults
{
=======
function Compare-Vaults {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    Param($vault1, $vault2)
    Assert-AreEqual $vault1.VaultName $vault2.VaultName
    Assert-AreEqual $vault1.ResourceGroupName $vault2.ResourceGroupName
    Assert-AreEqual $vault1.Location $vault2.Location
    Assert-AreEqual $vault1.Sku $vault2.Sku
    Assert-AreEqual $vault1.EnabledForDeployment $vault2.EnabledForDeployment
    Assert-AreEqual $vault1.EnableSoftDelete $vault2.EnableSoftDelete
    Assert-AreEqual $vault1.EnabledForTemplateDeployment $vault2.EnabledForTemplateDeployment
    Assert-AreEqual $vault1.EnabledForDiskEncryption $vault2.EnabledForDiskEncryption

<<<<<<< HEAD
    If($vault2.AccessPolicies.Count -eq 1)
    {
=======
    If ($vault2.AccessPolicies.Count -eq 1) {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        CheckVaultAccessPolicy $vault1 $vault2.AccessPolicies[0].PermissionsToKeys $vault2.AccessPolicies[0].PermissionsToSecrets $vault2.AccessPolicies[0].PermissionsToCertificates $vault2.AccessPolicies[0].PermissionsToStorage
        Assert-AreEqual $vault1.AccessPolicies[0].ObjectId $vault2.AccessPolicies[0].ObjectId
    }
}

<<<<<<< HEAD
function Test-NetworkRuleSet
{
	$resourceGroupName = getAssetName
	$resourceGroupLocation = Get-Location "Microsoft.Resources" "resourceGroups" "westus"
	$vaultName = getAssetName
	$vaultLocation = Get-Location "Microsoft.KeyVault" "vaults" "westus"
	$virtualNetworkName = getAssetName
	$virtualNetworkLocation = Get-Location "Microsoft.Network" "virtualNetworks" "westus"

	try
	{
		$rg = New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation
		$vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroupName -Location $vaultLocation

		$frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "10.0.1.0/24" -ServiceEndpoint Microsoft.KeyVault 
		$virtualNetwork = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $resourceGroupName -Location $virtualNetworkLocation -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet

		$myNetworkResId = (Get-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $resourceGroupName).Subnets[0].Id
		Add-AzKeyVaultNetworkRule -VaultName $vaultName -IpAddressRange "10.0.1.0/24" -VirtualNetworkResourceId $myNetworkResId
		$vault = Get-AzKeyVault -ResourceGroupName $resourceGroupName -Name $vaultName
		Assert-AreEqual $vault.NetworkAcls.IpAddressRanges.Count 1
		Assert-AreEqual $vault.NetworkAcls.IpAddressRanges[0] "10.0.1.0/24"
		Assert-AreEqual $vault.NetworkAcls.VirtualNetworkResourceIds.Count 1
		Assert-AreEqual $vault.NetworkAcls.VirtualNetworkResourceIds[0] $myNetworkResId
		Assert-AreEqual $vault.NetworkAcls.Bypass.toString() "AzureServices"
		Assert-AreEqual $vault.NetworkAcls.DefaultAction.toString() "Allow"

		$networkRule = Update-AzKeyVaultNetworkRuleSet -VaultName $vaultName -ResourceGroupName $resourceGroupName -Bypass None -DefaultAction Deny -PassThru
		Assert-AreEqual $networkRule.NetworkAcls.Bypass.toString() "None"
		Assert-AreEqual $networkRule.NetworkAcls.DefaultAction.toString() "Deny"
		$vault = Get-AzKeyVault -ResourceGroupName $resourceGroupName -Name $vaultName
		Assert-AreEqual $vault.NetworkAcls.Bypass.toString() "None"
		Assert-AreEqual $vault.NetworkAcls.DefaultAction.toString() "Deny"

		Remove-AzKeyVaultNetworkRule -VaultName $vaultName -ResourceGroupName $resourceGroupName -IpAddressRange "10.0.1.0/24" -VirtualNetworkResourceId $myNetworkResId
		$vault = Get-AzKeyVault -ResourceGroupName $resourceGroupName -Name $vaultName
		Assert-AreEqual $vault.NetworkAcls.IpAddressRanges.Count 0
		Assert-AreEqual $vault.NetworkAcls.VirtualNetworkResourceIds.Count 0
	}
	finally
	{
		Remove-AzResourceGroup -Name $resourceGroupName -Force
	}
}
=======
function Test-UpdateKeyVault {
    $resourceGroupName = getAssetName
    $resourceGroupLocation = Get-Location "Microsoft.Resources" "resourceGroups" "westus"
    $vaultLocation = Get-Location "Microsoft.KeyVault" "vaults" "westus"

    try {
        $rg = New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation
        $originVault = New-AzKeyVault -VaultName (getAssetName) -ResourceGroupName $resourceGroupName -Location $vaultLocation
        Assert-True { $originVault.EnableSoftDelete } "1. EnableSoftDelete should be true"
        Assert-True { $originVault.EnablePurgeProtection -ne $true } "1. EnablePurgeProtection should not be true"
        Assert-AreEqual 90 $originVault.SoftDeleteRetentionInDays "1. SoftDeleteRetentionInDays should default to 90"

        # Then enable purge protection
        $vault = $originVault | Update-AzKeyVault -EnablePurgeProtection
        Assert-True { $vault.EnableSoftDelete } "3. EnableSoftDelete should be true"
        Assert-True { $vault.EnablePurgeProtection } "3. EnablePurgeProtection should be true"
        Assert-True { $vault.SoftDeleteRetentionInDays -eq $originVault.SoftDeleteRetentionInDays }

        # # Only enable purge protection (TODO: uncomment this assert after keyvault team deploys their fix)
        # $vault = New-AzKeyVault -VaultName (getAssetName) -ResourceGroupName $resourceGroupName -Location $vaultLocation
        # Assert-Throws { $vault = $vault | Update-AzKeyVault -EnablePurgeProtection }
        # # Retention cannot be updated once set
        # Assert-Throws { $vault = $vault | Update-AzKeyVault -SoftDeleteRetentionInDays 80}

        #Set EnableRbacAuthorization true
        $vault = $vault | Update-AzKeyVault -EnableRbacAuthorization $true
        Assert-True { $vault.EnableRbacAuthorization } "5. EnableRbacAuthorization should be true"

        #Set EnableRbacAuthorization false
        $vault = $vault | Update-AzKeyVault -EnableRbacAuthorization $false
        Assert-False { $vault.EnableRbacAuthorization } "6. EnableRbacAuthorization should be false"

        # Update Tags
        $vault = $vault | Update-AzKeyVault -Tag @{key = "value"}
        Assert-AreEqual 1 $vault.Tags.Count "7. Tags should contain a key-value pair (key, value)"
        Assert-True { $vault.Tags.Contains("key") } "7. Tags should contain a key-value pair (key, value)"
        Assert-AreEqual "value" $vault.Tags["key"] "7. Tags should contain a key-value pair (key, value)"

        # Clean Tags
        $vault = $vault | Update-AzKeyVault -Tag @{}
        Assert-AreEqual 0 $vault.Tags.Count "8. Tags should be empty"

    }
    finally {
        $rg | Remove-AzResourceGroup -Force
    }
}
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
