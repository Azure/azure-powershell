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
 function Create-FileShare($sa)
{
	$suffix = $(Get-RandomSuffix 5)
	$fileshareName = "PSTestFileShare" + $suffix
	$fileshareName = $fileshareName.ToLower()
 	Assert-NotNull $sa
	$fileShare = Get-AzureStorageShare -Context $sa.Context -Name $fileshareName
 	if ($fileShare -eq $null)
	{
		New-AzureStorageShare -Name $fileshareName -Context $sa.Context
		New-AzureStorageDirectory -Context $sa.Context -ShareName $fileshareName -Path "myDirectory" -ErrorAction Ignore
		
		$sourceDir = "C:\Users\Public\"
		echo "This is a sample text file" > $sourceDir + $fileShareName + ".txt"
		$sourceFile = $sourceDir + $fileShareName + ".txt"
		
		Set-AzureStorageFileContent `
			-Context $sa.Context `
			-ShareName $fileshareName `
			-Source $sourceFile `
			-Path "myDirectory\SampleUpload.txt"
		
		$fileShare = Get-AzureStorageShare -Context $sa.Context -Name $fileshareName
	}
	return $fileShare
}
 function Delete-Vault($vault)
{
	$containers = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage
	foreach ($container in $containers)
	{
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureFiles
		foreach ($item in $items)
		{
			Disable-AzureRmRecoveryServicesBackupProtection `
				-VaultId $vault.ID `
				-Item $item `
				-RemoveRecoveryPoints -Force
		}
	}
 	Remove-AzureRmRecoveryServicesVault -Vault $vault
}
 function Enable-Protection(
	$vault, 
	$file,
	$saName)
{
	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureStorage `
		-FriendlyName $saName;
 	if ($container -eq $null)
	{
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "AFSBackupPolicy";
	
		Enable-AzureRmRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-Name $file.Name `
			-storageAccountName $saName | Out-Null
 		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureStorage `
			-FriendlyName $saName;
	}
	
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureFiles `
		-Name $file.Name
 	return $item
}