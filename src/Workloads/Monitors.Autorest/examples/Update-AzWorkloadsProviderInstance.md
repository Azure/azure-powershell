### Example 1: Update an existing provider
```powershell
$providerSetting = New-AzWorkloadsProviderSqlServerInstanceObject -Password '<password>' -Port 1433 -Username '<username>' -Hostname 10.1.14.5 -SapSid X00 -SslPreference Disabled

Update-AzWorkloadsProviderInstance -MonitorName sap-0202-ams9 -Name sql-prov-1 -ResourceGroupName sap-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -ProviderSetting $providerSetting
```

```output
Name       ResourceGroupName ProvisioningState IdentityType
----       ----------------- ----------------- ------------
sql-prov-1 sap-0802-rg1     Succeeded
```

Update an existing provider for a specific AMS instance

### Example 2: Update an existing provider by Id
```powershell
Update-AzWorkloadsProviderInstance -MonitorName sap-160323-ams4 -Name sap-sql-3 -ResourceGroupName sap-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -ProviderSetting '{"sslPreference":"Disabled","providerType":"MsSqlServer","hostname":"10.1.14.5","sapSid":"X00","dbPort":"1433","dbUsername":"","dbPassword":""}'
```

```output
Name       ResourceGroupName ProvisioningState IdentityType
----       ----------------- ----------------- ------------
sap-sql-3 sap-0802-rg1     Succeeded
```

Update an existing provider for a specific AMS instance by Arm Id
