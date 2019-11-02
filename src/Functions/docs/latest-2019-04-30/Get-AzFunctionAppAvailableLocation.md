---
external help file:
Module Name: Az.Functions
online version: https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azfunctionappavailablelocation
schema: 2.0.0
---

# Get-AzFunctionAppAvailableLocation

## SYNOPSIS
Gets the location where a function app for the given os and plan type is available.

## SYNTAX

```
Get-AzFunctionAppAvailableLocation [-PlanType] <String> [-OSType] <String> [[-DefaultProfile] <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the location where a function app for the given os and plan type is available.

## EXAMPLES

### Example 1: Get the locations where Premium is available for Linux.
```powershell
PS C:\> Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Linux

```

### Example 2: Get the locations where Premium is available for Windows.
```powershell
PS C:\> Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Windows

```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSType
The OS type for the service plan.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanType
The plan type.
Valid inputs: 'Premium'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20160301.IGeoRegion

## ALIASES

## NOTES

## RELATED LINKS

