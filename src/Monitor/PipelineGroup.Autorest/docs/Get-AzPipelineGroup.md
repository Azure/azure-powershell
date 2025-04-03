---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azpipelinegroup
schema: 2.0.0
---

# Get-AzPipelineGroup

## SYNOPSIS
Returns the specific pipeline group instance.

## SYNTAX

### List (Default)
```
Get-AzPipelineGroup [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPipelineGroup -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPipelineGroup -InputObject <IPipelineGroupIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzPipelineGroup -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the specific pipeline group instance.

## EXAMPLES

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

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IPipelineGroupIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of pipeline group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PipelineGroupName

Required: True
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
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IPipelineGroupIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IPipelineGroup

## NOTES

## RELATED LINKS

