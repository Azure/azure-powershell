### Example 1: Create a monitor resource
```powershell
New-AzDatadogMonitor -ResourceGroupName azure-rg-test -Name Datadog-pwsh01 -SkuName 'drawdown_testing_20200904_Monthly' -Location 'eastus2euap' -UserInfoEmailAddress 'xxxx@microsoft.com' -UserInfoName 'user' -UserInfoPhoneNumber 'xxxxxxxxxxxx' -IdentityType SystemAssigned
```

```output
Location    Name           Type
--------    ----           ----
eastus2euap Datadog-pwsh01 microsoft.Datadog/monitors
```

This command creates a monitor resource.
