### Example 1: List plans data associated with specified organization
```powershell
Get-AzNewRelicPlan -SubscriptionId 272c26cb-7026-4b37-b190-7cb7b2abecb0 -OrganizationId 9c5445c7-65e3-4bd5-8581-80c65584100f
```

```output
PlanDataUsageType PlanDataBillingCycle PlanDataPlanDetail                                                                      PlanDataEffectiveDate OrgCreationSource AccountCreationSource
----------------- -------------------- ------------------                                                                      --------------------- ----------------- ---------------------
PAYG              MONTHLY              newrelicpaygtestplan2@TIDgmz7xq9ge3py@PUBIDnewrelicinc1635200720692.newrelic_liftr_payg 6/28/2023 9:28:22 AM  LIFTR
```

List plans data associated with specified Organization Id

### Example 2: Link plans account with specified organization in different subscription
```powershell
Get-AzNewRelicPlan -SubscriptionId 272c26cb-7026-4b37-b190-7cb7b2abecb0 -OrganizationId 9c5445c7-65e3-4bd5-8581-80c65584100f -AccountId 3996563
```

Link plans account with specified organization in different subscription

