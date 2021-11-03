### Example 1: List all logz monitor resources under a subscription
```powershell
PS C:\> Get-AzLogzMonitor

Name                            MonitoringStatus Location      ResourceGroupName
----                            ---------------- --------      -----------------
ssoMultipleTest03               Enabled          westus2       koyTest
saurgupta_logz_001              Enabled          westus2       saurgTest
saurg-test-logz-01              Enabled          westus2       saurgTest
```

This command lists all logz monitor resources under a subscription.

### Example 2: List all logz monitor resources under a resource group
```powershell
PS C:\> Get-AzLogzMonitor -ResourceGroupName logz-rg-test

Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01 Enabled          westus2  logz-rg-test
```

This command lists all logz monitor resources under a resource group.

### Example 3: Get the properties of a specific logz monitor resource
```powershell
PS C:\> Get-AzLogzMonitor -ResourceGroupName logz-rg-test -Name logz-pwsh01

Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01 Enabled          westus2  logz-rg-test
```

This command gets the properties of a specific logz monitor resource.

### Example 4: Get the properties of a specific logz monitor resource by pipeline
```powershell
PS C:\> New-AzLogzMonitor -ResourceGroupName logz-rg-test -Name logz-pwsh01 -Location 'westus2' -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress 'xxxxx@microsoft.com' -UserInfoPhoneNumber 'xxxxxxxx' -UserInfoFirstName 'xxx' -UserInfoLastName 'xxx' | Get-AzLogzMonitor

Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01 Enabled          westus2  logz-rg-test
```

This command gets the properties of a specific logz monitor resource by pipeline.