---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
online version: 
schema: 2.0.0
---

# Disable-AzureRmDataCollection

## SYNOPSIS
Opts out of collecting data to improve the AzurePowerShell cmdlets. 
Data is not collected unless you explicitly opt in.

## SYNTAX

```
Disable-AzureRmDataCollection [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
You can improve the experience of using the Microsoft Cloud and Azure PowerShell by opting in to data collection.
Azure PowerShell does not collect data without your consent - you must explicitly opt in by executing Enable-AzureRmDataCollection, or by answering yes when Azure PowerShell prompts you about collecting data the first time you execute a cmdlet.
Microsoft aggregates collected data to identify patterns of usage, to identify common issues and to improve the experience of using Azure PowerShell.
Microsoft Azure PowerShell does not collect any private data, or any personally identifiable information.

Run the Disable-AzureRMDataCollection cmdlet to disable data collection for the current user.
This will prevent the current user from being prompted about data collection the first time cmdlets are executed.

To enable data collection for the current user, run the Enable-AzureRmDataCollection cmdlet.

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Enable-AzureRmDataCollection]()

