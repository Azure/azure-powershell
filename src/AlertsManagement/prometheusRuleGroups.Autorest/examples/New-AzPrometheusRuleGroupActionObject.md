### Example 1: Create an in-memory object for PrometheusRuleGroupAction.
```powershell
New-AzPrometheusRuleGroupActionObject -ActionGroupId /subscriptions/fffffffff-ffff-ffff-ffff-ffffffffffff/resourceGroups/MyresourceGroup/providers/microsoft.insights/actiongroups/MyActionGroup -ActionProperty @{"key1" = "value1"}

```

```output
ActionGroupId
-------------
/subscriptions/fffffffff-ffff-ffff-ffff-ffffffffffff/resourceGroups/MyresourceGroup/providers/microsoft.insights/acti…
```

Create an in-memory object for PrometheusRuleGroupAction.
