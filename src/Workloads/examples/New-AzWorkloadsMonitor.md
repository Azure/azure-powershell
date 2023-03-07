### Example 1: Creates a SAP monitor for the specified subscription, resource group, and resource name
```powershell
New-AzWorkloadsMonitor -ResourceGroupName PowerShell-CLI-TestRG -Name powershellmonitor07 -Location eastus2euap -AppLocation eastus -ManagedResourceGroupName powershellmonitor07-mrg -MonitorSubnet "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/PowerShell-CLI-TestRG/providers/Microsoft.Network/virtualNetworks/lucas-workloads-vnet/subnets/subnet02" -RoutingPreference 'RouteAll' -ZoneRedundancyPreference Disabled
```

```output
Name                ResourceGroupName     ManagedResourceGroupConfigurationName Location    ProvisioningState
----                -----------------     ------------------------------------- --------    -----------------
powershellmonitor07 PowerShell-CLI-TestRG powershellmonitor07-mrg               eastus2euap Succeeded
```

This command creates a SAP monitor for the specified subscription, resource group, and resource name.