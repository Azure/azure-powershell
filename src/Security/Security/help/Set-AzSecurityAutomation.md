---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-help.xml
Module Name: Az.Security
online version:
schema: 2.0.0
---

# Set-AzSecurityAutomation

## SYNOPSIS
Creates or updates a security automation. If a security automation is already created and a subsequent request is issued for the same automation id, then it will be updated.

## SYNTAX

## DESCRIPTION
Creates or updates a security automation. If a security automation is already created and a subsequent request is issued for the same automation id, then it will be updated.

## EXAMPLES

### Example 1
```powershell
Set-AzSecurityAutomation -ResourceGroupName rg -Name automationTest -Location centralus -Description "Test automation creation" -Scopes $scopes -Sources $sources -Actions $actions
```

Creates or updates security automation 'automationTest' under resource group 'rg'

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Security.Models.Automations.PSSecurityAutomation

## OUTPUTS

### Microsoft.Azure.Commands.Security.Models.Automations.PSSecurityAutomation

## NOTES

## RELATED LINKS
