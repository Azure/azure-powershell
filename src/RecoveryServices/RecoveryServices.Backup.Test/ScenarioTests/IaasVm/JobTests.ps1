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

function Test-AzureVMGetJobs
{
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiaga-adhoc-vault"
	$vmName1 = "VM;iaasvmcontainerv2;hiagarg;pstest-ccy-vm"
	$vmName2 = "VM;iaasvmcontainerv2;hiagarg;pstest-ccy-vm2"
	$vmFriendlyName1 = "pstest-ccy-vm"
	$vmFriendlyName2 = "pstest-ccy-vm2"
	
	try
	{
		# Setup
		$vm1 = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmFriendlyName1
		$vm2 = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmFriendlyName2
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName 

		# Disable soft Delete
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"

		# Disable Protection 
		$item = Get-AzRecoveryServicesBackupItem -VaultId $vault.ID -BackupManagementType AzureVM -WorkloadType AzureVM
		$job = Disable-AzRecoveryServicesBackupProtection -VaultId $vault.ID -Item $item[0] -RemoveRecoveryPoints -Force;
		$job2 = Disable-AzRecoveryServicesBackupProtection -VaultId $vault.ID -Item $item[1] -RemoveRecoveryPoints -Force;

		$item = Get-AzRecoveryServicesBackupItem -VaultId $vault.ID -BackupManagementType AzureVM -WorkloadType AzureVM

		# undelete backup item
		# $undeleteJob = Undo-AzRecoveryServicesBackupItemDeletion -Item $item[0] -VaultId $vault.ID
		# $undeleteJob2 = Undo-AzRecoveryServicesBackupItemDeletion -Item $item[1] -VaultId $vault.ID

		# Enable Protection
		Enable-Protection $vault $vm1
		
		# Test 1: Triggering a new job increases job count

		$startDate1 = Get-QueryDateInUtc $((Get-Date).AddDays(-1)) "StartDate1"
		$endDate1 = Get-QueryDateInUtc $(Get-Date) "EndDate1"

		$jobs = Get-AzRecoveryServicesBackupJob -VaultId $vault.ID -From $startDate1 -To $endDate1
		$jobCount1 = $jobs.Count
						
		Enable-Protection $vault $vm2
				
		$endDate2 = Get-QueryDateInUtc $(Get-Date) "EndDate2"

		$jobs = Get-AzRecoveryServicesBackupJob -VaultId $vault.ID -From $startDate1 -To $endDate2
		$jobCount2 = $jobs.Count

		Assert-True { $jobCount1 -lt $jobCount2 }

		# Test 2: Job details
		foreach ($job in $jobs)
		{
			$jobDetails = Get-AzRecoveryServicesBackupJobDetail -VaultId $vault.ID -Job $job;
			$jobDetails2 = Get-AzRecoveryServicesBackupJobDetail `
				-VaultId $vault.ID `
				-JobId $job.JobId

			Assert-AreEqual $jobDetails.JobId $job.JobId
			Assert-AreEqual $jobDetails2.JobId $job.JobId
		}

		# Test 3: Job Status filter
		$jobs = Get-AzRecoveryServicesBackupJob `
			-VaultId $vault.ID `
			-From $startDate1 `
			-To $endDate2 `
			-Status Completed
		Assert-True { $jobs.Count -gt 0}

		# Test 4: Job Operation filter
		$jobs = Get-AzRecoveryServicesBackupJob `
			-VaultId $vault.ID `
			-From $startDate1 `
			-To $endDate2 `
			-Operation ConfigureBackup
		Assert-True { $jobs.Count -gt 0}

		# Test 5: Job BackupManagementType filter
		$jobs = Get-AzRecoveryServicesBackupJob `
			-VaultId $vault.ID `
			-From $startDate1 `
			-To $endDate2 `
			-BackupManagementType AzureVM
		Assert-True { $jobs.Count -gt 0} 
	}
	finally
	{
		# Cleanup
		# Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMGetJobsTimeFilter
{
	# $location = "southeastasia"
	# $resourceGroupName = Create-ResourceGroup -Location $location
	
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiaga-adhoc-vault"
	$vmName1 = "VM;iaasvmcontainerv2;hiagarg;hiaga-adhoc-vm"
	$vmName2 = "VM;iaasvmcontainerv2;hiagarg;hiaganewvm3"	
	$vmFriendlyName1 = "hiaga-adhoc-vm"
	$vmFriendlyName2 = "hiaganewvm3"
	$protectionState = "IRPending"

	try
	{
		# Setup
		$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmFriendlyName1
		$vm2 = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmFriendlyName2
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName 

		# $vm1 = Create-VM $resourceGroupName $location 1
		# $vm2 = Create-VM $resourceGroupName $location 2
		# $vault = Create-RecoveryServicesVault $resourceGroupName $location

		# Disable soft Delete
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"

		# Enable-Protection $vault $vm1
		# Enable-Protection $vault $vm2

		# Generic time filter test

		$startTime1 = Get-QueryDateInUtc $((Get-Date).AddDays(-1)) "StartTime1"
		$endTime1 = Get-QueryDateInUtc $(Get-Date) "EndTime1"

		$filteredJobs = Get-AzRecoveryServicesBackupJob `
			-VaultId $vault.ID `
			-From $startTime1 `
			-To $endTime1

		# Adding a second here and there to make sure comparison works fine
		$startTime1.AddSeconds(-1);
		$endTime1.AddSeconds(1);

		foreach ($job in $filteredJobs)
		{
			Assert-AreEqual $job.StartTime.ToUniversalTime().CompareTo($startTime1) 1
			Assert-AreEqual $endTime1.CompareTo($job.StartTime.ToUniversalTime()) 1
		}

		# Negative test cases

		# 1. rangeEnd <= rangeStart
		Assert-ThrowsContains { Get-AzRecoveryServicesBackupJob `
			-VaultId $vault.ID `
			-From $endTime1 `
			-To $startTime1; } `
			"To filter should not be less than From filter";
		
		# 2. rangeStart.Kind != DateTimeKind.Utc
		$startTime2 = Get-QueryDateLocal $((Get-Date).AddDays(-20)) "StartTime2"
		$endTime2 = $endTime1
		Assert-ThrowsContains { Get-AzRecoveryServicesBackupJob `
			-VaultId $vault.ID `
			-From $startTime2 `
			-To $endTime2 } `
			"Please specify From and To filter values in UTC. Other timezones are not supported";

		# 3. rangeStart > DateTime.UtcNow
		$startTime4 = Get-QueryDateInUtc $((Get-Date).AddYears(100).AddDays(-1)) "StartTime4"
		$endTime4 = Get-QueryDateInUtc $((Get-Date).AddYears(100)) "EndTime4"
		Assert-ThrowsContains { Get-AzRecoveryServicesBackupJob `
			-VaultId $vault.ID `
			-From $startTime4 `
			-To $endTime4 } `
			"From date should be less than current UTC time";
	}
	finally
	{
		# Cleanup
		# Cleanup-ResourceGroup $resourceGroupName
	}
}

function Test-AzureVMWaitJob
{	
	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiaga-adhoc-vault"
	$vmName1 = "VM;iaasvmcontainerv2;hiagarg;pstest-ccy-vm"
	$vmName2 = "VM;iaasvmcontainerv2;hiagarg;pstest-ccy-vm2"	
	$vmFriendlyName1 = "pstest-ccy-vm"
	$vmFriendlyName2 = "pstest-ccy-vm2"

	try
	{
		# Setup
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName
		
		# Disable soft Delete
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"		
		
		$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID		
		
		# Trigger backup and wait for completion
		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item[0] 

		Assert-True { $backupJob.Status -eq "InProgress" }

		$backupJob = Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID -Job $backupJob

		Assert-True { $backupJob.Status -eq "Completed" }
	}
	finally
	{
		# no Cleanup		
	}
}

function Test-AzureVMCancelJob
{
	# $location = "southeastasia"
	# $resourceGroupName = Create-ResourceGroup -Location $location

	$location = "centraluseuap"
	$resourceGroupName = "hiagarg"
	$vaultName = "hiaga-adhoc-vault"
	$vmName1 = "VM;iaasvmcontainerv2;hiagarg;pstest-ccy-vm"
	$vmFriendlyName1 = "pstest-ccy-vm"

	try
	{
		# Setup
		$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmFriendlyName1
		$vault = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName -Name $vaultName 

		# $vm2 = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmFriendlyName2
		# $vm = Create-VM $resourceGroupName $location
		# $vault = Create-RecoveryServicesVault $resourceGroupName $location

		# Disable soft Delete
		Set-AzRecoveryServicesVaultProperty -VaultId $vault.ID -SoftDeleteFeatureState "Disable"

		$item = Get-AzRecoveryServicesBackupItem -VaultId $vault.ID -BackupManagementType "AzureVM" -WorkloadType "AzureVM" # Enable-Protection $vault $vm
		
		$backupJob = Backup-AzRecoveryServicesBackupItem -VaultId $vault.ID -Item $item[0]

		Assert-True { $backupJob.Status -eq "InProgress" }

		$cancelledJob = Stop-AzRecoveryServicesBackupJob -VaultId $vault.ID -Job $backupJob

		Assert-True { $cancelledJob.Status -ne "InProgress" }
	}
	finally
	{
		# Cleanup
		# Cleanup-ResourceGroup $resourceGroupName
	}
}

# =====================================================================================================
# Cross Subscription Backup (CSB) job scenario test. See the CSB header comment in
# ScenarioTests/IaasVm/ItemTests.ps1 for the full list of values to update when re-recording against your
# own resources (the VM must live in a subscription different from the vault's, in the same region).
# =====================================================================================================
function Test-AzureVMCSBJobSubscription
{
	# Verifies that the detailed job for a Cross Subscription Backup (CSB) protected item
	# exposes ContainerSubscriptionId, populated from extendedInfo.propertyBag["VM Subscription ID"].
	# This test is self-contained: it creates a fresh vault (in an existing resource group), protects a
	# cross-subscription VM, triggers an on-demand backup, inspects the resulting backup job's detail, and
	# deletes the vault in the finally block so it is re-runnable. The cross-subscription VM is pre-existing.
	$resourceGroupName = "singhprab-csb-vault-rg-ea"
	$vaultName = "singhprab-csb-job-vault"
	$location = "eastasia"
	# The VM (container) resides in a subscription different from the vault's subscription.
	$vmName = "singhprab-ps-vm9"
	$vmResourceGroupName = "singhprab-rg-1c"
	$containerSubscriptionId = "80abcfe3-b410-42b2-983f-df23cba781dc"
	$tag = @{"MABUsed"="Yes";"Owner"="singhprab";"Purpose"="Testing";"DeleteBy"="12-2099"}

	# Keep a handle to the vault for cleanup in the finally block so the test is re-runnable.
	$vault = $null

	try
	{
		# Create a fresh vault so the test runs against a clean vault (no soft-deleted leftovers).
		New-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName -Location $location -Tag $tag | Out-Null
		$vault = Get-AzRecoveryServicesVault -Name $vaultName -ResourceGroupName $resourceGroupName

		# Use the built-in Enhanced (V2) policy. Standard VMs can be protected with enhanced policies.
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy -VaultId $vault.ID -Name "EnhancedPolicy"

		# Enable protection for the cross-subscription VM using the new -ContainerSubscriptionId parameter.
		Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-Name $vmName `
			-ResourceGroupName $vmResourceGroupName `
			-ContainerSubscriptionId $containerSubscriptionId;

		$item = Get-AzRecoveryServicesBackupItem `
			-BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID `
			| Where-Object { $_.Name -match $vmName }

		Assert-NotNull $item;

		# The backup item for the CSB VM exposes ContainerSubscriptionId (parsed from SourceResourceId).
		$expectedContainerSubscriptionId = $item.ContainerSubscriptionId
		Assert-True { $expectedContainerSubscriptionId -eq $containerSubscriptionId };

		# Trigger an on-demand backup so there is a Backup job to inspect.
		$backupJob = Backup-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Item $item | Wait-AzRecoveryServicesBackupJob -VaultId $vault.ID

		Assert-True { $backupJob.Status -eq "Completed" };

		# The detailed job must expose ContainerSubscriptionId equal to the VM's subscription,
		# populated from extendedInfo.propertyBag["VM Subscription ID"].
		$jobDetail = Get-AzRecoveryServicesBackupJobDetail -VaultId $vault.ID -Job $backupJob

		Assert-NotNull $jobDetail;
		Assert-True { $jobDetail.ContainerSubscriptionId -eq $expectedContainerSubscriptionId };
	}
	finally
	{
		# Cleanup: disable protection with delete-backup-data, then delete the fresh vault so the test can be
		# re-run from a clean state. Remove-AzRecoveryServicesVault purges the soft-deleted item as part of
		# deleting the vault (the vault has AlwaysOn soft delete, which cannot be disabled).
		if ($vault -ne $null)
		{
			$cleanupItem = Get-AzRecoveryServicesBackupItem `
				-BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID `
				| Where-Object { $_.Name -match $vmName }
			if ($cleanupItem -ne $null)
			{
				Disable-AzRecoveryServicesBackupProtection `
					-VaultId $vault.ID `
					-Item $cleanupItem `
					-RemoveRecoveryPoints -Force
			}
			Remove-AzRecoveryServicesVault -Vault $vault
		}
	}
}