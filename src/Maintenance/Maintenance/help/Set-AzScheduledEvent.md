---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.dll-Help.xml
Module Name: Az.Maintenance
online version:  https://learn.microsoft.com/powershell/module/az.maintenance/set-azscheduledevent
schema: 2.0.0
---

# Set-AzScheduledEvent

## SYNOPSIS
Acknowledge ScheduledEvent

## SYNTAX

```
Set-AzScheduledEvent [-ResourceGroupName] <String> [-ResourceType] <String> [-ResourceName] <String>
 [-ScheduledEventId] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Acknowledge ScheduledEvent

## EXAMPLES

### Example 1
```powershell
Set-AzScheduledEvent -ResourceGroupName testrg -ResourceType virtualMachines -ResourceName testvm -ScheduledEventId F1574F0D-2CFC-4F5A-8C0E-F84FF8776F93
```

Acknowledge Scheduledevent of a VirtualMachine

### Example 2
```powershell
Set-AzScheduledEvent -ResourceGroupName testrg -ResourceType virtualMachineScaleSets -ResourceName testvmss -ScheduledEventId F1574F0D-2CFC-4F5A-8C0E-F84FF8776F93
```

Acknowledge Scheduledevent of a VirtualMachineScaleSet

### Example 3
```powershell
Set-AzScheduledEvent -ResourceGroupName testrg -ResourceType AvailabilitySets -ResourceName testavset -ScheduledEventId F1574F0D-2CFC-4F5A-8C0E-F84FF8776F93
```

Acknowledge Scheduledevent of a AvailabilitySet

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource Group Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceName
The resource name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceType
The resource type.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ScheduledEventId
The ScheduledEvent Id

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Maintenance.Models.PSScheduledEvent

## NOTES

## RELATED LINKS
