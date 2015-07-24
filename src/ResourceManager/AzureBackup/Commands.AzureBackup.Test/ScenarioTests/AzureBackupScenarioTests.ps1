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
$Location = "westus"
$VirtualMachineName = "e2etest"
$ProtectionPolicyName = "e2epolicy"
$ManagedResourceGroupName = "powershellbvt"
$ManagedResourceName = "powershellbvt"

function Test-AzureBackupEndToEnd
{
	New-AzureBackupVault -ResourceGroupName $ResourceGroupName -Name $ResourceName -Region "SouthEast Asia"
	$vault = Get-AzureBackupVault -Name $ResourceName;
	$Job = Register-AzureBackupContainer -Vault $vault -Name $VirtualMachineName -ServiceName $VirtualMachineName;
	Wait-AzureBackupJob -Job $Job;
	$JobDetails = Get-AzureBackupJobDetails -Vault $vault -JobId $Job.InstanceId;
	Assert-AreEqual $JobDetails.Status "Completed";
	
	$protectionpolicy = New-AzureBackupProtectionPolicy -Vault $vault -Name $ProtectionPolicyName -WorkloadType "VM" -BackupType "Full" -ScheduleRunTimes ((Get-Date -Hour 15 -Minute 30 -Second 0).ToUniversalTime()) -Daily -RetentionType "Days" -RetentionDuration 20;
	Assert-AreEqual $protectionpolicy.Name $ProtectionPolicyName;
	Assert-AreEqual $protectionpolicy.WorkloadType "VM";
	Assert-AreEqual $protectionpolicy.BackupType "Type";
	Assert-AreEqual $protectionpolicy.RetentionType "Days";
	Assert-AreEqual $protectionpolicy.RetentionDuration "20";
	Assert-AreEqual $protectionpolicy.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $protectionpolicy.ResourceName $ResourceName;
	Assert-AreEqual $protectionpolicy.Location $Location;
	
	$container = Get-AzureBackupContainer -Vault $vault;
	Assert-AreEqual $container.ManagedResourceGroupName $VirtualMachineName;
	Assert-AreEqual $container.ManagedResourceName $VirtualMachineName;
	Assert-AreEqual $container.HealthStatus "Healthy";
	Assert-AreEqual $container.RegisrationStatus "Registered";
	Assert-AreEqual $container.ContainerType "IaasVMContainer";
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
	Assert-AreEqual $item.ProtectionPolicyName  $ProtectionPolicyName;
	Assert-AreEqual $item.ContainerType "IaasVMContainer";
	Assert-AreEqual $item.Type "VM";
	Assert-AreEqual $item.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $item.ResourceName $ResourceName;
	Assert-AreEqual $item.Location $Location;
	
	$Job = Backup-AzureBackupItem -Item $item[0];
	Wait-AzureBackupJob -Job $Job;
	$JobDetails = Get-AzureBackupJobDetails -Vault $vault -JobID $Job.InstanceId;
	Assert-AreEqual $JobDetails.Operation "Backup";
	Assert-AreEqual $JobDetails.Status "Completed";
	Assert-AreEqual $JobDetails.WorkloadName $VirtualMachineName;
	Assert-AreEqual $JobDetails.Properties.Values.Contains($VirtualMachineName) "True";
	Assert-AreEqual $JobDetails.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $JobDetails.ResourceName $ResourceName;
	Assert-AreEqual $JobDetails.Location $ResourceGroupName;

	$item = Get-AzureBackupItem -Container $container[0];
	Assert-AreEqual $item.ProtectionStatus "Protected";
	Assert-AreEqual $item.ProtectionPolicyName $ProtectionPolicyName;
	Assert-AreEqual $item.WorkloadName $VirtualMachineName;
	Assert-AreEqual $item.RecoveryPointsCount "1";
	Assert-AreEqual $item.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $item.ResourceName $ResourceName;
	Assert-AreEqual $item.Location $ResourceGroupName;

	#ToDo: Swatim to verify output Assert after this.
	$recoveryPoints = Get-AzureBackupRecoveryPoint -Item $item[0];
	$Job = Disable-AzureBackupProtection -RemoveRecoveryPoints -Item $item[0];
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

	$Job = Unregister-AzureBackupContainer -Container $container[0];
	Wait-AzureBackupJob -Job $Job;
	$JobDetails = Get-AzureBackupJobDetails -Vault $vault -JobId $Job.InstanceId;
	Assert-AreEqual $JobDetails.Status "Completed";

	Remove-AzureBackupProtectionPolicy -ProtectionPolicy $protectionpolicy;
	
	Remove-AzureBackupVault -Vault $vault;

}