### Example 1: Get latest linked SaaS resource for a NewRelic monitor
```powershell
Invoke-AzNewRelicLatestMonitorLinkedSaaS -MonitorName "test-01" -ResourceGroupName "ps-test"
```

```output
SaasResourceId           : /subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/ps-test/providers/NewRelic.Observability/monitors/test-01/saasResources/12345678-1234-1234-1234-123456789abc
SaasResourceName         : test-01-saas
SaasResourceState        : Active
MarketplaceSubscriptionId: 12345678-1234-1234-1234-123456789abc
PlanId                   : newrelicpaygtestplan2@123456789123456@PUBIDnewrelicinc1234567891234
OrganizationId           : 987654321
AccountId                : 123456789
CreatedDate              : 6/27/2023 8:30:45 AM
LastModifiedDate         : 6/27/2023 8:30:45 AM
```

Retrieves the latest SaaS resource linked to the specified NewRelic monitor

### Example 2: Get latest linked SaaS resource using pipeline
```powershell
$monitor = Get-AzNewRelicMonitor -Name "test-01" -ResourceGroupName "ps-test"
$monitor | Invoke-AzNewRelicLatestMonitorLinkedSaaS
```

```output
SaasResourceId           : /subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/ps-test/providers/NewRelic.Observability/monitors/test-01/saasResources/12345678-1234-1234-1234-123456789abc
SaasResourceName         : test-01-saas
SaasResourceState        : Active
MarketplaceSubscriptionId: 12345678-1234-1234-1234-123456789abc
PlanId                   : newrelicpaygtestplan2@123456789123456@PUBIDnewrelicinc1234567891234
OrganizationId           : 987654321
AccountId                : 123456789
CreatedDate              : 6/27/2023 8:30:45 AM
LastModifiedDate         : 6/27/2023 8:30:45 AM
```

Retrieves the latest SaaS resource linked to the NewRelic monitor using pipeline input

