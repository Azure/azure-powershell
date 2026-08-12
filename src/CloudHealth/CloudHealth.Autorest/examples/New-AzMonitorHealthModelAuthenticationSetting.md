### Example 1: Create an authentication setting
```powershell
# Create the authentication setting default-auth using the health model's system-assigned identity
$property = New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject -ManagedIdentityName SystemAssigned -DisplayName 'Default managed identity'
New-AzMonitorHealthModelAuthenticationSetting -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name default-auth -Property $property
```

Creates an authentication setting that discovery rules reference by name.
The identity must already be enabled on the health model.
