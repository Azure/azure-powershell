### Example 1: Creates or updates an IoT Connector resource with the specified parameters.
```powershell
<<<<<<< HEAD
$arr = @()
New-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Location eastus2 -IngestionEndpointConfigurationConsumerGroup "sajob-01-portal_input-01_consumer_group" -IngestionEndpointConfigurationEventHubName "sajob01portaleventhub" -IngestionEndpointConfigurationFullyQualifiedEventHubNamespace "sdk-Namespace-4761.servicebus.windows.net" -DeviceMappingContent @{"templateType"="CollectionContent";"template"=$arr}
```

```output
=======
PS C:\> $arr = @()
PS C:\> New-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Location eastus2 -IngestionEndpointConfigurationConsumerGroup "sajob-01-portal_input-01_consumer_group" -IngestionEndpointConfigurationEventHubName "sajob01portaleventhub" -IngestionEndpointConfigurationFullyQualifiedEventHubNamespace "sdk-Namespace-4761.servicebus.windows.net" -DeviceMappingContent @{"templateType"="CollectionContent";"template"=$arr}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus2  azpshcws/azpsiotconnector azps_test_group
```

Creates or updates an IoT Connector resource with the specified parameters.