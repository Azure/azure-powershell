---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version: https://docs.microsoft.com/powershell/module/az.accounts/enable-azdatacollection
schema: 2.0.0
---

# Enable-AzDataCollection

## SYNOPSIS
Enables Azure PowerShell to collect data to improve the user experience with the Azure PowerShell
cmdlets. Executing this cmdlet opts in to data collection for the current user on the current
machine. Data is collected by default unless you explicitly opt out.

## SYNTAX

```
Enable-AzDataCollection [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION

The `Enable-AzDataCollection` cmdlet is used to opt in to data collection. Azure PowerShell
automatically collects telemetry data by default. Microsoft aggregates collected data to identify
patterns of usage, to identify common issues, and to improve the experience of Azure PowerShell.
Microsoft Azure PowerShell doesn't collect any private or personal data. To disable data collection,
you must explicitly opt out by executing `Disable-AzDataCollection`.

## EXAMPLES

### Example 1: Enabling data collection for the current user

The following example shows how to enable data collection for the current user.

```powershell
Enable-AzDataCollection
```

## PARAMETERS

### -DefaultProfile

The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm

Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

[Disable-AzDataCollection](./Disable-AzDataCollection.md)
