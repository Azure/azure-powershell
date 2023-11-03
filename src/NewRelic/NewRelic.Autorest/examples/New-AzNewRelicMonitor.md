### Example 1: Create monitor
```powershell
New-AzNewRelicMonitor -Name test-01 -ResourceGroupName ps-test -Location eastus -PlanDataPlanDetail "newrelic-pay-as-you-go-free-live@TIDgmz7xq9ge3py@PUBIDnewrelicinc1635200720692.newrelic_liftr_payg"-PlanDataBillingCycle 'MONTHLY' -PlanDataUsageType 'PAYG' -PlanDataEffectiveDate (Get-Date -DisplayHint DateTime) -UserInfoEmailAddress v-jiaji@outlook.com -UserInfoFirstName "Joyer" -UserInfoLastName "Jin"
```

```output
Location Name    SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName RetryAfter
-------- ----    -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- ----------
eastus   test-01 6/27/2023 8:30:45 AM v-jiaji@outlook.com User                    6/27/2023 8:30:45 AM     v-jiaji@outlook.com    User                         ps-test
```

Create NewRelic monitor with Plan data and User information