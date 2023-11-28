### Example 1: Create a Managed Environment used to host container apps.
```powershell
New-AzOperationalInsightsWorkspace -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp -Sku PerGB2018 -Location canadacentral -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"

$CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp).CustomerId
$SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp).PrimarySharedKey
$workloadProfile = New-AzContainerAppWorkloadProfileObject -Name "Consumption" -Type "Consumption"

New-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app -Location eastus -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false -WorkloadProfile $workloadProfile
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
East US  azps-env azps_test_group_app
```

Create a Managed Environment used to host container apps.