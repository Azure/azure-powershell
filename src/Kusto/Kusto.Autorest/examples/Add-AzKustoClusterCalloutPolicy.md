### Example 1: Adding two callout policies to a cluster
```powershell
$kustoCalloutPolicy = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.ICalloutPolicy]@{
    calloutType = "kusto"
    outboundAccess = "Allow"
    calloutUriRegex = "*"
}
$sqlCalloutPolicy = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.ICalloutPolicy]@{
    calloutType = "sql"
    outboundAccess = "Deny"
    calloutUriRegex = "*"
}
Add-AzKustoClusterCalloutPolicy -ResourceGroupName rg1 -ClusterName cluster1 -SubscriptionId sub -Value @($kustoCalloutPolicy, $sqlCalloutPolicy)
```

The above command adds the two defined callout policies to cluster1 in rg1.
