---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
online version: 
schema: 2.0.0
---

# Enable-AzureRmDataCollection
## SYNOPSIS
Enables Azure PowerShell to collect data to improve the user experience with AzurePowerShell cmdlets.
Executing this cmdlet opts in to data collection for the current user on the current machine.
No data is collected unless you explicitly opt in.

## SYNTAX

```
Enable-AzureRmDataCollection [-WhatIf] [-Confirm]
```

## DESCRIPTION
You can improve the experience of using the Microsoft Cloud and Azure PowerShell by opting in to data collection.
Azure PowerShell does not collect data without your consent - you must explicitly opt in by executing Enable-AzureRmDataCollection, or by answering yes when Azure PowerShell prompts you about collecting data the first time you execute a cmdlet.
Microsoft aggregates collected data to identify patterns of usage, to identify common issues and to improve the experience of using Azure PowerShell.
Microsoft Azure PowerShell does not collect any private data, or any personally identifiable information.

Run the Enable-AzureRMDataCollection cmdlet to enable data collection for the current user on the current machine.
This will prevent the current user from being prompted about data collection the first time cmdlets are executed.

To disable data collection for the current user, run the Disable-AzureRmDataCollection cmdlet.

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Confirm
{{Fill Confirm Description}}

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
{{Fill WhatIf Description}}

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

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Disable-AzureRmDataCollection]()

