---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionsoftdeletedbackupinstance
schema: 2.0.0
---

# Get-AzDataProtectionSoftDeletedBackupInstance

## SYNOPSIS
Gets a deleted backup instance with name in a backup vault

## SYNTAX

### List (Default)
```
Get-AzDataProtectionSoftDeletedBackupInstance -ResourceGroupName <String> -VaultName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDataProtectionSoftDeletedBackupInstance -BackupInstanceName <String> -ResourceGroupName <String>
 -VaultName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataProtectionSoftDeletedBackupInstance -InputObject <IDataProtectionIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a deleted backup instance with name in a backup vault

## EXAMPLES

### Example 1: Get soft deleted backup instances for a backup vault
```powershell
Get-AzDataProtectionSoftDeletedBackupInstance -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName
```

```output
Name
----
alrpstestvm-datadisk-000-xxxxxxxx-xxxx-alrpstestvm-datadisk-000-xxxx-xxxx-xxxxxxxx-066c-xxxx-91fc-xxxxxxxxxxxx
```

This cmdlet is used to fetch the list of backup instances which are in soft deleted state for the backup vault.

## PARAMETERS

### -BackupInstanceName
The name of the deleted backup instance

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the backup vault.

```yaml
Type: System.String
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20230501.IDeletedBackupInstanceResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IDataProtectionIdentity>`: Identity Parameter
  - `[BackupInstanceName <String>]`: The name of the backup instance.
  - `[BackupPolicyName <String>]`: 
  - `[Id <String>]`: Resource identity path
  - `[JobId <String>]`: The Job ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[Location <String>]`: The location in which uniqueness will be verified.
  - `[OperationId <String>]`: 
  - `[RecoveryPointId <String>]`: 
  - `[RequestName <String>]`: 
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceGuardProxyName <String>]`: name of the resource guard proxy
  - `[ResourceGuardsName <String>]`: The name of ResourceGuard
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.
  - `[VaultName <String>]`: The name of the backup vault.

## RELATED LINKS

