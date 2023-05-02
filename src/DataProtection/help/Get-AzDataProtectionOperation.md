---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionoperation
schema: 2.0.0
---

# Get-AzDataProtectionOperation

## SYNOPSIS
Returns the list of available operations.

## SYNTAX

```
Get-AzDataProtectionOperation [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns the list of available operations.

## EXAMPLES

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

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IClientDiscoveryValueForSingleApi

## NOTES

ALIASES

## RELATED LINKS

