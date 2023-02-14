### Example 1: Create a Prometheus rule group definition.
```powershell
ew-AzPrometheusRuleGroup -ResourceGroupName MyResourceGroup -RuleGroupName RuleGroup1 -Location "East Us" -Rule $rule -Scope "/subscriptions/{subscription}/resourcegroups/MyResourceGroup/providers/microsoft.monitor/accounts/MyMonitor"
```

```output
Name       Location Interval ClusterName Enabled
----       -------- -------- ----------- -------
RuleGroup2 East Us
```

Create a Prometheus rule group definition.
