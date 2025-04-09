---
external help file: Az.IoTOperationsService-help.xml
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/set-aziotoperationsservicedataflow
schema: 2.0.0
---

# Set-AzIoTOperationsServiceDataflow

## SYNOPSIS
update a DataflowResource

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzIoTOperationsServiceDataflow -InstanceName <String> -Name <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -ExtendedLocationName <String> [-Mode <String>]
 [-Operation <IDataflowOperation[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Set-AzIoTOperationsServiceDataflow -InstanceName <String> -Name <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Set-AzIoTOperationsServiceDataflow -InstanceName <String> -Name <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
update a DataflowResource

## EXAMPLES

### Example 1: Update a dataflow
```powershell
Set-AzIoTOperationsServiceDataflow -InstanceName "aio-117832708" `
  -Name "dataflow-name" `
  -ProfileName "dataflowprofile-name" `
  -ResourceGroupName "aio-validation-117832708" `
  -ExtendedLocationName "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.ExtendedLocation/customLocations/location-117832708" `
  -Mode "Enabled" `
  -Operation @(
    @{
      operationType = "Source"
      sourceSettings = @{
        endpointRef         = "default"
        assetRef            = "do-not-delete"
        serializationFormat = "Json"
        dataSources         = @("azure-iot-operations/data/do-not-delete")
      }
    },
    @{
      operationType = "BuiltInTransformation"
      builtInTransformationSettings = @{
        serializationFormat = "Json"
        datasets            = @()
        filter              = @()
        map                 = @(
          @{
            type    = "PassThrough"
            inputs  = @("*")
            output  = "*"
          }
        )
      }
    },
    @{
      operationType = "Destination"
      destinationSettings = @{
        endpointRef     = "default"
        dataDestination = "fgn"
      }
    }
  )
```

```output
ExtendedLocationName         : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.ExtendedLocation/customLocations/location-11783270
                               8
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.IoTOperations/instances/aio-117832708/dataflowProf
                               iles/dataflowprofile-name/dataflows/mydataflow
Mode                         : Enabled
Name                         : mydataflow
Operation                    : {{
                                 "sourceSettings": {
                                   "endpointRef": "default",
                                   "assetRef": "do-not-delete",
                                   "serializationFormat": "Json",
                                   "dataSources": [ "azure-iot-operations/data/do-not-delete" ]
                                 },
                                 "operationType": "Source"
                               }, {
                                 "builtInTransformationSettings": {
                                   "serializationFormat": "Json",
                                   "datasets": [ ],
                                   "filter": [ ],
                                   "map": [
                                     {
                                       "type": "PassThrough",
                                       "inputs": [ "*" ],
                                       "output": "*"
                                     }
                                   ]
                                 },
                                 "operationType": "BuiltInTransformation"
                               }, {
                                 "destinationSettings": {
                                   "endpointRef": "default",
                                   "dataDestination": "fgn"
                                 },
                                 "operationType": "Destination"
                               }}
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-117832708
SystemDataCreatedAt          : 3/13/2025 6:49:12 PM
SystemDataCreatedBy          : henrymorales@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/13/2025 6:49:19 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Type                         : microsoft.iotoperations/instances/dataflowprofiles/dataflows
```

Updates a dataflow

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

### -ExtendedLocationName
The name of the extended location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceName
Name of instance.

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

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mode
Mode for Dataflow.
Optional; defaults to Enabled.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Instance dataflowProfile dataflow resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DataflowName

Required: True
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

### -Operation
List of operations including source and destination references as well as transformation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowOperation[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Name of Instance dataflowProfile resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DataflowProfileName

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
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowResource

## NOTES

## RELATED LINKS
