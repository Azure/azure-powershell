---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/set-azrecoveryservicesbackupresourcevaultconfig
schema: 2.0.0
---

# Set-AzRecoveryServicesBackupResourceVaultConfig

## SYNOPSIS
Updates vault security config.

## SYNTAX

### PutExpanded (Default)
```
Set-AzRecoveryServicesBackupResourceVaultConfig -ResourceGroupName <String> -VaultName <String>
 [-SubscriptionId <String>] [-EnhancedSecurityState <EnhancedSecurityState>] [-ETag <String>]
 [-IsSoftDeleteFeatureStateEditable] [-Location <String>] [-ResourceGuardOperationRequest <String[]>]
 [-SoftDeleteFeatureState <SoftDeleteFeatureState>] [-StorageModelType <StorageType>]
 [-StorageType <StorageType>] [-StorageTypeState <StorageTypeState>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Put
```
Set-AzRecoveryServicesBackupResourceVaultConfig -ResourceGroupName <String> -VaultName <String>
 -Parameter <IBackupResourceVaultConfigResource> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates vault security config.

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

### -EnhancedSecurityState
Enabled or Disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.EnhancedSecurityState
Parameter Sets: PutExpanded
Aliases:

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
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsSoftDeleteFeatureStateEditable
Is soft delete feature state editable

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Backup resource vault config details.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IBackupResourceVaultConfigResource
Parameter Sets: Put
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ResourceGuardOperationRequest
ResourceGuard Operation Requests

```yaml
Type: System.String[]
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftDeleteFeatureState
Soft Delete feature state

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.SoftDeleteFeatureState
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageModelType
Storage type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.StorageType
Parameter Sets: PutExpanded
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
Parameter Sets: PutExpanded
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
Parameter Sets: PutExpanded
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
Parameter Sets: (All)
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
Parameter Sets: PutExpanded
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IBackupResourceVaultConfigResource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IBackupResourceVaultConfigResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PARAMETER <IBackupResourceVaultConfigResource>`: Backup resource vault config details.
  - `[ETag <String>]`: Optional ETag.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[EnhancedSecurityState <EnhancedSecurityState?>]`: Enabled or Disabled.
  - `[IsSoftDeleteFeatureStateEditable <Boolean?>]`: Is soft delete feature state editable
  - `[ResourceGuardOperationRequest <String[]>]`: ResourceGuard Operation Requests
  - `[SoftDeleteFeatureState <SoftDeleteFeatureState?>]`: Soft Delete feature state
  - `[StorageModelType <StorageType?>]`: Storage type.
  - `[StorageType <StorageType?>]`: Storage type.
  - `[StorageTypeState <StorageTypeState?>]`: Locked or Unlocked. Once a machine is registered against a resource, the storageTypeState is always Locked.

## RELATED LINKS

