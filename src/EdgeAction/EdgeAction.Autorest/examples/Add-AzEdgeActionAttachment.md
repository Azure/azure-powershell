### Example 1: Attach an AFD rule to an edge action

```powershell
Add-AzEdgeActionAttachment -EdgeActionName "myEdgeAction" -ResourceGroupName "myResourceGroup" -AttachedResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Cdn/profiles/myAfdProfile/rulesets/myRuleSet/rules/myRule"
```

Attaches an Azure Front Door rule to the specified edge action, enabling the edge action to process requests for that rule.

### Example 2: Attach an AFD rule using pipeline input

```powershell
Get-AzEdgeAction -Name "myEdgeAction" -ResourceGroupName "myResourceGroup" | Add-AzEdgeActionAttachment -AttachedResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Cdn/profiles/myAfdProfile/rulesets/myRuleSet/rules/myRule"
```

Retrieves an edge action and pipes it to attach an AFD rule.

