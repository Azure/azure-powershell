### Example 1: Retrieve Prometheus rule group definitions in a resource group.
```powershell
Get-AzPrometheusRuleGroup -ResourceGroupName MyResourceGroup
```

```output
Name         Location Interval ClusterName Enabled
----         -------- -------- ----------- -------
RuleGroup1   East Us                       False
RuleGroup2   East Us
```

Retrieve Prometheus rule group definitions in a resource group.

### Example 2: Retrieve a Prometheus rule group definition.
```powershell
Get-AzPrometheusRuleGroup -ResourceGroupName lnxtest -RuleGroupName RuleGroup2
```

```output
Name       Location Interval ClusterName Enabled
----       -------- -------- ----------- -------
RuleGroup2 East Us

```

Retrieve a Prometheus rule group definition.

