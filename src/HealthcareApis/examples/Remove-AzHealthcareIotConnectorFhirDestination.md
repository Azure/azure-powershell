### Example 1: Deletes an IoT Connector FHIR destination.
```powershell
Remove-AzHealthcareIotConnectorFhirDestination -FhirDestinationName azpsfhirdestination -IotConnectorName azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

Deletes an IoT Connector FHIR destination.

### Example 2: Deletes an IoT Connector FHIR destination.
```powershell
Get-AzHealthcareIotConnectorFhirDestination -FhirDestinationName azpsfhirdestination -IotConnectorName azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Remove-AzHealthcareIotConnectorFhirDestination
```

Deletes an IoT Connector FHIR destination.