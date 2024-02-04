### Example 1: Patch an IoT Connector.
```powershell
Update-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Tag @{"123"="abc"}
```

```output
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus2  azpshcws/azpsiotconnector azps_test_group
```

Patch an IoT Connector.

### Example 2: Patch an IoT Connector.
```powershell
Get-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Update-AzHealthcareIotConnector -Tag @{"123"="abc"}
```

```output
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus2  azpshcws/azpsiotconnector azps_test_group
```

Patch an IoT Connector.