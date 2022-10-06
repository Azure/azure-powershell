---
external help file:
Module Name: Az.SoftwarePlanRp
online version: https://docs.microsoft.com/en-us/powershell/module/az.softwareplanrp/get-azsoftwareplanrphybridusebenefitrevision
schema: 2.0.0
---

# Get-AzSoftwarePlanRpHybridUseBenefitRevision

## SYNOPSIS
Gets the version history of a hybrid use benefit

## SYNTAX

```
Get-AzSoftwarePlanRpHybridUseBenefitRevision -PlanId <String> -Scope <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the version history of a hybrid use benefit

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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

### -PlanId
This is a unique identifier for a plan.
Should be a guid.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope at which the operation is performed.
This is limited to Microsoft.Compute/virtualMachines and Microsoft.Compute/hostGroups/hosts for now

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.SoftwarePlanRp.Models.Api20191201.IHybridUseBenefitModel

## NOTES

ALIASES

## RELATED LINKS

