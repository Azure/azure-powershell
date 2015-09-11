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
$Location = "southeastasia"
$VirtualMachineName = "hydrarecordvm"
$ProtectionPolicyName = "e2epolicy1"
$RestoreStorageAccount = "e2estore"

function Test-AzureBackupEndToEnd
{
	New-AzureRMBackupVault -ResourceGroupName $ResourceGroupName -Name $ResourceName -Region $Location;
	$vault = Get-AzureRMBackupVault -Name $ResourceName;
	$Job = Register-AzureRMBackupContainer -Vault $vault -Name $VirtualMachineName -ServiceName $VirtualMachineName;
	Wait-AzureRMBackupJob -Job $Job;
	$JobDetails = Get-AzureRMBackupJobDetails -Vault $vault -JobId $Job.InstanceId;
	Assert-AreEqual $JobDetails.Status "Completed";
	
	$r1 = New-AzureRMBackupRetentionPolicyObject -DailyRetention -Retention 20;
	$r2 = New-AzureRMBackupRetentionPolicyObject -WeeklyRetention -DaysOfWeek "Monday" -Retention 10;
	$r3 = New-AzureRMBackupRetentionPolicyObject -MonthlyRetentionInDailyFormat -DaysOfMonth "10" -Retention 10;
	$r = ($r1, $r2, $r3);
	$backupTime = (Get-Date("17 August 2015 15:30:00")).ToUniversalTime();
	$protectionpolicy = New-AzureRMBackupProtectionPolicy -Vault $vault -Name $ProtectionPolicyName -Type "AzureVM" -Daily -BackupTime $backupTime -RetentionPolicy $r; 

	Assert-AreEqual $protectionpolicy.Name $ProtectionPolicyName;
	Assert-AreEqual $protectionpolicy.Type "AzureVM";
	Assert-AreEqual $protectionpolicy.ScheduleType "Daily";
	Assert-AreEqual $protectionpolicy.RetentionPolicy.Count 3;
	Assert-AreEqual $protectionpolicy.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $protectionpolicy.ResourceName $ResourceName;
	Assert-AreEqual $protectionpolicy.Location $Location;
	
	$container = Get-AzureRMBackupContainer -Vault $vault -Name $VirtualMachineName -Type "AzureVM";
	Assert-AreEqual $container.ContainerType "AzureVM";
	Assert-AreEqual $container.ContainerUniqueName.Contains("iaasvmcontainer") "True";
	Assert-AreEqual $container.ContainerUniqueName.Contains($VirtualMachineName) "True";
	Assert-AreEqual $container.Status "Registered";
	Assert-AreEqual $container.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $container.ResourceName $ResourceName;
	Assert-AreEqual $container.Location $Location;

	$Job = Enable-AzureRMBackupProtection -Item $container[0] -Policy $protectionpolicy[0];
	Wait-AzureRMBackupJob -Job $Job;
	$JobDetails = Get-AzureRMBackupJobDetails -Vault $vault -JobID $Job.InstanceId;
	Assert-AreEqual $JobDetails.Operation "ConfigureBackup";
	Assert-AreEqual $JobDetails.Status "Completed";
	Assert-AreEqual $JobDetails.WorkloadName $VirtualMachineName;
	Assert-AreEqual $JobDetails.Properties.Values.Contains($VirtualMachineName) "True";
	Assert-AreEqual $JobDetails.Properties.Values.Contains($ProtectionPolicyName) "True";
	Assert-AreEqual $JobDetails.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $JobDetails.ResourceName $ResourceName;
	Assert-AreEqual $JobDetails.Location $Location;

	$item = Get-AzureRMBackupItem -Container $container[0];
	Assert-AreEqual $item.ProtectionStatus "Protected";
	Assert-AreEqual $item.DataSourceStatus "IRPending";
	Assert-AreEqual $item.ProtectionPolicyName  $ProtectionPolicyName;
	Assert-AreEqual $item.ContainerType "AzureVM";
	Assert-NotNull $item.Type;
	Assert-AreEqual $item.ItemName.Contains("iaasvmcontainer") "True";
	Assert-AreEqual $item.ItemName.Contains($VirtualMachineName) "True";
	Assert-AreEqual $item.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $item.ResourceName $ResourceName;
	Assert-AreEqual $item.Location $Location;

	$Job = Backup-AzureRMBackupItem -Item $item[0];
	Wait-AzureRMBackupJob -Job $Job;
	$JobDetails = Get-AzureRMBackupJobDetails -Vault $vault -JobID $Job.InstanceId;
	Assert-AreEqual $JobDetails.Operation "Backup";
	Assert-AreEqual $JobDetails.Status "Completed";
	Assert-NotNull $JobDetails.WorkloadType;
	Assert-AreEqual $JobDetails.WorkloadName $VirtualMachineName;
	Assert-AreEqual $JobDetails.Properties.Values.Contains($VirtualMachineName) "True";
	Assert-AreEqual $JobDetails.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $JobDetails.ResourceName $ResourceName;
	Assert-AreEqual $JobDetails.Location $Location;

	$item = Get-AzureRMBackupItem -Container $container[0];
	Assert-AreEqual $item.ProtectionStatus "Protected";
	Assert-AreEqual $item.DataSourceStatus "Protected";
	Assert-AreEqual $item.ProtectionPolicyName $ProtectionPolicyName;
	Assert-AreEqual $item.RecoveryPointsCount "1";
	Assert-AreEqual $item.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $item.ResourceName $ResourceName;
	Assert-AreEqual $item.Location $Location;

	$recoveryPoints = Get-AzureRMBackupRecoveryPoint -Item $item[0];
	Assert-NotNull $recoveryPoints.RecoveryPointTime;
	Assert-NotNull $recoveryPoints.RecoveryPointName;
	# Assert-AreEqual $recoveryPoints.RecoveryPointType "FileSystemConsistent";
	Assert-AreEqual $recoveryPoints.ContainerType "AzureVM";
	Assert-AreEqual $recoveryPoints.ItemName.Contains($VirtualMachineName) "True";
	Assert-AreEqual $recoveryPoints.ItemName.Contains("iaasvmcontainer") "True";

	$Job = Restore-AzureRMBackupItem -RecoveryPoint $recoveryPoints -StorageAccountName $RestoreStorageAccount;
	Wait-AzureRMBackupJob -Job $Job;
	$JobDetails = Get-AzureRMBackupJobDetails -Vault $vault -JobID $Job.InstanceId;
	Assert-AreEqual $JobDetails.Operation "Restore";
	Assert-AreEqual $JobDetails.Status "Completed";
	Assert-NotNull $JobDetails.WorkloadType;
	Assert-AreEqual $JobDetails.WorkloadName $VirtualMachineName;
	Assert-AreEqual $JobDetails.Properties.Values.Contains($RestoreStorageAccount) "True";
	Assert-AreEqual $JobDetails.Properties.Values.Contains("Recover disks") "True";
	Assert-AreEqual $JobDetails.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $JobDetails.ResourceName $ResourceName;
	Assert-AreEqual $JobDetails.Location $Location;

	$Job = Disable-AzureRMBackupProtection -RemoveRecoveryPoints -Item $item[0];
	Wait-AzureRMBackupJob -Job $Job;
	$JobDetails = Get-AzureRMBackupJobDetails -Vault $vault -JobID $Job.InstanceId;
	Assert-AreEqual $JobDetails.Operation "Unprotect";
	Assert-AreEqual $JobDetails.Status "Completed";
	Assert-AreEqual $JobDetails.WorkloadName $VirtualMachineName;
	Assert-AreEqual $JobDetails.Properties.Values.Contains($VirtualMachineName) "True";
	Assert-AreEqual $JobDetails.Properties.Keys.Contains("Delete Backup Data") "True";
	Assert-AreEqual $JobDetails.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $JobDetails.ResourceName $ResourceName;
	Assert-AreEqual $JobDetails.Location $Location;

	$Job = Unregister-AzureRMBackupContainer -Container $container[0];
	Wait-AzureRMBackupJob -Job $Job;
	$JobDetails = Get-AzureRMBackupJobDetails -Vault $vault -JobId $Job.InstanceId;
	Assert-AreEqual $JobDetails.Operation "UnRegister";
	Assert-AreEqual $JobDetails.Status "Completed";
	Assert-AreEqual $JobDetails.WorkloadName $VirtualMachineName;

	Remove-AzureRMBackupProtectionPolicy -ProtectionPolicy $protectionpolicy;
	
	Remove-AzureRMBackupVault -Vault $vault;

	$deletedVault = Get-AzureRMBackupVault -Name $ResourceName;
	Assert-Null $deletedVault;
}