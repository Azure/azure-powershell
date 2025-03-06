
### Example 1: List Broker
```powershell
Get-AzIoTOperationsServiceBroker -InstanceName "aio-3lrx4" -ResourceGroupName "aio-validation-117026523"
```

```output
AdvancedEncryptInternalTraffic : Enabled
BackendChainPartition          : 2
BackendChainRedundancyFactor   : 2
BackendChainWorker             : 2
ClientMaxKeepAliveSecond       :
ClientMaxMessageExpirySecond   :
ClientMaxPacketSizeByte        :
ClientMaxReceiveMaximum        :
ClientMaxSessionExpirySecond   :
DiskBackedMessageBuffer        : {
                                 }
ExtendedLocationName           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117026523/providers/Mi
                                 crosoft.ExtendedLocation/customLocations/location-3lrx4
ExtendedLocationType           : CustomLocation
FrontendReplica                : 2
FrontendWorker                 : 2
GenerateResourceLimitCpu       : Disabled
Id                             : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117026523/providers/Mi
                                 crosoft.IoTOperations/instances/aio-3lrx4/brokers/default
InternalCertDuration           :
InternalCertRenewBefore        :
LogLevel                       : info
MemoryProfile                  : Medium
MetricPrometheusPort           : 9600
Name                           : default
PrivateKeyAlgorithm            :
PrivateKeyRotationPolicy       :
ProvisioningState              : Succeeded
ResourceGroupName              : aio-validation-117026523
SelfCheckIntervalSecond        : 30
SelfCheckMode                  : Enabled
SelfCheckTimeoutSecond         : 15
SelfTracingIntervalSecond      : 30
SelfTracingMode                : Enabled
SubscriberQueueLimitLength     :
SubscriberQueueLimitStrategy   :
SystemDataCreatedAt            : 3/5/2025 5:07:34 PM
SystemDataCreatedBy            : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType        : Application
SystemDataLastModifiedAt       : 3/5/2025 6:28:37 PM
SystemDataLastModifiedBy       : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType   : Application
TraceCacheSizeMegabyte         : 16
TraceMode                      : Enabled
TraceSpanChannelCapacity       : 1000
Type                           : microsoft.iotoperations/instances/brokers
```

This command gets a list of brokers

