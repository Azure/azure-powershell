---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesbackuppolicy
schema: 2.0.0
---

# Get-AzRecoveryServicesBackupPolicy

## SYNOPSIS
Provides the details of the backup policies associated to Recovery Services Vault.
This is an asynchronous\r\noperation.
Status of the operation can be fetched using GetPolicyOperationResult API.

## SYNTAX

### List (Default)
```
Get-AzRecoveryServicesBackupPolicy -ResourceGroupName <String> -VaultName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzRecoveryServicesBackupPolicy -PolicyName <String> -ResourceGroupName <String> -VaultName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Provides the details of the backup policies associated to Recovery Services Vault.
This is an asynchronous\r\noperation.
Status of the operation can be fetched using GetPolicyOperationResult API.

## EXAMPLES

### Example 1: Get all backup policies in a recovery services vault
```powershell
$pol = Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName "myresourcegroup" -VaultName "myvault"
$pol
```

```output
ETag Id                                                                                                                                                                           Location Name                Type
---- --                                                                                                                                                                           -------- ----                ----
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/policy1                          policy1             Microsoft.RecoveryServices/vaults/backupPolicies
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/HourlyLogBackup                  HourlyLogBackup     Microsoft.RecoveryServices/vaults/backupPolicies
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/DefaultPolicy                    DefaultPolicy       Microsoft.RecoveryServices/vaults/backupPolicies
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/policy2                          policy2             Microsoft.RecoveryServices/vaults/backupPolicies
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/testPolicy                       testPolicy          Microsoft.RecoveryServices/vaults/backupPolicies
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/EnhancedPolicy                   EnhancedPolicy      Microsoft.RecoveryServices/vaults/backupPolicies
```

Gets all the backup policies in the specified vault in the specified resource group.

### Example 2: Get info for a specific backup policy
```powershell
$pol = Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName "myresourcegroup" -VaultName "myvault" -Name "DefaultPolicy"
$pol 
```

```output
ETag Id                                                                                                                                                                           Location Name       Type
---- --                                                                                                                                                                           -------- ----       ----
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/testPolicy                       testPolicy Microsoft.RecoveryServices/vaults/backupPolicies

```

Gets info for a specific backup policy by its name in the specified vault in the specified resource group.

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

### -Filter
OData filter options.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyName
Backup policy information to be fetched.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the recovery services vault is present.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription Id.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the recovery services vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicyResource

## NOTES

ALIASES

## RELATED LINKS

