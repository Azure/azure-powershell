---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azdataboundarytenant
schema: 2.0.0
---

# Get-AzDataBoundaryTenant

## SYNOPSIS
Get data boundary of tenant.

## SYNTAX

```
Get-AzDataBoundaryTenant [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get data boundary of tenant.

## EXAMPLES

### Example 1: Get Tenant Level Data Boundary
```powershell
Get-AzDataBoundaryTenant
```

```output
Name                                    Id                                                                                      Properties 
--------                                ----                                                                                    ------------
00000000-0000-0000-0000-000000000000    /providers/Microsoft.Resources/dataBoundaries/00000000-0000-0000-0000-000000000000      dataBoundary: EU, provisioningState: Created
```

Gets the dataBoundary at the tenant level.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBoundary.Models.IDataBoundaryDefinition

## NOTES

## RELATED LINKS
