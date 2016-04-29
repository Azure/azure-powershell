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

function Test-AzureSqlPolicyScenario
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "swatiSqlRG" -Name "swatiSqlRG";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	# get default objects
	$retPolicy = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType "AzureSql"

	# now create new policy
	$policy = New-AzureRmRecoveryServicesBackupProtectionPolicy -Name "swati321" -WorkloadType "AzureSql" -RetentionPolicy $retPolicy
		
	# now get policy and update it with new schedule/retention
	$retPolicy = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType "AzureSql"

    $temp = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name "swati321"	
	Assert-AreEqual $temp.RetentionPolicy.RetentionDuration.RetentionCount 180;
	Assert-AreEqual $temp.RetentionPolicy.RetentionDuration.RetentionDurationType "Days";

	$retPolicy.RetentionDuration.RetentionDurationType = "Months"
	Set-AzureRmRecoveryServicesBackupProtectionPolicy -RetentionPolicy $retPolicy -Policy $temp

	$temp = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name "swati321"
	Assert-AreEqual $temp.RetentionPolicy.RetentionDuration.RetentionCount 180;
	Assert-AreEqual $temp.RetentionPolicy.RetentionDuration.RetentionDurationType "Months";

	#cleanup 
	Remove-AzureRmRecoveryServicesProtectionPolicy -Policy $temp -Force
}