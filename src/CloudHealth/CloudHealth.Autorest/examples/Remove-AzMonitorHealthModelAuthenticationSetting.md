### Example 1: Delete an authentication setting
```powershell
Remove-AzMonitorHealthModelAuthenticationSetting -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name default-auth
```

Deletes the authentication setting. Discovery rules that reference it stop working.
