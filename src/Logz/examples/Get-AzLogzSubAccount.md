### Example 1: List all sub accounts under a given monitor resource
```powershell
<<<<<<< HEAD
Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01
```

```output
=======
PS C:\> Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                MonitoringStatus Location ResourceGroupName
----                ---------------- -------- -----------------
logz01-subaccount01 Enabled          westus2  logz-rg-test
logz01-subaccount02 Enabled          westus2  logz-rg-test
```

This command lists all sub accounts under a given monitor resource.

### Example 2: Get a sub account under a given monitor resource
```powershell
<<<<<<< HEAD
Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01 -Name logz01-subaccount01
```

```output
=======
PS C:\> Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01 -Name logz01-subaccount01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                MonitoringStatus Location ResourceGroupName
----                ---------------- -------- -----------------
logz01-subaccount01 Enabled          westus2  logz-rg-test
```

This command gets a sub account under a given monitor resource.

### Example 3: Get a sub account under a given monitor resource by pipeline
```powershell
<<<<<<< HEAD
New-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 -Location 'westus2' -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress 'xxxxx@microsoft.com' -UserInfoPhoneNumber 'xxxxxx' -UserInfoFirstName 'xxx' -UserInfoLastName 'xxx' | Get-AzLogzSubAccount
```

```output
=======
PS C:\> New-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 -Location 'westus2' -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress 'xxxxx@microsoft.com' -UserInfoPhoneNumber 'xxxxxx' -UserInfoFirstName 'xxx' -UserInfoLastName 'xxx' | Get-AzLogzSubAccount

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name           MonitoringStatus Location ResourceGroupName
----           ---------------- -------- -----------------
logz-pwshsub01 Enabled          westus2  logz-rg-test
```

This command gets a sub account under a given monitor resource by pipeline.