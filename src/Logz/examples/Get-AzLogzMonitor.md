### Example 1: List all logz monitor resources under a subscription
```powershell
<<<<<<< HEAD
Get-AzLogzMonitor
```

```output
=======
PS C:\> Get-AzLogzMonitor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                            MonitoringStatus Location      ResourceGroupName
----                            ---------------- --------      -----------------
ssoMultipleTest03               Enabled          westus2       koyTest
saurgupta_logz_001              Enabled          westus2       saurgTest
saurg-test-logz-01              Enabled          westus2       saurgTest
```

This command lists all logz monitor resources under a subscription.

### Example 2: List all logz monitor resources under a resource group
```powershell
<<<<<<< HEAD
Get-AzLogzMonitor -ResourceGroupName logz-rg-test
```

```output
Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01   Enabled          westus2  logz-rg-test
=======
PS C:\> Get-AzLogzMonitor -ResourceGroupName logz-rg-test

Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01 Enabled          westus2  logz-rg-test
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command lists all logz monitor resources under a resource group.

### Example 3: Get the properties of a specific logz monitor resource
```powershell
<<<<<<< HEAD
Get-AzLogzMonitor -ResourceGroupName logz-rg-test -Name logz-pwsh01
```

```output
Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01   Enabled          westus2  logz-rg-test
=======
PS C:\> Get-AzLogzMonitor -ResourceGroupName logz-rg-test -Name logz-pwsh01

Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01 Enabled          westus2  logz-rg-test
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command gets the properties of a specific logz monitor resource.

### Example 4: Get the properties of a specific logz monitor resource by pipeline
```powershell
<<<<<<< HEAD
New-AzLogzMonitor -ResourceGroupName logz-rg-test -Name logz-pwsh01 -Location 'westus2' -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress 'xxxxx@microsoft.com' -UserInfoPhoneNumber 'xxxxxxxx' -UserInfoFirstName 'xxx' -UserInfoLastName 'xxx' | Get-AzLogzMonitor
```

```output
Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01   Enabled          westus2  logz-rg-test
=======
PS C:\> New-AzLogzMonitor -ResourceGroupName logz-rg-test -Name logz-pwsh01 -Location 'westus2' -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress 'xxxxx@microsoft.com' -UserInfoPhoneNumber 'xxxxxxxx' -UserInfoFirstName 'xxx' -UserInfoLastName 'xxx' | Get-AzLogzMonitor

Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01 Enabled          westus2  logz-rg-test
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command gets the properties of a specific logz monitor resource by pipeline.