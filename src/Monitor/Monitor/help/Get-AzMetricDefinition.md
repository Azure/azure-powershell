---
external help file: Az.Metric.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azmetricdefinition
schema: 2.0.0
---

# Get-AzMetricDefinition

## SYNOPSIS
Lists the metric definitions for the subscription.

## SYNTAX

### List (Default)
```
Get-AzMetricDefinition [-SubscriptionId <String[]>] -Region <String> [-MetricNamespace <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzMetricDefinition -ResourceUri <String> [-MetricNamespace <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Lists the metric definitions for the subscription.

## EXAMPLES

### Example 1: Get Metric definitions for a web site resource
```powershell
Get-AzMetricDefinition -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Default-Web-EastUS/providers/Microsoft.Web/sites/website
```

```output
Category DisplayDescription
-------- ------------------                                                                                                                                                                  
         The amount of CPU consumed by the app, in seconds. For more information about this metric. Please see https://aka.ms/website-monitor-cpu-time-vs-cpu-percentage (CPU time vs CPU p… 
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
         The number of bound sockets existing in the sandbox (w3wp.exe and its child processes). A bound socket is created by calling bind()/connect() APIs and remains until said socket i… 
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
         The number of times the generation 0 objects are garbage collected since the start of the app process. Higher generation GCs include all lower generation GCs. For WebApps and Fun… 
         The number of times the generation 1 objects are garbage collected since the start of the app process. Higher generation GCs include all lower generation GCs. For WebApps and Fun… 
         The number of times the generation 2 objects are garbage collected since the start of the app process. For WebApps and FunctionApps.
         Health check status. For WebApps and FunctionApps.
         Percentage of filesystem quota consumed by the app. For WebApps and FunctionApps.
```

This command gets the metric definitions for the specified resource.

### Example 2: List the metric definitions for a web site resource URI
```powershell
Get-AzMetricDefinition -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Default-Web-EastUS/providers/Microsoft.Web/sites/website | Format-List
```

```output
Category                 : 
Dimension                : {{
                             "value": "Instance",
                             "localizedValue": "Instance"
                           }}
DisplayDescription       : The amount of CPU consumed by the app, in seconds. For more information about this metric. Please see https://aka.ms/website-monitor-cpu-time-vs-cpu-percentage(CPU time vs CPU percentage). For WebApps only.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Web/sites/joyerfirstweb/providers/microsoft.insights/metricdefinitions/CpuTime
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
NameLocalizedValue       : CPU Time
NameValue                : CpuTime
Namespace                : Microsoft.Web/sites
PrimaryAggregationType   : Total
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Web/sites/joyerfirstweb
SupportedAggregationType : {Count, Total, Minimum, Maximum}
Unit                     : Seconds

Category                 : 
Dimension                : {{
                             "value": "Instance",
                             "localizedValue": "Instance"
                           }}
DisplayDescription       : The total number of requests regardless of their resulting HTTP status code. For WebApps and FunctionApps.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Web/sites/joyerfirstweb/providers/microsoft.insights/metricdefinitions/Requests
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
NameLocalizedValue       : Requests
NameValue                : Requests
Namespace                : Microsoft.Web/sites
PrimaryAggregationType   : Total
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Web/sites/joyerfirstweb
SupportedAggregationType : {None, Average, Minimum, Maximum…}
Unit                     : Count

Category                 : 
Dimension                : {{
                             "value": "Instance",
                             "localizedValue": "Instance"
                           }}
DisplayDescription       : The amount of incoming bandwidth consumed by the app, in MiB. For WebApps and FunctionApps.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Web/sites/joyerfirstweb/providers/microsoft.insights/metricdefinitions/BytesReceived
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
NameLocalizedValue       : Data In
NameValue                : BytesReceived
Namespace                : Microsoft.Web/sites
PrimaryAggregationType   : Total
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Web/sites/joyerfirstweb
SupportedAggregationType : {None, Average, Minimum, Maximum…}
Unit                     : Bytes
```

This command lists the metric definitions for website and the output is detailed.

### Example 3: List the metric definitions with region
```powershell
Get-AzMetricDefinition -Region eastus2euap -MetricNamespace "Microsoft.Storage/storageAccounts"
```

```output
Category    DisplayDescription
--------    ------------------                                                                                                                                                               
Capacity    The amount of storage used by the storage account. For standard storage accounts, it's the sum of capacity used by blob, table, file, and queue. For premium storage accounts a… 
Transaction The number of requests made to a storage service or the specified API operation. This number includes successful and failed requests, as well as requests which produced errors… 
Transaction The amount of ingress data, in bytes. This number includes ingress from an external client into Azure Storage as well as ingress within Azure.
Transaction The amount of egress data. This number includes egress to external client from Azure Storage as well as egress within Azure. As a result, this number does not reflect billable… 
Transaction The average time used to process a successful request by Azure Storage. This value does not include the network latency specified in SuccessE2ELatency.
Transaction The average end-to-end latency of successful requests made to a storage service or the specified API operation, in milliseconds. This value includes the required processing ti… 
Transaction The percentage of availability for the storage service or the specified API operation. Availability is calculated by taking the TotalBillableRequests value and dividing it by …
```

This command lists metric dimension from region for the subscription.

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

### -MetricNamespace
Metric namespace where the metrics you want reside.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Aliases: ResourceId

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

### Microsoft.Azure.PowerShell.Cmdlets.Metric.Models.IMetricDefinition

### Microsoft.Azure.PowerShell.Cmdlets.Metric.Models.ISubscriptionScopeMetricDefinition

## NOTES

## RELATED LINKS
