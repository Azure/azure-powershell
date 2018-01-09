---
Download Help Link: None_Azure
external help file: Microsoft.Azure.Commands.PowerBI.dll-Help.xml
Help Version: 0.0.1.0
Locale: en-US
Module Guid: acace26c-1775-4100-85c0-20c4d71eaa22
Module Name: AzureRM.PowerBIEmbedded
schema: 2.0.0
---

# Test-AzureRmPowerBIEmbeddedCapacity

## SYNOPSIS
Tests the existence of an instance of PowerBI Embedded Capacity.

## SYNTAX

```
Test-AzureRmPowerBIEmbeddedCapacity 
	[-Name] <String> 
	[<CommonParameters>]
```

## DESCRIPTION
The Test-AzureRmPowerBIEmbeddedCapacity cmdlet tests the existence of an instance of PowerBI Embedded Capacity

## EXAMPLES

### Example 1
```
PS C:\> Test-AzureRmPowerBIEmbeddedCapacity -Name "testcapacity"
True
```

This command will test if there is a capacity named testcapacity

## PARAMETERS

### -Name
Name of the PowerBI Embedded Capacity

```yaml
Type: String
Aliases: 

Required: True
Position: 0
Default value: None
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzureRmPowerBIEmbeddedCapacity](./Get-AzureRmPowerBIEmbeddedCapacity.md)

[Remove-AzureRmPowerBIEmbeddedCapacity](./Remove-AzureRmPowerBIEmbeddedCapacity.md)
