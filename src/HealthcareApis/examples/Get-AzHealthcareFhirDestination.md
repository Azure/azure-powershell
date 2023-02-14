### Example 1: Lists all FHIR destinations for the given IoT Connector
```powershell
<<<<<<< HEAD
Get-AzHealthcareFhirDestination -IotConnectorName azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
=======
PS C:\> Get-AzHealthcareFhirDestination -IotConnectorName azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                                          ResourceGroupName
-------- ----                                          -----------------
eastus2  azpshcws/azpsiotconnector/azpsfhirdestination azps_test_group
```

Lists all FHIR destinations for the given IoT Connector