### Example 1: Patch an IoT Connector.
```powershell
<<<<<<< HEAD
Update-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Tag @{"123"="abc"}
```

```output
=======
PS C:\> Update-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Tag @{"123"="abc"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus2  azpshcws/azpsiotconnector azps_test_group
```

Patch an IoT Connector.

### Example 2: Patch an IoT Connector.
```powershell
<<<<<<< HEAD
Get-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Update-AzHealthcareIotConnector -Tag @{"123"="abc"}
```

```output
=======
PS C:\> Get-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Update-AzHealthcareIotConnector -Tag @{"123"="abc"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus2  azpshcws/azpsiotconnector azps_test_group
```

Patch an IoT Connector.