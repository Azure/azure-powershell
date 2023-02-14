### Example 1: Create a monitor resource
```powershell
<<<<<<< HEAD
New-AzDatadogMonitor -ResourceGroupName azure-rg-test -Name Datadog-pwsh01 -SkuName 'drawdown_testing_20200904_Monthly' -Location 'eastus2euap' -UserInfoEmailAddress 'xxxx@microsoft.com' -UserInfoName 'user' -UserInfoPhoneNumber 'xxxxxxxxxxxx' -IdentityType SystemAssigned
```

```output
=======
PS C:\> New-AzDatadogMonitor -ResourceGroupName azure-rg-test -Name Datadog-pwsh01 -SkuName 'drawdown_testing_20200904_Monthly' -Location 'eastus2euap' -UserInfoEmailAddress 'xxxx@microsoft.com' -UserInfoName 'user' -UserInfoPhoneNumber 'xxxxxxxxxxxx' -IdentityType SystemAssigned

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location    Name           Type
--------    ----           ----
eastus2euap Datadog-pwsh01 microsoft.Datadog/monitors
```

This command creates a monitor resource.
