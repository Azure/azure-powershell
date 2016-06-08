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
$ContainerName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"
$ContainerType = "IaasVMContainer"
$DataSourceType = "VM"
$DataSourceId = "17593283453810"
$Location = "southeastasia"
$PolicyName = "Policy9";
$PolicyId = "c87bbada-6e1b-4db2-b76c-9062d28959a4";
$POName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"
$ItemName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"
$RecoveryPointName = "587454680194"
$StorageAccountName = "portalvhds7jzk3jty85qx5"


function Test-RestoreAzureBackUpItem
{
    $azureBackUpRecoveryPoint = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureRMBackupRecoveryPoint
	$azureBackUpRecoveryPoint.ResourceGroupName = $ResourceGroupName
	$azureBackUpRecoveryPoint.ResourceName = $ResourceName
	$azureBackUpRecoveryPoint.Location = $Location
	$azureBackUpRecoveryPoint.ContainerUniqueName = $ContainerName
	$azureBackUpRecoveryPoint.ItemName = $ItemName
	$azureBackUpRecoveryPoint.RecoveryPointName = $RecoveryPointName
	$jobId = Restore-AzureRmBackupItem -RecoveryPoint $azureBackUpRecoveryPoint -StorageAccountName $StorageAccountName
}
