---
external help file:
Module Name: Az.EdgeAction
online version: https://learn.microsoft.com/powershell/module/az.edgeaction/get-azedgeactionexecutionfilter
schema: 2.0.0
---

# Get-AzEdgeActionExecutionFilter

## SYNOPSIS
Get a EdgeActionExecutionFilter

## SYNTAX

### List (Default)
```
Get-AzEdgeActionExecutionFilter -EdgeActionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzEdgeActionExecutionFilter -EdgeActionName <String> -ExecutionFilter <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEdgeActionExecutionFilter -InputObject <IEdgeActionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityEdgeAction
```
Get-AzEdgeActionExecutionFilter -EdgeActionInputObject <IEdgeActionIdentity> -ExecutionFilter <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a EdgeActionExecutionFilter

## EXAMPLES

### Example 1: List all execution filters for an edge action
```powershell
Get-AzEdgeActionExecutionFilter -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction"
```

```output
Name      Location ProvisioningState
----      -------- -----------------
filter1   global   Succeeded
filter2   global   Succeeded
```

Lists all execution filters configured for the specified edge action.

### Example 2: Get a specific execution filter
```powershell
Get-AzEdgeActionExecutionFilter -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -ExecutionFilter "filter1"
```

```output
Name    Location ProvisioningState
----    -------- -----------------
filter1 global   Succeeded
```

Gets details of the specified execution filter.

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

### -EdgeActionInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionIdentity
Parameter Sets: GetViaIdentityEdgeAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EdgeActionName
The name of the Edge Action

```yaml
Type: System.String
Parameter Sets: Get, List
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
Parameter Sets: Get, GetViaIdentityEdgeAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionExecutionFilter

## NOTES

## RELATED LINKS

