### Example 1: Create a new provider
```powershell
$providerSetting = New-AzWorkloadsProviderSqlServerInstanceObject -Password '<password>' -Port 1433 -Username '<username>' -Hostname 10.1.14.5 -SapSid X00 -SslPreference Disabled
        $providerSetting.ProviderType | Should -Be "MsSqlServer"
        
New-AzWorkloadsProviderInstance -MonitorName suha-0202-ams9 -Name sql-prov-1 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -ProviderSetting $providerSetting
```

```output
Name       ResourceGroupName ProvisioningState IdentityType
----       ----------------- ----------------- ------------
sql-prov-1 suha-0802-rg1     Succeeded
```

Creates a new provider for a specific AMS instance

### Example 2: Create a new provider by Id
```powershell
New-AzWorkloadsProviderInstance -MonitorName suha-160323-ams4 -Name suha-sql-3 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -ProviderSetting '{"sslPreference":"Disabled","providerType":"MsSqlServer","hostname":"10.1.14.5","sapSid":"X00","dbPort":"1433","dbUsername":"","dbPassword":""}'
```

```output
Name       ResourceGroupName ProvisioningState IdentityType
----       ----------------- ----------------- ------------
suha-sql-3 suha-0802-rg1     Succeeded
```

Creates a new provider for a specific AMS instance by Arm Id

