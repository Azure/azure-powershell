### Example 1: Creates or updates a Managed Environment used to host container apps.
```powershell
New-AzOperationalInsightsWorkspace -ResourceGroupName azpstest_gp -Name workspace-azpstestgp -Sku PerGB2018 -Location canadacentral -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"
$CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName azpstest_gp -Name workspace-azpstestgp).CustomerId
$SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName azpstest_gp -Name workspace-azpstestgp).PrimarySharedKey

New-AzContainerAppManagedEnv -EnvName azps-env -ResourceGroupName azpstest_gp -Location canadacentral -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
canadacentral azps-env azpstest_gp
```

Creates or updates a Managed Environment used to host container apps.