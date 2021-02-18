---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.accounts/enable-azdatacollection
=======
online version: https://docs.microsoft.com/powershell/module/az.accounts/enable-azdatacollection
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Enable-AzDataCollection

## SYNOPSIS
<<<<<<< HEAD
Enables Azure PowerShell to collect data to improve the user experience with AzurePowerShell cmdlets.
Executing this cmdlet opts in to data collection for the current user on the current machine.
No data is collected unless you explicitly opt in.
=======
Enables Azure PowerShell to collect data to improve the user experience with the Azure PowerShell
cmdlets. Executing this cmdlet opts in to data collection for the current user on the current
machine. Data is collected by default unless you explicitly opt out.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## SYNTAX

```
Enable-AzDataCollection [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
<<<<<<< HEAD
You can improve the experience of using the Microsoft Cloud and Azure PowerShell by opting in to data collection.
Azure PowerShell does not collect data without your consent - you must explicitly opt in by executing Enable-AzDataCollection, or by answering yes when Azure PowerShell prompts you about collecting data the first time you execute a cmdlet.
Microsoft aggregates collected data to identify patterns of usage, to identify common issues and to improve the experience of using Azure PowerShell.
Microsoft Azure PowerShell does not collect any private data, or any personally identifiable information.
Run the Enable-AzDataCollection cmdlet to enable data collection for the current user on the current machine.
This will prevent the current user from being prompted about data collection the first time cmdlets are executed.
To disable data collection for the current user, run the Disable-AzDataCollection cmdlet.
=======

The `Enable-AzDataCollection` cmdlet is used to opt in to data collection. Azure PowerShell
automatically collects telemetry data by default. Microsoft aggregates collected data to identify
patterns of usage, to identify common issues, and to improve the experience of Azure PowerShell.
Microsoft Azure PowerShell doesn't collect any private or personal data. To disable data collection,
you must explicitly opt out by executing `Disable-AzDataCollection`.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## EXAMPLES

### Example 1: Enabling data collection for the current user
<<<<<<< HEAD
```
PS C:\> Enable-AzDataCollection
```

This example shows how to enable data collection for the current user.
=======

The following example shows how to enable data collection for the current user.

```powershell
Enable-AzDataCollection
```
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## PARAMETERS

### -DefaultProfile
<<<<<<< HEAD
The credentials, account, tenant and subscription used for communication with azure.
=======

The credentials, account, tenant, and subscription used for communication with Azure.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).
=======
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## INPUTS

### None

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

[Disable-AzDataCollection](./Disable-AzDataCollection.md)
<<<<<<< HEAD

=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
