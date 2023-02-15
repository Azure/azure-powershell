---
external help file:
Module Name: Az.Automanage
online version: https://learn.microsoft.com/powershell/module/az.automanage/get-azautomanagebestpractice
schema: 2.0.0
---

# Get-AzAutomanageBestPractice

## SYNOPSIS
Get information about a Automanage best practice

## SYNTAX

### List (Default)
```
Get-AzAutomanageBestPractice [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAutomanageBestPractice -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get information about a Automanage best practice

## EXAMPLES

### Example 1: List all Automanage best practices under a subscription
```powershell
Get-AzAutomanageBestPractice
```

```output
Name
----
AzureBestPracticesProduction
AzureBestPracticesDevTest
```

This commmand lists all Automanage best practices under a subscription.

### Example 2: Get information about a Automanage best practice by name
```powershell
Get-AzAutomanageBestPractice -Name AzureBestPracticesProduction
```

```output
Name
----
AzureBestPracticesProduction
```

This command gets information about a Automanage best practice by name.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The Automanage best practice name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: BestPracticeName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IBestPractice

## NOTES

ALIASES

## RELATED LINKS

