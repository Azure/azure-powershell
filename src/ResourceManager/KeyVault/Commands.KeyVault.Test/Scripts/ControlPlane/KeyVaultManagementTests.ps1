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

#------------------------------New-AzureKeyVault--------------------------------------

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
	$actual = New-AzureKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Tags @{Name = $tagName; Value = $tagValue}	
		
	# Assert
	Assert-AreEqual $vaultName $actual.VaultName			
	Assert-AreEqual $rgname $actual.ResourceGroupName
	Assert-AreEqual $location $actual.Location
	Assert-AreEqual $actual.Tags[0]["Value"] $tagValue
	Assert-AreEqual $actual.Tags[0]["Name"] $tagName
	Assert-AreEqual "Standard" $actual.Sku	
	Assert-AreEqual $false $actual.EnabledForDeployment

	# Default Access Policy
	$upn = @(Get-AzureAccount)[0].Id
	$objectId = @(Get-AzureADUser -Mail $upn)[0].Id
	$expectedPermsToKeys = @("get",
            "create",
            "delete",
            "list",
            "update",
            "import",
            "backup",
            "restore")
	$expectedPermsToSecrets = @("all")

	Assert-AreEqual 1 @($actual.AccessPolicies).Count	
	Assert-AreEqual $objectId $actual.AccessPolicies[0].ObjectId
	$result = Compare-Object $expectedPermsToKeys $actual.AccessPolicies[0].PermissionsToKeys
	Assert-Null $result
	$result = Compare-Object $expectedPermsToSecrets $actual.AccessPolicies[0].PermissionsToSecrets
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
	$actual = New-AzureKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location -Sku premium -EnabledForDeployment
		
	# Assert
	Assert-AreEqual $vaultName $actual.VaultName			
	Assert-AreEqual $rgname $actual.ResourceGroupName
	Assert-AreEqual $location $actual.Location	
	Assert-AreEqual "Premium" $actual.Sku
	Assert-AreEqual 1 @($actual.AccessPolicies).Count
	Assert-AreEqual $true $actual.EnabledForDeployment
}

<#
.SYNOPSIS
Recreate vault fails
#>
function Test-RecreateVaultFails
{
	Param($existingVaultName, $rgName, $location)

	 Assert-Throws { New-AzureKeyVault -VaultName $existingVaultName -ResourceGroupName $rgname -Location $location }
}

function Test-CreateVaultInUnknownResGrpFails
{
	Param($location)

	$vaultname = Get-VaultName			
	$rgName = Get-ResourceGroupName

	Assert-Throws { New-AzureKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $location }
}

function Test-CreateVaultPositionalParams
{
	Param($rgName, $location)

	# Setup	
	$vaultname = Get-VaultName					
		
	# Test
	$actual = New-AzureKeyVault $vaultName $rgname $location

	Assert-NotNull $actual		
}
#-------------------------------------------------------------------------------------

#------------------------------Get-AzureKeyVault--------------------------------------

function Test-GetVaultByNameAndResourceGroup
{
	Param($existingVaultName, $rgName)

	$got = Get-AzureKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName

	Assert-NotNull $got
}

function Test-GetVaultByNameAndResourceGroupPositionalParams
{
	Param($existingVaultName, $rgName)

	$got = Get-AzureKeyVault $existingVaultName $rgName

	Assert-NotNull $got
}

function Test-GetVaultByName
{
	Param($existingVaultName)

	$got = Get-AzureKeyVault -VaultName $existingVaultName

	Assert-NotNull $got
}

function Test-GetUnknownVaultFails
{
	Param($rgName)
	$vaultname = Get-VaultName		
	
	Assert-Throws { Get-AzureKeyVault -VaultName $vaultName -ResourceGroupName $rgName }
}

function Test-GetVaultFromUnknownResourceGroupFails
{
	Param($existingVaultName)
	$rgName = Get-ResourceGroupName	
	
	Assert-Throws { Get-AzureKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName }
}

function Test-ListVaultsByResourceGroup
{
	Param($rgName)
	$list = Get-AzureKeyVault -ResourceGroupName $rgName

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
	$list = Get-AzureKeyVault 

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
	$list = Get-AzureKeyVault -Tag  @{Name = $tagName; Value = $tagValue}

	Assert-NotNull $list
	Assert-True { $list.Count -gt 0 }	
}

function Test-ListVaultsByUnknownResourceGroupFails
{
	$rgName = Get-ResourceGroupName	
	
	Assert-Throws { Get-AzureKeyVault -ResourceGroupName $rgName }
}

#-------------------------------------------------------------------------------------

#------------------------------Remove-AzureKeyVault-----------------------------------
function Test-DeleteVaultByName
{
	Param($rgName, $location)
	$vaultName = Get-VaultName
	
	New-AzureKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location 
	
	Remove-AzureKeyVault -VaultName $vaultName -Force -Confirm:$false

	Assert-Throws { Get-AzureKeyVault -VaultName $vaultName -ResourceGroupName $rgName }
}

function Test-DeleteUnknownVaultFails
{	
	$vaultName = Get-VaultName

	Assert-Throws { Remove-AzureKeyVault -VaultName $vaultName  } 
}

#-------------------------------------------------------------------------------------

#------------------------------Set-AzureKeyVaultAccessPolicy--------------------------

function Test-SetRemoveAccessPolicyByUPN
{
	Param($existingVaultName, $rgName, $upn)
	
	$PermToKeys = @("encrypt", "decrypt", "unwrapKey", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")
	$PermToSecrets = @("get", "list", "set", "delete")
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PassThru

	CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets

    $adUser = (Get-AzureADUser -ObjectId $vault.AccessPolicies[0].ObjectId)[0]
	Assert-True (($upn -eq $adUser.UserPrincipalName) -or `
                ($upn -eq $adUser.Mail))

	$vault = Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PassThru
	Assert-AreEqual 0 $vault.AccessPolicies.Count
}

function Test-SetRemoveAccessPolicyBySPN
{
	Param($existingVaultName, $rgName, $spn)
	
	$PermToKeys = @()
	$PermToSecrets = @("get", "set", "list")
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ServicePrincipalName $spn -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PassThru

	CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets
	
	Assert-AreEqual $spn (Get-AzureADServicePrincipal -ObjectId $vault.AccessPolicies[0].ObjectId)[0].ServicePrincipalName

	$vault = Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -SPN $spn -PassThru
	Assert-AreEqual 0 $vault.AccessPolicies.Count
}

function Test-SetRemoveAccessPolicyByObjectId
{
	Param($existingVaultName, $rgName, $upn)

	$user = Get-AzureADUser -UserPrincipalName $upn
	if ($user -eq $null)
	{
		$user = Get-AzureADUser -Mail $upn
	}
	Assert-NotNull $user
	$objId = $user.Id
	
	$PermToKeys = @("encrypt", "decrypt")
	$PermToSecrets = @()
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PassThru

	CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets
	
	Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId

	$vault = Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PassThru
	Assert-AreEqual 0 $vault.AccessPolicies.Count
}

function Test-SetRemoveAccessPolicyByCompoundId
{
	Param($existingVaultName, $rgName, $upn, $appId)

	Assert-NotNull $appId
	
	$user = Get-AzureADUser -UserPrincipalName $upn
	if ($user -eq $null)
	{
		$user = Get-AzureADUser -Mail $upn
	}
	Assert-NotNull $user
	$objId = $user.Id
	
	$PermToKeys = @("encrypt", "decrypt")
	$PermToSecrets = @()
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PermissionsToKeys $PermToKeys -PassThru

	CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets
	
	Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId
	Assert-AreEqual $appId $vault.AccessPolicies[0].ApplicationId	

	$vault = Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PassThru
	Assert-AreEqual 0 $vault.AccessPolicies.Count
}

function Test-RemoveAccessPolicyWithCompoundIdPolicies
{
	Param($existingVaultName, $rgName, $upn, $appId1, $appId2)

	Assert-NotNull $appId1
	Assert-NotNull $appId2

	$user = Get-AzureADUser -UserPrincipalName $upn
	if ($user -eq $null)
	{
		$user = Get-AzureADUser -Mail $upn
	}
	Assert-NotNull $user
	$objId = $user.Id
	
	# Add three access policies: ObjectId, (ObjectId, App1), (ObjectId, App2)
	$PermToKeys = @("encrypt", "decrypt")
	$PermToSecrets = @()
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PassThru
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId1 -PermissionsToKeys $PermToKeys -PassThru
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId2 -PermissionsToKeys $PermToKeys -PassThru
	Assert-AreEqual 3 $vault.AccessPolicies.Count
	
	# Remove one policy if specify compound id
	$vault = Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId1 -PassThru
	Assert-AreEqual 2 $vault.AccessPolicies.Count
	
	# Remove remaining two policies if specify object id
	$vault = Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PassThru	
	Assert-AreEqual 0 $vault.AccessPolicies.Count
}

function Test-SetCompoundIdAccessPolicy
{
	Param($existingVaultName, $rgName, $upn, $appId)

	Assert-NotNull $appId

	$user = Get-AzureADUser -UserPrincipalName $upn
	if ($user -eq $null)
	{
		$user = Get-AzureADUser -Mail $upn
	}
	Assert-NotNull $user
	$objId = $user.Id
	
	# Add one compound id policy
	$PermToKeys = @("encrypt", "decrypt")
	$PermToSecrets = @()
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PermissionsToKeys $PermToKeys -PassThru

	CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets
	
	Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId
	Assert-AreEqual $appId $vault.AccessPolicies[0].ApplicationId	

	# Add one object id policy	
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToKeys $PermToKeys -PassThru
	Assert-AreEqual 2 $vault.AccessPolicies.Count

	# Change compound id policy shall not affect object id policy		
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PermissionsToKeys @("encrypt") -PassThru
	Assert-AreEqual 2 $vault.AccessPolicies.Count
	$vault = Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -ApplicationId $appId -PassThru
	CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets
	Assert-AreEqual $objId $vault.AccessPolicies[0].ObjectId
	Assert-AreEqual $vault.AccessPolicies[0].ApplicationId $null
	
	$vault = Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PassThru	
	Assert-AreEqual 0 $vault.AccessPolicies.Count
}



function Test-ModifyAccessPolicy
{
	Param($existingVaultName, $rgName, $upn)
	
	# Adding nothing should not change the vault
	$PermToKeys = @()
	$PermToSecrets = @()	
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PermissionsToKeys $PermToKeys -PassThru
	Assert-NotNull $vault
	Assert-AreEqual 0 $vault.AccessPolicies.Count

	# Add some perms now
	$PermToKeys = @("encrypt", "decrypt", "unwrapKey", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")
	$PermToSecrets = @("get", "list", "set", "delete")
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UPN $upn -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PassThru

	CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets
	$adUser = (Get-AzureADUser -ObjectId $vault.AccessPolicies[0].ObjectId)[0]
	Assert-True (($upn -eq $adUser.UserPrincipalName) -or `
                ($upn -eq $adUser.Mail))

	$objId = $vault.AccessPolicies[0].ObjectId

	# Remove one perm from keys list, use piping to set
	$vault.AccessPolicies[0].PermissionsToKeys.Remove("unwrapKey")	
	$vault = $vault.AccessPolicies[0] | Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -PassThru

	$PermToKeys = @("encrypt", "decrypt", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")	
	CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets

	# Change just the secrets perms
	$PermToSecrets = @("all")
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $objId -PermissionsToSecrets $PermToSecrets -PassThru
	CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets

	# Remove just the keys perms
	$PermToKeys = @()
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PermissionsToKeys $PermToKeys -PassThru
	CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets
	
	# Remove secret perms too
	$PermToSecrets = @()	
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PassThru
	Assert-NotNull $vault
	Assert-AreEqual 0 $vault.AccessPolicies.Count
}

function Test-ModifyAccessPolicyEnabledForDeployment
{
	Param($existingVaultName, $rgName, $upn)
	$vault = Get-AzureKeyVault -VaultName $existingVaultName -ResourceGroupName $rgName
	Assert-NotNull $vault
	Assert-AreEqual 0 $vault.AccessPolicies.Count
	Assert-AreEqual $false $vault.EnabledForDeployment

	# Set and Remove EnabledForDeployment, without any other permissions
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForDeployment -PassThru
	Assert-NotNull $vault
	Assert-AreEqual 0 $vault.AccessPolicies.Count
	Assert-AreEqual $true $vault.EnabledForDeployment

	$vault = Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForDeployment -PassThru
	Assert-NotNull $vault
	Assert-AreEqual 0 $vault.AccessPolicies.Count
	Assert-AreEqual $false $vault.EnabledForDeployment

	# Set and Remove EnabledForDeployment, with other permissions
	$PermToKeys = @("encrypt", "decrypt", "unwrapKey", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore")
	$PermToSecrets = @("get", "list", "set", "delete")
	$vault = Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForDeployment -UPN $upn -PermissionsToKeys $PermToKeys -PermissionsToSecrets $PermToSecrets -PassThru
	CheckVaultAccessPolicy $vault $PermToKeys $PermToSecrets	
	Assert-AreEqual $true $vault.EnabledForDeployment

	$vault = Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -EnabledForDeployment -ObjectId $vault.AccessPolicies[0].ObjectId -PassThru
	Assert-AreEqual 0 $vault.AccessPolicies.Count
	Assert-AreEqual $false $vault.EnabledForDeployment
}

function Test-ModifyAccessPolicyNegativeCases
{
	Param($existingVaultName, $rgName, $upn)

	# "all" plus other perms
	Assert-Throws { Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PermissionsToKeys get, all }
	Assert-Throws { Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PermissionsToSecrets get, all }

	# random string in perms
	Assert-Throws { Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn -PermissionsToSecrets blah, get }

	# invalid set of params
	Assert-Throws { Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName }
	Assert-Throws { Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName }
	Assert-Throws { Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName }
	Assert-Throws { Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName }
	Assert-Throws { Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UserPrincipalName $upn }
	Assert-Throws { Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -SPN $upn }
	Assert-Throws { Set-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -ObjectId $upn }
}

function Test-RemoveNonExistentAccessPolicyDoesNotThrow
{
	Param($existingVaultName, $rgName, $upn)		
	$vault = Remove-AzureKeyVaultAccessPolicy -VaultName $existingVaultName -ResourceGroupName $rgName -UPN $upn -PassThru
	Assert-AreEqual 0 $vault.AccessPolicies.Count
}

#-------------------------------------------------------------------------------------


#------------------------------Piping--------------------------

function Test-CreateDeleteVaultWithPiping
{
	Param($rgName, $location)
	$vaultName = Get-VaultName
	
	New-AzureKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $location | Get-AzureKeyVault | Remove-AzureKeyVault -Force -Confirm:$false

	Assert-Throws { Get-AzureKeyVault -VaultName $vaultName -ResourceGroupName $rgName }
}

#-------------------------------------------------------------------------------------

function CheckVaultAccessPolicy
{
	Param($vault, $expectedPermsToKeys, $expectedPermsToSecrets)
	Assert-NotNull $vault
	Assert-AreEqual 1 $vault.AccessPolicies.Count	
	
	$compare = Compare-Object $vault.AccessPolicies[0].PermissionsToKeys $expectedPermsToKeys
	Assert-Null $compare 
	$compare = Compare-Object $vault.AccessPolicies[0].PermissionsToSecrets $expectedPermsToSecrets
    Assert-Null $compare
}
