### Example 1: List plans data associated with specified organization
```powershell
Get-AzNewRelicPlan -SubscriptionId 11111111-2222-3333-4444-123456789101 -OrganizationId 11111111-2222-3333-4444-123456789104
```

```output
PlanDataUsageType PlanDataBillingCycle PlanDataPlanDetail                                                                      PlanDataEffectiveDate OrgCreationSource AccountCreationSource
----------------- -------------------- ------------------                                                                      --------------------- ----------------- ---------------------
PAYG              MONTHLY              newrelicpaygtestplan2@123456789123456@PUBIDnewrelicinc1234567891234.newrelic_liftr_payg 6/28/2023 9:28:22 AM  LIFTR
```

List plans data associated with specified Organization Id

### Example 2: Link plans account with specified organization in different subscription
```powershell
Get-AzNewRelicPlan -SubscriptionId 11111111-2222-3333-4444-123456789101 -OrganizationId 11111111-2222-3333-4444-123456789104 -AccountId 1234567
```

Link plans account with specified organization in different subscription

