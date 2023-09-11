### Example 1: Create a Managed Environment used to host container apps.
```powershell
New-AzOperationalInsightsWorkspace -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp -Sku PerGB2018 -Location canadacentral -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"

$CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp).CustomerId
$SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp).PrimarySharedKey

New-AzContainerAppManagedEnv -EnvName azps-env -ResourceGroupName azps_test_group_app -Location canadacentral -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false
```

```output
Location       Name     ResourceGroupName
--------       ----     -----------------
Canada Central azps-env azps_test_group_app
```

Create a Managed Environment used to host container apps.