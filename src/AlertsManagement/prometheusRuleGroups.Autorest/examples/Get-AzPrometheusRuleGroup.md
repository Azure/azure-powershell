### Example 1: Retrieve a Prometheus rule group definition from subscription.
```powershell
Get-AzPrometheusRuleGroup
```

```output
Name     Location ClusterName Enabled
----     -------- ----------- -------
newrule  eastus               True
newrule2 eastus               False
```

Retrieve a Prometheus rule group definition from subscription.

### Example 2: Retrieve a certain Prometheus rule group definition.
```powershell
 Get-AzPrometheusRuleGroup -RuleGroupName newrule -ResourceGroupName MyGroupName
```

```output
Name    Location ClusterName Enabled
----    -------- ----------- -------
newrule eastus               True
```

Retrieve a certain Prometheus rule group definition from ResourceGroup.

