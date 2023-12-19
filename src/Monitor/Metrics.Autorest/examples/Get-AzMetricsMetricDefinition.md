### Example 1: List the metric definitions for a storage account resource URI
```powershell
Get-AzMetricsMetricDefinition -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 -Namespace Microsoft.Storage/storageAccounts | Format-List
```

```output
Category                 : Capacity
Dimension                : 
DisplayDescription       : The amount of storage used by the storage account. For standard storage accounts, it's the sum of capacity used by blob, table, file, and        
                           queue. For premium storage accounts and Blob storage accounts, it is the same as BlobCapacity or FileCapacity.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
                           /providers/microsoft.insights/metricdefinitions/UsedCapacity
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1H",
                             "retention": "P93D"
                           }}
MetricClass              : 
NameLocalizedValue       : Used capacity
NameValue                : UsedCapacity
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Average
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Average}
Unit                     : Bytes

Category                 : Transaction
Dimension                : {{
                             "value": "ResponseType",
                             "localizedValue": "Response type"
                           }, {
                             "value": "GeoType",
                             "localizedValue": "Geo type"
                           }, {
                             "value": "ApiName",
                             "localizedValue": "API name"
                           }, {
                             "value": "Authentication",
                             "localizedValue": "Authentication"
                           }…}
DisplayDescription       : The number of requests made to a storage service or the specified API operation. This number includes successful and failed requests, as well    
                           as requests which produced errors. Use ResponseType dimension for the number of different type of response.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
                           /providers/microsoft.insights/metricdefinitions/Transactions
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT5M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT15M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT30M",
                             "retention": "P93D"
                           }…}
MetricClass              : 
NameLocalizedValue       : Transactions
NameValue                : Transactions
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Total
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Total}
Unit                     : Count

Category                 : Transaction
Dimension                : {{
                             "value": "GeoType",
                             "localizedValue": "Geo type"
                           }, {
                             "value": "ApiName",
                             "localizedValue": "API name"
                           }, {
                             "value": "Authentication",
                             "localizedValue": "Authentication"
                           }}
DisplayDescription       : The amount of ingress data, in bytes. This number includes ingress from an external client into Azure Storage as well as ingress within Azure.   
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
                           /providers/microsoft.insights/metricdefinitions/Ingress
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT5M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT15M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT30M",
                             "retention": "P93D"
                           }…}
MetricClass              : 
NameLocalizedValue       : Ingress
NameValue                : Ingress
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Total
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Total, Average, Minimum, Maximum}
Unit                     : Bytes

Category                 : Transaction
Dimension                : {{
                             "value": "GeoType",
                             "localizedValue": "Geo type"
                           }, {
                             "value": "ApiName",
                             "localizedValue": "API name"
                           }, {
                             "value": "Authentication",
                             "localizedValue": "Authentication"
                           }}
DisplayDescription       : The amount of egress data. This number includes egress to external client from Azure Storage as well as egress within Azure. As a result, this   
                           number does not reflect billable egress.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
                           /providers/microsoft.insights/metricdefinitions/Egress
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT5M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT15M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT30M",
                             "retention": "P93D"
                           }…}
MetricClass              : 
NameLocalizedValue       : Egress
NameValue                : Egress
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Total
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Total, Average, Minimum, Maximum}
Unit                     : Bytes

Category                 : Transaction
Dimension                : {{
                             "value": "GeoType",
                             "localizedValue": "Geo type"
                           }, {
                             "value": "ApiName",
                             "localizedValue": "API name"
                           }, {
                             "value": "Authentication",
                             "localizedValue": "Authentication"
                           }}
DisplayDescription       : The average time used to process a successful request by Azure Storage. This value does not include the network latency specified in
                           SuccessE2ELatency.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011
                           /providers/microsoft.insights/metricdefinitions/SuccessServerLatency
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT5M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT15M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT30M",
                             "retention": "P93D"
                           }…}
MetricClass              : 
NameLocalizedValue       : Success Server Latency
NameValue                : SuccessServerLatency
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Average
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Average, Minimum, Maximum}
Unit                     : MilliSeconds

Category                 : Transaction
Dimension                : {{
                             "value": "GeoType",
                             "localizedValue": "Geo type"
                           }, {
                             "value": "ApiName",
                             "localizedValue": "API name"
                           }, {
                             "value": "Authentication",
                             "localizedValue": "Authentication"
                           }}
DisplayDescription       : The average end-to-end latency of successful requests made to a storage service or the specified API operation, in milliseconds. This value      
                           includes the required processing time within Azure Storage to read the request, send the response, and receive acknowledgment of the response.   
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
                           /providers/microsoft.insights/metricdefinitions/SuccessE2ELatency
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT5M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT15M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT30M",
                             "retention": "P93D"
                           }…}
MetricClass              : 
NameLocalizedValue       : Success E2E Latency
NameValue                : SuccessE2ELatency
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Average
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Average, Minimum, Maximum}
Unit                     : MilliSeconds

Category                 : Transaction
Dimension                : {{
                             "value": "GeoType",
                             "localizedValue": "Geo type"
                           }, {
                             "value": "ApiName",
                             "localizedValue": "API name"
                           }, {
                             "value": "Authentication",
                             "localizedValue": "Authentication"
                           }}
DisplayDescription       : The percentage of availability for the storage service or the specified API operation. Availability is calculated by taking the
                           TotalBillableRequests value and dividing it by the number of applicable requests, including those that produced unexpected errors. All
                           unexpected errors result in reduced availability for the storage service or the specified API operation.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
                           /providers/microsoft.insights/metricdefinitions/Availability
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT5M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT15M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT30M",
                             "retention": "P93D"
                           }…}
MetricClass              : 
NameLocalizedValue       : Availability
NameValue                : Availability
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Average
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Average, Minimum, Maximum}
Unit                     : Percent 
```

This command lists the metric definitions for a storage account resource URI.

### Example 2: List the metric definitions for a web site resource URI
```powershell
Get-AzMetricsMetricDefinition -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/monitor-metric/providers/Microsoft.Web/sites/metricstest01 -Namespace Microsoft.Web/sites
```

```output
Category DisplayDescription
-------- ------------------                                                                                                                                                                                                                         
         The amount of CPU consumed by the app, in seconds. For more information about this metric. Please see https://aka.ms/website-monitor-cpu-time-vs-cpu-percentage (CPU time vs CPU percentage). For WebApps only.
         The total number of requests regardless of their resulting HTTP status code. For WebApps and FunctionApps.
         The amount of incoming bandwidth consumed by the app, in MiB. For WebApps and FunctionApps.
         The amount of outgoing bandwidth consumed by the app, in MiB. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code 101. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code >= 200 but < 300. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code >= 300 but < 400. For WebApps and FunctionApps.
         The count of requests resulting in HTTP 401 status code. For WebApps and FunctionApps.
         The count of requests resulting in HTTP 403 status code. For WebApps and FunctionApps.
         The count of requests resulting in HTTP 404 status code. For WebApps and FunctionApps.
         The count of requests resulting in HTTP 406 status code. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code >= 400 but < 500. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code >= 500 but < 600. For WebApps and FunctionApps.
         The current amount of memory used by the app, in MiB. For WebApps and FunctionApps.
         The average amount of memory used by the app, in megabytes (MiB). For WebApps and FunctionApps.
         The average time taken for the app to serve requests, in seconds. For WebApps and FunctionApps.
         The time taken for the app to serve requests, in seconds. For WebApps and FunctionApps.
         The number of bound sockets existing in the sandbox (w3wp.exe and its child processes). A bound socket is created by calling bind()/connect() APIs and remains until said socket is closed with CloseHandle()/closesocket(). For WebApps … 
         The total number of handles currently open by the app process. For WebApps and FunctionApps.
         The number of threads currently active in the app process. For WebApps and FunctionApps.
         Private Bytes is the current size, in bytes, of memory that the app process has allocated that can't be shared with other processes. For WebApps and FunctionApps.
         The rate at which the app process is reading bytes from I/O operations. For WebApps and FunctionApps.
         The rate at which the app process is writing bytes to I/O operations. For WebApps and FunctionApps.
         The rate at which the app process is issuing bytes to I/O operations that don't involve data, such as control operations. For WebApps and FunctionApps.
         The rate at which the app process is issuing read I/O operations. For WebApps and FunctionApps.
         The rate at which the app process is issuing write I/O operations. For WebApps and FunctionApps.
         The rate at which the app process is issuing I/O operations that aren't read or write operations. For WebApps and FunctionApps.
         The number of requests in the application request queue. For WebApps and FunctionApps.
         The current number of Assemblies loaded across all AppDomains in this application. For WebApps and FunctionApps.
         The current number of AppDomains loaded in this application. For WebApps and FunctionApps.
         The total number of AppDomains unloaded since the start of the application. For WebApps and FunctionApps.
         The number of times the generation 0 objects are garbage collected since the start of the app process. Higher generation GCs include all lower generation GCs. For WebApps and FunctionApps.
         The number of times the generation 1 objects are garbage collected since the start of the app process. Higher generation GCs include all lower generation GCs. For WebApps and FunctionApps.
         The number of times the generation 2 objects are garbage collected since the start of the app process. For WebApps and FunctionApps.
         Health check status. For WebApps and FunctionApps.
         Percentage of filesystem quota consumed by the app. For WebApps and FunctionApps.
```

This command lists the metric definitions for a web site resource URI.

### Example 3: List the metric definitions for the subscription
```powershell
Get-AzMetricsMetricDefinition -Region eastus -Namespace microsoft.compute/virtualmachines
```

```output
Category DisplayDescription                                                                                                              IsDimensionRequired MetricClass Namespace                         PrimaryAggregationType ResourceId        
-------- ------------------                                                                                                              ------------------- ----------- ---------                         ---------------------- ----------        
         The percentage of allocated compute units that are currently in use by the Virtual Machine(s)                                   False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         The number of billable bytes received on all network interfaces by the Virtual Machine(s) (Incoming Traffic) (Deprecated)       False                           microsoft.compute/virtualmachines Total                  subscriptions/9e… 
         The number of billable bytes out on all network interfaces by the Virtual Machine(s) (Outgoing Traffic) (Deprecated)            False                           microsoft.compute/virtualmachines Total                  subscriptions/9e… 
         Bytes read from disk during monitoring period                                                                                   False                           microsoft.compute/virtualmachines Total                  subscriptions/9e… 
         Bytes written to disk during monitoring period                                                                                  False                           microsoft.compute/virtualmachines Total                  subscriptions/9e… 
         Disk Read IOPS                                                                                                                  False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Disk Write IOPS                                                                                                                 False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Total number of credits available to burst. Only available on B-series burstable VMs                                            False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Total number of credits consumed by the Virtual Machine. Only available on B-series burstable VMs                               False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Bytes/Sec read from a single disk during monitoring period                                                                      False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Bytes/Sec written to a single disk during monitoring period                                                                     False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Read IOPS from a single disk during monitoring period                                                                           False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Write IOPS from a single disk during monitoring period                                                                          False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Data Disk Queue Depth(or Queue Length)                                                                                          False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Average time to complete each IO during monitoring period for Data Disk. Values are in milliseconds.                            False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of data disk bandwidth consumed per minute. Only available on VM series that support premium storage.                False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of data disk I/Os consumed per minute. Only available on VM series that support premium storage.                     False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Baseline bytes per second throughput Data Disk can achieve without bursting                                                     False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Baseline IOPS Data Disk can achieve without bursting                                                                            False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Maximum bytes per second throughput Data Disk can achieve with bursting                                                         False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Maximum IOPS Data Disk can achieve with bursting                                                                                False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of Data Disk burst bandwidth credits used so far                                                                     False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of Data Disk burst I/O credits used so far                                                                           False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Bytes/Sec read from a single disk during monitoring period for OS disk                                                          False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Bytes/Sec written to a single disk during monitoring period for OS disk                                                         False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Read IOPS from a single disk during monitoring period for OS disk                                                               False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Write IOPS from a single disk during monitoring period for OS disk                                                              False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         OS Disk Queue Depth(or Queue Length)                                                                                            False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Average time to complete each IO during monitoring period for OS Disk. Values are in milliseconds.                              False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of operating system disk bandwidth consumed per minute. Only available on VM series that support premium storage.    False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of operating system disk I/Os consumed per minute. Only available on VM series that support premium storage.         False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Baseline bytes per second throughput OS Disk can achieve without bursting                                                       False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Baseline IOPS OS Disk can achieve without bursting                                                                              False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Maximum bytes per second throughput OS Disk can achieve with bursting                                                           False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Maximum IOPS OS Disk can achieve with bursting                                                                                  False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of OS Disk burst bandwidth credits used so far                                                                       False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of OS Disk burst I/O credits used so far                                                                             False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Average time to complete each IO during monitoring period for Temp Disk. Values are in milliseconds.                            False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Bytes/Sec read from a single disk during monitoring period for Temp Disk.                                                       False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Bytes/Sec written to a single disk during monitoring period for Temp Disk.                                                      False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Read IOPS from a single disk during monitoring period for Temp Disk.                                                            False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Write IOPS from a single disk during monitoring period for Temp Disk.                                                           False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Temp Disk Queue Depth(or Queue Length).                                                                                         False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Premium Data Disk Cache Read Hit                                                                                                False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Premium Data Disk Cache Read Miss                                                                                               False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Premium OS Disk Cache Read Hit                                                                                                  False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Premium OS Disk Cache Read Miss                                                                                                 False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of cached disk bandwidth consumed by the VM. Only available on VM series that support premium storage.               False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of cached disk IOPS consumed by the VM. Only available on VM series that support premium storage.                    False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of uncached disk bandwidth consumed by the VM. Only available on VM series that support premium storage.             False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of uncached disk IOPS consumed by the VM. Only available on VM series that support premium storage.                  False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Amount of physical memory, in bytes, immediately available for allocation to a process or for system use in the Virtual Machine False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Measure of Availability of Virtual machines over time.                                                                          False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of Uncached Burst IO Credits used by the VM.                                                                         False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of Uncached Burst BPS Credits used by the VM.                                                                        False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of Cached Burst IO Credits used by the VM.                                                                           False                           microsoft.compute/virtualmachines Average                subscriptions/9e… 
         Percentage of Cached Burst BPS Credits used by the VM.                                                                          False                           microsoft.compute/virtualmachines Average                subscriptions/9e…
```

This command lists the metric definitions for the subscription.