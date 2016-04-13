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

function Test-PolicyScenario
{
	$vault = Get-AzureRmRecoveryServicesVault -ResourceGroupName "phaniktRSV" -Name "phaniktRs1";
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault;

	# get default objects
	$schedulePolicy = Get-AzureRmRecoveryServicesSchedulePolicyObject -WorkloadType "AzureVM"
	$retPolicy = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType "AzureVM"

	# now create new policy
	$policy = New-AzureRmRecoveryServicesBackupProtectionPolicy -Name "pwtest1" -WorkloadType "AzureVM" -RetentionPolicy $retPolicy -SchedulePolicy $schedulePolicy
		
	# now get policy and update it with new schedule/retention
	$schedulePolicy = Get-AzureRmRecoveryServicesSchedulePolicyObject -WorkloadType "AzureVM"
	$retPolicy = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType "AzureVM"

    $temp = Get-AzureRmRecoveryServicesProtectionPolicy -Name "pwtest1"	
	Set-AzureRmRecoveryServicesBackupProtectionPolicy -RetentionPolicy $retPolicy -SchedulePolicy $schedulePolicy -Policy $temp

	#cleanup 

	Remove-AzureRmRecoveryServicesProtectionPolicy -Policy $temp -Force
}