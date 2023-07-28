### Example 1: Update Spring Cloud Service by name.
```powershell
Update-AzSpring -ResourceGroupName azps_test_group_spring -Name azps-spring -Tag @{"abc"="123"}
```

```output
Location Name        ProvisioningState SkuName SkuTier    ResourceGroupName
-------- ----        ----------------- ------- -------    -----------------
eastus   azps-spring Succeeded         S0      Standard   azps_test_group_spring
```

Update Spring Cloud Service by name.

### Example 2: Update Spring Cloud Service by pipeline.
```powershell
Get-AzSpring -ResourceGroupName azps_test_group_spring -Name azps-spring | Update-AzSpring -Tag @{"abc"="123"}
```

```output
Location Name        ProvisioningState SkuName SkuTier    ResourceGroupName
-------- ----        ----------------- ------- -------    -----------------
eastus   azps-spring Succeeded         S0      Standard   azps_test_group_spring
```

Update Spring Cloud Service by pipeline.