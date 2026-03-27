### Example 1: Resubscribe NewRelic monitor to Azure Marketplace billing
```powershell
Invoke-AzNewRelicResubscribeMonitor -MonitorName "test-01" -ResourceGroupName "ps-test" -OrganizationId "987654321" -PlanId "newrelicpaygtestplan3@123456789123456@PUBIDnewrelicinc1234567891234" -PublisherId "newrelicinc1234567891234" -OfferId "newrelic-pay-as-you-go"
```

```output
Location        Name     SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------        ----     -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus          test-01  6/27/2023 8:30:45 AM  user1@outlook.com     User                    6/27/2023 10:45:30 AM    user1@outlook.com        User                         ps-test
```

Resubscribes the NewRelic organization to be billed through Azure Marketplace with a new plan

### Example 2: Resubscribe monitor using resubscribe properties object
```powershell
$resubscribeProps = @{
    OrganizationId = "987654321"
    PlanId = "newrelicpaygtestplan3@123456789123456@PUBIDnewrelicinc1234567891234"
    PublisherId = "newrelicinc1234567891234"
    OfferId = "newrelic-pay-as-you-go"
    TermId = "hjdtn7tfq3ka3"
    ResourceGroup = "ps-test-new"
    SubscriptionId = "22222222-3333-4444-5555-666666666666"
}
Invoke-AzNewRelicResubscribeMonitor -MonitorName "test-01" -ResourceGroupName "ps-test" -Body $resubscribeProps
```

```output
Location        Name     SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------        ----     -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus          test-01  6/27/2023 8:30:45 AM  user1@outlook.com     User                    6/27/2023 10:45:30 AM    user1@outlook.com        User                         ps-test
```

Resubscribes the NewRelic monitor using a properties object containing all resubscription details including new subscription and resource group

