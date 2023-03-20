### Example 1: List DigitalTwinsInstances resource.
```powershell
Get-AzDigitalTwinsInstance
```

```output
Name                      Location ResourceGroupName
----                      -------- -----------------
azps-dt                   eastus   azps_test_group
azps-digitaltwin-instance eastus   azps_test_group
```

List DigitalTwinsInstances resource.

### Example 2: Get DigitalTwinsInstances resource by ResourceGroup.
```powershell
Get-AzDigitalTwinsInstance -ResourceGroupName azps_test_group
```

```output
Name                       Location ResourceGroupName
----                       -------- -----------------
azps-digitaltwins-instance eastus   azps_test_group
```

Get DigitalTwinsInstances resource by ResourceGroup.

### Example 3: Get DigitalTwinsInstances resource by Instance Name.
```powershell
Get-AzDigitalTwinsInstance -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance
```

```output
Name                       Location ResourceGroupName
----                       -------- -----------------
azps-digitaltwins-instance eastus   azps_test_group
```

Get DigitalTwinsInstances resource by Instance Name.