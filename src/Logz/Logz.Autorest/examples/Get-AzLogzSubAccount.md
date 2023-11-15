### Example 1: List all sub accounts under a given monitor resource
```powershell
Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01
```

```output
Name                MonitoringStatus Location ResourceGroupName
----                ---------------- -------- -----------------
logz01-subaccount01 Enabled          westus2  logz-rg-test
logz01-subaccount02 Enabled          westus2  logz-rg-test
```

This command lists all sub accounts under a given monitor resource.

### Example 2: Get a sub account under a given monitor resource
```powershell
Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01 -Name logz01-subaccount01
```

```output
Name                MonitoringStatus Location ResourceGroupName
----                ---------------- -------- -----------------
logz01-subaccount01 Enabled          westus2  logz-rg-test
```

This command gets a sub account under a given monitor resource.

### Example 3: Get a sub account under a given monitor resource by pipeline
```powershell
New-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 -Location 'westus2' -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress 'xxxxx@microsoft.com' -UserInfoPhoneNumber 'xxxxxx' -UserInfoFirstName 'xxx' -UserInfoLastName 'xxx' | Get-AzLogzSubAccount
```

```output
Name           MonitoringStatus Location ResourceGroupName
----           ---------------- -------- -----------------
logz-pwshsub01 Enabled          westus2  logz-rg-test
```

This command gets a sub account under a given monitor resource by pipeline.