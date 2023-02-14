### Example 1: Creates or updates an IoT Connector FHIR destination resource with the specified parameters.
```powershell
<<<<<<< HEAD
$arr = @()
New-AzHealthcareIotConnectorFhirDestination -FhirDestinationName azpsfhirdestination -IotConnectorName azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws -FhirServiceResourceId "/subscriptions/{SubscriptionId}/resourceGroups/azps_test_group/providers/Microsoft.HealthcareApis/workspaces/azpshcws/fhirservices/azpsfhirservice" -ResourceIdentityResolutionType 'Create' -Location eastus2 -FhirMappingContent @{"templateType"="CollectionFhirTemplate";"template"=$arr}
```

```output
=======
PS C:\> $arr = @()
PS C:\> New-AzHealthcareIotConnectorFhirDestination -FhirDestinationName azpsfhirdestination -IotConnectorName azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws -FhirServiceResourceId "/subscriptions/{SubscriptionId}/resourceGroups/azps_test_group/providers/Microsoft.HealthcareApis/workspaces/azpshcws/fhirservices/azpsfhirservice" -ResourceIdentityResolutionType 'Create' -Location eastus2 -FhirMappingContent @{"templateType"="CollectionFhirTemplate";"template"=$arr}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                                          ResourceGroupName
-------- ----                                          -----------------
eastus2  azpshcws/azpsiotconnector/azpsfhirdestination azps_test_group
```

Creates or updates an IoT Connector FHIR destination resource with the specified parameters.