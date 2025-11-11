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
Recovery Services Soft Deleted Vault Tests
#>
function Test-RecoveryServicesSoftDeletedVaultOperations
{
    $location = "westus"
    $resourceGroupName = "hiagawus-rg"
    $softDeletedVaultNamePattern = "hiagawus-rg_*"  # Pattern to match the vault name
    $expectedBackupItems = @("hiagaCRRRVM23", "hiagawusCRR-vm")
    $subscriptionId = "f879818f-5b29-4a43-8961-34169783144f" # use this subscription for this test
    $originalRSVname = "hiagawusCRR-vault"

    try
    {
        # 1. Get-AzRecoveryServicesSoftDeletedVault - Get all soft deleted vaults in location
        $softDeletedVaults = Get-AzRecoveryServicesSoftDeletedVault -Location $location
        
        Assert-NotNull($softDeletedVaults)
        Assert-True { $softDeletedVaults.Count -gt 0 }
        
        # Find the target soft deleted vault by resource group and name pattern
        $targetSoftDeletedVault = $softDeletedVaults | Where-Object { 
            $_.ResourceGroupName -eq $resourceGroupName -and $_.Name -like $softDeletedVaultNamePattern 
        }
        Assert-NotNull($targetSoftDeletedVault)
        Assert-AreEqual $resourceGroupName $targetSoftDeletedVault.ResourceGroupName
        Assert-AreEqual $location $targetSoftDeletedVault.Location
        Assert-NotNull($targetSoftDeletedVault.Properties)

        # Get the actual vault name for subsequent operations
        $vaultName = $targetSoftDeletedVault.Name
        Write-Host "Found soft-deleted vault: $vaultName"

        # 2. Get-AzRecoveryServicesSoftDeletedVault - Get specific soft deleted vault by name
        $specificSoftDeletedVault = Get-AzRecoveryServicesSoftDeletedVault -Location $location -Name $vaultName -ResourceGroupName $resourceGroupName
        
        Assert-NotNull($specificSoftDeletedVault)
        Assert-AreEqual $vaultName $specificSoftDeletedVault.Name
        Assert-AreEqual $resourceGroupName $specificSoftDeletedVault.ResourceGroupName

        # 3. Get-AzRecoveryServicesSoftDeletedVaultBackupItem - Using VaultId
        $backupItemsUsingVaultId = Get-AzRecoveryServicesSoftDeletedVaultBackupItem -VaultId $targetSoftDeletedVault.ID
        
        Assert-NotNull($backupItemsUsingVaultId)
        Assert-True { $backupItemsUsingVaultId.Count -ge 2 }
        
        # Verify expected backup items exist
        $foundBackupItems = @()
        foreach ($item in $backupItemsUsingVaultId)
        {
            foreach ($expectedItem in $expectedBackupItems)
            {
                if ($item.Name -like "*$expectedItem*" -or $item.SourceResourceId -like "*$expectedItem*")
                {
                    $foundBackupItems += $expectedItem
                    break
                }
            }
        }
        Assert-True { $foundBackupItems.Count -eq $expectedBackupItems.Count }

        # 4. Get-AzRecoveryServicesSoftDeletedVaultBackupItem - Using VaultName and ResourceGroupName
        $backupItemsUsingVaultName = Get-AzRecoveryServicesSoftDeletedVaultBackupItem -VaultName $vaultName -ResourceGroupName $resourceGroupName
        
        Assert-NotNull($backupItemsUsingVaultName)
        Assert-True { $backupItemsUsingVaultName.Count -ge 2 }
        Assert-AreEqual $backupItemsUsingVaultId.Count $backupItemsUsingVaultName.Count

        # 5. Undo-AzRecoveryServicesVaultDeletion - Restore the soft deleted vault
        $undeleteResult = Undo-AzRecoveryServicesVaultDeletion -ResourceGroupName $resourceGroupName -Name $vaultName -Location $location -Force
        
        Assert-NotNull($undeleteResult)

        # Wait a bit for the restoration to complete
        Start-Sleep -Seconds 30

        # 6. Get-AzRecoveryServicesVault - Verify vault is now active again
        $activeVault = Get-AzRecoveryServicesVault -Name $originalRSVname -ResourceGroupName $resourceGroupName
        
        Assert-NotNull($activeVault)
        Assert-AreEqual $originalRSVname $activeVault.Name
        Assert-AreEqual $resourceGroupName $activeVault.ResourceGroupName
        Assert-AreEqual $location $activeVault.Location
        Assert-NotNull($activeVault.ID)
        Assert-NotNull($activeVault.Type)

        # 7. Verify the vault is no longer in soft deleted state
        $softDeletedVaultsAfterRestore = Get-AzRecoveryServicesSoftDeletedVault -Location $location
        $softDeletedVaultAfterRestore = $softDeletedVaultsAfterRestore | Where-Object { $_.Properties.VaultId -match $originalRSVname }
        Assert-Null($softDeletedVaultAfterRestore)

        # 8. Remove-AzRecoveryServicesVault - Delete the vault again to maintain original test state
        Remove-AzRecoveryServicesVault -Vault $activeVault

        # Wait a bit for the deletion to complete
        Start-Sleep -Seconds 30

        # 9. Verify vault is back to soft deleted state (note: name may have changed due to new GUID)
        $softDeletedVaultsFinal = Get-AzRecoveryServicesSoftDeletedVault -Location $location
        $finalSoftDeletedVault = $softDeletedVaultsFinal | Where-Object { 
            $_.ResourceGroupName -eq $resourceGroupName -and $_.Name -like $softDeletedVaultNamePattern 
        }
        Assert-NotNull($finalSoftDeletedVault)
        Write-Host "Vault back in soft-deleted state with name: $($finalSoftDeletedVault.Name)"

        # 10. Verify active vault no longer exists (check by resource group and original pattern)
        $activeVaultsCheck = Get-AzRecoveryServicesVault -Name $originalRSVname -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
        Assert-Null($activeVaultCheck)
    }
    finally
    {
        # If test fails, attempt to clean up by ensuring vault is in soft deleted state                
        $activeVaultsCleanup = Get-AzRecoveryServicesVault -Name $originalRSVname -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
        if ($activeVaultCleanup -ne $null)
        {
            Remove-AzRecoveryServicesVault -Vault $activeVaultCleanup
        }        
    }
}
