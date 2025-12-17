### Example 1: Retrieve enterprise add-on details for a Grafana workspace
```powershell
Test-AzGrafanaEnterpriseDetail -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana
```

```output
MarketplaceTrialQuota SaasSubscriptionDetail
--------------------- ----------------------
14                    Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.SubscriptionDetails
```

Retrieves the enterprise add-on details and subscription information for the specified Azure Managed Grafana workspace.

### Example 2: Retrieve enterprise details using pipeline input
```powershell
Get-AzGrafana -ResourceGroupName azpstest-gp -Name azpstest-grafana | Test-AzGrafanaEnterpriseDetail
```

```output
MarketplaceTrialQuota SaasSubscriptionDetail
--------------------- ----------------------
14                    Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.SubscriptionDetails
```

Retrieves enterprise add-on details by piping a Grafana workspace object from Get-AzGrafana.

