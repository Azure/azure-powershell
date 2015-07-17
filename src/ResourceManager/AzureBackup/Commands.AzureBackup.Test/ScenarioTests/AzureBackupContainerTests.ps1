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

$ResourceGroupName = "backuprg"
$ResourceName = "backuprn1"
$ContainerName = "DPMDRSCALEINT1.DPMDOM02.SELFHOST.CORP.MICROSOFT.COM"
$ContainerType = "Windows"
$ContainerId = "10034"
$ContainerStatus = "Registered"

function Test-AzureBackupMarsContainerScenario
{
	$vault = Get-AzureBackupVault -ResourceGroupName $ResourceGroupName -Name $ResourceName
	
	$containers = Get-AzureBackupContainer -vault $vault -type $ContainerType
	Assert-AreEqual $containers[0].ContainerType $ContainerType;
	Assert-AreEqual $containers[0].Id $ContainerId;
	Assert-AreEqual $containers[0].Location $vault.Region;
	Assert-AreEqual $containers[0].Name $ContainerName;
	Assert-AreEqual $containers[0].ResourceGroupName $vault.ResourceGroupName;
	Assert-AreEqual $containers[0].ResourceName $vault.Name;
	Assert-AreEqual $containers[0].Status $ContainerStatus;

	$namedContainers = Get-AzureBackupContainer -vault $vault -type $ContainerType -name $ContainerName
	$container = $namedContainers[0];
	Assert-AreEqual $container.ContainerType $ContainerType;
	Assert-AreEqual $container.Id $ContainerId;
	Assert-AreEqual $container.Location $vault.Region;
	Assert-AreEqual $container.Name $ContainerName;
	Assert-AreEqual $container.ResourceGroupName $vault.ResourceGroupName;
	Assert-AreEqual $container.ResourceName $vault.Name;
	Assert-AreEqual $container.Status $ContainerStatus;
	
	#Enable-AzureBackupContainerReregistration -Container $container	
	
	Unregister-AzureBackupContainer -Container $container -Force

	$unregContainers = Get-AzureBackupContainer -vault $vault -type $ContainerType -name $ContainerName
	Assert-AreEqual $unregContainers.Count 0;
}
