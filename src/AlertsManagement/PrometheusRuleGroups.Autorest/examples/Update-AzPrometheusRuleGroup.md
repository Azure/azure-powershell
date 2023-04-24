### Example 1: Update an Prometheus rule group definition.
```powershell
Update-AzPrometheusRuleGroup -RuleGroupName MyRuleGroup -ResourceGroupName MyResourceGroup -Enabled:$false
```

```output
Name         Location ClusterName Enabled
----         -------- ----------- -------
MyRuleGroup  eastus               False
```

Disable certain rule group.

