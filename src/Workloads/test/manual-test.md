# List all commands
```powershell
Get-Command -Module Az.Workloads
```

# Get help of the cmdlet.
```powershell
Get-Help Get-help New-AzWorkloadsMonitor -Full
```

# Request Payload

You can add `-Debug` parameter to each cmdlet to display the request payload. 

# Create workloads monitor
```powershell
New-AzWorkloadsMonitor -ResourceGroupName PowerShell-CLI-TestRG -Name powershellmonitor07 -Location eastus2euap -AppLocation eastus -ManagedResourceGroupName powershellmonitor07-mrg -MonitorSubnet "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/PowerShell-CLI-TestRG/providers/Microsoft.Network/virtualNetworks/lucas-workloads-vnet/subnets/subnet02" -RoutingPreference 'RouteAll' -ZoneRedundancyPreference Disab
```

+ Get-AzWorkloadsMonitor: Get or list workloads monitor
+ Update-AzWorkloadsMonitor: Update a workloads monitor
+ Remove-AzWorkloadsMonitor: Remove a workloads monitor

# Create workloads sap virtual instance
```powershell
# CreateWithDiscovery
New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name L02 -Location eastus2 -Environment 'Prod' -SapProduct 'S4HANA' -CentralServerVmId '/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/DHRUV-SVI-SCALE-TEST-AVSDISCOVERY8.2.202109120216FEB5738-INFRA/providers/Microsoft.Compute/virtualMachines/a12appvm0'

# CreateWithJsonTemplatePath
New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name L02 -Location eastuseuap -Environment 'Prod' -SapProduct 'S4HANA' -Configuration .\test\configuration.json -Tag @{'k1'='v1'} -IdentityType 'UserAssigned' -ManagedResourceGroupName "L02-rg" -UserAssignedIdentity @{'/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'='v1'}
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

+ Get-AzWorkloadsProviderInstance : Get or list workloads provider instance
+ Remove-AzWorkloadsProviderInstance: Remove a workloads provider instance

+ Can use `New-AzWorkloadsProviderHanaDbInstanceObject` create HanaDb object as value of the `ProviderSetting` parameter
+ Can use `New-AzWorkloadsProviderPrometheusHaClusterInstanceObject` create PrometheusHa object as value of the `ProviderSetting` parameter
+ Can use `New-AzWorkloadsProviderPrometheusOSInstanceObject` create PrometheusOS object as value of the `ProviderSetting` parameter
+ Can use `New-AzWorkloadsProviderSapNetWeaverInstanceObject` create SapNetWeaver object as value of the `ProviderSetting` parameter
+ Can use `New-AzWorkloadsProviderSqlServerInstanceObject` create SqlServer object as value of the `ProviderSetting` parameter

# Creates a SAP Landscape Monitor Dashboard
```powershell
$sidMapp = @()
$sidMapp += New-AzWorkloadsSapLandscapeMonitorSidMappingObject -Name sidMapp01 -TopSid '01','02'
$sidMapp += New-AzWorkloadsSapLandscapeMonitorSidMappingObject -Name sidMapp02 -TopSid '01','02'
$metricThresholds = @()
$metricThresholds += New-AzWorkloadsSapLandscapeMonitorMetricThresholdsObject -Name 't01' -Green 125  -Red 256 -Yellow 123
$metricThresholds += New-AzWorkloadsSapLandscapeMonitorMetricThresholdsObject -Name 't02' -Green 125  -Red 256 -Yellow 123

New-AzWorkloadsSapLandscapeMonitor -ResourceGroupName 'PowerShell-CLI-TestRG' -MonitorName powershellmonitor07 -GroupingLandscape $sidMapp -GroupingSapApplication $sidMapp -TopMetricsThreshold $metricThresholds
```
