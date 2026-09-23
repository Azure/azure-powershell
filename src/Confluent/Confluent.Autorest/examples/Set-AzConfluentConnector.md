### Example 1: Update connector
```powershell
Set-AzConfluentConnector `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -ClusterId "lkc-examplekafka1" `
    -Name "conn_3" `
    -ConnectorBasicInfoConnectorClassName "AZUREBLOBSOURCE" `
    -ConnectorBasicInfoConnectorName "conn_3" `
    -ConnectorBasicInfoConnectorType "SOURCE" `
    -ConnectorServiceTypeInfoConnectorServiceType "AzureBlobStorageSourceConnector" `
    -PartnerConnectorInfoPartnerConnectorType "KafkaAzureBlobStorageSource"
```

```output
ConnectorBasicInfoConnectorClassName             : AZUREBLOBSOURCE
ConnectorBasicInfoConnectorId                :
ConnectorBasicInfoConnectorName              : conn_3
ConnectorBasicInfoConnectorState             : PROVISIONING
ConnectorBasicInfoConnectorType              : SOURCE
ConnectorServiceTypeInfo                     : {
                                                 "connectorServiceType": "AzureBlobStorageSourceConnector"
                                               }
ConnectorServiceTypeInfoConnectorServiceType : AzureBlobStorageSourceConnector
Id                                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environ
                                               ments/env-exampleenv001/clusters/lkc-examplekafka1/connectors/conn_3
Name                                         : conn_3
PartnerConnectorInfo                         : {
                                                 "partnerConnectorType": "KafkaAzureBlobStorageSource",
                                                 "authType": "SERVICE_ACCOUNT",
                                                 "inputFormat": "AVRO",
                                                 "outputFormat": "AVRO"
                                               }
PartnerConnectorInfoPartnerConnectorType     : KafkaAzureBlobStorageSource
ResourceGroupName                            : sharedrp-confluent
SystemDataCreatedAt                          : 3/7/2026 3:26:51 PM
SystemDataCreatedBy                          : user4@example.com
SystemDataCreatedByType                      : User
SystemDataLastModifiedAt                     : 3/7/2026 3:26:51 PM
SystemDataLastModifiedBy                     : user4@example.com
SystemDataLastModifiedByType                 : User
Type                                         : microsoft.confluent/organizations/environments/clusters/connectors
```

This command updates connector