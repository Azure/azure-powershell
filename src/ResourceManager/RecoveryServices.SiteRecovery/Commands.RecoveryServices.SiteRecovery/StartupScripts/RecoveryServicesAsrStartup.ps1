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

@{
    # Azure Site Recovery aliases
    "Edit-ASRRecoveryPlan" = "Edit-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Edit-ASRRP" = "Edit-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Get-ASRAlertSetting" = "Get-AzureRmRecoveryServicesAsrAlertSetting";
    "Get-ASREvent" = "Get-AzureRmRecoveryServicesAsrEvent";
    "Get-ASRFabric" = "Get-AzureRmRecoveryServicesAsrFabric";
    "Get-ASRJob" = "Get-AzureRmRecoveryServicesAsrJob";
    "Get-ASRNetwork" = "Get-AzureRmRecoveryServicesAsrNetwork";
    "Get-ASRNetworkMapping" = "Get-AzureRmRecoveryServicesAsrNetworkMapping";
    "Get-ASRNotificationSetting" = "Get-AzureRmRecoveryServicesAsrAlertSetting";
    "Get-ASRPolicy" = "Get-AzureRmRecoveryServicesAsrPolicy";
    "Get-ASRProtectableItem" = "Get-AzureRmRecoveryServicesAsrProtectableItem";
    "Get-ASRProtectionContainer" = "Get-AzureRmRecoveryServicesAsrProtectionContainer";
    "Get-ASRProtectionContainerMapping" = "Get-AzureRmRecoveryServicesAsrProtectionContainerMapping";
    "Get-ASRRecoveryPlan" = "Get-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Get-ASRRecoveryPoint" = "Get-AzureRmRecoveryServicesAsrRecoveryPoint";
    "Get-ASRReplicationProtectedItem" = "Get-AzureRmRecoveryServicesAsrReplicationProtectedItem";
    "Get-ASRRP" = "Get-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Get-ASRServicesProvider" = "Get-AzureRmRecoveryServicesAsrServicesProvider";
    "Get-ASRStorageClassification" = "Get-AzureRmRecoveryServicesAsrStorageClassification";
    "Get-ASRStorageClassificationMapping" = "Get-AzureRmRecoveryServicesAsrStorageClassificationMapping";
    "Get-ASRvCenter" = "Get-AzureRmRecoveryServicesAsrvCenter";
    "Get-ASRVaultContext" = "Get-AzureRmRecoveryServicesAsrVaultContext";
    "Get-ASRVaultSettings" = "Get-AzureRmRecoveryServicesAsrVaultContext";
    "Get-AzureRmRecoveryServicesAsrNotificationSetting" = "Get-AzureRmRecoveryServicesAsrAlertSetting";
    "Get-AzureRmRecoveryServicesAsrVaultSettings" = "Get-AzureRmRecoveryServicesAsrVaultContext";
    "New-ASRFabric" = "New-AzureRmRecoveryServicesAsrFabric";
    "New-ASRNetworkMapping" = "New-AzureRmRecoveryServicesAsrNetworkMapping";
    "New-ASRPolicy" = "New-AzureRmRecoveryServicesAsrPolicy";
    "New-ASRProtectableItem" = "New-AzureRmRecoveryServicesAsrProtectableItem";
    "New-ASRProtectionContainerMapping" = "New-AzureRmRecoveryServicesAsrProtectionContainerMapping";
    "New-ASRRecoveryPlan" = "New-AzureRmRecoveryServicesAsrRecoveryPlan";
    "New-ASRReplicationProtectedItem" = "New-AzureRmRecoveryServicesAsrReplicationProtectedItem";
    "New-ASRRP" = "New-AzureRmRecoveryServicesAsrRecoveryPlan";
    "New-ASRStorageClassificationMapping" = "New-AzureRmRecoveryServicesAsrStorageClassificationMapping";
    "New-ASRvCenter" = "New-AzureRmRecoveryServicesAsrvCenter";
    "Remove-ASRFabric" = "Remove-AzureRmRecoveryServicesAsrFabric";
    "Remove-ASRNetworkMapping" = "Remove-AzureRmRecoveryServicesAsrNetworkMapping";
    "Remove-ASRPolicy" = "Remove-AzureRmRecoveryServicesAsrPolicy";
    "Remove-ASRProtectionContainerMapping" = "Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping";
    "Remove-ASRRecoveryPlan" = "Remove-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Remove-ASRReplicationProtectedItem" = "Remove-AzureRmRecoveryServicesAsrReplicationProtectedItem";
    "Remove-ASRRP" = "Remove-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Remove-ASRServicesProvider" = "Remove-AzureRmRecoveryServicesAsrServicesProvider";
    "Remove-ASRStorageClassificationMapping" = "Remove-AzureRmRecoveryServicesAsrStorageClassificationMapping";
    "Remove-ASRvCenter" = "Remove-AzureRmRecoveryServicesAsrvCenter";
    "Restart-ASRJob" = "Restart-AzureRmRecoveryServicesAsrJob";
    "Resume-ASRJob" = "Resume-AzureRmRecoveryServicesAsrJob";
    "Set-ASRAlertSetting" = "Set-AzureRmRecoveryServicesAsrAlertSetting";
    "Set-ASRNotificationSetting" = "Set-AzureRmRecoveryServicesAsrAlertSetting";
    "Set-ASRReplicationProtectedItem" = "Set-AzureRmRecoveryServicesAsrReplicationProtectedItem";
    "Set-ASRVaultContext" = "Set-AzureRmRecoveryServicesAsrVaultContext";
    "Set-ASRVaultSettings" = "Set-AzureRmRecoveryServicesAsrVaultContext";
    "Set-AzureRmRecoveryServicesAsrNotificationSetting" = "Set-AzureRmRecoveryServicesAsrAlertSetting";
    "Set-AzureRmRecoveryServicesAsrVaultSettings" = "Set-AzureRmRecoveryServicesAsrVaultContext";
    "Start-ASRApplyRecoveryPoint" = "Start-AzureRmRecoveryServicesAsrApplyRecoveryPoint";
    "Start-ASRCommitFailover" = "Start-AzureRmRecoveryServicesAsrCommitFailoverJob";
    "Start-ASRCommitFailoverJob" = "Start-AzureRmRecoveryServicesAsrCommitFailoverJob";
    "Start-ASRFO" = "Start-AzureRmRecoveryServicesAsrUnplannedFailoverJob";
    "Start-ASRPFO" = "Start-AzureRmRecoveryServicesAsrPlannedFailoverJob";
    "Start-ASRPlannedFailoverJob" = "Start-AzureRmRecoveryServicesAsrPlannedFailoverJob";
    "Start-ASRResyncJob" = "Start-AzureRmRecoveryServicesAsrResynchronizeReplicationJob";
    "Start-ASRResynchronizeReplicationJob" = "Start-AzureRmRecoveryServicesAsrResynchronizeReplicationJob";
    "Start-ASRSwitchProcessServerJob" = "Start-AzureRmRecoveryServicesAsrSwitchProcessServerJob";
    "Start-ASRTestFailoverCleanupJob" = "Start-AzureRmRecoveryServicesAsrTestFailoverCleanupJob";
    "Start-ASRTestFailoverJob" = "Start-AzureRmRecoveryServicesAsrTestFailoverJob";
    "Start-ASRTFO" = "Start-AzureRmRecoveryServicesAsrTestFailoverJob";
    "Start-ASRUnplannedFailoverJob" = "Start-AzureRmRecoveryServicesAsrUnplannedFailoverJob";
    "Stop-ASRJob" = "Stop-AzureRmRecoveryServicesAsrJob";
    "Update-ASRPolicy" = "Update-AzureRmRecoveryServicesAsrPolicy";
    "Update-ASRProtectionDirection" = "Update-AzureRmRecoveryServicesAsrProtectionDirection";
    "Update-ASRRecoveryPlan" = "Update-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Update-ASRServicesProvider" = "Update-AzureRmRecoveryServicesAsrServicesProvider";
    "Update-ASRvCenter" = "Update-AzureRmRecoveryServicesAsrvCenter";
}.GetEnumerator() | Select @{Name='Name'; Expression={$_.Key}}, @{Name='Value'; Expression={$_.Value}} | Set-Alias -Description "AzureAlias"
