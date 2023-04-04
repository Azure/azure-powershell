---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/update-azdataprotectionbackupvault
schema: 2.0.0
---

# Update-AzDataProtectionBackupVault

## SYNOPSIS
Updates a BackupVault resource belonging to a resource group.
For example, updating tags for a resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDataProtectionBackupVault -ResourceGroupName <String> -VaultName <String> [-SubscriptionId <String>]
 [-AzureMonitorAlertsForAllJobFailure <AlertsState>]
 [-CrossSubscriptionRestoreState <CrossSubscriptionRestoreState>] [-IdentityType <String>]
 [-ImmutabilityState <ImmutabilityState>] [-SoftDeleteRetentionDurationInDay <Double>]
 [-SoftDeleteState <SoftDeleteState>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDataProtectionBackupVault -InputObject <IDataProtectionIdentity>
 [-AzureMonitorAlertsForAllJobFailure <AlertsState>]
 [-CrossSubscriptionRestoreState <CrossSubscriptionRestoreState>] [-IdentityType <String>]
 [-ImmutabilityState <ImmutabilityState>] [-SoftDeleteRetentionDurationInDay <Double>]
 [-SoftDeleteState <SoftDeleteState>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a BackupVault resource belonging to a resource group.
For example, updating tags for a resource.

## EXAMPLES

### Example 1: Add tags to an existing backup vault
```powershell
$tag = @{"Owner"="sarath";"Purpose"="AzureBackupTesting"}
Update-AzDataProtectionBackupVault -SubscriptionId "xxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -Tag $tag
```

```output
ETag IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location      Name         Type
---- -------------------                  ----------------                     ------------   --------      ----         ----
     2ca1d5f7-38b3-4b61-aa45-8147d7e0edbc 72f988bf-86f1-41af-91ab-2d7cd011db47 SystemAssigned centraluseuap sarath-vault Microsoft.DataProtection/backupVaults
```

The first command creates a new tag hashtable with tags and their values.
The second command adds the given tags to the backup vault.

### Example 2: Disable Azure monitor alerts for job failures
```powershell
Update-AzDataProtectionBackupVault -ResourceGroupName "rgName" -VaultName "vaultName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -AzureMonitorAlertsForAllJobFailure 'Disabled'
```

```output
Name          Location      Type                                  IdentityType
----          --------      ----                                  ------------
vaultName southeastasia Microsoft.DataProtection/backupVaults SystemAssigned
```

This command disables the monitor alerts for all the job failures for the backup vault.
Allowed values are: Enabled, Disabled.
Note that by default this setting is enabled.

### Example 3: Update vault ImmutabilityState, CrossSubscriptionRestoreState, soft delete settings
```powershell
Update-AzDataProtectionBackupVault -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -CrossSubscriptionRestoreState Disabled -ImmutabilityState Disabled -SoftDeleteRetentionDurationInDay 99 -SoftDeleteState Off
```

```output
Name          Location      Type                                  IdentityType
----          --------      ----                                  ------------
vaultName southeastasia Microsoft.DataProtection/backupVaults SystemAssigned
```

This command is used to modify Immutability state, cross subscription restore state, soft delete settings of the vault.
These parameters are optional and can be used independently.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureMonitorAlertsForAllJobFailure
Parameter to Enable or Disable built-in azure monitor alerts for job failures.
Security alerts cannot be disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AlertsState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CrossSubscriptionRestoreState
Cross subscription restore state of the vault.
Allowed values are Disabled, Enabled, PermanentlyDisabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CrossSubscriptionRestoreState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -IdentityType
The identityType which can be either SystemAssigned or None

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImmutabilityState
Immutability state of the vault.
Allowed values are Disabled, Unlocked, Locked.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ImmutabilityState
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftDeleteRetentionDurationInDay
Soft delete retention duration in days.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftDeleteState
Soft delete state of the vault.
Allowed values are Off, On, AlwaysOn.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SoftDeleteState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the backup vault.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupVaultResource

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

