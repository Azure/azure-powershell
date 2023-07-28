### Example 1: Get Spring Cloud Service by name.
```powershell
Get-AzSpring -ResourceGroupName azps_test_group_spring -Name azps-spring
```

```output
Location Name        ProvisioningState SkuName SkuTier    ResourceGroupName
-------- ----        ----------------- ------- -------    -----------------
eastus   azps-spring Succeeded         S0      Standard   azps_test_group_spring
```

Get Spring Cloud Service by name.

### Example 2: List all the spring cloud service under the resource group.
```powershell
Get-AzSpring -ResourceGroupName azps_test_group_spring
```

```output
Location Name          ProvisioningState SkuName SkuTier    ResourceGroupName
-------- ----          ----------------- ------- -------    -----------------
eastus   azps-spring   Succeeded         S0      Standard   azps_test_group_spring
eastus   azps-spring-1 Succeeded         E0      Enterprise azps_test_group_spring
```

List all the spring cloud service under the resource group.

### Example 3: List all the spring cloud service under the subscription.
```powershell
Get-AzSpring
```

```output
Location Name          ProvisioningState SkuName SkuTier    ResourceGroupName
-------- ----          ----------------- ------- -------    -----------------
eastus   azps-spring   Succeeded         S0      Standard   azps_test_group_spring
eastus   azps-spring-1 Succeeded         E0      Enterprise azps_test_group_spring
```

List all the spring cloud service under the subscription.