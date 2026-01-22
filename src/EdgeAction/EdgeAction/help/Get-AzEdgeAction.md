---
external help file: Az.EdgeAction-help.xml
Module Name: Az.EdgeAction
online version: https://learn.microsoft.com/powershell/module/az.edgeaction/get-azedgeaction
schema: 2.0.0
---

# Get-AzEdgeAction

## SYNOPSIS
Get a EdgeAction

## SYNTAX

### List (Default)
```
Get-AzEdgeAction [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzEdgeAction -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzEdgeAction -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEdgeAction -InputObject <IEdgeActionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a EdgeAction

## EXAMPLES

### Example 1: Get a specific edge action
```powershell
Get-AzEdgeAction -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction"
```

Retrieves details of a specific edge action.

### Example 2: List all edge actions in a resource group
```powershell
Get-AzEdgeAction -ResourceGroupName "myResourceGroup"
```

Lists all edge actions in the specified resource group.

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

### -Name
The name of the Edge Action

```yaml
Type: System.String
Parameter Sets: Get
Aliases: EdgeActionName

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
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeAction

## NOTES

## RELATED LINKS
