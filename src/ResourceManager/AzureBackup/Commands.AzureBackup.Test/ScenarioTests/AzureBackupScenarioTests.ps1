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

$ResourceGroupName = "scenariorg"
$ResourceName = "scenariorn"
$Location = "southeastasia"
$VirtualMachineName = "e2epowershell2"
$ProtectionPolicyName = "e2epolicy2"
$RestoreStorageAccount = "e2estore"
$ResultTxtFile = "EndToEndScenarioTest.txt"
$ResultCsvFile = "EndToEndScenarioTest.csv"


function Test-AzureBackupEndToEnd
{
	$FailFlag = 0;
	$FailedAt = "";

	Try
	{
	$startTime = Get-Date -format G;
	New-AzureResourceGroup -Name $ResourceGroupName -Location $Location -Force;	
	$endTime = Get-Date -format G;
	"New-AzureResourceGroup", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"New-AzureResourceGroup", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("New-AzureResourceGroup : " + $_);
	}
	
	Try
	{
	$startTime = Get-Date -format G;
	New-AzureRMBackupVault -ResourceGroupName $ResourceGroupName -Name $ResourceName -Region $Location;
	$endTime = Get-Date -format G;
	"New-AzureRMBackupVault", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"New-AzureRMBackupVault", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("New-AzureRMBackupVault : " + $_);
	}

	Try
	{
	$startTime = Get-Date -format G;
	$vault = Get-AzureRMBackupVault -Name $ResourceName;
	$endTime = Get-Date -format G;
	"Get-AzureRMBackupVault", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Get-AzureRMBackupVault", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Get-AzureRMBackupVault : " + $_);
	}

	Try
	{
	$startTime = Get-Date -format G;
	$Job = Register-AzureRMBackupContainer -Vault $vault -Name $VirtualMachineName -ServiceName $VirtualMachineName;
	Wait-AzureRMBackupJob -Job $Job;
	$JobDetails = Get-AzureRMBackupJobDetails -Vault $vault -JobId $Job.InstanceId;
	Assert-AreEqual $JobDetails.Status "Completed";
	$endTime = Get-Date -format G;
	"Register-AzureRMBackupContainer", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Register-AzureRMBackupContainer", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Register-AzureRMBackupContainer : " + $_);
	}
	
	Try
	{
	$startTime = Get-Date -format G;
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
	$endTime = Get-Date -format G;
	"New-AzureRMBackupProtectionPolicy", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"New-AzureRMBackupProtectionPolicy", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("New-AzureRMBackupProtectionPolicy : " + $_);
	}		

	Try
	{
	$startTime = Get-Date -format G;
	$container = Get-AzureRMBackupContainer -Vault $vault -Name $VirtualMachineName -Type "AzureVM";
	Assert-AreEqual $container.ContainerType "AzureVM";
	Assert-AreEqual $container.ContainerUniqueName.Contains("iaasvmcontainer") "True";
	Assert-AreEqual $container.ContainerUniqueName.Contains($VirtualMachineName) "True";
	Assert-AreEqual $container.Status "Registered";
	Assert-AreEqual $container.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $container.ResourceName $ResourceName;
	Assert-AreEqual $container.Location $Location;
	$endTime = Get-Date -format G;
	"Get-AzureRMBackupContainer", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Get-AzureRMBackupContainer", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Get-AzureRMBackupContainer : " + $_);
	}

	Try
	{
	$startTime = Get-Date -format G;
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
	$endTime = Get-Date -format G;
	"Enable-AzureRMBackupProtection", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Enable-AzureRMBackupProtection", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Enable-AzureRMBackupProtection : " + $_);
	}

	Try
	{
	$startTime = Get-Date -format G;
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
	$endTime = Get-Date -format G;
	"Get-AzureRMBackupItem", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Get-AzureRMBackupItem", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Get-AzureRMBackupItem : " + $_);
	}

	Try
	{
	$startTime = Get-Date -format G;
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
	$endTime = Get-Date -format G;
	"Backup-AzureRMBackupItem", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Backup-AzureRMBackupItem", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Backup-AzureRMBackupItem : " + $_);
	}	

	Try
	{
	$startTime = Get-Date -format G;
	$item = Get-AzureRMBackupItem -Container $container[0];
	Assert-AreEqual $item.ProtectionStatus "Protected";
	Assert-AreEqual $item.DataSourceStatus "Protected";
	Assert-AreEqual $item.ProtectionPolicyName $ProtectionPolicyName;
	Assert-AreEqual $item.RecoveryPointsCount "1";
	Assert-AreEqual $item.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $item.ResourceName $ResourceName;
	Assert-AreEqual $item.Location $Location;
	$endTime = Get-Date -format G;
	"Get-AzureRMBackupItemPostBackup", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Get-AzureRMBackupItemPostBackup", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Get-AzureRMBackupItemPostBackup : " + $_);
	}

	Try
	{
	$startTime = Get-Date -format G;
	$recoveryPoints = Get-AzureRMBackupRecoveryPoint -Item $item[0];
	Assert-NotNull $recoveryPoints.RecoveryPointTime;
	Assert-NotNull $recoveryPoints.RecoveryPointName;
	# Assert-AreEqual $recoveryPoints.RecoveryPointType "FileSystemConsistent";
	Assert-AreEqual $recoveryPoints.ContainerType "AzureVM";
	Assert-AreEqual $recoveryPoints.ItemName.Contains($VirtualMachineName) "True";
	Assert-AreEqual $recoveryPoints.ItemName.Contains("iaasvmcontainer") "True";
	$endTime = Get-Date -format G;
	"Get-AzureRMBackupRecoveryPoint", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Get-AzureRMBackupRecoveryPoint", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Get-AzureRMBackupRecoveryPoint : " + $_);
	}	

	Try
	{
	$startTime = Get-Date -format G;
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
	$endTime = Get-Date -format G;
	"Restore-AzureRMBackupItem", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Restore-AzureRMBackupItem", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Restore-AzureRMBackupItem : " + $_);
	}	

	Try
	{
	$startTime = Get-Date -format G;
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
	$endTime = Get-Date -format G;
	"Disable-AzureRMBackupProtection", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Disable-AzureRMBackupProtection", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Disable-AzureRMBackupProtection : " + $_);
	}	

	Try
	{
	$startTime = Get-Date -format G;
	$Job = Unregister-AzureRMBackupContainer -Container $container[0];
	Wait-AzureRMBackupJob -Job $Job;
	$JobDetails = Get-AzureRMBackupJobDetails -Vault $vault -JobId $Job.InstanceId;
	Assert-AreEqual $JobDetails.Operation "UnRegister";
	Assert-AreEqual $JobDetails.Status "Completed";
	Assert-AreEqual $JobDetails.WorkloadName $VirtualMachineName;
	$endTime = Get-Date -format G;
	"Unregister-AzureRMBackupContaine", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Unregister-AzureRMBackupContaine", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Unregister-AzureRMBackupContaine : " + $_);
	}	

	Try
	{
	$startTime = Get-Date -format G;
	Remove-AzureRMBackupProtectionPolicy -ProtectionPolicy $protectionpolicy;
	$endTime = Get-Date -format G;
	"Remove-AzureRMBackupProtectionPolicy", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Remove-AzureRMBackupProtectionPolicy", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Remove-AzureRMBackupProtectionPolicy : " + $_);
	}	
	
	Try
	{
	$startTime = Get-Date -format G;
	Remove-AzureRMBackupVault -Vault $vault;
	$deletedVault = Get-AzureRMBackupVault -Name $ResourceName;
	Assert-Null $deletedVault;
	$endTime = Get-Date -format G;
	"Remove-AzureRMBackupVault", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Remove-AzureRMBackupVault", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Remove-AzureRMBackupVault : " + $_);
	}	

	Try
	{
	$startTime = Get-Date -format G;
	Remove-AzureResourceGroup -Name $ResourceGroupName -Force;
	$endTime = Get-Date -format G;
	"Remove-AzureResourceGroup", "Pass", $startTime, $endTime -join "," >> $ResultTxtFile;
	}
	Catch
	{
		$endTime = Get-Date -format G;
		"Remove-AzureResourceGroup", "Fail", $startTime, $endTime -join "," >> $ResultTxtFile;
		$FailFlag = 1;
		$FailedAt = $FailedAt + ("Remove-AzureResourceGroup : " + $_);
	}
	
	import-csv $ResultTxtFile -delimiter "," | export-csv $ResultCsvFile -NoTypeInformation;

	if ($FailFlag -eq 1)
	{
		throw $FailedAt;
	}
}