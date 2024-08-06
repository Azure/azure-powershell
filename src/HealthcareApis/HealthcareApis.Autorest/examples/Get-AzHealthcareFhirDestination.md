### Example 1: Lists all FHIR destinations for the given IoT Connector
```powershell
Get-AzHealthcareFhirDestination -IotConnectorName azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
Location Name                                          ResourceGroupName
-------- ----                                          -----------------
eastus2  azpshcws/azpsiotconnector/azpsfhirdestination azps_test_group
```

Lists all FHIR destinations for the given IoT Connector