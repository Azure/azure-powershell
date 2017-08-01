---
external help file: Microsoft.Azure.Commands.Compute.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmVMRunCommandParameter

## SYNOPSIS
Remove a parameter from a Run command input object.

## SYNTAX

```
Remove-AzureRmVMRunCommandParameter [-RunCommandInput] <PSRunCommandInput> [-Name] <String> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Remove a parameter from a Run command input object.

## EXAMPLES

### Example 1
```
PS C:\> $runParameter = New-AzureRmVMRunCommandConfig -CommandId $commandId -Script $script `
                       | Add-AzureRmVMRunCommandParameter -Name $arg1 -Value $value1 `
PS C:\> $runParameter = Remove-AzureVMRunCommandParameter -RunCommandInput $runParameter -Name $arg1
PS C:\> Set-AzureRmVMRunCommand -ResourceGroupName $rgname -Name $vmname -RunCommandInput $runParameter
```

Run the command on the given VM with the command ID and the script after removing the parameter.

## PARAMETERS

### -Name
The run command parameter name.

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
Input object for Run command.

```yaml
Type: PSRunCommandInput
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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

### Microsoft.Azure.Commands.Compute.Automation.Models.PSRunCommandInput
System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSRunCommandInput

## NOTES

## RELATED LINKS

