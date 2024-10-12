---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/new-azpipelinegroup
schema: 2.0.0
---

# New-AzPipelineGroup

## SYNOPSIS
create a pipeline group instance.

## SYNTAX

### CreateExpanded (Default)
```
New-AzPipelineGroup -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-Exporter <IExporter[]>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-NetworkingConfiguration <INetworkingConfiguration[]>] [-PersistencePersistentVolumeName <String>]
 [-Processor <IProcessor[]>] [-Receiver <IReceiver[]>] [-Replica <Int32>] [-ServicePipeline <IPipeline[]>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzPipelineGroup -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzPipelineGroup -Name <String> -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
create a pipeline group instance.

## EXAMPLES

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

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exporter
The exporters specified for a pipeline group instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IExporter[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The name of the extended location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationType
The type of the extended location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of pipeline group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PipelineGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkingConfiguration
Networking configurations for the pipeline group instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.INetworkingConfiguration[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PersistencePersistentVolumeName
The name of the mounted persistent volume.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Processor
The processors specified for a pipeline group instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IProcessor[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Receiver
The receivers specified for a pipeline group instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IReceiver[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Replica
Defines the amount of replicas of the pipeline group instance.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePipeline
Pipelines belonging to a given pipeline group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IPipeline[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IPipelineGroup

## NOTES

## RELATED LINKS

