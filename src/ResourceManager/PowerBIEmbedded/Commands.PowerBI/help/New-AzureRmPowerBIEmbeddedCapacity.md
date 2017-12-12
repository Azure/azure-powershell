---
Download Help Link: None_Azure
external help file: Microsoft.Azure.Commands.PowerBI.dll-Help.xml
Help Version: 0.0.1.0
Locale: en-US
Module Guid: acace26c-1775-4100-85c0-20c4d71eaa22
Module Name: AzureRM.PowerBIEmbedded
schema: 2.0.0
---

# New-AzureRmPowerBIEmbeddedCapacity

## SYNOPSIS
Creates a new PowerBI Embedded Capacity.

## SYNTAX

```
New-AzureRmPowerBIEmbeddedCapacity 
	[-ResourceGroupName] <String> 
	[-Name] <String> 
	[-Location] <String>
 	[-Sku] <String> 
	[-Administrator] <String>
	[[-Tag] <Hashtable>] 
 	[-WhatIf] 
	[-Confirm] 
	[<CommonParameters>]
```

## DESCRIPTION
The New-AzureRmPowerBIEmbeddedCapacity cmdlet creates a new PowerBI Embedded Capacity

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName "testRG" -Name "testcapacity" -Location "West Central US" -Sku "A1" -Administrator admin@microsoft.com
Type                   : Microsoft.PowerBIDedicated/capacities
Id                     : /subscriptions/78e47976-.../resourceGroups/testRG/providers/Microsoft.PowerBIDedicated/capacities/testcapacity
ResourceGroup          : testRG
Name                   : testcapacity
Location               : West Central US
State                  : Succeeded
Administrator          : {admin@microsoft.com}
Sku                    : A1
Tier                   : PBIE_Azure
Tag                    : {}
```

Creates a capacity named testcapacity in the Azure region West Central US and in resource group testRG. The sku level for the capacity will be A1.

## PARAMETERS

### -ResourceGroupName
Name of the Azure resource group to which the capacity belongs

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept wildcard characters: False
```

### -Name
Name of the PowerBI Embedded Capacity

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept wildcard characters: False
```

### -Location
The Azure region where the PowerBI Embedded Capacity is hosted

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept wildcard characters: False
```

### -Sku
The name of the Sku for the capacity.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: A1, A2, A3, A4, A5, A6

Required: True
Position: 3
Default value: None
Accept wildcard characters: False
```

### -Administrator
A comma separated capacity names to set as administrator on the capacity

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: True
Position: 4
Default value: None
Accept wildcard characters: False
```

### -Tag
Key-value pairs in the form of a hash table set as tags on the capacity.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: 

Required: False
Default value: None
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

### Microsoft.Azure.Commands.PowerBI.Models.PSPowerBIEmbeddedCapacity

## NOTES

## RELATED LINKS

[Get-AzureRmPowerBIEmbeddedCapacity](./Get-AzureRmPowerBIEmbeddedCapacity.md)

[Remove-AzureRmPowerBIEmbeddedCapacity](./Remove-AzureRmPowerBIEmbeddedCapacity.md)
