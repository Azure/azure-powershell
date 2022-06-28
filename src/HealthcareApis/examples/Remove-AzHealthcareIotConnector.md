### Example 1: Deletes an IoT Connector.
```powershell
Remove-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

Deletes an IoT Connector.

### Example 2: Deletes an IoT Connector.
```powershell
Get-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Remove-AzHealthcareIotConnector
```

Deletes an IoT Connector.