### Example 1: Update a Broker Listener
```powershell
Set-AzIoTOperationsServiceBrokerListener -BrokerName "my-broker" -InstanceName "aio-instance-name" -ListenerName my-listener -ResourceGroupName "aio-validation-116116143" -ExtendedLocationName  "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.ExtendedLocation/customLocations/location-116116143"  -Port @(@{ port = 1883 })
```

```output
ExtendedLocationName         : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/reso
                               urceGroups/aio-validation-116116143/providers/Microsoft.
                               ExtendedLocation/customLocations/location-116116143
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/reso
                               urceGroups/aio-validation-116116143/providers/Microsoft.
                               IoTOperations/instances/aio-instance-name/brokers/my-bro
                               ker/listeners/my-listener
Name                         : my-listener
Port                         : {{
                                 "port": 1883,
                                 "protocol": "Mqtt"
                               }}
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-116116143
ServiceName                  :
ServiceType                  : ClusterIp
SystemDataCreatedAt          : 3/5/2025 10:23:16 PM
SystemDataCreatedBy          : henrymorales@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/5/2025 10:23:21 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Type                         : microsoft.iotoperations/instances/brokers/listeners

```

Update a broker listener
