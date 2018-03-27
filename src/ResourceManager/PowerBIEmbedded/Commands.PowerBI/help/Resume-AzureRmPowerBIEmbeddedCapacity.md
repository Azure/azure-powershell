---
external help file: Microsoft.Azure.Commands.PowerBI.dll-Help.xml
Module Name: AzureRM.PowerBIEmbedded
ms.assetid: 5321FC62-3585-4493-A3D2-22CD82503CA7
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.powerbiembedded/resume-azurermpowerbiembeddedcapacity
schema: 2.0.0
---

# Resume-AzureRmPowerBIEmbeddedCapacity

## SYNOPSIS
Resumes an instance of PowerBI Embedded Capacity.

## SYNTAX

```
Resume-AzureRmPowerBIEmbeddedCapacity 
	[-Name] <String> 
	[[-ResourceGroupName] <String>] 
	[-PassThru] 
	[-WhatIf]
 	[-Confirm] 
	[<CommonParameters>]
```

## DESCRIPTION
The Resume-AzureRmPowerBIEmbeddedCapacity cmdlet resumes an instance of PowerBI Embedded Capacity

## EXAMPLES

### Example 1
```
PS C:\> Resume-AzureRmPowerBIEmbeddedCapacity -Name "testcapacity" -ResourceGroupName "testRG" -PassThru
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

This command will resume a paused capacity named testcapacity in the resourcegroup testRG

## PARAMETERS

### -Name
Name of the PowerBI Embedded Capacity

```yaml
Type: String
Parameter Sets: ByNameAndResourceGroup
Aliases: 

Required: True
Position: 0
Default value: None
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Azure resource group to which the capacity belongs

```yaml
Type: String
Parameter Sets: ByNameAndResourceGroup
Aliases: 

Required: False
Default value: None
Accept wildcard characters: False
```

### -ResourceId
Azure resource ID

```yaml
Type: String
Parameter Sets: ByResourceId
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
Input object for Piping

```yaml
Type: PSPowerBIEmbeddedCapacity
Parameter Sets: ByInputObject
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### None
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.Commands.PowerBI.Models.PSPowerBIEmbeddedCapacity

## NOTES

## RELATED LINKS

[Get-AzureRmPowerBIEmbeddedCapacity](./Get-AzureRmPowerBIEmbeddedCapacity.md)

[Suspend-AzureRmPowerBIEmbeddedCapacity](./Suspend-AzureRmPowerBIEmbeddedCapacity.md)
