---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/update-azrecoveryservicesreplicationmigrationitem
schema: 2.0.0
---

# Update-AzRecoveryServicesReplicationMigrationItem

## SYNOPSIS
The operation to update the recovery settings of an ASR migration item.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzRecoveryServicesReplicationMigrationItem -FabricName <String> -MigrationItemName <String>
 -ProtectionContainerName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-ProviderSpecificDetailInstanceType <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzRecoveryServicesReplicationMigrationItem -FabricName <String> -MigrationItemName <String>
 -ProtectionContainerName <String> -ResourceGroupName <String> -ResourceName <String>
 -Input <IUpdateMigrationItemInput> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to update the recovery settings of an ASR migration item.

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

### -FabricName
Fabric name.

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

### -Input
Update migration item input.
To construct, see NOTES section for INPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IUpdateMigrationItemInput
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MigrationItemName
Migration item name.

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

### -ProtectionContainerName
Protection container name.

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

### -ProviderSpecificDetailInstanceType
The class type.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IUpdateMigrationItemInput

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IMigrationItem

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUT <IUpdateMigrationItemInput>`: Update migration item input.
  - `[ProviderSpecificDetailInstanceType <String>]`: The class type.

## RELATED LINKS

