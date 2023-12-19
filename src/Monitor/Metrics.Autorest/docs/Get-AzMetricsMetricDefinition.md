---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azmetricsmetricdefinition
schema: 2.0.0
---

# Get-AzMetricsMetricDefinition

## SYNOPSIS
Lists the metric definitions for the subscription.

## SYNTAX

### List (Default)
```
Get-AzMetricsMetricDefinition -Region <String> [-SubscriptionId <String[]>] [-Namespace <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzMetricsMetricDefinition -ResourceUri <String> [-Namespace <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists the metric definitions for the subscription.

## EXAMPLES

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

This command lists the metric definitions for the subscription.

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

### -Namespace
Metric namespace where the metrics you want reside.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: MetricNamespace

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Region
The region where the metrics you want reside.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The identifier of the resource.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: List
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Metrics.Models.IMetricDefinition

### Microsoft.Azure.PowerShell.Cmdlets.Metrics.Models.ISubscriptionScopeMetricDefinition

## NOTES

## RELATED LINKS

