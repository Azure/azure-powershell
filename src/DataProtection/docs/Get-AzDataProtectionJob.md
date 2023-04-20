---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionjob
schema: 2.0.0
---

# Get-AzDataProtectionJob

## SYNOPSIS
Gets a job with id in a backup vault

## SYNTAX

### List (Default)
```
Get-AzDataProtectionJob -ResourceGroupName <String> -VaultName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDataProtectionJob -Id <String> -ResourceGroupName <String> -VaultName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataProtectionJob -InputObject <IDataProtectionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a job with id in a backup vault

## EXAMPLES

### Example 1: Get All backup Jobs in a backup vault
```powershell
Get-AzDataProtectionJob -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName sarath-rg -VaultName sarath-vault
```

```output
Name                                 Type
----                                 ----
a6a4879d-f914-4174-b129-0e27da8a4fb0 Microsoft.DataProtection/backupVaults/backupJobs
1a402664-a245-4a9d-8bb5-a6bafbb40d26 Microsoft.DataProtection/backupVaults/backupJobs
672564f7-1f91-46e2-a0ca-4fb1dc977a1c Microsoft.DataProtection/backupVaults/backupJobs
1653a7b4-8ce4-457e-8084-dc1c9d9e4106 Microsoft.DataProtection/backupVaults/backupJobs
9f21c438-ca0d-45c1-88fe-79f08a8342c7 Microsoft.DataProtection/backupVaults/backupJobs
736bab4d-480f-49f8-92ea-57c5ff203c33 Microsoft.DataProtection/backupVaults/backupJobs
```

This command gets all the backup jobs in a given backup vault.

### Example 2: Get a single Job 
```powershell
Get-AzDataProtectionJob -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -Id 4abaea8c-f53a-4bb1-9963-59f96b597165
```

```output
Name                                 Type
----                                 ----
4abaea8c-f53a-4bb1-9963-59f96b597165 Microsoft.DataProtection/backupVaults/backupJobs
```

This command returns a single job entity with given Id.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Id
The Job ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Get
Aliases: JobId

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IAzureBackupJobResource

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
  - `[ResourceGuardsName <String>]`: The name of ResourceGuard
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.
  - `[VaultName <String>]`: The name of the backup vault.

## RELATED LINKS

