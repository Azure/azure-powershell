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
    $resourceProvider = Get-AzureRmResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}
  
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

	$resourceGroup = Get-AzureRmResourceGroup -Name $name -ErrorAction Ignore
	
	if ($resourceGroup -eq $null)
	{
		New-AzureRmResourceGroup -Name $name -Location $location | Out-Null
	}

	return $name
}

function Cleanup-ResourceGroup(
	[string] $resourceGroupName)
{
	$resourceGroup = Get-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction Ignore

	if ($resourceGroup -ne $null)
	{
		# Cleanup Vaults
		$vaults = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName
		foreach ($vault in $vaults)
		{
			Remove-AzureRmRecoveryServicesVault -Vault $vault
		}
	
		# Cleanup RG. This cleans up all VMs and Storage Accounts.
		Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
	}
}

<#
.SYNOPSIS
Recovery Services Vault CRUD Tests
#>
function Test-RecoveryServicesVaultCRUD
{
	$location = Get-ResourceGroupLocation
	$resourceGroupName = Create-ResourceGroup $location
	$name = "PSTestRSV" + @(Get-RandomSuffix)

	try
	{
	  # 1. New-AzureRmRecoveryServicesVault
		$vault1 = New-AzureRmRecoveryServicesVault -Name $name -ResourceGroupName $resourceGroupName -Location $location

		Assert-NotNull($vault1.Name)
		Assert-NotNull($vault1.ID)
		Assert-NotNull($vault1.Type)

		# 2. Set-AzureRmRecoveryServicesVaultContext
		Set-AzureRmRecoveryServicesVaultContext -Vault $vault1

		# 3. Get-AzureRmRecoveryServicesVault
		$vaults = Get-AzureRmRecoveryServicesVault -Name $name -ResourceGroupName $resourceGroupName

		Assert-NotNull($vaults)
		Assert-True { $vaults.Count -gt 0 }
		foreach ($vault in $vaults)
		{
			Assert-NotNull($vault.Name)
			Assert-NotNull($vault.ID)
			Assert-NotNull($vault.Type)
		}

		# 4. Get-AzureRmRecoveryServicesBackupProperty
		$vaultBackupProperties = Get-AzureRmRecoveryServicesBackupProperty -Vault $vault1

		Assert-NotNull($vaultBackupProperties.BackupStorageRedundancy)

		# 5. Set-AzureRmRecoveryServicesBackupProperties
		Set-AzureRmRecoveryServicesBackupProperties -Vault $vault1 -BackupStorageRedundancy LocallyRedundant

		# 6. Remove-AzureRmRecoveryServicesVault
		Remove-AzureRmRecoveryServicesVault -Vault $vault1

		$vaults = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $name
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
  		# 1. New-AzureRmRecoveryServicesVault
		$vault = New-AzureRmRecoveryServicesVault -Name $name -ResourceGroupName $resourceGroupName -Location $location

		# 2. Get-AzureRmRecoveryServicesVaultSettingsFile
		$file = Get-AzureRmRecoveryServicesVaultSettingsFile -Vault $vault -Backup
		
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