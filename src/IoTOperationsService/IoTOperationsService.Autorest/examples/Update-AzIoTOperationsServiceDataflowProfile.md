### Example 1: Update a Dataflow Profile
```powershell
Update-AzIoTOperationsServiceDataflowProfile -InstanceName "aio-instance-name" -Name dataflowprofile-name -ResourceGroupName "aio-validation-116116143"
```

```output
ExtendedLocationName         : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.Ext
                               endedLocation/customLocations/location-116116143
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.IoT
                               Operations/instances/aio-instance-name/dataflowProfiles/dataflowprofile-name
InstanceCount                : 1
LogLevel                     : info
MetricPrometheusPort         : 9600
Name                         : dataflowprofile-name
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-116116143
SystemDataCreatedAt          : 3/5/2025 10:31:27 PM
SystemDataCreatedBy          : henrymorales@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/5/2025 10:31:32 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Type                         : microsoft.iotoperations/instances/dataflowprofiles
```

Updates a dataflow profile


