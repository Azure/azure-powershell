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
 function Get-ResourceGroupLocation
{
	$location = Get-Location "Microsoft.RecoveryServices" "vaults" "West US";
	$outputLocation = $location.ToLower()
	$outputLocation = $outputLocation -replace '\s', ''
	$outputLocation = $outputLocation -replace '-', ''
	$outputLocation = $outputLocation -replace '_', ''
	return $outputLocation;
}
 function Get-RandomSuffix(
	[int] $size = 8)
{
	$variableName = "NamingSuffix"
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Record)
	{
		if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables.ContainsKey($variableName))
		{
			$suffix = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]
		}
		else
		{
			$suffix = @((New-Guid).Guid)
 			[Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName] = $suffix
		}
	}
	else
	{
		$suffix = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]
	}
 	return $suffix.Substring(0, $size)
}
 function Create-ResourceGroup(
	[string] $location,
	[int] $nick = -1)
{
	$name = "PSTestRG" + @(Get-RandomSuffix)
	if($nick -gt -1)
	{
		$name += $nick
	}
 	$resourceGroup = Get-AzureRmResourceGroup -Name $name -ErrorAction Ignore
	
	if ($resourceGroup -eq $null)
	{
		New-AzureRmResourceGroup -Name $name -Location $location | Out-Null
	}
 	return $name
}
 function Create-RecoveryServicesVault(
	[string] $resourceGroupName, 
	[string] $location)
{
	$name = "PSTestRSV" + @(Get-RandomSuffix)
 	$vault = Get-AzureRmRecoveryServicesVault `
		-ResourceGroupName $resourceGroupName `
		-Name $name -ErrorAction Ignore
 	if ($vault -eq $null)
	{
		$vault = New-AzureRmRecoveryServicesVault `
			-Name $name `
			-ResourceGroupName $resourceGroupName `
			-Location $location;
	}
 	return $vault
}
 function Cleanup-ResourceGroup(
	[string] $resourceGroupName)
{
	$resourceGroup = Get-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction Ignore
 	if ($resourceGroup -ne $null)
	{
		# Cleanup Vaults
		$vaults = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName
		foreach ($vault in $vaults)
		{
			Delete-Vault $vault
		}
	
		# Cleanup RG. This cleans up all VMs and Storage Accounts.
		Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
	}
}
 function Create-SA(
	[string] $resourceGroupName, 
	[string] $location)
{
	$name = "PSTestSA" + @(Get-RandomSuffix)
	$name = $name.ToLower()
 	$sa = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $name -ErrorAction Ignore
 	if ($sa -eq $null)
	{
		$job = New-AzureRmStorageAccount `
			-ResourceGroupName $resourceGroupName `
			-Name $name `
			-Location $location `
			-Type "Standard_LRS"
		$job | Wait-Job
		$sa = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $name
	}
 	return $name
}
 function Backup-Item(
	$vault,
	$item)
{
	return Backup-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Item $item | Wait-AzureRmRecoveryServicesBackupJob -VaultId $vault.ID
}
 function Get-RecoveryPoint(
	$vault,
	$item,
	$backupJob)
{
	$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
	$backupEndTime = $backupJob.EndTime.AddMinutes(1);
 	$rps = Get-AzureRmRecoveryServicesBackupRecoveryPoint `
		-VaultId $vault.ID `
		-Item $item `
		-StartDate $backupStartTime `
		-EndDate $backupEndTime
	
	return $rps[0]
}
 function Get-QueryDateInUtc(
	$date, 
	[string] $variableName)
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Record)
	{
		$queryDate = $date.ToUniversalTime()
		$queryDateString = $queryDate.ToString("u")
		
		[Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName] = $queryDateString
	}
	else
	{
		$queryDateString = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]
 		$queryDate = (Get-Date $queryDateString).ToUniversalTime()
	}
 	return $queryDate
}
 function Get-QueryDateLocal(
	$date, 
	[string] $variableName)
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Record)
	{
		$queryDate = $date
		
		[Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName] = $date
	}
	else
	{
		$queryDateString = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]
 		$queryDate = Get-Date $queryDateString
	}
 	return $queryDate
}