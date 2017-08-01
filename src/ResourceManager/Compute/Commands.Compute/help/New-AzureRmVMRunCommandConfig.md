---
external help file: Microsoft.Azure.Commands.Compute.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmVMRunCommandConfig

## SYNOPSIS
Create an input object for Run command.

## SYNTAX

```
New-AzureRmVMRunCommandConfig [[-CommandId] <String>] [[-Script] <String[]>]
 [[-Parameter] <RunCommandInputParameter[]>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create an input object for Run command.

## EXAMPLES

### Example 1
```
PS C:\> $runParameter = New-AzureRmVMRunCommandConfig -CommandId $commandId -Script $script `
                       | Add-AzureRmVMRunCommandParameter -Name $arg1 -Value $value1 `
PS C:\> Set-AzureRmVMRunCommand -ResourceGroupName $rgname -Name $vmname -RunCommandInput $runParameter
```

Run the command on the given VM with the command ID, the script, and the parameters.

## PARAMETERS

### -CommandId
The run command id.

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

### -Parameter
The run command parameters.

```yaml
Type: RunCommandInputParameter[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Script
Optional. The script to be executed.  When this value is given, the given script will override the default script of the command.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
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
System.String[]
Microsoft.Azure.Management.Compute.Models.RunCommandInputParameter[]

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSRunCommandInput

## NOTES

## RELATED LINKS

