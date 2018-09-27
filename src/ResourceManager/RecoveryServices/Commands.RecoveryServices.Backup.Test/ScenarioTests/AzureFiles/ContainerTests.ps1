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

#Setup Instructions:
#1. Create a resource group
#2. Create a storage account and a recovery services vault
#3. Create a file share in the storage account
#4. Fill the below global variables accordingly

$location = "westus"
$resourceGroupName = "sisi-RSV"
$vaultName = "sisi-RSV-29-6"
$fileShareName = "pstestfileshare"
$saName = "pstestsaa"

function Test-AzureFileContainer
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	$items = Enable-Protection $vault $fileShareName $saName
		
	# VARIATION-1: Get All Containers with only mandatory parameters
	$containers = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered;
	Assert-True { $containers.FriendlyName -contains $saName }

	# VARIATION-2: Get Containers with friendly name filter
	$containers = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered `
		-Name $saName;
	Assert-True { $containers.FriendlyName -contains $saName }

	# VARIATION-3: Get Containers with resource group filter
	$containers = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered `
		-ResourceGroupName $resourceGroupName;
	Assert-True { $containers.FriendlyName -contains $saName }
	
	# VARIATION-4: Get Containers with friendly name and resource group filters
	$containers = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered `
		-Name $saName `
		-ResourceGroupName $resourceGroupName;
	Assert-True { $containers.FriendlyName -contains $saName }
	
	# Disable Protection
	Disable-AzureRmRecoveryServicesBackupProtection `
		-VaultId $vault.ID `
		-Item $items `
		-RemoveRecoveryPoints `
		-Force;
	Unregister-AzureRmRecoveryServicesBackupContainer `
	-VaultId $vault.ID `
	-Container $containers
}

function Test-AzureFileUnregisterContainer
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
	$items = Enable-Protection $vault $fileShareName $saName

	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered `
		-FriendlyName $saName

	Unregister-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-Container $container

	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-Status Registered `
		-FriendlyName $saName
	Assert-Null $container	
}