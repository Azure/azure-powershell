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
    "Edit-ASRRP" = "Edit-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Edit-ASRRecoveryPlan" = "Edit-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Get-ASRFabric" = "Get-AzureRmRecoveryServicesAsrFabric";
    "Get-ASRJob" = "Get-AzureRmRecoveryServicesAsrJob";
    "Get-ASRNetwork" = "Get-AzureRmRecoveryServicesAsrNetwork";
    "Get-ASRNetworkMapping" = "Get-AzureRmRecoveryServicesAsrNetworkMapping";
    "Get-ASRPolicy" = "Get-AzureRmRecoveryServicesAsrPolicy";
    "Get-ASRProtectableItem" = "Get-AzureRmRecoveryServicesAsrProtectableItem";
    "Get-ASRProtectionContainer" = "Get-AzureRmRecoveryServicesAsrProtectionContainer";
    "Get-ASRProtectionContainerMapping" = "Get-AzureRmRecoveryServicesAsrProtectionContainerMapping";
    "Get-ASRRP" = "Get-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Get-ASRRecoveryPlan" = "Get-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Get-ASRRecoveryPoint" = "Get-AzureRmRecoveryServicesAsrRecoveryPoint";
    "Get-ASRReplicationProtectedItem" = "Get-AzureRmRecoveryServicesAsrReplicationProtectedItem";
    "Get-ASRServicesProvider" = "Get-AzureRmRecoveryServicesAsrServicesProvider";
    "Get-ASRStorageClassification" = "Get-AzureRmRecoveryServicesAsrStorageClassification";
    "Get-ASRStorageClassificationMapping" = "Get-AzureRmRecoveryServicesAsrStorageClassificationMapping";
    "New-ASRFabric" = "New-AzureRmRecoveryServicesAsrFabric";
    "New-ASRNetworkMapping" = "New-AzureRmRecoveryServicesAsrNetworkMapping";
    "New-ASRPolicy" = "New-AzureRmRecoveryServicesAsrPolicy";
    "New-ASRProtectionContainerMapping" = "New-AzureRmRecoveryServicesAsrProtectionContainerMapping";
    "New-ASRRP" = "New-AzureRmRecoveryServicesAsrRecoveryPlan";
    "New-ASRRecoveryPlan" = "New-AzureRmRecoveryServicesAsrRecoveryPlan";
    "New-ASRReplicationProtectedItem" = "New-AzureRmRecoveryServicesAsrReplicationProtectedItem";
    "New-ASRStorageClassificationMapping" = "New-AzureRmRecoveryServicesAsrStorageClassificationMapping";
    "Remove-ASRFabric" = "Remove-AzureRmRecoveryServicesAsrFabric";
    "Remove-ASRNetworkMapping" = "Remove-AzureRmRecoveryServicesAsrNetworkMapping";
    "Remove-ASRPolicy" = "Remove-AzureRmRecoveryServicesAsrPolicy";
    "Remove-ASRProtectionContainerMapping" = "Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping";
    "Remove-ASRRP" = "Remove-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Remove-ASRRecoveryPlan" = "Remove-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Remove-ASRReplicationProtectedItem" = "Remove-AzureRmRecoveryServicesAsrReplicationProtectedItem";
    "Remove-ASRServicesProvider" = "Remove-AzureRmRecoveryServicesAsrServicesProvider";
    "Remove-ASRStorageClassificationMapping" = "Remove-AzureRmRecoveryServicesAsrStorageClassificationMapping";
    "Restart-ASRJob" = "Restart-AzureRmRecoveryServicesAsrJob";
    "Resume-ASRJob" = "Resume-AzureRmRecoveryServicesAsrJob";
    "Set-ASRReplicationProtectedItem" = "Set-AzureRmRecoveryServicesAsrReplicationProtectedItem";
    "Set-ASRVaultContext" = "Set-AzureRmRecoveryServicesAsrVaultSettings";
    "Set-ASRVaultSettings" = "Set-AzureRmRecoveryServicesAsrVaultSettings";
    "Start-ASRApplyRecoveryPoint" = "Start-AzureRmRecoveryServicesAsrApplyRecoveryPoint";
    "Start-ASRCommitFailover" = "Start-AzureRmRecoveryServicesAsrCommitFailoverJob";
    "Start-ASRCommitFailoverJob" = "Start-AzureRmRecoveryServicesAsrCommitFailoverJob";
    "Start-ASRFO" = "Start-AzureRmRecoveryServicesAsrUnplannedFailoverJob";
    "Start-ASRPFO" = "Start-AzureRmRecoveryServicesAsrPlannedFailoverJob";
    "Start-ASRPlannedFailoverJob" = "Start-AzureRmRecoveryServicesAsrPlannedFailoverJob";
    "Start-ASRTFO" = "Start-AzureRmRecoveryServicesAsrTestFailoverJob";
    "Start-ASRTestFailoverJob" = "Start-AzureRmRecoveryServicesAsrTestFailoverJob";
    "Start-ASRUnplannedFailoverJob" = "Start-AzureRmRecoveryServicesAsrUnplannedFailoverJob";
    "Stop-ASRJob" = "Stop-AzureRmRecoveryServicesAsrJob";
    "Update-ASRPolicy" = "Update-AzureRmRecoveryServicesAsrPolicy";
    "Update-ASRProtectionDirection" = "Update-AzureRmRecoveryServicesAsrProtectionDirection";
    "Update-ASRRecoveryPlan" = "Update-AzureRmRecoveryServicesAsrRecoveryPlan";
    "Update-ASRServicesProvider" = "Update-AzureRmRecoveryServicesAsrServicesProvider";
}.GetEnumerator() | Select @{Name='Name'; Expression={$_.Key}}, @{Name='Value'; Expression={$_.Value}} | New-Alias -Description "AzureAlias"

