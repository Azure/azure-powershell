---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.dll-Help.xml
Module Name: Az.Maintenance
online version: https://learn.microsoft.com/powershell/module/az.maintenance/approve-azscheduledevent
schema: 2.0.0
---

# Approve-AzScheduledEvent

## SYNOPSIS

Approves a scheduled event for a resource.

## SYNTAX

```powershell
Approve-AzScheduledEvent [-ResourceGroupName] <String> [-ResourceType] <String> [-ResourceName] <String>
 [-ScheduledEventId] <String> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION

Approves a scheduled event for a virtual machine, virtual machine scale set, or availability set.

## EXAMPLES

### Example 1

```powershell
Approve-AzScheduledEvent -ResourceGroupName testrg -ResourceType virtualMachines -ResourceName testvm -ScheduledEventId F1574F0D-2CFC-4F5A-8C0E-F84FF8776F93
```

Approves a scheduled event for a virtual machine.

## PARAMETERS

### -AcquirePolicyToken

Acquire an Azure Policy token automatically for this resource operation.

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

### -ChangeReference

The change reference resource ID for this resource operation.

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

### -DefaultProfile

The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction

{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName

The resource Group Name.

```yaml
Type: System.String
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceType

The Microsoft.Compute resource type.
Supported values are `virtualMachines`, `virtualMachineScaleSets`, and `availabilitySets`.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: virtualMachines, virtualMachineScaleSets, availabilitySets

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ScheduledEventId

ScheduledEvents Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

## OUTPUTS

### Microsoft.Azure.Management.Maintenance.Models.ScheduledEventsApproveResponse

### Microsoft.Azure.Management.Maintenance.Models.MaintenanceError

## NOTES

## RELATED LINKS
