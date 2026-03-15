### Example 1: Create confluent Connector
```powershell
New-AzConfluentConnector `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -ClusterId "lkc-examplekafka1" `
    -Name "conn_3" `
    -JsonString '{
        "properties": {
            "connectorBasicInfo": {
                "connectorType": "SOURCE",
                "connectorClass": "AZUREBLOBSOURCE",
                "connectorName": "conn_3"
            },
            "connectorServiceTypeInfo": {
                "connectorServiceType": "AzureBlobStorageSourceConnector",
                "storageAccountName": "examplestorageacct",
                "storageAccountKey": "<base64-encoded-storage-account-key>",
                "storageContainerName": "testcontainer"
            },
            "partnerConnectorInfo": {
                "partnerConnectorType": "KafkaAzureBlobStorageSource",
                "maxTasks": "1",
                "authType": "KAFKA_API_KEY",
                "inputFormat": "AVRO",
                "outputFormat": "AVRO",
                "topicRegex": "topics:.*",
                "topicsDir": "topicsDir"
            }
        }
    }'
```

```output
ConnectorBasicInfoConnectorClassName             : AZUREBLOBSOURCE
ConnectorBasicInfoConnectorId                :
ConnectorBasicInfoConnectorName              : conn_3
ConnectorBasicInfoConnectorState             : PROVISIONING
ConnectorBasicInfoConnectorType              : SOURCE
ConnectorServiceTypeInfo                     : {
                                                 "connectorServiceType": "AzureBlobStorageSourceConnector",
                                                 "storageAccountName": "examplestorageacct",
                                                 "storageContainerName": "testcontainer"
                                               }
ConnectorServiceTypeInfoConnectorServiceType : AzureBlobStorageSourceConnector
Id                                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environ
                                               ments/env-exampleenv001/clusters/lkc-examplekafka1/connectors/conn_3
Name                                         : conn_3
PartnerConnectorInfo                         : {
                                                 "partnerConnectorType": "KafkaAzureBlobStorageSource",
                                                 "authType": "KAFKA_API_KEY",
                                                 "inputFormat": "AVRO",
                                                 "outputFormat": "AVRO",
                                                 "topicRegex": "topics:.*",
                                                 "topicsDir": "topicsDir",
                                                 "maxTasks": "1"
                                               }
PartnerConnectorInfoPartnerConnectorType     : KafkaAzureBlobStorageSource
ResourceGroupName                            : sharedrp-confluent
SystemDataCreatedAt                          : 3/7/2026 2:13:50 PM
SystemDataCreatedBy                          : user4@example.com
SystemDataCreatedByType                      : User
SystemDataLastModifiedAt                     : 3/7/2026 2:16:41 PM
SystemDataLastModifiedBy                     : user4@example.com
SystemDataLastModifiedByType                 : User
Type                                         : microsoft.confluent/organizations/environments/clusters/connectors
```

This command create confluent connector
