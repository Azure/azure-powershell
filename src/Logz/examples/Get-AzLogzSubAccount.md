### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzLogzSubAccount -ResourceGroupName lucas-rg-test -MonitorName logz-portal01

Name                MonitoringStatus Location ResourceGroupName
----                ---------------- -------- -----------------
logz01-subaccount01 Enabled          westus2  lucas-rg-test
logz01-subaccount02 Enabled          westus2  lucas-rg-test
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzLogzSubAccount -ResourceGroupName lucas-rg-test -MonitorName logz-portal01 -Name logz01-subaccount01

Name                MonitoringStatus Location ResourceGroupName
----                ---------------- -------- -----------------
logz01-subaccount01 Enabled          westus2  lucas-rg-test
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> New-AzLogzSubAccount -ResourceGroupName lucas-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 -Location 'westus2' -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress 'xxxxx@microsoft.com' -UserInfoPhoneNumber 'xxxxxx' -UserInfoFirstName 'xxx' -UserInfoLastName 'xxx' | Get-AzLogzSubAccount

Name           MonitoringStatus Location ResourceGroupName
----           ---------------- -------- -----------------
logz-pwshsub01 Enabled          westus2  lucas-rg-test
```

{{ Add description here }}