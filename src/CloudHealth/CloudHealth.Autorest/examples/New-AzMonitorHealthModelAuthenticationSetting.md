### Example 1: Add a managed identity authentication setting
```powershell
$property = New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject -ManagedIdentityName SystemAssigned -DisplayName 'Default managed identity'
New-AzMonitorHealthModelAuthenticationSetting -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name default-auth -Property $property
```

Registers the health model's system-assigned identity so discovery rules can query Azure on its behalf. The identity must already be enabled on the health model.
