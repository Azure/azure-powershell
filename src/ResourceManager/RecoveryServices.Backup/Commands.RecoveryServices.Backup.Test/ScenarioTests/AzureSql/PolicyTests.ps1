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
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "RsvTestRG" -Name "RsvTestRN";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	# get default objects
	$retPolicy = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType "AzureSQL"
	Assert-NotNull $retPolicy

	# now create new policy
	$policy = New-AzureRmRecoveryServicesBackupProtectionPolicy `
		-Name "swatipol1" -WorkloadType "AzureSQL" -RetentionPolicy $retPolicy
		
	# now get policy and update it with new schedule/retention
	$policy1 = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name "swatipol1"	
	Assert-AreEqual $policy1.RetentionPolicy.RetentionCount 10;
	Assert-AreEqual $policy1.RetentionPolicy.RetentionDurationType "Months"

	$retPolicy.RetentionDurationType = "Weeks"
	$retPolicy.RetentionCount = 2
	Set-AzureRmRecoveryServicesBackupProtectionPolicy -RetentionPolicy $retPolicy -Policy $policy1

	$policy1 = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name "swatipol1"
	Assert-AreEqual $policy1.RetentionPolicy.RetentionCount 2
	Assert-AreEqual $policy1.RetentionPolicy.RetentionDurationType "Weeks"

	# create another policy
	$policy2 = New-AzureRmRecoveryServicesBackupProtectionPolicy `
		-Name "swatipol2" -WorkloadType "AzureSQL" -RetentionPolicy $retPolicy

	$listPolicy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
		-WorkloadType "AzureSQLDatabase"
	Assert-NotNull $listPolicy

	#cleanup 
	Remove-AzureRmRecoveryServicesBackupProtectionPolicy -Policy $policy1 -Force
	Remove-AzureRmRecoveryServicesBackupProtectionPolicy -Policy $policy2 -Force
}