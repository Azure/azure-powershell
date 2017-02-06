---
external help file: Microsoft.Azure.Commands.Compute.dll-Help.xml
ms.assetid: 7C3CF963-6F1A-444C-B90C-C1D24F89204D
online version: 
schema: 2.0.0
---

# Stop-AzureRmVM

## SYNOPSIS
Stops an Azure virtual machine.

## SYNTAX

### InvokeByDynamicParameters (Default)
```
Stop-AzureRmVM [-ResourceGroupName] <String> -VMName <String> [-Force] [<CommonParameters>]
```

### InvokeByDynamicParametersForFriendMethod
```
Stop-AzureRmVM [-ResourceGroupName] <String> -VMName <String> [-Force] [-StayProvisioned] [<CommonParameters>]
```

## DESCRIPTION
The **Stop-AzureRmVM** cmdlet stops an Azure virtual machine.

## EXAMPLES

### Example 1: Stop a virtual machine
```
PS C:\>Stop-AzureRmVM -ResourceGroupName "ResourceGroup11" -Name "VirtualMachine07"
```

This command stops the virtual machine named VirtualMachine07 in ResourceGroup11.

## PARAMETERS

### -Force
Forces the command to run without asking for user confirmation.

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

### -ResourceGroupName
Specifies the name of the resource group of the virtual machine.

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

### -StayProvisioned
Indicates that this cmdlet uses the stay provisioned setting.

```yaml
Type: SwitchParameter
Parameter Sets: InvokeByDynamicParametersForFriendMethod
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMName
Specifies the name of the virtual machine.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: Named
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

[Start-AzureRmVM](./Start-AzureRmVM.md)

[Update-AzureRmVM](./Update-AzureRmVM.md)


