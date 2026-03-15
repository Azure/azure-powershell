### Example 1: Update confluent connector
```powershell
Update-AzConfluentConnector `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -ClusterId "lkc-examplekafka1" `
    -Name "conn_2" `
    -ConnectorBasicInfoConnectorClassName "AZUREBLOBSOURCE" `
    -ConnectorBasicInfoConnectorName "conn_2" `
    -ConnectorBasicInfoConnectorType "SOURCE" `
    -ConnectorServiceTypeInfoConnectorServiceType "AzureBlobStorageSourceConnector" `
    -PartnerConnectorInfoPartnerConnectorType "KafkaAzureBlobStorageSource"
```

```output
ConnectorBasicInfoConnectorClassName             : AZUREBLOBSOURCE
ConnectorBasicInfoConnectorId                : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environ
                                               ments/env-exampleenv001/clusters/lkc-examplekafka1/connectors/conn_2
ConnectorBasicInfoConnectorName              : conn_2
ConnectorBasicInfoConnectorState             : PROVISIONING
ConnectorBasicInfoConnectorType              : SOURCE
ConnectorServiceTypeInfo                     : {
                                                 "connectorServiceType": "AzureBlobStorageSinkConnector",
                                                 "storageAccountName": "examplestorageacct",
                                                 "storageAccountKey": "<base64-encoded-storage-account-key>",
                                                 "storageContainerName": "testcontainer"
                                               }
ConnectorServiceTypeInfoConnectorServiceType : AzureBlobStorageSinkConnector
Id                                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environ
                                               ments/env-exampleenv001/clusters/lkc-examplekafka1/connectors/conn_2
Name                                         : conn_2
PartnerConnectorInfo                         : {
                                                 "partnerConnectorType": "KafkaAzureBlobStorageSink",
                                                 "authType": "KAFKA_API_KEY",
                                                 "inputFormat": "AVRO",
                                                 "outputFormat": "AVRO",
                                                 "apiKey": "PL7EV4FPZK44HPG7",
                                                 "apiSecret": "<ApiSecret>",
                                                 "topics": [ "topic_1" ],
                                                 "topicsDir": "topicsDir",
                                                 "flushSize": "1000",
                                                 "maxTasks": "1",
                                                 "timeInterval": "DAILY"
                                               }
PartnerConnectorInfoPartnerConnectorType     : KafkaAzureBlobStorageSink
ResourceGroupName                            : sharedrp-confluent
SystemDataCreatedAt                          : 3/7/2026 11:57:53 AM
SystemDataCreatedBy                          : user4@example.com
SystemDataCreatedByType                      : User
SystemDataLastModifiedAt                     : 3/7/2026 3:35:10 PM
SystemDataLastModifiedBy                     : user4@example.com
SystemDataLastModifiedByType                 : User
Type                                         : microsoft.confluent/organizations/environments/clusters/connectors
```

This command updated confluent connector