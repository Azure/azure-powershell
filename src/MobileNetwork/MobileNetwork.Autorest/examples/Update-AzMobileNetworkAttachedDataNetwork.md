### Example 1: Updates an attached data network.
```powershell
Update-AzMobileNetworkAttachedDataNetwork -AttachedDataNetworkName azps-mn-adn -PacketCoreControlPlaneName azps-mn-pccp -PacketCoreDataPlaneName azps_test_group -ResourceGroupName -Tag @{"abc"="123"}
```

```output
Location Name        ResourceGroupName ProvisioningState
-------- ----        ----------------- -----------------
eastus   azps-mn-adn azps_test_group   Succeeded
```

Updates an attached data network.