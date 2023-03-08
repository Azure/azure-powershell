Get-Command -Module Az.Workloads
Get-Help Get-help New-AzWorkloadsMonitor -Full

Repo: 

You can add `-Debug` parameter for every cmdlet that print request payload. 

# Create workloads monitor
```powershell
New-AzWorkloadsMonitor -ResourceGroupName PowerShell-CLI-TestRG -Name powershellmonitor07 -Location eastus2euap -AppLocation eastus -ManagedResourceGroupName powershellmonitor07-mrg -MonitorSubnet "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/PowerShell-CLI-TestRG/providers/Microsoft.Network/virtualNetworks/lucas-workloads-vnet/subnets/subnet02" -RoutingPreference 'RouteAll' -ZoneRedundancyPreference Disab
```

+ Get-AzWorkloadsMonitor: Get or list workloads monitor
+ Update-AzWorkloadsMonitor: Update a workloads monitor
+ Remove-AzWorkloadsMonitor: Remove a workloads monitor

# Create workloads sap virtual instance.
```powershell
# CreateWithDiscovery
New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name L02 -Location eastus2 -Environment 'Prod' -SapProduct 'S4HANA' -CentralServerVmId '/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/DHRUV-SVI-SCALE-TEST-AVSDISCOVERY8.2.202109120216FEB5738-INFRA/providers/Microsoft.Compute/virtualMachines/a12appvm0'

# CreateWithJsonTemplatePath
New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name L02 -JsonTemplatePath .\test\sapVirtualInstalceJsonTemplate.json
```


+ Get-AzWorkloadsSapVirtualInstance: Get or list workloads monitor
+ Update-AzWorkloadsSapVirtualInstance: Update a workloads monitor
+ Remove-AzWorkloadsSapVirtualInstance: Remove a workloads monitor
+ Start-AzWorkloadsSapVirtualInstance: start a workloads monitor
+ Stop-AzWorkloadsSapVirtualInstance: stop a workloads monitor

# Create workloads provider instance
```powershell
# Create with db2
$db2Instance = New-AzWorkloadsProviderDB2InstanceObject -Hostname "hostname" -Name "dbName" -Username "username" -Password "password" -PasswordUri "uri" -Port "dbPort" -SapSid "SID" -SslCertificateUri "https://storageaccount.blob.core.windows.net/containername/filename" -SslPreference "ServerCertificate"
New-AzWorkloadsProviderInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -MonitorName powershellmonitor07 -Name workloadsPI -ProviderSetting $db2Instance
```

+ Get-AzWorkloadsProviderInstance
+ Remove-AzWorkloadsProviderInstance

+ New-AzWorkloadsProviderHanaDbInstanceObject
+ New-AzWorkloadsProviderPrometheusHaClusterInstanceObject
+ New-AzWorkloadsProviderPrometheusOSInstanceObject
+ New-AzWorkloadsProviderSapNetWeaverInstanceObject
+ New-AzWorkloadsProviderSqlServerInstanceObject
