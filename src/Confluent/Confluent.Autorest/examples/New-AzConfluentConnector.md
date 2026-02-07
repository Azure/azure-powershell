### Example 1: Create a new Confluent Connector
```powershell
New-AzConfluentConnector -Name 'testConnSrc_1' -ResourceGroupName 'LiftrConfluent_IT' -OrganizationName 'australiaeast-resource-name' -EnvironmentId 'env-n5zmkv' -ClusterId 'lkc-1126wj' -SubscriptionId '209ad589-cefc-4b2b-8eca-a12d726494a4' -ConnectorBasicInfoConnectorClass 'AZUREBLOBSINK' -ConnectorBasicInfoConnectorName 'testConnSrc_1' -ConnectorBasicInfoConnectorType 'SOURCE' -ConnectorServiceTypeInfoConnectorServiceType 'AzureBlobStorageSourceConnector' -PartnerConnectorInfoPartnerConnectorType 'KafkaAzureBlobStorageSource'
```

```output
ConnectorBasicInfoConnectorClass             : AZUREBLOBSINK
ConnectorBasicInfoConnectorId                : 
ConnectorBasicInfoConnectorName              : testConnSrc_1
ConnectorBasicInfoConnectorState             : PROVISIONING
ConnectorBasicInfoConnectorType              : SOURCE
ConnectorServiceTypeInfo                     : {
                                                 "connectorServiceType":
                                               "AzureBlobStorageSourceConnector"
                                               }
ConnectorServiceTypeInfoConnectorServiceType : AzureBlobStorageSourceConnector
Id                                           : /subscriptions/209ad589-cefc-4b2b-8eca-a12d726494a4/ 
                                               resourceGroups/LiftrConfluent_IT/providers/Microsoft 
                                               .Confluent/organizations/australiaeast-resource-name 
                                               /environments/env-n5zmkv/clusters/lkc-1126wj/connect 
                                               ors/testConnSrc_1
Name                                         : testConnSrc_1
PartnerConnectorInfo                         : {
                                                 "partnerConnectorType":
                                               "KafkaAzureBlobStorageSource",
                                                 "authType": "SERVICE_ACCOUNT",
                                                 "inputFormat": "AVRO",
                                                 "outputFormat": "AVRO"
                                               }
PartnerConnectorInfoPartnerConnectorType     : KafkaAzureBlobStorageSource
ResourceGroupName                            : LiftrConfluent_IT
SystemDataCreatedAt                          : 2/7/2026 6:54:18 AM
SystemDataCreatedBy                          : pgnanashekar@microsoft.com
SystemDataCreatedByType                      : User
SystemDataLastModifiedAt                     : 2/7/2026 6:54:18 AM
SystemDataLastModifiedBy                     : pgnanashekar@microsoft.com
SystemDataLastModifiedByType                 : User
Type                                         : microsoft.confluent/organizations/environments/clust 
                                               ers/connectors
```

This command creates a new Azure Blob Storage Source connector for a Confluent cluster.

