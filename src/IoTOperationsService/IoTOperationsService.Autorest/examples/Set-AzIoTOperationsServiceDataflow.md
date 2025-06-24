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


