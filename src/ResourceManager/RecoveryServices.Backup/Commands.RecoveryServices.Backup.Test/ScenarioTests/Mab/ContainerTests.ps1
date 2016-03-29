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
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "phaniktRSV" -Name "phaniktRs1";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	$containers = Get-AzureRmRecoveryServicesContainer -ContainerType "AzureVM" -Status "Registered";
	foreach ($container in $containers)
	{
		echo $container.Name $container.ResourceGroupName;
	}
	Assert-AreEqual $containers[0].FriendlyName "mylinux1";

	$namedContainer = Get-AzureRmRecoveryServicesContainer -ContainerType "AzureVM" -Status "Registered" -Name "mylinux1";
	Assert-AreEqual $namedContainer.FriendlyName "mylinux1";

	$rgFilteredContainer = Get-AzureRmRecoveryServicesContainer -ContainerType "AzureVM" -Status "Registered" -Name "mylinux1" -ResourceGroupName "00prjai12";
	echo $rgFilteredContainer.Name $rgFilteredContainer.ResourceGroupName;
}

function Test-UnregisterContainerScenario
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "phaniktRSV" -Name "phaniktRs1";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;
	
	$container = Get-AzureRmRecoveryServicesContainer -ContainerType "MAB" -Status "Registered" -Name "swatimab";
	Assert-AreEqual $container.FriendlyName "swatimab";

	Unregister-AzureRmRecoveryServicesBackupContainer -Container $container;
	$contianer = Get-AzureRmRecoveryServicesContainer -ContainerType "MAB" -Status "Registered" -Name "swatimab";
	Assert-Null $container;
}