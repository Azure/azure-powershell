---
external help file: Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmPowerBIEmbeddedCapacity

## SYNOPSIS
Gets the details of an PowerBI Embedded Capacity.

## SYNTAX

```
Get-AzureRmPowerBIEmbeddedCapacity [[-ResourceGroupName] <String>] [[-Name] <String>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmPowerBIEmbeddedCapacity cmdlet gets the details of an PowerBI Embedded Capacity.

## EXAMPLES

### Example 1
```
PS C:\>Get-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName "ResourceGroup03"
```

This command gets all Azure PowerBI Embedded Capacity in the resource group named ResourceGroup03.

### Example 2: Get a capacity
```
PS C:\>Get-AzureRmPowerBIEmbeddedCapacity -ResourceGroupName "ResourceGroup03" -Name "testcapacity"
```

This command gets the Azure PowerBI Embedded Capacity named testcapacity in the resource group named ResourceGroup03.

## PARAMETERS

### -Name
Name of the PowerBI Embedded Capacity

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

### -ResourceGroupName
Name of the Azure resource group to which the capacity belongs

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Models

## NOTES
Alias: Get-AzurePBIECapacity

## RELATED LINKS

[New-AzureRmPowerBIEmbeddedCapacity ](./New-AzureRmPowerBIEmbeddedCapacity.md)

[Remove-AzureRmPowerBIEmbeddedCapacity ](./Remove-AzureRmPowerBIEmbeddedCapacity.md)