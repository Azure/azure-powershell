### Example 1: Get the list of of available operations
```powershell
Get-AzDataProtectionOperation
```

```output
IsDataAction Name                                                                                                Origin
------------ ----                                                                                                ------
             Microsoft.DataProtection/locations/getBackupStatus/action                                           user
             Microsoft.DataProtection/backupVaults/backupInstances/write                                         user
             Microsoft.DataProtection/backupVaults/backupInstances/delete                                        user
             Microsoft.DataProtection/backupVaults/backupInstances/read                                          user
             Microsoft.DataProtection/backupVaults/backupInstances/read                                          user
             Microsoft.DataProtection/backupVaults/backupInstances/backup/action                                 user
             Microsoft.DataProtection/backupVaults/backupInstances/sync/action                                   user
             Microsoft.DataProtection/backupVaults/backupInstances/operationResults/read                         user
             Microsoft.DataProtection/backupVaults/backupInstances/stopProtection/action                         user
             Microsoft.DataProtection/backupVaults/backupInstances/suspendBackups/action                         user
             Microsoft.DataProtection/backupVaults/backupInstances/resumeProtection/action                       user
             Microsoft.DataProtection/backupVaults/backupInstances/resumeBackups/action                          user
             Microsoft.DataProtection/backupVaults/backupInstances/validateRestore/action                        user
             Microsoft.DataProtection/backupVaults/backupInstances/restore/action                                user
             Microsoft.DataProtection/backupVaults/backupPolicies/write                                          user
             Microsoft.DataProtection/backupVaults/backupPolicies/delete                                         user
             Microsoft.DataProtection/backupVaults/backupPolicies/read                                           user
             Microsoft.DataProtection/backupVaults/backupPolicies/read                                           user
             Microsoft.DataProtection/backupVaults/backupResourceGuardProxies/read                               user
             Microsoft.DataProtection/backupVaults/backupResourceGuardProxies/read                               user
             Microsoft.DataProtection/backupVaults/backupResourceGuardProxies/write                              user
             Microsoft.DataProtection/backupVaults/backupResourceGuardProxies/delete                             user
             Microsoft.DataProtection/backupVaults/backupResourceGuardProxies/unlockDelete/action                user
             Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints/read                           user
             Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints/read                           user
             Microsoft.DataProtection/backupVaults/backupInstances/findRestorableTimeRanges/action               user
             Microsoft.DataProtection/backupVaults/write                                                         user
             Microsoft.DataProtection/backupVaults/read                                                          user
             Microsoft.DataProtection/backupVaults/delete                                                        user
             Microsoft.DataProtection/backupVaults/operationResults/read                                         user
             Microsoft.DataProtection/locations/checkNameAvailability/action                                     user
             Microsoft.DataProtection/backupVaults/read                                                          user
             Microsoft.DataProtection/backupVaults/read                                                          user
             Microsoft.DataProtection/subscriptions/resourceGroups/providers/resourceGuards/write                user
             Microsoft.DataProtection/subscriptions/resourceGroups/providers/resourceGuards/read                 user
             Microsoft.DataProtection/subscriptions/resourceGroups/providers/resourceGuards/delete               user
             Microsoft.DataProtection/subscriptions/resourceGroups/providers/resourceGuards/read                 user
             Microsoft.DataProtection/subscriptions/providers/resourceGuards/read                                user
             Microsoft.DataProtection/subscriptions/resourceGroups/providers/resourceGuards/write                user
             Microsoft.DataProtection/subscriptions/resourceGroups/providers/resourceGuards/{operationName}/read user
             Microsoft.DataProtection/subscriptions/resourceGroups/providers/resourceGuards/{operationName}/read user
             Microsoft.DataProtection/subscriptions/providers/locations/checkFeatureSupport/action               user
             Microsoft.DataProtection/locations/operationStatus/read                                             user
             Microsoft.DataProtection/backupVaults/operationStatus/read                                          user
             Microsoft.DataProtection/subscriptions/resourceGroups/providers/operationStatus/read                user
             Microsoft.DataProtection/locations/operationResults/read                                            user
             Microsoft.DataProtection/backupVaults/validateForBackup/action                                      user
             Microsoft.DataProtection/backupVaults/backupJobs/read                                               user
             Microsoft.RecoveryServices/Vaults/backupJobs/read                                                   user
             Microsoft.DataProtection/register/action                                                            user
             Microsoft.DataProtection/unregister/action                                                          user
             Microsoft.DataProtection/operations/read                                                            user
```

The above command gets the list of available operations.

