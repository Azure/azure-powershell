---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/get-azcdnedgeactionexecutionfilter
schema: 2.0.0
---

# Get-AzCdnEdgeActionExecutionFilter

## SYNOPSIS
Get EdgeActionExecutionFilter resource

## SYNTAX

### List (Default)
```
Get-AzCdnEdgeActionExecutionFilter -EdgeActionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzCdnEdgeActionExecutionFilter -EdgeActionName <String> -ResourceGroupName <String>
 -ExecutionFilter <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get EdgeActionExecutionFilter resource

## EXAMPLES

### Example 1: List all Edge Action Execution Filters
```powershell
Get-AzCdnEdgeActionExecutionFilter -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001"
```

```output
Name                              : filter001
Id                                : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/executionFilters/filter001
Type                              : Microsoft.Cdn/edgeActions/executionFilters
Location                          : global
ProvisioningState                 : Succeeded
ExecutionFilterIdentifierHeaderName  : X-Filter-Key
ExecutionFilterIdentifierHeaderValue : FilterValue1
LastUpdateTime                    : 10/27/2025 10:30:45 AM

Name                              : filter002
Id                                : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/executionFilters/filter002
Type                              : Microsoft.Cdn/edgeActions/executionFilters
Location                          : global
ProvisioningState                 : Succeeded
ExecutionFilterIdentifierHeaderName  : X-Filter-Key
ExecutionFilterIdentifierHeaderValue : FilterValue2
LastUpdateTime                    : 10/27/2025 10:35:20 AM
```

List all Execution Filters of the specified Edge Action

### Example 2: Get a specific Edge Action Execution Filter by name
```powershell
Get-AzCdnEdgeActionExecutionFilter -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001" -ExecutionFilter "filter001"
```

```output
Name                              : filter001
Id                                : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001/executionFilters/filter001
Type                              : Microsoft.Cdn/edgeActions/executionFilters
Location                          : global
ProvisioningState                 : Succeeded
ExecutionFilterIdentifierHeaderName  : X-Filter-Key
ExecutionFilterIdentifierHeaderValue : FilterValue1
LastUpdateTime                    : 10/27/2025 10:30:45 AM
```

Get a specific Edge Action Execution Filter by name

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

### -EdgeActionName
The name of the Edge Action

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

### -ExecutionFilter
The name of the execution filter

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IEdgeActionExecutionFilter

## NOTES

## RELATED LINKS
