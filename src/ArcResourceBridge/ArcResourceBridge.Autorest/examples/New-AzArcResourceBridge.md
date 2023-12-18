### Example 1: Creates or updates an Appliance in the specified Subscription and Resource Group.
```powershell
New-AzArcResourceBridge -Name azps-resource-bridge -ResourceGroupName azps_test_group -Location eastus -IdentityType 'SystemAssigned' -Distro 'AKSEdge' -InfrastructureConfigProvider 'VMware' -Tag @{"123"="abc"}
```

```output
Name                 Location ProvisioningState ResourceGroupName
----                 -------- ----------------- -----------------
azps-resource-bridge eastus   Succeeded         azps_test_group
```

Creates or updates an Appliance in the specified Subscription and Resource Group.