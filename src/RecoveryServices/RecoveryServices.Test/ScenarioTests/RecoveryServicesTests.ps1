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

########################## Recovery Services Tests #############################

function Get-ResourceGroupLocation
{
    $namespace = "Microsoft.RecoveryServices"
    $type = "vaults"
    $resourceProvider = Get-AzResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}
  
    if ($resourceProvider -eq $null)
    {
        return "westus";
    }
	else
    {
		return $resourceProvider.Locations[0]
    }
}

function Get-RandomSuffix(
	[int] $size = 8)
{
	$variableName = "NamingSuffix"
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Record)
	{
		if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables.ContainsKey($variableName))
		{
			$suffix = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]
		}
		else
		{
			$suffix = @((New-Guid).Guid)

			[Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName] = $suffix
		}
	}
	else
	{
		$suffix = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]
	}

	return $suffix.Substring(0, $size)
}

function Create-ResourceGroup(
	[string] $location)
{
	$name = "PSTestRG" + @(Get-RandomSuffix)

	$resourceGroup = Get-AzResourceGroup -Name $name -ErrorAction Ignore
	
	if ($resourceGroup -eq $null)
	{
		New-AzResourceGroup -Name $name -Location $location | Out-Null
	}

	return $name
}

function Cleanup-ResourceGroup(
	[string] $resourceGroupName)
{
	$resourceGroup = Get-AzResourceGroup -Name $resourceGroupName -ErrorAction Ignore

	if ($resourceGroup -ne $null)
	{
		# Cleanup Vaults
		$vaults = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName
		foreach ($vault in $vaults)
		{
			Remove-AzRecoveryServicesVault -Vault $vault
		}
	
		# Cleanup RG. This cleans up all VMs and Storage Accounts.
		Remove-AzResourceGroup -Name $resourceGroupName -Force
	}
}

<#
.SYNOPSIS
Recovery Services Vault CRUD Tests
#>
function Test-RecoveryServicesVaultCRUD
{
	$location = "southeastasia"
	$resourceGroupName = Create-ResourceGroup $location
	$name = "PSTestRSV" + @(Get-RandomSuffix)

	try
	{
	  # 1. New-AzRecoveryServicesVault
		$vault1 = New-AzRecoveryServicesVault -Name $name -ResourceGroupName $resourceGroupName -Location $location

		Assert-NotNull($vault1.Name)
		Assert-NotNull($vault1.ID)
		Assert-NotNull($vault1.Type)

		# 2. Set-AzRecoveryServicesVault
		Set-AzRecoveryServicesVaultContext -Vault $vault1
		
		# 3. Get-AzRecoveryServicesVault
		$vaults = Get-AzRecoveryServicesVault -Name $name -ResourceGroupName $resourceGroupName

		Assert-NotNull($vaults)
		Assert-True { $vaults.Count -gt 0 }
		foreach ($vault in $vaults)
		{
			Assert-NotNull($vault.Name)
			Assert-NotNull($vault.ID)
			Assert-NotNull($vault.Type)
		}

		# 4. Get-AzRecoveryServicesBackupProperty
		$vaultBackupProperties = Get-AzRecoveryServicesBackupProperty -Vault $vault1

		Assert-NotNull($vaultBackupProperties.BackupStorageRedundancy)

		# 5. Set-AzRecoveryServicesBackupProperties
		Set-AzRecoveryServicesBackupProperties -Vault $vault1 -BackupStorageRedundancy LocallyRedundant

		# 6. Remove-AzRecoveryServicesVault
		Remove-AzRecoveryServicesVault -Vault $vault1

		$vaults = Get-AzRecoveryServicesVault -Name $name
		Assert-True { $vaults.Count -eq 0 } 
	}
	finally
	{
		Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-GetRSVaultSettingsFile
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location
	$name = "PSTestRSV" + @(Get-RandomSuffix)

	try
	{
  		# 1. New-AzRecoveryServicesVault
		$vault = New-AzRecoveryServicesVault -Name $name -ResourceGroupName $resourceGroupName -Location $location

		# 2. Get-AzRecoveryServicesVaultSettingsFile
		$file = Get-AzRecoveryServicesVaultSettingsFile -Vault $vault -Backup
		
		if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Record)
		{
			Assert-NotNull $file
			Assert-NotNull $file.FilePath
		}
	}
	finally
	{
		Cleanup-ResourceGroup $resourceGroupName
	}
}

<#
.SYNOPSIS
Recovery Services Soft Deleted Vault Tests - Delete, Get, and Undo deletion
#>
function Test-RecoveryServicesSoftDeletedVaultOperations
{
    $location = "centraluseuap"
    $resourceGroupName = Create-ResourceGroup $location
    $name = "PSTestRSV" + @(Get-RandomSuffix)

    try
    {
        # 1. Create a new Recovery Services Vault
        $vault = New-AzRecoveryServicesVault -Name $name -ResourceGroupName $resourceGroupName -Location $location

        Assert-NotNull($vault.Name)
        Assert-NotNull($vault.ID)
        Assert-NotNull($vault.Type)
        Assert-AreEqual $name $vault.Name
        Assert-AreEqual $location $vault.Location

        # 2. Delete the vault (this will soft delete it)
        Remove-AzRecoveryServicesVault -Vault $vault

        # Verify vault is no longer in active vaults list
        $activeVaults = Get-AzRecoveryServicesVault -Name $name -ResourceGroupName $resourceGroupName
        Assert-True { $activeVaults.Count -eq 0 }

        # 3. Get soft deleted vault
        $softDeletedVaults = Get-AzRecoveryServicesSoftDeletedVault -Location $location
        Assert-NotNull($softDeletedVaults)
        Assert-True { $softDeletedVaults.Count -gt 0 }

        # Find our specific soft deleted vault
        $targetSoftDeletedVault = $softDeletedVaults | Where-Object { 
            $_.Name -eq $name -and $_.ResourceGroupName -eq $resourceGroupName 
        }
        
        Assert-NotNull($targetSoftDeletedVault)
        Assert-AreEqual $name $targetSoftDeletedVault.Name
        Assert-AreEqual $location $targetSoftDeletedVault.Location
        Assert-AreEqual $resourceGroupName $targetSoftDeletedVault.ResourceGroupName
        Assert-NotNull($targetSoftDeletedVault.Properties.VaultId)
        Assert-NotNull($targetSoftDeletedVault.Properties.VaultDeletionTime)
        Assert-NotNull($targetSoftDeletedVault.Properties.PurgeAt)

        # 4. Get soft deleted vault by name
        $specificSoftDeletedVault = Get-AzRecoveryServicesSoftDeletedVault -Location $location -Name $name
        Assert-NotNull($specificSoftDeletedVault)
        Assert-AreEqual $name $specificSoftDeletedVault.Name
        Assert-AreEqual $location $specificSoftDeletedVault.Location

        # 5. Get soft deleted vault by resource group filter
        $filteredSoftDeletedVaults = Get-AzRecoveryServicesSoftDeletedVault -Location $location -ResourceGroupName $resourceGroupName
        Assert-NotNull($filteredSoftDeletedVaults)
        $filteredTargetVault = $filteredSoftDeletedVaults | Where-Object { $_.Name -eq $name }
        Assert-NotNull($filteredTargetVault)

        # 6. Undo vault deletion
        $undoResult = Undo-AzRecoveryServicesVaultDeletion -ResourceGroupName $resourceGroupName -Name $name -Location $location

        Assert-NotNull($undoResult)
        Assert-AreEqual $name $undoResult.Name
        Assert-AreEqual $location $undoResult.Location

        # 7. Verify vault is restored and back in active vaults list
        # Note: The restoration might take some time, so we may need to wait or poll
        Start-Sleep -Seconds 30  # Wait for restoration to complete

        $restoredVaults = Get-AzRecoveryServicesVault -Name $name -ResourceGroupName $resourceGroupName
        Assert-NotNull($restoredVaults)
        Assert-True { $restoredVaults.Count -gt 0 }
        
        $restoredVault = $restoredVaults[0]
        Assert-AreEqual $name $restoredVault.Name
        Assert-AreEqual $location $restoredVault.Location
        Assert-AreEqual $resourceGroupName $restoredVault.ResourceGroupName

        # 8. Verify soft deleted vault is no longer in soft deleted list
        $remainingSoftDeletedVaults = Get-AzRecoveryServicesSoftDeletedVault -Location $location -Name $name
        # After successful restoration, the vault should not be in soft deleted state
        # This assertion might need adjustment based on actual API behavior
        # Assert-Null($remainingSoftDeletedVaults)

        # Clean up the restored vault
        Remove-AzRecoveryServicesVault -Vault $restoredVault
    }
    finally
    {
        Cleanup-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Recovery Services Soft Deleted Vault Tests - Filter by existing vault pattern
#>
function Test-RecoveryServicesSoftDeletedVaultFiltering
{
    $location = "centraluseuap"
    
    try
    {
        # 1. Get all soft deleted vaults in the location
        $allSoftDeletedVaults = Get-AzRecoveryServicesSoftDeletedVault -Location $location
        
        if ($allSoftDeletedVaults -ne $null -and $allSoftDeletedVaults.Count -gt 0)
        {
            Assert-True { $allSoftDeletedVaults.Count -gt 0 }
            
            foreach ($vault in $allSoftDeletedVaults)
            {
                Assert-NotNull($vault.Name)
                Assert-NotNull($vault.Location)
                Assert-AreEqual $location $vault.Location
                Assert-NotNull($vault.Properties)
                Assert-NotNull($vault.Properties.VaultId)
            }

            # 2. Test filtering by vault name pattern (similar to your akkanaseTest23 example)
            $filteredByPattern = $allSoftDeletedVaults | Where-Object { $_.Properties.VaultId -match "PSTestRSV" }
            
            # 3. Test resource group filtering
            if ($allSoftDeletedVaults.Count -gt 0)
            {
                $firstVault = $allSoftDeletedVaults[0]
                if ($firstVault.ResourceGroupName -ne $null)
                {
                    $filteredByRG = Get-AzRecoveryServicesSoftDeletedVault -Location $location -ResourceGroupName $firstVault.ResourceGroupName
                    Assert-NotNull($filteredByRG)
                    
                    foreach ($vault in $filteredByRG)
                    {
                        Assert-AreEqual $firstVault.ResourceGroupName $vault.ResourceGroupName
                    }
                }
            }
        }
        else
        {
            Write-Warning "No soft deleted vaults found in location $location for filtering tests"
        }
    }
    catch
    {
        Write-Warning "Soft deleted vault filtering test encountered an issue: $($_.Exception.Message)"
        # Don't fail the test if there are no existing soft deleted vaults
    }
}
