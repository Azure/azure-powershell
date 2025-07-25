### Example 1: Create Pipeline Group with JSON file
```powershell
New-AzPipelineGroup -JsonFilePath CreatePipelineGroupBody.json -Name testgroup -ResourceGroupName kubetest -SubscriptionId 00000000-0000-0000-0000-000000000000
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
ExtendedLocationName            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/kubetest/prov
                                  iders/Microsoft.ExtendedLocation/customLocations/myloc
ExtendedLocationType            : CustomLocation
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/kubetest/prov
                                  iders/Microsoft.Monitor/pipelineGroups/testgroup
Location                        : centraluseuap
Name                            : testgroup
NetworkingConfiguration         :
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
                                      "endpoint": "0.0.0.0:7778"
                                    },
                                    "type": "OTLP",
                                    "name": "otlp1"
                                  }, {
                                    "udp": {
                                      "endpoint": "0.0.0.0:5556"
                                    },
                                    "type": "UDP",
                                    "name": "myudpreceiveralittlelong26283032"
                                  }, {
                                    "syslog": {
                                      "endpoint": "0.0.0.0:4445"
                                    },
                                    "type": "Syslog",
                                    "name": "mysyslog1"
                                  }}
Replica                         :
ResourceGroupName               : kubetest
RetryAfter                      :
ServicePipeline                 : {{
                                    "name": "MyPipeline1",
                                    "type": "logs",
                                    "receivers": [ "otlp1", "myudpreceiveralittlelong26283032", "mysyslog1" ],
                                    "processors": [ "batchproc1" ],
                                    "exporters": [ "gigla1" ]
                                  }}
SystemDataCreatedAt             : 9/26/2024 6:50:55 AM
SystemDataCreatedBy             : xxxxxxxx@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 9/26/2024 6:51:30 AM
SystemDataLastModifiedBy        : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType    : Application
Tag                             : {
                                  }
Type                            : microsoft.monitor/pipelinegroups
```

Create Pipeline Group with JSON file

### Example 2: Create Pipeline Group with expanded parameters
```powershell
New-AzPipelineGroup -Name testgroup -ResourceGroupName kubetest -SubscriptionId 00000000-0000-0000-0000-000000000000 -Location centraluseuap -ExtendedLocationName "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/kubetest/providers/Microsoft.ExtendedLocation/customLocations/myloc" -ExtendedLocationType CustomLocation -NetworkingConfiguration @() -Replica 1 -Exporter @{name="gigla1"; type="AzureMonitorWorkspaceLogs"; azureMonitorWorkspaceLog=@{api=@{dataCollectionEndpointUrl="https://myexporter.eastus-1.ingest.monitor.azure.com"; dataCollectionRule="dcr-00000000000000000000000000000000"; stream="Custom-MyTableRawData"; schema=@{recordMap=@(@{from="body"; to="Body"},@{from="severity_text"; to="SeverityText"},@{from="time_unix_nano"; to="TimeGenerated"})}}}} -Processor @{name="batchproc1"; type="Batch"; batch=@{batchSize=10}} -Receiver @(@{name="otlp1"; type="OTLP"; otlp=@{endpoint="0.0.0.0:7777"}}, @{name="myudpreceiveralittlelong26283032"; type="UDP"; udp=@{endpoint="0.0.0.0:5555"}}, @{name="mysyslog1"; type="Syslog"; syslog=@{endpoint="0.0.0.0:4444"}}) -ServicePipeline @{name="MyPipeline1"; type="logs"; receiver=@("otlp1", "myudpreceiveralittlelong26283032", "mysyslog1"); processor=@("batchproc1"); exporter=@("gigla1")}
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
ExtendedLocationName            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/kubetest/prov
                                  iders/Microsoft.ExtendedLocation/customLocations/myloc
ExtendedLocationType            : CustomLocation
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/kubetest/prov
                                  iders/Microsoft.Monitor/pipelineGroups/testgroup
Location                        : centraluseuap
Name                            : testgroup
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
SystemDataCreatedAt             : 9/26/2024 8:18:42 AM
SystemDataCreatedBy             : xxxxxxxx@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 9/26/2024 8:19:11 AM
SystemDataLastModifiedBy        : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType    : Application
Tag                             : {
                                  }
Type                            : microsoft.monitor/pipelinegroups
```

Create Pipeline Group with expanded parameters

