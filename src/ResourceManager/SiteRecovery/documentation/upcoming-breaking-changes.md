<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Upcoming Breaking Changes", and should adhere to the following format:

    # Upcoming Breaking Changes

    ## Release X.0.0 - January 2017

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above section follows the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

# Upcoming Breaking Changes

## Release 5.0.x - month 2018

## Deprecation of the AzureRm.SiteRecovery module

The AzureRm.SiteRecovery module will be deprecated in an upcoming release.

The AzureRm.SiteRecovery module is being superseded by the AzureRm.RecoveryServices.SiteRecovery module.

The AzureRm.RecoveryServices.SiteRecovery is a functional superset of the AzureRm.SiteRecovery module and includes a new set of equivalent cmdlets and easy to use aliases to help you manage your Azure Site Recovery deployments.

| Deprecated cmdlet                                      | Equivalent cmdlet (AzureRm.RecoveryServices & AzureRm.RecoveryServices.SiteRecovery)        |                       Aliases                      |
|--------------------------------------------------------|---------------------------------------------------------------------------------------------|----------------------------------------------------|
| Edit-AzureRmSiteRecoveryRecoveryPlan                   | Edit-AzureRmRecoveryServicesAsrRecoveryPlan                                                 | Edit-ASRRecoveryPlan,Edit-ASRRP                    |
| Get-AzureRmSiteRecoveryFabric                          | Get-AzureRmRecoveryServicesAsrFabric                                                        | Get-ASRFabric                                      |
| Get-AzureRmSiteRecoveryJob                             | Get-AzureRmRecoveryServicesAsrJob                                                           | Get-ASRJob                                         |
| Get-AzureRmSiteRecoveryNetwork                         | Get-AzureRmRecoveryServicesAsrNetwork                                                       | Get-ASRNetwork                                     |
| Get-AzureRmSiteRecoveryNetworkMapping                  | Get-AzureRmRecoveryServicesAsrNetworkMapping                                                | Get-ASRNetworkMapping                              |
| Get-AzureRmSiteRecoveryPolicy                          | Get-AzureRmRecoveryServicesAsrPolicy                                                        | Get-ASRPolicy                                      |
| Get-AzureRmSiteRecoveryProtectableItem                 | Get-AzureRmRecoveryServicesAsrProtectableItem                                               | Get-ASRProtectableItem                             |
| Get-AzureRmSiteRecoveryProtectionContainer             | Get-AzureRmRecoveryServicesAsrProtectionContainer                                           | Get-ASRProtectionContainer                         |
| Get-AzureRmSiteRecoveryProtectionContainerMapping      | Get-AzureRmRecoveryServicesAsrProtectionContainerMapping                                    | Get-ASRProtectionContainerMapping                  |
| Get-AzureRmSiteRecoveryProtectionEntity                | Get-AzureRmRecoveryServicesAsrProtectableItem                                               | Get-ASRProtectableItem                             |
| Get-AzureRmSiteRecoveryRecoveryPlan                    | Get-AzureRmRecoveryServicesAsrRecoveryPlan                                                  | Get-ASRRecoveryPlan                                |
| Get-AzureRmSiteRecoveryRecoveryPoint                   | Get-AzureRmRecoveryServicesAsrRecoveryPoint                                                 | Get-ASRRecoveryPoint                               |
| Get-AzureRmSiteRecoveryReplicationProtectedItem        | Get-AzureRmRecoveryServicesAsrReplicationProtectedItem                                      | Get-ASRReplicationProtectedItem                    |
| Get-AzureRmSiteRecoveryServer                          | Get-AzureRmRecoveryServicesAsrServicesProvider                                              | Get-ASRServicesProvider                            |
| Get-AzureRmSiteRecoveryServicesProvider                | Get-AzureRmRecoveryServicesAsrServicesProvider                                              | Get-ASRServicesProvider                            |
| Get-AzureRmSiteRecoverySite                            | Get-AzureRmRecoveryServicesAsrFabric                                                        | Get-ASRFabric                                      |
| Get-AzureRmSiteRecoveryStorageClassification           | Get-AzureRmRecoveryServicesAsrStorageClassification                                         | Get-ASRStorageClassification                       |
| Get-AzureRmSiteRecoveryStorageClassificationMapping    | Get-AzureRmRecoveryServicesAsrStorageClassificationMapping                                  | Get-ASRStorageClassificationMapping                |
| Get-AzureRmSiteRecoveryVault                           | Get-AzureRmRecoveryServicesVault                                                            |                                                    |
| Get-AzureRmSiteRecoveryVaultSettings                   | Get-AzureRmRecoveryServicesAsrVaultContext                                                  |                                                    |
| Get-AzureRmSiteRecoveryVaultSettingsFile               | Get-AzureRmRecoveryServicesVaultSettingsFile                                                |                                                    |
| Get-AzureRmSiteRecoveryVM                              | Get-AzureRmRecoveryServicesAsrReplicationProtectedItem                                      | Get-ASRReplicationProtectedItem                    |
| Import-AzureRmSiteRecoveryVaultSettingsFile            | Import-AzureRmRecoveryServicesAsrVaultSettingsFile                                          |                                                    |
| New-AzureRmSiteRecoveryFabric                          | New-AzureRmRecoveryServicesAsrFabric                                                        | New-ASRFabric                                      |
| New-AzureRmSiteRecoveryNetworkMapping                  | New-AzureRmRecoveryServicesAsrNetworkMapping                                                | New-ASRNetworkMapping                              |
| New-AzureRmSiteRecoveryPolicy                          | New-AzureRmRecoveryServicesAsrPolicy                                                        | New-ASRPolicy                                      |
| New-AzureRmSiteRecoveryProtectionContainerMapping      | New-AzureRmRecoveryServicesAsrProtectionContainerMapping                                    | New-ASRProtectionContainerMapping                  |
| New-AzureRmSiteRecoveryRecoveryPlan                    | New-AzureRmRecoveryServicesAsrRecoveryPlan                                                  | New-ASRRecoveryPlan,New-ASRRP                      |
| New-AzureRmSiteRecoveryReplicationProtectedItem        | New-AzureRmRecoveryServicesAsrReplicationProtectedItem                                      | New-ASRReplicationProtectedItem                    |
| New-AzureRmSiteRecoverySite                            | New-AzureRmRecoveryServicesAsrFabric                                                        | New-ASRFabric                                      |
| New-AzureRmSiteRecoveryStorageClassificationMapping    | New-AzureRmRecoveryServicesAsrStorageClassificationMapping                                  | New-ASRStorageClassificationMapping                |
| New-AzureRmSiteRecoveryVault                           | New-AzureRmRecoveryServicesVault                                                            |                                                    |
| Remove-AzureRmSiteRecoveryFabric                       | Remove-AzureRmRecoveryServicesAsrFabric                                                     | Remove-ASRFabric                                   |
| Remove-AzureRmSiteRecoveryNetworkMapping               | Remove-AzureRmRecoveryServicesAsrNetworkMapping                                             | Remove-ASRNetworkMapping                           |
| Remove-AzureRmSiteRecoveryPolicy                       | Remove-AzureRmRecoveryServicesAsrPolicy                                                     | Remove-ASRPolicy                                   |
| Remove-AzureRmSiteRecoveryProtectionContainerMapping   | Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping                                 | Remove-ASRProtectionContainerMapping               |
| Remove-AzureRmSiteRecoveryRecoveryPlan                 | Remove-AzureRmRecoveryServicesAsrRecoveryPlan                                               | Remove-ASRRecoveryPlan                             |
| Remove-AzureRmSiteRecoveryReplicationProtectedItem     | Remove-AzureRmRecoveryServicesAsrReplicationProtectedItem                                   | Remove-ASRReplicationProtectedItem                 |
| Remove-AzureRmSiteRecoveryServer                       | Remove-AzureRmRecoveryServicesAsrServicesProvider / Remove-AzureRmRecoveryServicesAsrFabric |                                                    |
| Remove-AzureRmSiteRecoveryServicesProvider             | Remove-AzureRmRecoveryServicesAsrServicesProvider                                           | Remove-ASRServicesProvider                         |
| Remove-AzureRmSiteRecoverySite                         | Remove-AzureRmRecoveryServicesAsrFabric                                                     | Remove-ASRFabric                                   |
| Remove-AzureRmSiteRecoveryStorageClassificationMapping | Remove-AzureRmRecoveryServicesAsrStorageClassificationMapping                               | Remove-ASRStorageClassificationMapping             |
| Remove-AzureRmSiteRecoveryVault                        | Remove-AzureRmRecoveryServicesVault                                                         |                                                    |
| Restart-AzureRmSiteRecoveryJob                         | Restart-AzureRmRecoveryServicesAsrJob                                                       | Restart-ASRJob                                     |
| Resume-AzureRmSiteRecoveryJob                          | Resume-AzureRmRecoveryServicesAsrJob                                                        | Resume-ASRJob                                      |
| Set-AzureRmSiteRecoveryProtectionEntity                | New-AzureRmRecoveryServicesAsrReplicationProtectedItem                                      | New-ASRReplicationProtectedItem                    |
| Set-AzureRmSiteRecoveryReplicationProtectedItem        | Set-AzureRmRecoveryServicesAsrReplicationProtectedItem                                      | Set-ASRReplicationProtectedItem                    |
| Set-AzureRmSiteRecoveryVaultSettings                   | Set-AzureRmRecoveryServicesAsrVaultContext                                                  | Set-ASRVaultContext                                |
| Set-AzureRmSiteRecoveryVM                              | Set-AzureRmRecoveryServicesAsrReplicationProtectedItem                                      | Set-ASRReplicationProtectedItem                    |
| Start-AzureRmSiteRecoveryApplyRecoveryPoint            | Start-AzureRmRecoveryServicesAsrApplyRecoveryPoint                                          | Start-ASRApplyRecoveryPoint                        |
| Start-AzureRmSiteRecoveryCommitFailoverJob             | Start-AzureRmRecoveryServicesAsrCommitFailoverJob                                           | Start-ASRCommitFailover,Start-ASRCommitFailoverJob |
| Start-AzureRmSiteRecoveryPlannedFailoverJob            | Start-AzureRmRecoveryServicesAsrPlannedFailoverJob                                          | Start-ASRPlannedFailoverJob                        |
| Start-AzureRmSiteRecoveryPolicyAssociationJob          | New-AzureRmRecoveryServicesAsrProtectionContainerMapping                                    | New-ASRProtectionContainerMapping                  |
| Start-AzureRmSiteRecoveryPolicyDissociationJob         | Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping                                 | Remove-ASRProtectionContainerMapping               |
| Start-AzureRmSiteRecoveryTestFailoverJob               | Start-AzureRmRecoveryServicesAsrTestFailoverJob                                             | Start-ASRTestFailoverJob,Start-ASRTFO              |
| Start-AzureRmSiteRecoveryUnplannedFailoverJob          | Start-AzureRmRecoveryServicesAsrUnplannedFailoverJob                                        | Start-ASRUnplannedFailoverJob                      |
| Stop-AzureRmSiteRecoveryJob                            | Stop-AzureRmRecoveryServicesAsrJob                                                          | Stop-ASRJob                                        |
| Update-AzureRmSiteRecoveryPolicy                       | Update-AzureRmRecoveryServicesAsrPolicy                                                     | Update-ASRPolicy                                   |
| Update-AzureRmSiteRecoveryProtectionDirection          | Update-AzureRmRecoveryServicesAsrProtectionDirection                                        | Update-ASRProtectionDirection                      |
| Update-AzureRmSiteRecoveryRecoveryPlan                 | Update-AzureRmRecoveryServicesAsrRecoveryPlan                                               | Update-ASRRecoveryPlan                             |
| Update-AzureRmSiteRecoveryServer                       | Update-AzureRmRecoveryServicesAsrServicesProvider                                           | Update-ASRServicesProvider                         |
| Update-AzureRmSiteRecoveryServicesProvider             | Update-AzureRmRecoveryServicesAsrvCenter                                                    | Update-ASRvCenter                                  |
