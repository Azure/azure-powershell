### Example 1: List callout policies to a cluster
```powershell

Get-AzKustoClusterCalloutPolicy -ResourceGroupName rg1 -ClusterName cluster1 -SubscriptionId sub

```

```output
CalloutId           CalloutType       CalloutUriRegex OutboundAccess
---------           -----------       --------------- --------------
*_cosmosdb          cosmosdb          *               Allow
*_postgresql        postgresql        *               Deny
*_sandbox_artifacts sandbox_artifacts *               Allow
*_genevametrics     genevametrics     *               Deny
*_kusto             kusto             *               Allow
*_sql               sql               *               Deny
```

The above command returns a list of the callout policies of cluster1 in rg1.