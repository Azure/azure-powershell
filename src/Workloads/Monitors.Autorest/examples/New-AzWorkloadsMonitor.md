### Example 1: Creates a SAP monitor for the specified subscription, resource group, and resource name
```powershell
New-AzWorkloadsMonitor -Name suha-160323-ams4 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -Location eastus2euap -AppLocation eastus -ManagedResourceGroupName mrg-1603234 -MonitorSubnet /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/e2e-portal-wlmonitor-do-not-delete/providers/Microsoft.Network/virtualNetworks/vnetpeeringtest/subnets/snet-1603-3 -RoutingPreference RouteAll -ZoneRedundancyPreference Disabled
```

```output
Name             ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----             ----------------- ------------------------------------- --------    -----------------
suha-160323-ams4 suha-0802-rg1     mrg-1603234                           eastus2euap Succeeded
```

This command creates a SAP monitor for the specified subscription, resource group, and resource name.