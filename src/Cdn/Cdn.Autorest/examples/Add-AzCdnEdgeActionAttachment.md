### Example 1: Add an EdgeAction attachment
```powershell
Add-AzCdnEdgeActionAttachment -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -AttachedResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/profiles/fdp001/ruleSets/ruleset001/rules/rule001"
```

Adds the specified Front Door rule as an attachment to the EdgeAction resource.
