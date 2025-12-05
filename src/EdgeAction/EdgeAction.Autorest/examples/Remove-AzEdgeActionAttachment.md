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

