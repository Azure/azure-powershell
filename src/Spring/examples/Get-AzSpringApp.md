### Example 1: List all App under the spring service.
```powershell
Get-AzSpringApp -ResourceGroupName azps_test_group_spring -ServiceName azps-spring
```

```output
Location Name  ProvisioningState ResourceGroupName
-------- ----  ----------------- -----------------
eastus   tools Succeeded         azps_test_group_spring
```

Lise all App under the spring service.

### Example 2: Get an App and its properties.
```powershell
Get-AzSpringApp -ResourceGroupName azps_test_group_spring -ServiceName azps-spring -Name tools
```

```output
Location Name  ProvisioningState ResourceGroupName
-------- ----  ----------------- -----------------
eastus   tools Succeeded         azps_test_group_spring
```

Get an App and its properties.