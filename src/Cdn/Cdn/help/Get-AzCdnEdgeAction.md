---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/get-azcdnedgeaction
schema: 2.0.0
---

# Get-AzCdnEdgeAction

## SYNOPSIS
Get EdgeAction resource

## SYNTAX

### List (Default)
```
Get-AzCdnEdgeAction [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzCdnEdgeAction -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzCdnEdgeAction -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get EdgeAction resource

## EXAMPLES

### Example 1: List all Edge Actions in a resource group
```powershell
Get-AzCdnEdgeAction -ResourceGroupName "testps-rg-da16jm"
```

```output
Location Name          Kind ResourceGroupName
-------- ----          ---- -----------------
Global   edgeaction001      testps-rg-da16jm
Global   edgeaction002      testps-rg-da16jm
```

List all Edge Actions under the resource group

### Example 2: Get a specific Edge Action by name
```powershell
Get-AzCdnEdgeAction -ResourceGroupName "testps-rg-da16jm" -Name "edgeaction001"
```

```output
Location Name          Kind ResourceGroupName
-------- ----          ---- -----------------
Global   edgeaction001      testps-rg-da16jm
```

Get a specific Edge Action by name under the resource group

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IEdgeAction

## NOTES

## RELATED LINKS
