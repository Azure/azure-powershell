### Example 1: Create a monitor resource
```powershell
New-AzLogzMonitor -ResourceGroupName logz-rg-test -Name pwsh-logz05 -Location 'westus2' -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanEffectiveDate (Get-Date -AsUTC) -PlanDetail '100gb14days' -UserInfoEmailAddress 'xxxxx@microsoft.com' -UserInfoPhoneNumber 'xxxxxxxx' -UserInfoFirstName 'xxx' -UserInfoLastName 'xxx'
```

```output
Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01 Enabled          westus2  logz-rg-test
```

This command creates a monitor resource.
