---
external help file: Microsoft.Azure.Commands.Compute.dll-Help.xml
ms.assetid: 7B3259CD-079D-4E07-8608-F818522EE7CF
online version: 
schema: 2.0.0
---

# Start-AzureRmVM

## SYNOPSIS
Starts an Azure virtual machine.

## SYNTAX

### ResourceGroupNameParameterSetName (Default)
```
Start-AzureRmVM [-Name] <String> [-ResourceGroupName] <String> [<CommonParameters>]
```

### IdParameterSetName
```
Start-AzureRmVM [-Name] <String> [-Id] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzureRmVM** cmdlet starts an Azure virtual machine.

## EXAMPLES

### Example 1: Start a virtual machine
```
PS C:\>Start-AzureRmVM -ResourceGroupName "ResourceGroup11" -Name "VirtualMachine07"
```

This command starts the virtual machine named VirtualMachine07 in ResourceGroup11.

## PARAMETERS

### -Id
Specifies the Resource ID of the virtual machine.

```yaml
Type: String
Parameter Sets: IdParameterSetName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the virtual machine to start.

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

### -ResourceGroupName
Specifies the name of the resource group of the virtual machine.

```yaml
Type: String
Parameter Sets: ResourceGroupNameParameterSetName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmVM](./Get-AzureRmVM.md)

[New-AzureRmVM](./New-AzureRmVM.md)

[Remove-AzureRmVM](./Remove-AzureRmVM.md)

[Restart-AzureRmVM](./Restart-AzureRmVM.md)

[Stop-AzureRmVM](./Stop-AzureRmVM.md)

[Update-AzureRmVM](./Update-AzureRmVM.md)


