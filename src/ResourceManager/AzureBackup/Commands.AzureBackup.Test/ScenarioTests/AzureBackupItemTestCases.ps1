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
$DataSourceType = "IaasVM"
$DataSourceId = "17593283453810"
$Location = "SouthEast Asia"
$PolicyName = "ProtPolicy01";
$PolicyId = "/subscriptions/f5303a0b-fae4-4cdb-b44d-0e4c032dde26/resourceGroups/backuprg/providers/Microsoft.Backup/BackupVault/backuprn/protectionPolicies/DefaultPolicy";
$POName = "hydrarecordvm"
$itemName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"


function Test-GetAzureBackupItemTests
{
	$azureBackUpContainer = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureRMBackupContainer
	$azureBackUpContainer.ResourceGroupName = $ResourceGroupName
	$azureBackUpContainer.ResourceName = $ResourceName
	$azureBackUpContainer.Location = $Location
	$azureBackUpContainer.ContainerUniqueName = $ContainerName
	$azureBackUpContainer.ContainerType = $ContainerType
	$item = Get-AzureRMBackupItem -Container $azureBackUpContainer
	if (!($item -eq $null))
	{
		foreach($backupitem in $item)
		{   
			Assert-NotNull $backupitem.ProtectionStatus 'ProtectionStatus should not be null'    
			Assert-NotNull $backupitem.Name 'Name should not be null'            
			Assert-NotNull $backupitem.Type 'Type should not be null'            
			Assert-NotNull $backupitem.ContainerType 'ContainerType should not be null'      
			Assert-NotNull $backupitem.ContainerUniqueName 'ContainerUniqueName should not be null'
			Assert-NotNull $backupitem.ResourceGroupName 'ResourceGroupName should not be null'  
			Assert-NotNull $backupitem.ResourceName 'ResourceName should not be null'      
			Assert-NotNull $backupitem.Location 'Location should not be null' 
		}
	}
}

function Test-EnableAzureBackupProtection
{	
    $vault = Get-AzureRMBackupVault -Name $ResourceName
	$policyList = Get-AzureRMBackupProtectionPolicy -Vault $vault
	$policy = $policyList[0]

	$azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureRMBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ContainerType = $ContainerType
	$azureBackUpItem.Type = $DataSourceType
	$azureBackUpItem.Name = $POName
	$azureBackUpItem.ItemName = $itemName
	$jobId = Enable-AzureRMBackupProtection -Item $azureBackUpItem -Policy $policy 
	
}

function Test-DisableAzureBackupProtection
{	
	$azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureRMBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ContainerType = $ContainerType
	$azureBackUpItem.Type = $DataSourceType
	$azureBackUpItem.ItemName = $itemName
	$azureBackUpItem.Name = $POName
	$jobId1 = Disable-AzureRMBackupProtection -Item $azureBackUpItem
}
