---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/update-azrecoveryservicesbackupresourcestorageconfigsnoncrr
schema: 2.0.0
---

# Update-AzRecoveryServicesBackupResourceStorageConfigsNonCrr

## SYNOPSIS
Updates vault storage model type.

## SYNTAX

### PatchExpanded (Default)
```
Update-AzRecoveryServicesBackupResourceStorageConfigsNonCrr -ResourceGroupName <String> -VaultName <String>
 [-SubscriptionId <String>] [-CrossRegionRestoreFlag] [-DedupState <DedupState>] [-ETag <String>]
 [-Location <String>] [-StorageModelType <StorageType>] [-StorageType <StorageType>]
 [-StorageTypeState <StorageTypeState>] [-Tag <Hashtable>] [-XcoolState <XcoolState>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Patch
```
Update-AzRecoveryServicesBackupResourceStorageConfigsNonCrr -ResourceGroupName <String> -VaultName <String>
 -Parameter <IBackupResourceConfigResource> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentity
```
Update-AzRecoveryServicesBackupResourceStorageConfigsNonCrr -InputObject <IRecoveryServicesIdentity>
 -Parameter <IBackupResourceConfigResource> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### PatchViaIdentityExpanded
```
Update-AzRecoveryServicesBackupResourceStorageConfigsNonCrr -InputObject <IRecoveryServicesIdentity>
 [-CrossRegionRestoreFlag] [-DedupState <DedupState>] [-ETag <String>] [-Location <String>]
 [-StorageModelType <StorageType>] [-StorageType <StorageType>] [-StorageTypeState <StorageTypeState>]
 [-Tag <Hashtable>] [-XcoolState <XcoolState>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates vault storage model type.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -CrossRegionRestoreFlag
Opt in details of Cross Region Restore feature.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DedupState
Vault Dedup state

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DedupState
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
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

### -ETag
Optional ETag.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.IRecoveryServicesIdentity
Parameter Sets: PatchViaIdentity, PatchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The resource storage details.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IBackupResourceConfigResource
Parameter Sets: Patch, PatchViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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
The name of the resource group where the recovery services vault is present.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageModelType
Storage type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.StorageType
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageType
Storage type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.StorageType
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageTypeState
Locked or Unlocked.
Once a machine is registered against a resource, the storageTypeState is always Locked.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.StorageTypeState
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription Id.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
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
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the recovery services vault.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -XcoolState
Vault x-cool state

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.XcoolState
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IBackupResourceConfigResource

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.IRecoveryServicesIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IRecoveryServicesIdentity>`: Identity Parameter
  - `[AzureRegion <String>]`: Azure region to hit Api
  - `[BackupEngineName <String>]`: Name of the backup management server.
  - `[ContainerName <String>]`: 
  - `[FabricName <String>]`: Fabric name associated with the backed up item.
  - `[Id <String>]`: Resource identity path
  - `[IntentObjectName <String>]`: Backed up item name whose details are to be fetched.
  - `[JobName <String>]`: Name of the job whose details are to be fetched.
  - `[OperationId <String>]`: Operation id
  - `[PolicyName <String>]`: Backup policy information to be fetched.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[ProtectedItemName <String>]`: 
  - `[RecoveryPointId <String>]`: 
  - `[ResourceGroupName <String>]`: The name of the resource group where the recovery services vault is present.
  - `[ResourceGuardProxyName <String>]`: 
  - `[SubscriptionId <String>]`: The subscription Id.
  - `[VaultName <String>]`: The name of the recovery services vault.

`PARAMETER <IBackupResourceConfigResource>`: The resource storage details.
  - `[ETag <String>]`: Optional ETag.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[CrossRegionRestoreFlag <Boolean?>]`: Opt in details of Cross Region Restore feature.
  - `[DedupState <DedupState?>]`: Vault Dedup state
  - `[StorageModelType <StorageType?>]`: Storage type
  - `[StorageType <StorageType?>]`: Storage type.
  - `[StorageTypeState <StorageTypeState?>]`: Locked or Unlocked. Once a machine is registered against a resource, the storageTypeState is always Locked.
  - `[XcoolState <XcoolState?>]`: Vault x-cool state

## RELATED LINKS

