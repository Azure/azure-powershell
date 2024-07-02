### Example 1: Update Device Serial Number
```powershell
Update-AzNetworkFabricDevice -Name $name -ResourceGroupName $resourceGroupName -SerialNumber $serialNumber
```

```output
AdministrativeState Annotation ConfigurationState HostName Id
------------------- ---------- ------------------ -------- --
Enabled                        Succeeded          AR-MGMT1 /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershe…
```

This command updates the serial number of the device


