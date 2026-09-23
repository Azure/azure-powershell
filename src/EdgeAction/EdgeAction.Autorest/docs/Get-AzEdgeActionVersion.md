---
external help file:
Module Name: Az.EdgeAction
online version: https://learn.microsoft.com/powershell/module/az.edgeaction/get-azedgeactionversion
schema: 2.0.0
---

# Get-AzEdgeActionVersion

## SYNOPSIS
Get a EdgeActionVersion

## SYNTAX

### List (Default)
```
Get-AzEdgeActionVersion -EdgeActionName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzEdgeActionVersion -EdgeActionName <String> -ResourceGroupName <String> -Version <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEdgeActionVersion -InputObject <IEdgeActionIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityEdgeAction
```
Get-AzEdgeActionVersion -EdgeActionInputObject <IEdgeActionIdentity> -Version <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a EdgeActionVersion

## EXAMPLES

### Example 1: Get a specific edge action version
```powershell
Get-AzEdgeActionVersion -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1"
```

Retrieves details of a specific version of an edge action.

### Example 2: List all versions of an edge action
```powershell
Get-AzEdgeActionVersion -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction"
```

Lists all versions for the specified edge action.

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

### -Version
The name of the Edge Action version

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionVersion

## NOTES

## RELATED LINKS

