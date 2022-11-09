### Example 1: Gets the SSO configuration details from the partner
```powershell
Get-AzDynatraceMonitorSSODetail -ResourceGroupName dyobrg -MonitorName dyob-pwsh01 -UserPrincipal "user@microsoft.com"
```

```output
AadDomain AdminUser              IsSsoEnabled MetadataUrl SingleSignOnUrl
--------- ---------              ------------ ----------- ---------------
{}        {v-diya@microsoft.com} Disabled
```

This command gets the SSO configuration details from the partner.