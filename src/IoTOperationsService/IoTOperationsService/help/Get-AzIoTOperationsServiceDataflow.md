---
external help file: Az.IoTOperationsService-help.xml
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/get-aziotoperationsservicedataflow
schema: 2.0.0
---

# Get-AzIoTOperationsServiceDataflow

## SYNOPSIS
Get a DataflowResource

## SYNTAX

### List (Default)
```
Get-AzIoTOperationsServiceDataflow -InstanceName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzIoTOperationsServiceDataflow -InstanceName <String> -Name <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityInstance
```
Get-AzIoTOperationsServiceDataflow -Name <String> -ProfileName <String>
 -InstanceInputObject <IIoTOperationsServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityDataflowProfile
```
Get-AzIoTOperationsServiceDataflow -Name <String> -DataflowProfileInputObject <IIoTOperationsServiceIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzIoTOperationsServiceDataflow -InputObject <IIoTOperationsServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a DataflowResource

## EXAMPLES

### Example 1: List Dataflows
```powershell
Get-AzIoTOperationsServiceDataflow -InstanceName "aio-117832708" -ProfileName "dataflowprofile-name" -ResourceGroupName "aio-validation-117832708" -name "mydataflow"
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

Gets a dataflow

## PARAMETERS

### -DataflowProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentityDataflowProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentityInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceName
Name of instance.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Instance dataflowProfile dataflow resource

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityInstance, GetViaIdentityDataflowProfile
Aliases: DataflowName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Name of Instance dataflowProfile resource

```yaml
Type: System.String
Parameter Sets: List, Get, GetViaIdentityInstance
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowResource

## NOTES

## RELATED LINKS
