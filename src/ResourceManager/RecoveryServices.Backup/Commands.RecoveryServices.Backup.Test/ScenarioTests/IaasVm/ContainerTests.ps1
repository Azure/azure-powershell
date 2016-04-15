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

function Test-GetContainerScenario
{
	# 1. Get the vault
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "PsTestRsVault";

	# 2. Set the vault context
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	# VAR-1: Get All Containers with only mandatory parameters
	$containers = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered";
	foreach ($container in $containers)
	{
		echo $container.Name $container.ResourceGroupName;
	}
	Assert-AreEqual $containers[2].FriendlyName "mkheranirmvm1";

	# VAR-2: Get Containers with friendly name filter
	$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -Name "mkheraniRMVM1";
	Assert-AreEqual $namedContainer.FriendlyName "mkheraniRMVM1";

	# VAR-3: Get Containers with friendly name and resource group filters
	$rgFilteredContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -Name "mkheraniRMVM1" -ResourceGroupName "RsvTestRG";
	Assert-AreEqual $namedContainer.FriendlyName "mkheraniRMVM1";

	# VAR-4: Get Containers with resource group filter
	$rgFilteredContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -ResourceGroupName "RsvTestRG";
	Assert-AreEqual $namedContainer.FriendlyName "mkheraniRMVM1";
}