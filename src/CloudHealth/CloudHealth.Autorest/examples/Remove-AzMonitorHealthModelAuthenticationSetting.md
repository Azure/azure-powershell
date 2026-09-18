### Example 1: Delete an authentication setting
```powershell
# Delete the authentication setting default-auth
Remove-AzMonitorHealthModelAuthenticationSetting -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name default-auth
```

Deletes the authentication setting.
Discovery rules reference an authentication setting by name.
