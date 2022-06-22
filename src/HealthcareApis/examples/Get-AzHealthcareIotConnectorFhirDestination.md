### Example 1: Gets the properties of the specified Iot Connector FHIR destination.
```powershell
Get-AzHealthcareIotConnectorFhirDestination -FhirDestinationName azpsfhirdestination -IotConnectorName azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
Location Name                                          ResourceGroupName
-------- ----                                          -----------------
eastus2  azpshcws/azpsiotconnector/azpsfhirdestination azps_test_group
```

Gets the properties of the specified Iot Connector FHIR destination.