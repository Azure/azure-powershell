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

function Test-PolicyScenario
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "phaniktRSV" -Name "phaniktRs1";
	$containers = Get-AzureRmRecoveryServicesContainer -Vault $vault -ContainerType "AzureVM" -Status "Registered";
	foreach ($container in $containers)
	{
		echo $container.Name $container.ResourceGroupName;
	}
	Assert-AreEqual $containers[0].Name "mylinux1";

	$namedContainer = Get-AzureRmRecoveryServicesContainer -Vault $vault -ContainerType "AzureVM" -Status "Registered" -Name "mylinux1";
	Assert-AreEqual $namedContainer.Name "mylinux1";

	$rgFilteredContainer = Get-AzureRmRecoveryServicesContainer -Vault $vault -ContainerType "AzureVM" -Status "Registered" -Name "mylinux1" -ResourceGroupName "00prjai12";
	echo $rgFilteredContainer.Name $rgFilteredContainer.ResourceGroupName;
}