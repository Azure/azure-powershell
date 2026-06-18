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
 [-SubscriptionId <String[]>] -ExecutionFilter <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get EdgeActionExecutionFilter resource

## EXAMPLES

### Example 1: List execution filters for an EdgeAction
```powershell
Get-AzCdnEdgeActionExecutionFilter -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001
```

Lists execution filters under the specified EdgeAction resource.

### Example 2: Get an execution filter
```powershell
Get-AzCdnEdgeActionExecutionFilter -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -ExecutionFilter filter001
```

Gets the specified EdgeAction execution filter.

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
