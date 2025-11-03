### Example 1: Initialize SaaS resource with publisher ID and SaaS GUID
```powershell
Initialize-AzNewRelicSaaSResource -PublisherId "newrelicinc1234567891234" -SaasGuid "12345678-1234-1234-1234-123456789abc"
```

```output
SaasResourceId           : /subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/rg-newrelic/providers/NewRelic.Observability/monitors/newrelic-monitor-01/saasResources/12345678-1234-1234-1234-123456789abc
SaasResourceName         : newrelic-monitor-01
SaasResourceState        : Active
MarketplaceSubscriptionId: 12345678-1234-1234-1234-123456789abc
PlanId                   : newrelicpaygtestplan2@123456789123456@PUBIDnewrelicinc1234567891234
```

Initialize a NewRelic SaaS resource using the publisher ID and SaaS GUID to activate the marketplace subscription

### Example 2: Initialize SaaS resource using a request object
```powershell
$saasRequest = [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.ActivateSaaSParameterRequest]@{
    PublisherId = "newrelicinc1234567891234"
    SaasGuid = "12345678-1234-1234-1234-123456789abc"
}
Initialize-AzNewRelicSaaSResource -Request $saasRequest
```

```output
SaasResourceId           : /subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/rg-newrelic/providers/NewRelic.Observability/monitors/newrelic-monitor-01/saasResources/12345678-1234-1234-1234-123456789abc
SaasResourceName         : newrelic-monitor-01
SaasResourceState        : Active
MarketplaceSubscriptionId: 12345678-1234-1234-1234-123456789abc
PlanId                   : newrelicpaygtestplan2@123456789123456@PUBIDnewrelicinc1234567891234
```

Initialize a NewRelic SaaS resource by providing a request object containing the publisher ID and SaaS GUID

