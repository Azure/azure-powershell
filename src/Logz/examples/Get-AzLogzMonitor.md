### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzLogzMonitor

Name                            MonitoringStatus Location      ResourceGroupName
----                            ---------------- --------      -----------------
ssoMultipleTest03               Enabled          westus2       koyTest
saurgupta_logz_001              Enabled          westus2       saurgTest
saurg-test-logz-01              Enabled          westus2       saurgTest
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzLogzMonitor -ResourceGroupName lucas-rg-test

Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01 Enabled          westus2  lucas-rg-test
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> Get-AzLogzMonitor -ResourceGroupName lucas-rg-test -Name logz-pwsh01

Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01 Enabled          westus2  lucas-rg-test
```

{{ Add description here }}

### Example 4: {{ Add title here }}
```powershell
PS C:\> New-AzLogzMonitor -ResourceGroupName lucas-rg-test -Name logz-pwsh01 -Location 'westus2' -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress 'xxxxx@microsoft.com' -UserInfoPhoneNumber 'xxxxxxxx' -UserInfoFirstName 'xxx' -UserInfoLastName 'xxx' | Get-AzLogzMonitor

Name          MonitoringStatus Location ResourceGroupName
----          ---------------- -------- -----------------
logz-pwsh01 Enabled          westus2  lucas-rg-test
```

{{ Add description here }}