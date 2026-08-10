### Example 1: Change the display name of an authentication setting
```powershell
$property = New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject -ManagedIdentityName SystemAssigned -DisplayName 'Workload managed identity'
Update-AzMonitorHealthModelAuthenticationSetting -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name default-auth -Property $property
```

Updates an existing authentication setting.
