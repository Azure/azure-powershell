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

$containerName = "psbvtsqlvm"
$resourceGroupName = "pstestwlRG1bca8"
$vaultName = "pstestwlRSV1bca8"
$resourceId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/pscloudtestrg/providers/Microsoft.Compute/virtualMachines/psbvtsqlvm"

function Test-AzureVmWorkloadUnDeleteContainer
{
	$subscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiagaVault2"
	$containerName = "sql-migration-vm2"

	try
	{   
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

		# get soft deleted container 
		$container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultId $vault.ID -BackupManagementType AzureWorkload -ContainerType AzureVMAppContainer | Where-Object { $_.Name -match $containerName}

		# verify isDeferredDelete - currently not supported

		# undelete 
		$undeletedContainer = Undo-AzRecoveryServicesBackupContainerDeletion -Container $container[0] -BackupManagementType AzureWorkload -WorkloadType MSSQL -VaultId $vault.ID -Force -Confirm:$false

		# verify isDeferredDelete false - currently not supported

		# Reregister  
		$reregisteredContainer = Register-AzRecoveryServicesBackupContainer -Container $container -BackupManagementType AzureWorkload -WorkloadType MSSQL -VaultId $vault.ID -Force
		
		Assert-True {$reregisteredContainer.Status -eq "Registered"}		
	}
	finally	
	{						
		# soft delete container
		Unregister-AzRecoveryServicesBackupContainer -Container $reregisteredContainer -VaultId $vault.ID -Force -Confirm:$false
		$container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultId $vault.ID -BackupManagementType AzureWorkload -ContainerType AzureVMAppContainer | Where-Object { $_.Name -match $containerName}

		Assert-True {$container.Status -eq "SoftDeleted"}
	}
}

function Get-AzureVmWorkloadContainer
{
   $resourceGroupName = "sqlcontainer-pstest-rg" #"pstestwlRG1bca8"
   $vaultName = "sqlcontainer-pstest-vault" # "pstestwlRSV1bca8"
   $containerName = "sql-pstest-vm"
   $resourceId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/sqlcontainer-pstest-rg/providers/Microsoft.Compute/virtualMachines/sql-pstest-vm"
   #$resourceId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/pstestwlRG1bca8/providers/Microsoft.Compute/virtualMachines/sql-pstest-vm"

   try
   {
      $vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

	  #Register container
      <# $container = Register-AzRecoveryServicesBackupContainer `
         -ResourceId $resourceId `
         -BackupManagementType AzureWorkload `
         -WorkloadType MSSQL `
         -VaultId $vault.ID `
		 -Force
	  Assert-AreEqual $container.Status "Registered" #>

      # VARIATION-1: Get All Containers with only mandatory parameters
      $containers = Get-AzRecoveryServicesBackupContainer `
         -VaultId $vault.ID `
         -ContainerType AzureVMAppContainer;
      Assert-True { $containers[0].FriendlyName -contains $containerName }

      # VARIATION-2: Get Containers with friendly name filter
      $containers = Get-AzRecoveryServicesBackupContainer `
         -VaultId $vault.ID `
         -ContainerType AzureVMAppContainer `
         -FriendlyName $containerName;
      Assert-True { $containers.FriendlyName -contains $containerName }

      # VARIATION-3: Get Containers with resource group filter
      $containers = Get-AzRecoveryServicesBackupContainer `
         -VaultId $vault.ID `
         -ContainerType AzureVMAppContainer `
         -ResourceGroupName $resourceGroupName;
      Assert-True { $containers[0].FriendlyName -contains $containerName }
   
      # VARIATION-4: Get Containers with friendly name and resource group filters
      $containers = Get-AzRecoveryServicesBackupContainer `
         -VaultId $vault.ID `
         -ContainerType AzureVMAppContainer `
         -FriendlyName $containerName `
         -ResourceGroupName $resourceGroupName;
      Assert-True { $containers.FriendlyName -contains $containerName }
   }
   finally
   {
	  #Unregister container
      <# Unregister-AzRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-Container $containers #>
   }
}

function Unregister-AzureWorkloadContainer
{
      $vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName

	  #Register container
      $container = Register-AzRecoveryServicesBackupContainer `
         -ResourceId $resourceId `
         -BackupManagementType AzureWorkload `
         -WorkloadType MSSQL `
         -VaultId $vault.ID `
		 -Force
	  Assert-AreEqual $container.Status "Registered"

	  #Unregister container
      Get-AzRecoveryServicesBackupContainer `
         -VaultId $vault.ID `
         -ContainerType AzureVMAppContainer `
         -FriendlyName $containerName | Unregister-AzRecoveryServicesBackupContainer -VaultId $vault.ID

	  $container = Get-AzRecoveryServicesBackupContainer `
         -VaultId $vault.ID `
         -ContainerType AzureVMAppContainer `
         -FriendlyName $containerName
      Assert-Null $container
}