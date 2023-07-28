### Example 1: Create or update a new standard spring cloud service.
```powershell
New-AzSpring -ResourceGroupName azps_test_group_spring -Name azps-spring -Location eastus
```

```output
Location Name        ProvisioningState SkuName SkuTier    ResourceGroupName
-------- ----        ----------------- ------- -------    -----------------
eastus   azps-spring Succeeded         S0      Standard   azps_test_group_spring
```

Create or update a new standard spring cloud service.