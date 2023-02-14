### Example 1: Update an Prometheus rule group definition.
```powershell
 Update-AzPrometheusRuleGroup -RuleGroupName lnxRuleGroup -ResourceGroupName lnxtest -Enabled:$true
```

```output
Name         Location Interval ClusterName Enabled
----         -------- -------- ----------- -------
lnxRuleGroup East Us                       
```

Update an Prometheus rule group definition.

