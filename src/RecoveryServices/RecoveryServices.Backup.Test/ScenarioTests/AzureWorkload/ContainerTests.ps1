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

$containerName = "pstestwlvm1bca8"
$resourceGroupName = "pstestwlRG1bca8"
$vaultName = "pstestwlRSV1bca8"
$resourceId = "/subscriptions/da364f0f-307b-41c9-9d47-b7413ec45535/resourceGroups/pstestwlRG1bca8/providers/Microsoft.Compute/virtualMachines/pstestwlvm1bca8"

function Get-AzureVmWorkloadContainer
{
   try
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

      # VARIATION-1: Get All Containers with only mandatory parameters
      $containers = Get-AzRecoveryServicesBackupContainer `
         -VaultId $vault.ID `
         -ContainerType AzureVMAppContainer `
         -Status Registered;
      Assert-True { $containers.FriendlyName -contains $containerName }

      # VARIATION-2: Get Containers with friendly name filter
      $containers = Get-AzRecoveryServicesBackupContainer `
         -VaultId $vault.ID `
         -ContainerType AzureVMAppContainer `
         -Status Registered `
         -FriendlyName $containerName;
      Assert-True { $containers.FriendlyName -contains $containerName }

      # VARIATION-3: Get Containers with resource group filter
      $containers = Get-AzRecoveryServicesBackupContainer `
         -VaultId $vault.ID `
         -ContainerType AzureVMAppContainer `
         -Status Registered `
         -ResourceGroupName $resourceGroupName;
      Assert-True { $containers.FriendlyName -contains $containerName }
   
      # VARIATION-4: Get Containers with friendly name and resource group filters
      $containers = Get-AzRecoveryServicesBackupContainer `
         -VaultId $vault.ID `
         -ContainerType AzureVMAppContainer `
         -Status Registered `
         -FriendlyName $containerName `
         -ResourceGroupName $resourceGroupName;
      Assert-True { $containers.FriendlyName -contains $containerName }
   }
   finally
   {
	  #Unregister container
      Unregister-AzRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-Container $containers
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
         -Status Registered `
         -FriendlyName $containerName | Unregister-AzRecoveryServicesBackupContainer -VaultId $vault.ID

	  $container = Get-AzRecoveryServicesBackupContainer `
         -VaultId $vault.ID `
         -ContainerType AzureVMAppContainer `
         -Status Registered `
         -FriendlyName $containerName
      Assert-Null $container
}