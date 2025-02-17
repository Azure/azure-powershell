### Example 1: List all the pipeline group resources in a resource group
```powershell
Get-AzPipelineGroup -SubscriptionId 00000000-0000-0000-0000-000000000000 -ResourceGroupName testgroup
```

```output
Exporter                        : {{
                                    "azureMonitorWorkspaceLogs": {
                                      "api": {
                                        "schema": {
                                          "recordMap": [
                                            {
                                              "from": "body",
                                              "to": "Body"
                                            },
                                            {
                                              "from": "severity_text",
                                              "to": "SeverityText"
                                            },
                                            {
                                              "from": "time_unix_nano",
                                              "to": "TimeGenerated"
                                            }
                                          ]
                                        },
                                        "dataCollectionEndpointUrl":
                                  "https://myexporter.eastus-1.ingest.monitor.azure.com",
                                        "stream": "Custom-MyTableRawData",
                                        "dataCollectionRule": "dcr-00000000000000000000000000000000"
                                      }
                                    },
                                    "type": "AzureMonitorWorkspaceLogs",
                                    "name": "gigla1"
                                  }}
ExtendedLocationName            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/kubetest/provid
                                  ers/Microsoft.ExtendedLocation/customLocations/myloc
ExtendedLocationType            : CustomLocation
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/kubetest/provid
                                  ers/Microsoft.Monitor/pipelineGroups/mygroup
Location                        : eastus2euap
Name                            : mygroup
NetworkingConfiguration         : {}
PersistencePersistentVolumeName :
Processor                       : {{
                                    "batch": {
                                      "batchSize": 10
                                    },
                                    "type": "Batch",
                                    "name": "batchproc1"
                                  }}
ProvisioningState               : Succeeded
Receiver                        : {{
                                    "otlp": {
                                      "endpoint": "0.0.0.0:7777"
                                    },
                                    "type": "OTLP",
                                    "name": "otlp1"
                                  }, {
                                    "udp": {
                                      "endpoint": "0.0.0.0:5555"
                                    },
                                    "type": "UDP",
                                    "name": "myudpreceiveralittlelong26283032"
                                  }, {
                                    "syslog": {
                                      "endpoint": "0.0.0.0:4444"
                                    },
                                    "type": "Syslog",
                                    "name": "mysyslog1"
                                  }}
Replica                         : 1
ResourceGroupName               : kubetest
RetryAfter                      :
ServicePipeline                 : {{
                                    "name": "MyPipeline1",
                                    "type": "logs",
                                    "receivers": [ "otlp1", "myudpreceiveralittlelong26283032", "mysyslog1" ],
                                    "processors": [ "batchproc1" ],
                                    "exporters": [ "gigla1" ]
                                  }}
SystemDataCreatedAt             : 9/25/2024 11:24:39 AM
SystemDataCreatedBy             : xxxxxxxx@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 9/25/2024 11:25:11 AM
SystemDataLastModifiedBy        : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType    : Application
Tag                             : {
                                  }
Type                            : microsoft.monitor/pipelinegroups
```

List all the pipeline group resources in a resource group