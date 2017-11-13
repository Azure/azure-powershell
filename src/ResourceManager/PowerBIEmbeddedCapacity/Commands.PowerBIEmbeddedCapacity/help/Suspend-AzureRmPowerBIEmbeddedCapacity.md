---
external help file: Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.dll-Help.xml
online version: 
schema: 1.0.0
---

# Suspend-AzureRmPowerBIEmbeddedCapacity

## SYNOPSIS
Suspends an instance of PowerBI Embedded Capacity

## SYNTAX

```
Suspend-AzureRmPowerBIEmbeddedCapacity 
	[[-ResourceGroupName] <String>] 
	[-Name] <String> 
	[-PassThru] 
	[-WhatIf]
 	[-Confirm] 
	[<CommonParameters>]
```

## DESCRIPTION
The Suspend-AzureRmPowerBIEmbeddedCapacity cmdlet suspends an instance of PowerBI Embedded Capacity

## EXAMPLES

### Example 1
```
PS C:\> Suspend-AzureRmPowerBIEmbeddedCapacity -Name "testcapacity" -ResourceGroupName "testRG"
Sku                    : A1
Tier                   : PBIE_Azure
Administrators         : {{admin@microsoft.com}}
State                  : Succeeded
ProvisioningState      : Succeeded
Id                     : /subscriptions/78e47976-009f-4d4a-a961-6046cdabf459/resourceGroups/testRG/providers/Microsoft.PowerBIDedicated/capacities/testcapacity
Name                   : testcapacity
Type                   : Microsoft.PowerBIDedicated/capacities
Location               : West US
Tag                    : {}
```

This command will suspend an active capacity named testcapacity in the resourcegroup testgroup

## PARAMETERS

### -Name
Name of the PowerBI Embedded Capacity

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

### -ResourceGroupName
Name of the Azure resource group to which the capacity belongs

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Will return the deleted capacity details if the operation completes successfully

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts user to confirm whether to perform the operation

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
Describes the actions the current operation will perform without actually performing them

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Models.AzurePowerBIEmbeddedCapacity

## NOTES

## RELATED LINKS

[Get-AzureRmPowerBIEmbeddedCapacity](./Get-AzureRmPowerBIEmbeddedCapacity.md)

[Resume-AzureRmPowerBIEmbeddedCapacity](./Resume-AzureRmPowerBIEmbeddedCapacity.md)

