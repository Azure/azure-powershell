### Example 1: Gets all the Dynatrace environments that a user can link a azure resource
```powershell
Get-AzDynatraceMonitorLinkableEnv -ResourceGroupName dyobrg -Name dyob-pwsh01 -Region 'East US' -UserPrincipal 'user@microsoft.com' -TenantId 'xxxxxxxx-xxxxx-xxxx-xxxx-xxxxx'
```

```output
```

This command gets all the Dynatrace environments that a user can link a azure resource.