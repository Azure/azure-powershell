### Example 1: Update a Broker
```powershell
Update-AzIoTOperationsServiceBroker -InstanceName "aio-instance-name" -Name "my-broker" -ResourceGroupName "aio-validation-116116143" 
```

```output
AdvancedEncryptInternalTraffic : Enabled
BackendChainPartition          : 0
BackendChainRedundancyFactor   : 0
BackendChainWorker             :
ClientMaxKeepAliveSecond       :
ClientMaxMessageExpirySecond   :
ClientMaxPacketSizeByte        :
ClientMaxReceiveMaximum        :
ClientMaxSessionExpirySecond   :
DiskBackedMessageBuffer        : {
                                 }
ExtendedLocationName           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-
                                 116116143/providers/Microsoft.ExtendedLocation/customLocations/location-116116143
ExtendedLocationType           : CustomLocation
FrontendReplica                : 0
FrontendWorker                 :
GenerateResourceLimitCpu       :
Id                             : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-
                                 116116143/providers/Microsoft.IoTOperations/instances/aio-instance-name/brokers/my
                                 -broker
InternalCertDuration           :
InternalCertRenewBefore        :
LogLevel                       : info
MemoryProfile                  : Medium
MetricPrometheusPort           : 9600
Name                           : my-broker
PrivateKeyAlgorithm            :
PrivateKeyRotationPolicy       :
ProvisioningState              : Succeeded
ResourceGroupName              : aio-validation-116116143
SelfCheckIntervalSecond        : 30
SelfCheckMode                  : Enabled
SelfCheckTimeoutSecond         : 15
SelfTracingIntervalSecond      : 30
SelfTracingMode                : Enabled
SubscriberQueueLimitLength     :
SubscriberQueueLimitStrategy   :
SystemDataCreatedAt            : 3/5/2025 10:00:59 PM
SystemDataCreatedBy            : henrymorales@microsoft.com
SystemDataCreatedByType        : User
SystemDataLastModifiedAt       : 3/5/2025 10:01:11 PM
SystemDataLastModifiedBy       : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType   : Application
TraceCacheSizeMegabyte         : 16
TraceMode                      : Enabled
TraceSpanChannelCapacity       : 1000
Type                           : microsoft.iotoperations/instances/brokers
```

Update a Broker