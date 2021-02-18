---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.accounts/disable-azdatacollection
=======
online version: https://docs.microsoft.com/powershell/module/az.accounts/disable-azdatacollection
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Disable-AzDataCollection

## SYNOPSIS
<<<<<<< HEAD
Opts out of collecting data to improve the AzurePowerShell cmdlets. 
Data is not collected unless you explicitly opt in.
=======
Opts out of collecting data to improve the Azure PowerShell cmdlets. Data is collected by default
unless you explicitly opt out.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## SYNTAX

```
Disable-AzDataCollection [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
<<<<<<< HEAD
You can improve the experience of using the Microsoft Cloud and Azure PowerShell by opting in to data collection.
Azure PowerShell does not collect data without your consent - you must explicitly opt in by executing Enable-AzDataCollection, or by answering yes when Azure PowerShell prompts you about collecting data the first time you execute a cmdlet.
Microsoft aggregates collected data to identify patterns of usage, to identify common issues and to improve the experience of using Azure PowerShell.
Microsoft Azure PowerShell does not collect any private data, or any personally identifiable information.
Run the Disable-AzDataCollection cmdlet to disable data collection for the current user.
This will prevent the current user from being prompted about data collection the first time cmdlets are executed.
To enable data collection for the current user, run the Enable-AzDataCollection cmdlet.
=======

The `Disable-AzDataCollection` cmdlet is used to opt out of data collection. Azure PowerShell
automatically collects telemetry data by default. To disable data collection, you must explicitly
opt-out. Microsoft aggregates collected data to identify patterns of usage, to identify common
issues, and to improve the experience of Azure PowerShell. Microsoft Azure PowerShell doesn't
collect any private or personal data. If you've previously opted out, run the
`Enable-AzDataCollection` cmdlet to re-enable data collection for the current user on the current
machine.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## EXAMPLES

### Example 1: Disabling data collection for the current user
<<<<<<< HEAD
```
PS C:\> Disable-AzDataCollection
```

This example shows how to disable data collection for the current user. 
=======

The following example shows how to disable data collection for the current user.

```powershell
Disable-AzDataCollection
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

[Enable-AzDataCollection](./Enable-AzDataCollection.md)
<<<<<<< HEAD

=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
