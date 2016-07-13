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

$resourceGroupName = "labRG1";
$resourceName = "pstestrsvault";
$defaultPolicyName = "DefaultPolicy";
# Create VM instead of taking these as parameters
$vmResourceGroupName = "arpittestresourcegroup";
$vmName = "arpittestencvm1";
$vmStorageAccountName = "mkheranirmrestore";
$vmStorageAccountResourceGroup = "mkheranirmrestore";
$vmUniqueName = "iaasvmcontainerv2;" + $vmResourceGroupName + ";" + $vmName;

function Test-GetContainerScenario
{
	# 1. Create / update and get vault
	$vaultLocation = get_available_location;
	$vault = New-AzureRmRecoveryServicesVault `
		-Name $resourceName -ResourceGroupName $resourceGroupName -Location $vaultLocation;
	
	# 2. Set vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	# 3. Get container
	$global:container = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType AzureVM `
		-Name $vmName `
		-ResourceGroupName $vmResourceGroupName `
		-Status Registered;

	# 4. If not already protected, enable protection
	if ($global:container -eq $null)
	{
		# 4.1 Get default policy
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name $defaultPolicyName;	
	
		Enable-AzureRmRecoveryServicesBackupProtection `
			-Policy $policy -Name $vmName -ResourceGroupName $vmResourceGroupName;

		$global:container = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Name $vmName `
			-ResourceGroupName $vmResourceGroupName `
			-Status Registered;
	}

	# VAR-1: Get All Containers with only mandatory parameters
	$containers = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType "AzureVM" -Status "Registered";
	
	$global:containerExists = $false;
	foreach ($container in $containers)
	{
		if ($container.Name -match $vmUniqueName)
		{
			$global:containerExists = $true;
		}
	}
	Assert-AreEqual $global:containerExists $true;

	# VAR-2: Get Containers with friendly name filter
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType "AzureVM" -Status "Registered" -Name $vmName;
	Assert-AreEqual $namedContainer.Name $vmUniqueName;

	# VAR-3: Get Containers with friendly name and resource group filters
	$rgFilteredContainer = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType "AzureVM" `
		-Status "Registered" `
		-Name $vmName `
		-ResourceGroupName $vmResourceGroupName;
	Assert-AreEqual $namedContainer.Name $vmUniqueName;

	# VAR-4: Get Containers with resource group filter
	$rgFilteredContainer = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType "AzureVM" -Status "Registered" -ResourceGroupName $vmResourceGroupName;
	Assert-AreEqual $namedContainer.Name $vmUniqueName;
}