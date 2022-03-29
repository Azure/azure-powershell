### Example 1: 
```powershell
New-AzStackHciCluster -Name "myCluster" -ResourceGroupName "test-rg" -AadTenantId "c76bd4d1-bea3-45ea-be1b-4a745a675d07" -AadClientId "24a6e53d-04e5-44d2-b7cc-1b732a847dfc" -Location "eastus"
```

```output
Location Name      ResourceGroupName
-------- ----      -----------------
eastus   myCluster test-rg
```

This command creates a Stack HCI cluster

### Example 2: 
```powershell
New-AzStackHciCluster -Name "myCluster2" -ResourceGroupName "test-rg" -AadTenantId "c76bd4d1-bea3-45ea-be1b-4a745a675d07" -AadClientId "24a6e53d-04e5-44d2-b7cc-1b732a847dfc" -Location "westeurope" -DesiredPropertyDiagnosticLevel "Off" -DesiredPropertyWindowsServerSubscription "Enabled"
```

```output
Location   Name       ResourceGroupName
--------   ----       -----------------
westeurope myCluster2 test-rg
```

This command creates a Stack HCI cluster with DiagnosticLevel = "Off" and WindowsServerSubscription = "Enabled". By default, these values are set to "Basic" and "Disabled" respectively.

