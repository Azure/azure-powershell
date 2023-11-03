### Example 1: List the properties of the specified IoT Connector.
```powershell
Get-AzHealthcareIotConnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus2  azpshcws/azpsiotconnector azps_test_group
```

List the properties of the specified IoT Connector.

### Example 2: Gets the properties of the specified IoT Connector.
```powershell
Get-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus2  azpshcws/azpsiotconnector azps_test_group
```

Gets the properties of the specified IoT Connector.