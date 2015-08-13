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
$VirtualMachineName = "e2etest"
$ProtectionPolicyName = "e2epolicy"
$RestoreStorageAccount = "e2estore"

function Test-AzureBackupEndToEnd
{
	New-AzureBackupVault -ResourceGroupName $ResourceGroupName -Name $ResourceName -Region "SouthEast Asia"
	$vault = Get-AzureBackupVault -Name $ResourceName;
	$Job = Register-AzureBackupContainer -Vault $vault -Name $VirtualMachineName -ServiceName $VirtualMachineName;
	Wait-AzureBackupJob -Job $Job;
	$JobDetails = Get-AzureBackupJobDetails -Vault $vault -JobId $Job.InstanceId;
	Assert-AreEqual $JobDetails.Status "Completed";
	
	$r1 = New-AzureBackupRetentionPolicyObject -DailyRetention -Retention 20;
	$r2 = New-AzureBackupRetentionPolicyObject -WeeklyRetention -DaysOfWeek "Monday" -Retention 10;
	$r3 = New-AzureBackupRetentionPolicyObject -MonthlyRetentionInDailyFormat -DaysOfMonth "10" -Retention 10;
	$r = ($r1, $r2, $r3);
	$backupTime = (Get-Date -Hour 15 -Minute 30 -Second 0).ToUniversalTime();
	$protectionpolicy = New-AzureBackupProtectionPolicy -Vault $vault -Name $ProtectionPolicyName -Type "IaasVM" -Daily -BackupTime $backupTime -RetentionPolicies $r; 

	Assert-AreEqual $protectionpolicy.Name $ProtectionPolicyName;
	Assert-AreEqual $protectionpolicy.Type "IaasVM";
	Assert-AreEqual $protectionpolicy.ScheduleType "Daily";
	Assert-AreEqual $protectionpolicy.RetentionPolicyList.Count 3;
	Assert-AreEqual $protectionpolicy.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $protectionpolicy.ResourceName $ResourceName;
	Assert-AreEqual $protectionpolicy.Location $Location;
	
	$container = Get-AzureBackupContainer -Vault $vault -Name $VirtualMachineName -Type AzureVM
	Assert-AreEqual $container.ContainerType "IaasVM";
	Assert-AreEqual $container.ContainerUniqueName.Contains("iaasvmcontainer") "True";
	Assert-AreEqual $container.ContainerUniqueName.Contains($VirtualMachineName) "True";
	Assert-AreEqual $container.Status "Registered";
	Assert-AreEqual $container.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $container.ResourceName $ResourceName;
	Assert-AreEqual $container.Location $Location;

	$Job = Enable-AzureBackupProtection -Item $container[0] -Policy $protectionpolicy[0];
	Wait-AzureBackupJob -Job $Job;
	$JobDetails = Get-AzureBackupJobDetails -Vault $vault -JobID $Job.InstanceId;
	Assert-AreEqual $JobDetails.Operation "ConfigureBackup";
	Assert-AreEqual $JobDetails.Status "Completed";
	Assert-AreEqual $JobDetails.WorkloadName $VirtualMachineName;
	Assert-AreEqual $JobDetails.Properties.Values.Contains($VirtualMachineName) "True";
	Assert-AreEqual $JobDetails.Properties.Values.Contains($ProtectionPolicyName) "True";
	Assert-AreEqual $JobDetails.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $JobDetails.ResourceName $ResourceName;
	Assert-AreEqual $JobDetails.Location $ResourceGroupName;

	$item = Get-AzureBackupItem -Container $container[0];
	Assert-AreEqual $item.ProtectionStatus "Protected";
	Assert-AreEqual $item.DataSourceStatus "IRPending";
	Assert-AreEqual $item.ProtectionPolicyName  $ProtectionPolicyName;
	Assert-AreEqual $item.ContainerType "AzureVM";
	Assert-AreEqual $item.Type "IaasVM";
	Assert-AreEqual $item.ItemName.Contains("iaasvmcontainer") "True";
	Assert-AreEqual $item.ItemName.Contains($VirtualMachineName) "True";
	Assert-AreEqual $item.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $item.ResourceName $ResourceName;
	Assert-AreEqual $item.Location $Location;
	
	$Job = Backup-AzureBackupItem -Item $item[0];
	Wait-AzureBackupJob -Job $Job;
	$JobDetails = Get-AzureBackupJobDetails -Vault $vault -JobID $Job.InstanceId;
	Assert-AreEqual $JobDetails.Operation "Backup";
	Assert-AreEqual $JobDetails.Status "Completed";
	Assert-AreEqual $JobDetails.WorkloadType "VM";
	Assert-AreEqual $JobDetails.WorkloadName $VirtualMachineName;
	Assert-AreEqual $JobDetails.Properties.Values.Contains($VirtualMachineName) "True";
	Assert-AreEqual $JobDetails.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $JobDetails.ResourceName $ResourceName;
	Assert-AreEqual $JobDetails.Location $ResourceGroupName;

	$item = Get-AzureBackupItem -Container $container[0];
	Assert-AreEqual $item.ProtectionStatus "Protected";
	Assert-AreEqual $item.DataSourceStatus "Protected";
	Assert-AreEqual $item.ProtectionPolicyName $ProtectionPolicyName;
	Assert-AreEqual $item.WorkloadName $VirtualMachineName;
	Assert-AreEqual $item.RecoveryPointsCount "1";
	Assert-AreEqual $item.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $item.ResourceName $ResourceName;
	Assert-AreEqual $item.Location $ResourceGroupName;

	#ToDo: Swatim to verify output Assert after this.
	$recoveryPoints = Get-AzureBackupRecoveryPoint -Item $item[0];
	Assert-NotNull $recoveryPoints.RecoveryPointTime;
	Assert-NotNull $recoveryPoints.RecoveryPointName;
	Assert-AreEqual $recoveryPoints.RecoveryPointType "AppConsistent";
	Assert-AreEqual $recoveryPoints.ContainerType "AzureVM";
	Assert-AreEqual $recoveryPoints.ItemName.Contains($VirtualMachineName) "True";
	Assert-AreEqual $recoveryPoints.ItemName.Contains("iaasvmcontainer") "True";

	$Job = Restore-AzureBackupItem -RecoveryPoint $recoveryPoints -StorageAccountName $RestoreStorageAccount;
	Wait-AzureBackupJob -Job $Job;
	$JobDetails = Get-AzureBackupJobDetails -Vault $vault -JobID $Job.InstanceId;
	Assert-AreEqual $JobDetails.Operation "Restore";
	Assert-AreEqual $JobDetails.Status "Completed";
	Assert-AreEqual $JobDetails.WorkloadType "VM";
	Assert-AreEqual $JobDetails.WorkloadName $VirtualMachineName;
	Assert-AreEqual $JobDetails.Properties.Values.Contains($RestoreStorageAccount) "True";
	Assert-AreEqual $JobDetails.Properties.Values.Contains("Recover disks") "True";
	Assert-AreEqual $JobDetails.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $JobDetails.ResourceName $ResourceName;
	Assert-AreEqual $JobDetails.Location $ResourceGroupName;

	$Job = Disable-AzureBackupProtection -RemoveRecoveryPoints -Item $item[0];
	Wait-AzureBackupJob -Job $Job;
	$JobDetails = Get-AzureBackupJobDetails -Vault $vault -JobID $Job.InstanceId;
	Assert-AreEqual $JobDetails.Operation "Unprotect";
	Assert-AreEqual $JobDetails.Status "Completed";
	Assert-AreEqual $JobDetails.WorkloadName $VirtualMachineName;
	Assert-AreEqual $JobDetails.Properties.Values.Contains($VirtualMachineName) "True";
	Assert-AreEqual $JobDetails.Properties.Keys.Contains("Delete Backup Data") "True";
	Assert-AreEqual $JobDetails.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $JobDetails.ResourceName $ResourceName;
	Assert-AreEqual $JobDetails.Location $ResourceGroupName;

	$Job = Unregister-AzureBackupContainer -Container $container[0];
	Wait-AzureBackupJob -Job $Job;
	$JobDetails = Get-AzureBackupJobDetails -Vault $vault -JobId $Job.InstanceId;
	Assert-AreEqual $JobDetails.Operation "UnRegister";
	Assert-AreEqual $JobDetails.Status "Completed";
	Assert-AreEqual $JobDetails.WorkloadName $VirtualMachineName;

	Remove-AzureBackupProtectionPolicy -ProtectionPolicy $protectionpolicy;
	
	Remove-AzureBackupVault -Vault $vault;

	$deletedVault = Get-AzureBackupVault -Name $ResourceName;
	Assert-Null $deletedVault;
}