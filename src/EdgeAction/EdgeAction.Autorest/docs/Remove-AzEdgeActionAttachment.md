---
external help file:
Module Name: Az.EdgeAction
online version: https://learn.microsoft.com/powershell/module/az.edgeaction/remove-azedgeactionattachment
schema: 2.0.0
---

# Remove-AzEdgeActionAttachment

## SYNOPSIS
A long-running resource action.

## SYNTAX

### DeleteExpanded (Default)
```
Remove-AzEdgeActionAttachment -EdgeActionName <String> -ResourceGroupName <String>
 -AttachedResourceId <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Delete
```
Remove-AzEdgeActionAttachment -EdgeActionName <String> -ResourceGroupName <String>
 -Body <IEdgeActionAttachment> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzEdgeActionAttachment -InputObject <IEdgeActionIdentity> -Body <IEdgeActionAttachment>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentityExpanded
```
Remove-AzEdgeActionAttachment -InputObject <IEdgeActionIdentity> -AttachedResourceId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaJsonFilePath
```
Remove-AzEdgeActionAttachment -EdgeActionName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DeleteViaJsonString
```
Remove-AzEdgeActionAttachment -EdgeActionName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
A long-running resource action.

## EXAMPLES

### Example 1: Remove an AFD rule attachment from an edge action
```powershell
Remove-AzEdgeActionAttachment -EdgeActionName "myEdgeAction" -ResourceGroupName "myResourceGroup" -AttachedResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Cdn/profiles/myAfdProfile/rulesets/myRuleSet/rules/myRule"
```

Removes the specified AFD rule attachment from the edge action.

### Example 2: Remove an attachment using pipeline input
```powershell
Get-AzEdgeAction -Name "myEdgeAction" -ResourceGroupName "myResourceGroup" | Remove-AzEdgeActionAttachment -AttachedResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Cdn/profiles/myAfdProfile/rulesets/myRuleSet/rules/myRule"
```

Retrieves an edge action and pipes it to remove the specified AFD rule attachment.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttachedResourceId
The attached resource Id

```yaml
Type: System.String
Parameter Sets: DeleteExpanded, DeleteViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Edge action attachment information

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionAttachment
Parameter Sets: Delete, DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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
Parameter Sets: Delete, DeleteExpanded, DeleteViaJsonFilePath, DeleteViaJsonString
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
Parameter Sets: DeleteViaIdentity, DeleteViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Delete operation

```yaml
Type: System.String
Parameter Sets: DeleteViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Delete operation

```yaml
Type: System.String
Parameter Sets: DeleteViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: Delete, DeleteExpanded, DeleteViaJsonFilePath, DeleteViaJsonString
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
Type: System.String
Parameter Sets: Delete, DeleteExpanded, DeleteViaJsonFilePath, DeleteViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionAttachment

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

