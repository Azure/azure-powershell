---
external help file: Microsoft.Azure.Commands.Compute.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmVMRunCommand

## SYNOPSIS
Run a command on the VM.

## SYNTAX

```
Set-AzureRmVMRunCommand [-ResourceGroupName] <String> [-VMName] <String> [-RunCommandInput] <PSRunCommandInput>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Run a command on the VM.

## EXAMPLES

### Example 1
```
PS C:\> $runParameter = New-AzureRmVMRunCommandInputConfig -CommandId $commandId -Script $script `
                       | Add-AzureRmVMRunCommandInputParameter -Name $arg1 -Value $value1 `
PS C:\> Set-AzureRmVMRunCommand -ResourceGroupName $rgname -Name $vmname -RunCommandInput $runParameter
```

Run the command on the given VM with the command ID, the script, and the parameters.

## PARAMETERS

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

### -RunCommandInput
Parameters supplied to the Run command operation.

```yaml
Type: PSRunCommandInput
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMName
The name of the virtual machine.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: 2
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSRunCommandResult

## NOTES

## RELATED LINKS

