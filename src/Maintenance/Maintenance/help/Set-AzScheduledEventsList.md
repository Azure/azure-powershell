---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.dll-Help.xml
Module Name: Az.Maintenance
online version:
schema: 2.0.0
---

# Set-AzScheduledEventsList

## SYNOPSIS

Acknowledge list of ScheduledEvents of a resource

## SYNTAX

```powershell
Set-AzScheduledEventsList [-ResourceGroupName] <String> [-ResourceType] <String> [-ResourceName] <String>
 -ScheduledEventsId <String[]> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION

Acknowledge list of ScheduledEvents of a resource. Supported resources types are VirtualMachines, VirtualMachineScaleSets, AvailabilitySets.

## EXAMPLES

### Example 1

```powershell
Set-AzScheduledEventsList -ResourceGroupName testrg -ResourceType virtualMachines -ResourceName testvm -ScheduledEventsId F1574F0D-2CFC-4F5A-8C0E-F84FF8776F93
```

Acknowledge ScheduledEvents job of a VirtualMachine

### Example 2

```powershell
Set-AzScheduledEventsList -ResourceGroupName testrg -ResourceType virtualMachineScaleSets -ResourceName testvmss -ScheduledEventsId F1574F0D-2CFC-4F5A-8C0E-F84FF8776F93,CCB334AE-7404-4DE9-A7A8-54B7DB69B566
```

Acknowledge list of ScheduledEvents job of a VirtualMachineScaleSet

### Example 3

```powershell
Set-AzScheduledEventsList -ResourceGroupName testrg -ResourceType AvailabilitySets -ResourceName testavset -ScheduledEventsId F1574F0D-2CFC-4F5A-8C0E-F84FF8776F93,CCB334AE-7404-4DE9-A7A8-54B7DB69B566
```

Acknowledge list ScheduledEvents job of a AvailabilitySet

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
Position: 3
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
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ScheduledEventsId

The list of ScheduledEvents Ids.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.Management.Maintenance.Models.ScheduledEventsApproveResponse

## NOTES

## RELATED LINKS
