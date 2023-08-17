### Example 1: Update metadata of DigitalTwinsInstance.
```powershell
Update-AzDigitalTwinsInstance -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -Tag @{"abc"="123"}
```

```output
Name                       Location ResourceGroupName
----                       -------- -----------------
azps-digitaltwins-instance eastus   azps_test_group
```

Update metadata of DigitalTwinsInstance.

### Example 2: Update the AzDigitalTwinsInstance by another AzDigitalTwinsInstance.
```powershell
Get-AzDigitalTwinsInstance -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance | Update-AzDigitalTwinsInstance -Tag @{"1234"="abcd"}
```

```output
Name                       Location ResourceGroupName
----                       -------- -----------------
azps-digitaltwins-instance eastus   azps_test_group
```

Update the AzDigitalTwinsInstance by another AzDigitalTwinsInstance.