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
$ResourceName = "backuprn"
$ContainerName = "DPMDRSCALEINT1.DPMDOM02.SELFHOST.CORP.MICROSOFT.COM"
$ContainerType = "Windows"
$ContainerId = "223719"
$ContainerStatus = "Registered"

function Test-AzureBackupMarsContainerScenario
{
    $vault = Get-AzureRMBackupVault -ResourceGroupName $ResourceGroupName -Name $ResourceName
    
    $containers = Get-AzureRMBackupContainer -vault $vault -type $ContainerType
    Assert-AreEqual $containers[0].ContainerType $ContainerType;
    Assert-AreEqual $containers[0].Id $ContainerId;
    Assert-AreEqual $containers[0].Location $vault.Region;
    Assert-AreEqual $containers[0].Name $ContainerName;
    Assert-AreEqual $containers[0].ResourceGroupName $vault.ResourceGroupName;
    Assert-AreEqual $containers[0].ResourceName $vault.Name;
    Assert-AreEqual $containers[0].Status $ContainerStatus;

    $namedContainers = Get-AzureRMBackupContainer -vault $vault -type $ContainerType -name $ContainerName
    $container = $namedContainers[0];
    Assert-AreEqual $container.ContainerType $ContainerType;
    Assert-AreEqual $container.Id $ContainerId;
    Assert-AreEqual $container.Location $vault.Region;
    Assert-AreEqual $container.Name $ContainerName;
    Assert-AreEqual $container.ResourceGroupName $vault.ResourceGroupName;
    Assert-AreEqual $container.ResourceName $vault.Name;
    Assert-AreEqual $container.Status $ContainerStatus;	
    
    Enable-AzureRMBackupContainerReregistration -Container $container	
    
    Unregister-AzureRMBackupContainer -Container $container -Force

    $unregContainers = Get-AzureRMBackupContainer -vault $vault -type $ContainerType -name $ContainerName
    Assert-AreEqual $unregContainers.Count 0;
}

$IaasVMManagedResourceName = "hydrarecordvm"
$IaasVMManagedResourceGroupName = "hydrarecordvm"
$VaultResourceName = "backuprn"
$VaultResourceRGName = "backuprg"


function Test-RegisterAzureBackupContainer
{ 
    $vault = Get-AzureRMBackupVault -Name $VaultResourceName
    $jobId = Register-AzureRMBackupContainer -vault $vault -Name $IaasVMManagedResourceName -ServiceName $IaasVMManagedResourceGroupName 
     
    Assert-NotNull $jobId 'Job should not be null'; 
} 


function Test-UnregisterAzureBackupContainer 
{ 
    $vault = Get-AzureRMBackupVault -Name $VaultResourceName
    $container = Get-AzureRMBackupContainer -Name $IaasVMManagedResourceName -Type AzureVM -ManagedResourceGroupName $IaasVMManagedResourceGroupName -Vault $vault
    $jobId = Unregister-AzureRMBackupContainer -Container $container 
     
    Assert-NotNull $jobId 'Job should not be null'; 
}

$BMSContainerType = "AzureVM"
$BMSContainerUniqueName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"
$BMSContainerName = "hydrarecordvm"
$BMSContainerStatus = "Registered"

function Test-AzureBackupContainerScenario
{
    $vault = Get-AzureRMBackupVault -ResourceGroupName $ResourceGroupName -Name $ResourceName
    
    $containers = Get-AzureRMBackupContainer -vault $vault -type $BMSContainerType
    Assert-AreEqual $containers[0].ContainerType $BMSContainerType;
    Assert-AreEqual $containers[0].ContainerUniqueName $BMSContainerUniqueName;
    Assert-AreEqual $containers[0].Location $vault.Region;
    Assert-AreEqual $containers[0].Name $BMSContainerName;
    Assert-AreEqual $containers[0].ResourceGroupName $vault.ResourceGroupName;
    Assert-AreEqual $containers[0].ResourceName $vault.Name;
    Assert-AreEqual $containers[0].Status $BMSContainerStatus;

    $namedContainers = Get-AzureRMBackupContainer -vault $vault -type $BMSContainerType -name $BMSContainerName
    $container = $namedContainers[0];
    Assert-AreEqual $container.ContainerType $BMSContainerType;
    Assert-AreEqual $container.ContainerUniqueName $BMSContainerUniqueName;
    Assert-AreEqual $container.Location $vault.Region;
    Assert-AreEqual $container.Name $BMSContainerName;
    Assert-AreEqual $container.ResourceGroupName $vault.ResourceGroupName;
    Assert-AreEqual $container.ResourceName $vault.Name;
    Assert-AreEqual $container.Status $BMSContainerStatus;
}