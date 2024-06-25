### Example 1: Create monitor
```powershell
New-AzNewRelicMonitor -Name test-01 -ResourceGroupName ps-test -Location eastus -PlanDataPlanDetail "newrelicpaygtestplan2@123456789123456@PUBIDnewrelicinc1234567891234.newrelic_liftr_payg"-PlanDataBillingCycle 'MONTHLY' -PlanDataUsageType 'PAYG' -PlanDataEffectiveDate (Get-Date -DisplayHint DateTime) -UserInfoEmailAddress user1@outlook.com -UserInfoFirstName "group" -UserInfoLastName "test"
```

```output
Location Name    SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName RetryAfter
-------- ----    -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- ----------
eastus   test-01 6/27/2023 8:30:45 AM user1@outlook.com User                    6/27/2023 8:30:45 AM     user1@outlook.com    User                         ps-test
```

Create NewRelic monitor with Plan data and User information