---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azdataboundaryscope
schema: 2.0.0
---

# Get-AzDataBoundaryScope

## SYNOPSIS
Get data boundary at specified scope

## SYNTAX

```
Get-AzDataBoundaryScope -Scope <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Get data boundary at specified scope

## EXAMPLES

### Example 1: Get Subscription Scoped Data Boundary
```powershell
$scope = "/subscriptions/11111111-1111-1111-1111-111111111111"
Get-AzDataBoundaryScope -Scope $scope
```

```output
Name                                    Id                                                                                      Properties 
--------                                ----                                                                                    ------------
00000000-0000-0000-0000-000000000000    /providers/Microsoft.Resources/dataBoundaries/00000000-0000-0000-0000-000000000000      dataBoundary: EU, provisioningState: Created
```

Gets the dataBoundary at the subscription scope.

### Example 2: Get Resource Group Scoped Data Boundary
```powershell
$scope =  "/subscriptions/11111111-1111-1111-1111-111111111111/resourcegroups/my-resource-group"
Get-AzDataBoundaryScope -Scope $scope
```

```output
Name                                    Id                                                                                      Properties 
--------                                ----                                                                                    ------------
00000000-0000-0000-0000-000000000000    /providers/Microsoft.Resources/dataBoundaries/00000000-0000-0000-0000-000000000000      dataBoundary: EU, provisioningState: Created
```

Gets the dataBoundary at the resource group scope.

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

### -Scope
The scope at which the operation is performed.

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

### Microsoft.Azure.PowerShell.Cmdlets.DataBoundary.Models.IDataBoundaryDefinition

## NOTES

## RELATED LINKS
